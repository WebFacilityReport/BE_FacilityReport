using Infrastructure.IService;
using Infrastructure.Model.Request.RequestAccount;
using Infrastructure.Model.Response.ResponseAccount;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<ResponseAllAccount>> RegisterAccountAdmin(RequestRegisterAccount requestRegisterAccount)
        {
            var response = await _accountService.RegisterAccountAdmin(requestRegisterAccount);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpPost]
        public async Task<ActionResult<ResponseAllAccount>> RegisterAccountManager(RequestRegisterAccount requestRegisterAccount)
        {

            var response = await _accountService.RegisterAccountManager(requestRegisterAccount);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpPost]
        public async Task<ActionResult<ResponseAllAccount>> RegisterAccountManagerOffice(RequestRegisterAccount requestRegisterAccount)
        {

            var response = await _accountService.RegisterAccountManagerOffice(requestRegisterAccount);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpPost]
        public async Task<ActionResult<ResponseAllAccount>> RegisterAccountStaff(RequestRegisterAccount requestRegisterAccount)
        {

            var response = await _accountService.RegisterAccountStaff(requestRegisterAccount);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpPost]
        public async Task<ActionResult<ResponseAllAccount>> RegisterAccountCustomer(RequestRegisterAccount requestRegisterAccount)
        {

            var response = await _accountService.RegisterAccountCustomer(requestRegisterAccount);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<ResponseAllAccount>>> GetALLAccount()
        {
            var response = await _accountService.GetAllAccounts();
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });

        }
        [Authorize]
        [HttpPatch]
        public async Task<ActionResult<ResponseAllAccount>> UpdateAccount(Guid accountId, UpdateAccount update)
        {
            var response = await _accountService.UpdateAccount(accountId, update);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });

        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ResponseAllAccount>> ProfileAccount(Guid accountId)
        {
            var response = await _accountService.GetById(accountId);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });

        }
    }
}
