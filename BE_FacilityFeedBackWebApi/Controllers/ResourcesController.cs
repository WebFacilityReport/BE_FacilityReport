using Domain.Entity;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestResource;
using Infrastructure.Model.Response.ResponseResource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BE_FacilityFeedBackWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {

        private readonly IReService _resourceService;

        public ResourcesController(IReService resourceService)
        {
            _resourceService = resourceService;
        }

        // GET: api/Resources
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseResource>>> GetResources()
        {
            var response = await _resourceService.GetAllResource();
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<Resource>> GetById(Guid resourceId)
        {
            var response = await _resourceService.GetById(resourceId);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }

    }
}
