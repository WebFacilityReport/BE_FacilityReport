using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestTask;
using Domain.Enum;
using Domain.Entity;
using System.Text.Json;

namespace WebRazorPage.Pages.ManagerOffice.Job
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IJobService _jobService;


        public CreateModel(IAccountService accountService, IJobService jobService)
        {
            _accountService = accountService;
            _jobService = jobService;
        }


        [BindProperty]
        public string Now { get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

        [BindProperty]
        public RequestTaskResourceRz Job { get; set; } = default!;

        [BindProperty]
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
                //if (!ModelState.IsValid || Job == null)
                //{
                //    return Page();
                //}
                Job.CreatorId = Account.AccountId;
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
