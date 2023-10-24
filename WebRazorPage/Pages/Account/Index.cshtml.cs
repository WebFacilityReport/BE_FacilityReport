using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.IService.ServiceImplement;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.Model.Response.ResponseAccount;

namespace WebRazorPage.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService, List<ResponseAllAccount> account)
        {
            _accountService = accountService;
            Account = account;
        }

        public List<ResponseAllAccount> Account { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Account = await _accountService.GetAllAccounts();
        }
        
    }
}
