using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.IService;
using Infrastructure.IService.ServiceImplement;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.Model.Response.ResponseAccount;

namespace WebRazorPage.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IHubContext<ChatHub> _chatHubContext;

        public IndexModel(IAccountService accountService, IHubContext<ChatHub> chatHubContext)
        {
            _accountService = accountService;
            _chatHubContext = chatHubContext;
        }

        public List<ResponseAllAccount> Account { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Account = await _accountService.GetAllAccounts();
            await _chatHubContext.Clients.All.SendAsync("ReceiveMessage", Account, Account);
        }
        public async Task SendMessage(string user, string message)
        {
            await _chatHubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
