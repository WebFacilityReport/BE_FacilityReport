using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestTask;
using Domain.Enum;


namespace WebRazorPage.Pages.ManagerOffice.Job
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IJobService _jobService;


        [BindProperty]
        public Guid AccountId { get; set; }

        public CreateModel(IAccountService accountService, IJobService jobService)
        {
            _accountService = accountService;
            _jobService = jobService;
        }
        [BindProperty]
        public RequestTaskResourceRz Job { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var accountId = HttpContext.Session.GetString("ACCOUNTID");
                // Check if the session value is not null or empty
                if (!string.IsNullOrEmpty(accountId))
                {
                    var account = await _accountService.GetUsernameRz(accountId);
                    AccountId = account.AccountId;
                }
                ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");
                return Page();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");

                return Page();
            }
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (!ModelState.IsValid || Job == null)
                {
                    return Page();
                }
                Job.CreatorId = AccountId;
                var task = await _jobService.AddTaskResourceRz(Job);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");

                return Page();
            }
        }
    }
}
