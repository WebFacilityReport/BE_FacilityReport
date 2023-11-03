using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseFeedBack;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebRazorPage.Pages.FeedBacks
{
    public class IndexModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IAccountService _accountService;

        public IndexModel(IFeedbackService feedbackService, IAccountService accountService)
        {
            _feedbackService = feedbackService;
            _accountService = accountService;
        }

        public List<ResponseFeedBack> Feedback { get; set; } = default!;
        
        [BindProperty]
        public Account Account { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var accountJsonString = HttpContext.Session.GetString("Account");

                if (accountJsonString == null) return Redirect("/");

                var account = JsonSerializer.Deserialize<Account>(accountJsonString);

                if (account == null) return Redirect("/");

                Account = account;

                var username = Account.Username;
                var role = Account.Role;
                var accountId = Account.AccountId;

                if (role == "MANAGER_OFFICE" || role == "MANAGER")
                {
                    Feedback = await _feedbackService.GetFeedBack();

                }
                else
                {
                    if (!string.IsNullOrEmpty(username))
                    {
                        Feedback = await _feedbackService.GetFeedBackbyAccountRZ(account.AccountId);
                    }
                }
         
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
            }
            return Page();
        }
    }
}
