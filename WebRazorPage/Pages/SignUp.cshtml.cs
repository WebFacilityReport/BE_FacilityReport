using Domain.Entity;
using Domain.Enum;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestAccount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace WebRazorPage.Pages
{
    public class SignUpModel : PageModel
    {
        private IAccountService _accountService;
        public SignUpModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public RequestRegisterAccount RequestAccount { get; set; } = default!;

        [BindProperty]
        public string Role { get; set; } = "CUSTOMER";

        public string Now { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        public SelectList SelectListRoleSelect { get; set; } = new SelectList(new List<SelectListItem>
        {
            new SelectListItem { Value = "CUSTOMER", Text = "Customer" },
            new SelectListItem { Value = "STAFF", Text = "Staff" }
        }, "Value", "Text");
        public IActionResult OnGet()
        {
            var accountJsonString = HttpContext.Session.GetString("Account");
            if (accountJsonString != null) return Redirect("/Home");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (Role == "CUSTOMER")
                {
                    await _accountService.RegisterAccountCustomer(RequestAccount);
                }
                else
                {
                    await _accountService.RegisterAccountStaff(RequestAccount);
                }
                return Redirect("/");
            } catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message.ToString();
                return Page();
            }
        }
    }
}
