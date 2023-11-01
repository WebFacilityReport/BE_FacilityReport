﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseTask;

namespace WebRazorPage.Pages.ManagerOffice.Job
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IJobService _jobService;

        public DetailsModel(IAccountService accountService, IJobService jobService)
        {
            _accountService = accountService;
            _jobService = jobService;
        }

        [BindProperty]
        public ResponseTask Job { get; set; } = default!;
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
                else
                {
                    Job = job;
                }
                return Page();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }
        }
    }
}
