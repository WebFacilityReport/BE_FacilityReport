using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.Model.Response.ResponseTask;

namespace WebRazorPage.Pages.ManagerOffice.Job
{
    public class IndexModel : PageModel
    {
        private readonly IJobService _jobService;

        public IndexModel(IJobService jobService)
        {
            _jobService = jobService;
        }

        public List<ResponseTask> Job { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Job = await _jobService.GetAllTask();
        }
    }
}
