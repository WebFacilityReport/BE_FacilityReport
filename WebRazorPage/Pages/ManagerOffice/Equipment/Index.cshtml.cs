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

namespace WebRazorPage.Pages.ManagerOffice.Equipment
{
    public class IndexModel : PageModel
    {
        private readonly IEquipmentService _equipmentService;

        public IndexModel(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public List<ResponseEquipment> Equipment { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Equipment = await _equipmentService.GetEquipment();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                Page();
            }
        }
    }
}
