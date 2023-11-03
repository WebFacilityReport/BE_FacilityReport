using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entity;
using Infrastructure.IService;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Model.Request.RequestFeedBack;
using Domain.Enum;
using System.Text.Json;

namespace WebRazorPage.Pages.FeedBacks
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
        public Account Account { get; set; } = default!;

        [BindProperty]
        public RequestFeedBackRZ Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["EquipmentId"] = new SelectList((await _equipmentService.GetEquipmentActive()).Select(c => new SelectListItem
            {
                Text = $"{c.Location}  Mã: {c.EquipmentId}",
                Value = c.EquipmentId.ToString()
            }), "Value", "Text");

            var accountJsonString = HttpContext.Session.GetString("Account");

                if (accountJsonString == null) return Redirect("/");

                var account = JsonSerializer.Deserialize<Account>(accountJsonString);

                if (account == null) return Redirect("/");

                Account = account;

                return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["EquipmentId"] = new SelectList((await _equipmentService.GetEquipmentActive()).Select(c => new SelectListItem
            {
                Text = $"{c.Location}  Mã: {c.EquipmentId}",
                Value = c.EquipmentId.ToString()
            }), "Value", "Text");

            try
            {
                Feedback.AccountId = Account.AccountId;
                var feedback = await _feedbackService.CreateFeedBackRz(Feedback);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message.ToString();
            }
            return Page();
        }
    }
}
