using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseFeedBack;
using Domain.Entity;

namespace WebRazorPage.Pages.FeedBack
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

        public async Task OnGetAsync()
        {
            try
            {
                var role = HttpContext.Session.GetString("ROLE");
                var accountId = HttpContext.Session.GetString("ACCOUNTID");
                if (role == "MANAGER_OFFICE" || role == "MANAGER")
                {
                    Feedback = await _feedbackService.GetFeedBack();

                }
                else
                {
                    var username = HttpContext.Session.GetString("ACCOUNTID");
                    if (!string.IsNullOrEmpty(username))
                    {
                        var account = await _accountService.GetUsernameRz(username);
                        Feedback = await _feedbackService.GetFeedBackbyAccountRZ(account.AccountId);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                Page();
            }
        }
    }
}
