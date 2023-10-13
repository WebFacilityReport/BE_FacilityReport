using Infrastructure.IService;
using Infrastructure.Model.Request.RequestAccount;
using Infrastructure.Model.Response.ResponseAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BE_FacilityFeedBackWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenResponseMessToken>> Login(RequestLogin requestLogin)
        {
            var response = await _accountService.CreateToken(requestLogin);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
    }
}
