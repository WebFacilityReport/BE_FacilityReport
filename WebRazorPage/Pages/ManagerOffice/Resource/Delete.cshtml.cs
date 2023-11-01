﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseResource;
using Domain.Enum;

namespace WebRazorPage.Pages.ManagerOffice.Resource
{
    public class DeleteModel : PageModel
    {
        private readonly IReService _resourceService;

        public DeleteModel(IReService resourceService)
        {
            _resourceService = resourceService;
        }

        [BindProperty]
        public ResponseResource Resource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
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
                else
                {
                    Resource = resource;
                }
                return Page();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var resource = await _resourceService.UpdateStatus(id,StatusResource.INACTIVE.ToString());
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
