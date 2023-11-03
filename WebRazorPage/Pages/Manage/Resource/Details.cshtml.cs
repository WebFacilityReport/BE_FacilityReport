
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseResource;
using Domain.Entity;
using System.Text.Json;

namespace WebRazorPage.Pages.ManagerOffice.Resource
{
    public class DetailsModel : PageModel
    {
        private readonly IReService _resourceService;

        public DetailsModel(IReService resourceService)
        {
            _resourceService = resourceService;
        }

        public ResponseResource Resource { get; set; } = default!;

        [BindProperty]
        public Account Account { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var accountJsonString = HttpContext.Session.GetString("Account");

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            Account = account;

            var resource = await _resourceService.GetById(id);
            if (resource == null)
            {
                return NotFound();
            }
            else
            {
                Resource = resource;
            }
            return Page();
        }
    }
}
