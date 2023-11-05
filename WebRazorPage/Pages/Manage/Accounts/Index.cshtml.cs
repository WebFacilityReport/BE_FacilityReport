using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entity;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebRazorPage.Pages.Manage.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;
                
        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<Account> Accounts { get;set; } = default!;

        [BindProperty]
        public Account SessionAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var accountJsonString = HttpContext.Session.GetString("Account");

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            SessionAccount = account;

            Accounts = await _accountService.GetAllAccountsRZ();
            return Page();
        }
    }
}
