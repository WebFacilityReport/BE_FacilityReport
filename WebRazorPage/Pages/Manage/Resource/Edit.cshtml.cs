using Domain.Entity;
using Domain.Enum;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseResource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace WebRazorPage.Pages.ManagerOffice.Resource
{
    public class EditModel : PageModel
    {
        private readonly IReService _resourceService;

        public EditModel(IReService resourceService)
        {
            _resourceService = resourceService;
        }

        [BindProperty]
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
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var resource = await _resourceService.GetById(id);
                if (resource == null)
                {
                    return NotFound();
                }
                Resource = resource;
                return Page();

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var resource = await _resourceService.UpdateStatus(id, StatusResource.ACTIVE.ToString());
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }
        }

    }
}
