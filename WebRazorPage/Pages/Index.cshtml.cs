using Domain.Entity;
using Domain.Enum;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        public string Password { get; set; } = string.Empty;

        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            var accountJsonString = HttpContext.Session.GetString("Account");
            if (accountJsonString != null) return Redirect("/Home");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    var account = await _accountService.LoginRZ(Username, Password);
                    HttpContext.Session.SetString("Account", JsonSerializer.Serialize(account));

                    return Redirect("/Home");
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message.ToString();
                return Page();
            }
        }
    }
}