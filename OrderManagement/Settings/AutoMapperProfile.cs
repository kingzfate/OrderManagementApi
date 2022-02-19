using ApplicationCore.Entities;
using AutoMapper;
using OrderManagementApi.Models;

namespace OrderManagementApi.Settings
{
    /// <summary>
    /// Profile for mapping
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// ctor
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<CreateOrderApiModel, Order>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(product => new Product { Name = product })))
                                                   .ForMember(dest => dest.Postamat, opt => opt.MapFrom(src => new Postamat()));
        }
    }
}