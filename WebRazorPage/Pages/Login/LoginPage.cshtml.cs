using Domain.Enum;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


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
                    if (account.Role.Equals(ROlE.MANAGER_OFFICE.ToString()))
                    {
                        HttpContext.Session.SetString("ROLE", "MANAGER_OFFICE");
                    }
                    else if (account.Role.Equals(ROlE.CUSTOMER.ToString()))
                    {
                        HttpContext.Session.SetString("ROLE", "CUSTOMER");
                    }
                    else if (account.Role.Equals(ROlE.STAFF.ToString()))
                    {
                        HttpContext.Session.SetString("ROLE", "STAFF");
                    }
                    else if (account.Role.Equals(ROlE.MANAGER.ToString()))
                    {
                        HttpContext.Session.SetString("ROLE", "MANAGER");
                    }
                    HttpContext.Session.SetString("ACCOUNTID", account.Username.ToString());

                    return Redirect("/UIROLE");
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


