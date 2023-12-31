﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestTask;
using Domain.Enum;
using Domain.Entity;
using System.Text.Json;

namespace WebRazorPage.Pages.ManagerOffice.Job;

public class CreateFixEquipmentModel : PageModel
{
    private readonly IAccountService _accountService;
    private readonly IJobService _jobService;
    private readonly IReService _reService;
    private readonly IEquipmentService _equipmentService;

    public CreateFixEquipmentModel(IAccountService accountService, IJobService jobService, IReService reService, IEquipmentService equipmentService)
    {
        _accountService = accountService;
        _jobService = jobService;
        _reService = reService;
        _equipmentService = equipmentService;
    }

    [BindProperty]
    public string Now { get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

    [BindProperty]
    public RequestUpdateStatusHistoryRZ Job { get; set; } = default!;

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
            var resource = await _reService.getAllResourceACTIVEs();

            var test = await _equipmentService.GetEquipmentFix();
            // Check if the session value is not null or empty
                
            ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");
            ViewData["EquipmentId"] = new SelectList((await _equipmentService.GetEquipmentFix()).Select(c => new SelectListItem
            {
                Text = $"{c.Location}-{c.EquipmentId}",
                Value = c.EquipmentId.ToString()
            }), "Value", "Text");
            return Page();
        }
        catch (Exception ex)
        {
            ViewData["Message"] = ex.Message.ToString();
            ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");
            ViewData["EquipmentId"] = new SelectList((await _equipmentService.GetEquipmentFix()).Select(c => new SelectListItem
            {
                Text = $"{c.Location}-{c.EquipmentId}",
                Value = c.EquipmentId.ToString()
            }), "Value", "Text");
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
            var task = await _jobService.UpdateHistoryEquipmentRZ(Job);
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            ViewData["Message"] = ex.Message.ToString();
            ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");
            ViewData["EquipmentId"] = new SelectList((await _equipmentService.GetEquipmentFix()).Select(c => new SelectListItem
            {
                Text = $"{c.Location}-{c.EquipmentId}",
                Value = c.EquipmentId.ToString()
            }), "Value", "Text");

            return Page();
        }
    }
}
