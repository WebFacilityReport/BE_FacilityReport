using Microsoft.AspNetCore.Mvc;
using Infrastructure.Model.Response.ResponseTask;
using Infrastructure.IService;
using System.Net;
using Infrastructure.Model.Request.RequestTask;

namespace BE_FacilityFeedBackWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly IJobService _jobService;

        public TasksController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseTask>>> GetAllTask()
        {
            var response = await _jobService.GetAllTask();
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpPost]
        public async Task<ActionResult<ResponseTask>> CreateTaskResouce(RequestTaskResource requestTaskResource)
        {
            var response = await _jobService.AddTaskResource(requestTaskResource);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpPost]
        public async Task<ActionResult<ResponseTask>> CreateTaskEquipment(RequestTaskEquipment requestTaskEquipment)
        {
            var response = await _jobService.AddTaskEquipmentByResourceId(requestTaskEquipment);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpGet]
        public async Task<ActionResult<ResponseTask>> GetTaskById(Guid taskId)
        {
            var response = await _jobService.GetTaskById(taskId);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }

        [HttpPatch]
        public async Task<ActionResult<ResponseTask>> ChangeStatus(Guid taskId, string status)
        {
            var response = await _jobService.ChangeStatus(taskId, status);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseTask>> UpdateTask(Guid taskId, RequestUpdateTask requestUpdateTask)
        {
            var response = await _jobService.UpdateTask(taskId, requestUpdateTask);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }

    }
}
