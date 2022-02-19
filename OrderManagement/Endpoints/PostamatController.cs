using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Endpoints;

namespace OrderManagementApi.Endpoints
{
    /// <summary>
    /// Endpoint for working with postamates
    /// </summary>
    public class PostamatController : BaseApiEndpoint
    {
        private readonly IPostamatRepository _postamatRepository;

        /// <summary>
        /// ctor
        /// </summary>
        public PostamatController(IPostamatRepository postamatRepository)
        {
            _postamatRepository = postamatRepository;
        }

        /// <summary>
        /// Get working postamates
        /// </summary>
        [HttpGet]
        public async Task<IResult> GetWorking()
        {
            IEnumerable<Postamat> postamates = await _postamatRepository.GetWorkingAsync();
            return Results.Ok(postamates);
        }

        /// <summary>
        /// Get information on postomat
        /// </summary>
        /// <param name="number">Number of postamat</param>
        [HttpGet]
        public async Task<IResult> Info(string number)
        {
            Postamat postamat = await _postamatRepository.GetByNumberAsync(number);
            return Results.Ok(postamat);
        }
    }
}