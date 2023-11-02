using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseResource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public async Task OnGetAsync()
        {
            try
            {
                Resource = await _resourceService.SearchGetAllResource(SearchQuery);

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                Page();
            }
        }
    }
}
