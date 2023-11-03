using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseEquipment;
using Domain.Enum;
using System.Text.Json;

namespace WebRazorPage.Pages.ManagerOffice.Equipment
{
    public class DeleteModel : PageModel
    {
        private readonly IEquipmentService _equipmentService;

        public DeleteModel(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [BindProperty]
        public ResponseEquipment Equipment { get; set; } = default!;

        [BindProperty]
        public Account Account { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var accountJsonString = HttpContext.Session.GetString("Account");

            if (accountJsonString == null) return Redirect("/");

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return Redirect("/");

            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _equipmentService.GetById(id);

            if (equipment == null)
            {
                return NotFound();
            }
            else
            {
                Equipment = equipment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _equipmentService.ChangeStatus(id, STATUSEQUIPMENT.INACTIVE.ToString());
            return RedirectToPage("./Index");
        }
    }
}
