using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseTask;
using Domain.Entity;
using Domain.Enum;

namespace WebRazorPage.Pages.ManagerOffice.Job
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IJobService _jobService;

        public EditModel(IAccountService accountService, IJobService jobService)
        {
            _accountService = accountService;
            _jobService = jobService;
        }

        [BindProperty]
        public ResponseTask Job { get; set; } = default!;
        [BindProperty]
        public RequestUpdateTask RequestJob { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var job = await _jobService.GetTaskById(id);
                if (job == null)
                {
                    return NotFound();
                }
                Job = job;
                //ViewData["CreatorId"] = new SelectList(_context.Accounts, "AccountId", "Address");
                //ViewData["EmployeeId"] = new SelectList(_context.Accounts, "AccountId", "Address");

                return Page();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                Job = await _jobService.GetTaskById(id);
                return Page();
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var role = HttpContext.Session.GetString("ROLE");
                var accountId = HttpContext.Session.GetString("ACCOUNTID");
                if (role == "MANAGER_OFFICE")
                {
                    RequestJob.Description = Job.Description;
                    RequestJob.Title = Job.Title;
                    RequestJob.Deadline = Job.Deadline;
                    Job = await _jobService.UpdateTask(Job.TaskId, RequestJob);
                    return RedirectToPage("./Index");
                }
                else if (role == "STAFF")
                {
                    Job = await _jobService.ChangeStatusStaff(Job.TaskId, StatusTask.DONE.ToString());
                    return RedirectToPage("./Index");
                }
                return Page();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                Job = await _jobService.GetTaskById(Job.TaskId);

                return Page();
            }
        }
    }
}
