using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseTask;
using Microsoft.AspNetCore.Mvc;
using Domain.Enum;

namespace WebRazorPage.Pages.ManagerOffice.Job
{
    public class IndexModel : PageModel
    {
        private readonly IJobService _jobService;
        private readonly IAccountService _accountService;

        public IndexModel(IJobService jobService, IAccountService accountService)
        {
            _jobService = jobService;
            _accountService = accountService;
        }


        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<ResponseTask> Job { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                var role = HttpContext.Session.GetString("ROLE");
                if (role == "MANAGER_OFFICE")
                {
                    Job = await _jobService.SearchAllTask(SearchQuery);
                }
                else if (role == "STAFF")
                {
                    var username =  HttpContext.Session.GetString("ACCOUNTID");
                    var account = await _accountService.GetUsernameRz(username);
                    Job = await _jobService.GetListTaskStaff(account.AccountId, SearchQuery);
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
