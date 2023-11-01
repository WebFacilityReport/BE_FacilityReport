using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestTask;
using Domain.Enum;
using Domain.Entity;

namespace WebRazorPage.Pages.ManagerOffice.Job
{
    public class CreateEquipmentModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IJobService _jobService;
        private readonly IReService _reService;

        public CreateEquipmentModel(IAccountService accountService, IJobService jobService, IReService reService)
        {
            _accountService = accountService;
            _jobService = jobService;
            _reService = reService;
        }

        [BindProperty]
        public Guid CreatorId { get; set; }
        [BindProperty]
        public RequestTaskEquipmentRZ Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var resource = await _reService.getAllResourceACTIVEs();

            try
            {
                var accountId = HttpContext.Session.GetString("ACCOUNTID");

                // Check if the session value is not null or empty
                if (!string.IsNullOrEmpty(accountId))
                {
                    var account = await _accountService.GetUsernameRz(accountId);
                    CreatorId = account.AccountId;
                }
                ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");
                ViewData["ResourceId"] = new SelectList(resource.Select(c => new SelectListItem
                {
                    Text = $"{c.NameResource}-{c.ResourcesId}",
                    Value = c.ResourcesId.ToString() // Chuyển ResourceId thành chuỗi (string)
                }), "Value", "Text"); return Page();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");
                ViewData["ResourceId"] = new SelectList(resource.Select(c => new SelectListItem
                {
                    Text = $"{c.NameResource}-{c.ResourcesId}",
                    Value = c.ResourcesId.ToString() // Chuyển ResourceId thành chuỗi (string)
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
                var task = await _jobService.AddTaskEquipmentByResourceIdRZ(Job);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["EmployeeId"] = new SelectList(await _accountService.SearchAccountRole(ROlE.STAFF.ToString()), "AccountId", "Username");
                ViewData["ResourceId"] = new SelectList((await _reService.getAllResourceACTIVEs()).Select(c => new SelectListItem
                {
                    Text = $"{c.NameResource}-{c.ResourcesId}",
                    Value = c.ResourcesId.ToString() // Chuyển ResourceId thành chuỗi (string)
                }), "Value", "Text");

                return Page();
            }
        }
    }
}
