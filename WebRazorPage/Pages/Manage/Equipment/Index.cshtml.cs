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
using Infrastructure.Model.Response.ResponseResource;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Text.Json;

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
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

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
                Equipment = await _equipmentService.SearchGetEquipment(SearchQuery);
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
