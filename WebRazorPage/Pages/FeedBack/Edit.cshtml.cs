using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace WebRazorPage.Pages.FeedBack
{
    public class EditModel : PageModel
    {
        private readonly Domain.Entity.FacilityReportContext _context;

        public EditModel(Domain.Entity.FacilityReportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedback =  await _context.Feedbacks.FirstOrDefaultAsync(m => m.FeedBackId == id);
            if (feedback == null)
            {
                return NotFound();
            }
            Feedback = feedback;
           ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Address");
           ViewData["EquipmentId"] = new SelectList(_context.Equipment, "EquipmentId", "Location");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(Feedback.FeedBackId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FeedbackExists(Guid id)
        {
          return (_context.Feedbacks?.Any(e => e.FeedBackId == id)).GetValueOrDefault();
        }
    }
}
