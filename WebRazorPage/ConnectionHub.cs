using AutoMapper;
using Domain.Entity;
using Infrastructure.IService;
using Infrastructure.Mapper;
using Infrastructure.Model.Request.RequestFeedBack;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Text.Json;

namespace WebRazorPage
{
    public class ConnectionHub : Hub
    {   
        private readonly IFeedbackService _feedbackService;
        private readonly IAccountService _accountService;
        private readonly IEquipmentService _equipmentService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public static Dictionary<string, Guid> ConnectedClients = new ();
        public ConnectionHub(
            IFeedbackService feedbackService, 
            IAccountService accountService, 
            IEquipmentService equipmentService,
            INotificationService notificationService,
            IMapper mapper
            )
        {
            _feedbackService = feedbackService;
            _accountService = accountService;
            _equipmentService = equipmentService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async override Task OnConnectedAsync()
        {
            var accountJsonString = Context.GetHttpContext()?.Session.GetString("Account");

            if (accountJsonString == null) return;

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return;

            ConnectedClients.Add(Context.ConnectionId, account.AccountId);

            Console.WriteLine(JsonSerializer.Serialize(ConnectedClients));
        }

        public async Task CreateFeedback(RequestFeedBackRZ feedback)
        {
           

            var _feedback = await _feedbackService.CreateFeedBackRz(feedback);

            var accounts = await _accountService.SearchAccountRole("MANAGER_OFFICE");

            Console.WriteLine(JsonSerializer.Serialize(accounts));

            foreach (var account in accounts)
            {
                Console.WriteLine("!@3123");

                await _notificationService.Create(new Notification()
                {
                    AccountId = account.AccountId,
                    Message = "321323",
                    Title = $"An feedback with id {_feedback.FeedBackId} has been created",
                    NotificationId = Guid.NewGuid(),
                });

                foreach (var connectedClient in ConnectedClients)
                {
                    var connectedAccountId = connectedClient.Value;
                    var connectedAccount = await _accountService.GetById(connectedAccountId);

                    var role = connectedAccount.Role;
                    if (role != "MANAGER_OFFICE") continue;

                    var notis = await _notificationService.GetAllNotifications(connectedAccountId);
                    var _notis = _mapper.Map<List<Notification>, List<NotificationDTO>>(notis);

                    await Clients.Client(connectedClient.Key)
                        .SendAsync("CreateFeedbackSuccessfullyNotify", _notis);
                }
            }

            await Clients.Caller.SendAsync("CreateFeedbackSuccessfully", "You have successfully created a feedback");
        }

    }
}
