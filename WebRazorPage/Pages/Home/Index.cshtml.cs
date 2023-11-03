using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace WebRazorPage.Pages.Home
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Account Account { get; set; }
        public IActionResult OnGet()
        {
            var accountJsonString = HttpContext.Session.GetString("Account");
            
            Console.WriteLine(accountJsonString);

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            Account = account;

            return Page();
        }

        public IActionResult OnPostSignOut()
        {
            HttpContext.Session.Remove("Account");
            return Redirect("/");
        }
    }
}
