using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entity;
using Infrastructure.IService;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Model.Request.RequestFeedBack;
using Domain.Enum;

namespace WebRazorPage.Pages.FeedBack
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IAccountService _accountService;
        private readonly IEquipmentService _equipmentService;

        public CreateModel(IFeedbackService feedbackService, IAccountService accountService, IEquipmentService equipmentService)
        {
            _feedbackService = feedbackService;
            _accountService = accountService;
            _equipmentService = equipmentService;
        }

        [BindProperty]

        public Guid AccountId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var username = HttpContext.Session.GetString("ACCOUNTID");
                if (!string.IsNullOrEmpty(username))
                {
                    var account = await _accountService.GetUsernameRz(username);
                    AccountId = account.AccountId;
                }

                //ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Address");
                ViewData["EquipmentId"] = new SelectList((await _equipmentService.GetEquipmentActive()).Select(c => new SelectListItem
                {
                    Text = $"{c.Location}  Mã: {c.EquipmentId}",
                    Value = c.EquipmentId.ToString()
                }), "Value", "Text");
                return Page();

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["EquipmentId"] = new SelectList((await _equipmentService.GetEquipmentActive()).Select(c => new SelectListItem
                {
                    Text = $"{c.Location}  Mã: {c.EquipmentId}",
                    Value = c.EquipmentId.ToString()
                }), "Value", "Text");
                return Page();

            }
        }

        [BindProperty]
        public RequestFeedBackRZ Feedback { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                Feedback.AccountId = AccountId;
                var feedback = await _feedbackService.CreateFeedBackRz(Feedback);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["EquipmentId"] = new SelectList((await _equipmentService.GetEquipmentActive()).Select(c => new SelectListItem
                {
                    Text = $"{c.Location}  Mã: {c.EquipmentId}",
                    Value = c.EquipmentId.ToString()
                }), "Value", "Text");

                return Page();
            }
        }
    }
}
