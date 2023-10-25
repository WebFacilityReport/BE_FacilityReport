using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseResource;
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

        public List<ResponseResource> Resource { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Resource = await _resourceService.GetAllResource();
        }
    }
}
