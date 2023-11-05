using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure.IService;
using System.Text.Json;

namespace WebRazorPage.Pages.Manage.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;

        public EditModel(IAccountService accountService)
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
        public Account Account { get; set; } = default!;

        [BindProperty]
        public Account SessionAccount { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var accountJsonString = HttpContext.Session.GetString("Account");

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            SessionAccount = account;

            if (id == null) return NotFound();

            var _account = await _accountService.GetByIdRZ(id.Value);
            if (_account == null)
            {
                return NotFound();
            }
            Account = _account;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            await _accountService.UpdateRZ(Account);

            return RedirectToPage("./Index");
        }
    }
}
