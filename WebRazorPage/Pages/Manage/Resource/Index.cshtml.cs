using Domain.Entity;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseResource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebRazorPage.Pages.ManagerOffice.Resource
{
    public class IndexModel : PageModel
    {
        private readonly IReService _resourceService;

        public IndexModel(IReService resourceService)
        {
            _resourceService = resourceService;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<ResponseResource> Resource { get; set; } = default!;
        
        [BindProperty]
        public Account Account { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
                var accountJsonString = HttpContext.Session.GetString("Account");

                if (accountJsonString == null) return Redirect("/");

                var account = JsonSerializer.Deserialize<Account>(accountJsonString);

                if (account == null) return Redirect("/");

                Account = account;
                try
            {
                Resource = await _resourceService.SearchGetAllResource(SearchQuery);

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                Page();
            }
            return Page();
        }
    }
}
