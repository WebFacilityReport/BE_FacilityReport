using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseFeedBack;
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
        [HttpGet]
        public async Task<ActionResult<ResponseFeedBack>> GetAllFeedBack()
        {
            var response = await _equipmentService.GetEquipment();
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpGet]
        public async Task<ActionResult<ResponseFeedBack>> GetFeedBackById(Guid feedBackId)
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
