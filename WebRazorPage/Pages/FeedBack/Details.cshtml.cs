using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace WebRazorPage.Pages.FeedBack
{
    public class DetailsModel : PageModel
    {
        private readonly Domain.Entity.FacilityReportContext _context;

        public DetailsModel(Domain.Entity.FacilityReportContext context)
        {
            _context = context;
        }

      public Feedback Feedback { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(m => m.FeedBackId == id);
            if (feedback == null)
            {
                return NotFound();
            }
            else 
            {
                Feedback = feedback;
            }
            return Page();
        }
    }
}
