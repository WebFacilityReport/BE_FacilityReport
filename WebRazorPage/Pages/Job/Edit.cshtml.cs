﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseTask;
using Domain.Entity;
using Domain.Enum;
using System.Text.Json;

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

        [BindProperty]
        public Account Account { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
                var accountJsonString = HttpContext.Session.GetString("Account");

                if (accountJsonString == null) return Redirect("/");

                var account = JsonSerializer.Deserialize<Account>(accountJsonString);

                if (account == null) return Redirect("/");

                Account = account;
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
            var accountJsonString = HttpContext.Session.GetString("Account");

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            Account = account;

            try
            {
                if (Account.Role == "MANAGER_OFFICE")
                {
                    RequestJob.Description = Job.Description;
                    RequestJob.Title = Job.Title;
                    RequestJob.Deadline = Job.Deadline;
                    Job = await _jobService.UpdateTask(Job.TaskId, RequestJob);
                }
                else if (Account.Role == "STAFF")
                {
                    Job = await _jobService.ChangeStatusStaff(Job.TaskId, StatusTask.DONE.ToString());             
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                Job = await _jobService.GetTaskById(Job.TaskId);

                return Page();
            }
        }

        public async Task<IActionResult> OnPostRejectAsync()
        {
            var accountJsonString = HttpContext.Session.GetString("Account");

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            Account = account;

            try
            {
                if (Account.Role == "MANAGER_OFFICE")
                {
                    RequestJob.Description = Job.Description;
                    RequestJob.Title = Job.Title;
                    RequestJob.Deadline = Job.Deadline;
                    Job = await _jobService.UpdateTask(Job.TaskId, RequestJob);
                }
                else if (Account.Role == "STAFF")
                {
                    Job = await _jobService.ChangeStatusStaff(Job.TaskId, StatusTask.REJECT.ToString());
                }
                return RedirectToPage("./Index");
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
