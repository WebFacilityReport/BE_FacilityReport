using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entity;
using Infrastructure.IService;
using Infrastructure.Model.Request.RequestAccount;
using Domain.Enum;
using System.Text.Json;

namespace WebRazorPage.Pages.Manage.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public string Now { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        public SelectList SelectListRoleSelect { get; set; } = new SelectList(new List<SelectListItem>
        {
            new SelectListItem { Value = "CUSTOMER", Text = "Customer" },
            new SelectListItem { Value = "STAFF", Text = "Staff" },
            new SelectListItem { Value = "MANAGER_OFFICE", Text = "Manager Office" },
        }, "Value", "Text");

        [BindProperty]
        public RequestRegisterAccount Account { get; set; } = default!;

        public Account SessionAccount { get; set; } = default!;

        public IActionResult OnGet()
        {
            var accountJsonString = HttpContext.Session.GetString("Account");

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            SessionAccount = account;
            return Page();
        }

        [BindProperty]
        public string Role { get; set; } = "CUSTOMER";
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                if (Role == "MANAGER_OFFICE")
                {
                    await _accountService.RegisterAccountManagerOffice(Account);
                }
                else if (Role == "STAFF")
                {
                    await _accountService.RegisterAccountStaff(Account);
                }
                else
                {
                    await _accountService.RegisterAccountCustomer(Account);
                }

            } catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }



            return RedirectToPage("./Index");
        }
    }
}
