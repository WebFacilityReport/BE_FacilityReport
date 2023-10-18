using Infrastructure.IService;
using Infrastructure.Model.Request.RequestFeedBack;
using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseFeedBack;
using Infrastructure.Model.Response.ResponseTask;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BE_FacilityFeedBackWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FeedBackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;

    public FeedBackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }


    [HttpGet]
    public async Task<ActionResult<List<ResponseFeedBack>>> GetAllTask()
    {
        var response = await _feedbackService.GetFeedBack();
        return Ok(new
        {
            Success = HttpStatusCode.OK,
            Message = "Success",
            Data = response
        });
    }

    [HttpPost]
    public async Task<ActionResult<ResponseFeedBack>> CreateFeedBack(RequestFeedBack requestFeedBack)
    {
        var response = await _feedbackService.CreateFeedBack(requestFeedBack);
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
        var response = await _feedbackService.GetById(feedBackId);
        return Ok(new
        {
            Success = HttpStatusCode.OK,
            Message = "Success",
            Data = response
        });
    }
}
