using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.Models;
using System.Text.RegularExpressions;

namespace OrderManagement.Endpoints
{
    /// <summary>
    /// Endpoint for working with orders
    /// </summary>
    public class OrderController : BaseApiEndpoint
    {
        private readonly IReadRepository<Order> _orderReadRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IPostamatRepository _postamatRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        public OrderController(
            IReadRepository<Order> orderReadRepository,
            IRepository<Order> orderRepository,
            IPostamatRepository postamatRepository,
            IRepository<Product> productRepository,
            IMapper mapper)
        {
            _orderReadRepository = orderReadRepository;
            _postamatRepository = postamatRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="model">Order</param>
        [HttpPost]
        public async Task<IResult> Create(CreateOrderApiModel model)
        {
            if (model.Products.Length > 10) return Results.BadRequest();
            if (!new Regex(@"^\d{4}-\d{3}$").Match(model.Postamat).Success) return Results.BadRequest();
            if (!new Regex(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$").Match(model.RecipientPhoneNumber).Success) return Results.BadRequest();

            Postamat postamat = await _postamatRepository.GetByNumberAsync(model.Postamat);
            if (postamat == null) return Results.NotFound();
            if (!postamat.Status) return Results.StatusCode(403);

            Order order = _mapper.Map<Order>(model);
            order.Postamat = postamat;
            order.Status = OrderStatus.Registered;
            await _orderRepository.AddAsync(order);

            return Results.Ok();
        }

        /// <summary>
        /// Update an existing order
        /// </summary>
        /// <param name="model">Order model</param>
        [HttpPost]
        public async Task<IResult> Update(UpdateOrderApiModel model)
        {
            if (!new Regex(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$").Match(model.RecipientPhoneNumber).Success) return Results.BadRequest();

            Order? order = await _orderRepository.GetByIdAsync(model.Id);
            if (order == null) return Results.NoContent();

            Postamat postamat = await _postamatRepository.GetByNumberAsync(order.Postamat.Number);
            if (!postamat.Status) return Results.StatusCode(403);

            order.Products = model.Products.Select(product => new Product { Name = product }).ToList();
            order.RecipientFullName = model.RecipientFullName;
            order.RecipientPhoneNumber = model.RecipientPhoneNumber;
            order.Amount = model.Amount;

            await _orderRepository.UpdateAsync(order);

            return Results.Ok();
        }

        /// <summary>
        /// Get information about an existing order 
        /// </summary>
        /// <param name="id">Order identifier</param>
        [HttpGet]
        public async Task<IResult> Info(int id)
        {
            Order? order = await _orderReadRepository.GetByIdAsync(id);
            if (order == null) return Results.NoContent();

            return Results.Ok(order);
        }

        /// <summary>
        /// Cancel the order
        /// </summary>
        /// <param name="id">Order identifier</param>
        [HttpGet]
        public async Task<IResult> Canceled(int id)
        {
            Order? order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return Results.NoContent();

            order.Status = OrderStatus.Canceled;
            await _orderRepository.UpdateAsync(order);

            return Results.Ok();
        }
    }
}