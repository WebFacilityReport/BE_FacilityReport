using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestTask;
using Domain.Enum;

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
    public Guid CreatorId { get; set; }
    [BindProperty]
    public RequestUpdateStatusHistoryRZ Job { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync()
    {
        try
        {


            var resource = await _reService.getAllResourceACTIVEs();
            var accountId = HttpContext.Session.GetString("ACCOUNTID");
            var test = await _equipmentService.GetEquipmentFix();
            // Check if the session value is not null or empty
            if (!string.IsNullOrEmpty(accountId))
            {
                var account = await _accountService.GetUsernameRz(accountId);
                CreatorId = account.AccountId;
            }
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
            if (!ModelState.IsValid || Job == null)
            {
                return Page();
            }
            Job.CreatorId = CreatorId;
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
