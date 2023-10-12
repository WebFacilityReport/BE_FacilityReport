using Domain.Entity;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestAccount;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BE_FacilityFeedBackWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<ActionResult<Account>> RegisterAccountAdmin(RequestRegisterAccount requestRegisterAccount)
        {

            var response = await _accountService.RegisterAccountAdmin(requestRegisterAccount);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });

        }
    }
}
