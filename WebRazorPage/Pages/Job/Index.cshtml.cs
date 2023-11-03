using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseTask;
using Microsoft.AspNetCore.Mvc;
using Domain.Enum;
using Domain.Entity;
using System.Text.Json;

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

        [BindProperty(SupportsGet = true)]
        public Account Account { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        { 
            var accountJsonString = HttpContext.Session.GetString("Account");

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            Account = account;
            try
            {
                var role = account.Role;

                if (role == "MANAGER_OFFICE")
                {
                    Job = await _jobService.SearchAllTask(SearchQuery);
                }
                else if (role == "STAFF")
                {
                    Job = await _jobService.GetListTaskStaff(account.AccountId, SearchQuery);
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                Page();
            }

            return Page();
        }
    }
}
