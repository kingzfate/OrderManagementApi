using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Endpoints
{
    /// <summary>
    /// Base class with routing settings for api
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiEndpoint
    {
    }
}