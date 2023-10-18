using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseFeedBack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BE_FacilityFeedBackWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ResponseFeedBack>> GetAllEquipment()
        {
            var response = await _equipmentService.GetEquipment();
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ResponseFeedBack>> GetEquipmentById(Guid feedBackId)
        {
            var response = await _equipmentService.GetById(feedBackId);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }

       
    }

}
