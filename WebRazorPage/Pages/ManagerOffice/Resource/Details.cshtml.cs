
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseResource;

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

        public async Task<IActionResult> OnGetAsync(Guid id)
        {

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
