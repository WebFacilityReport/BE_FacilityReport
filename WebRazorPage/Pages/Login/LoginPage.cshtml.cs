using Domain.Entity;
using Domain.Enum;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebRazor.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        //[EmailAddress]
        [Required]
        public string UserName { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        [BindProperty]
        public Account Account { get; set; } = default!;

        private readonly IAccountService _accountService;

        public LoginPageModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    var account = await _accountService.LoginRZ(UserName, Password);  
                    HttpContext.Session.SetString("Account", JsonSerializer.Serialize(account));

                    return Redirect("/Homepage");
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["Email"] = UserName;
                return Page();
            }
        }
    }
}


