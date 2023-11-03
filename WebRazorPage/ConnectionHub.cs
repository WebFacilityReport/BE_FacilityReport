﻿using AutoMapper;
using Domain.Entity;
using Infrastructure.IService;
using Infrastructure.Mapper;
using Infrastructure.Model.Request.RequestFeedBack;
using Infrastructure.Model.Request.RequestTask;
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
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public static Dictionary<string, Guid> ConnectedClients = new();
        public ConnectionHub(
            IFeedbackService feedbackService,
            IAccountService accountService,
            IEquipmentService equipmentService,
            INotificationService notificationService,
            IJobService jobService,
            IMapper mapper
            )
        {
            _feedbackService = feedbackService;
            _accountService = accountService;
            _equipmentService = equipmentService;
            _notificationService = notificationService;
            _mapper = mapper;
            _jobService = jobService;
        }

        public async override Task OnConnectedAsync()
        {
            var accountJsonString = Context.GetHttpContext()?.Session.GetString("Account");

            if (accountJsonString == null) return;

            var account = JsonSerializer.Deserialize<Account>(accountJsonString);

            if (account == null) return;

            ConnectedClients.Add(Context.ConnectionId, account.AccountId);

            var notis = await _notificationService.GetAllNotifications(account.AccountId);

            await Clients.Caller.SendAsync("UpdateNotify", notis);

            Console.WriteLine(JsonSerializer.Serialize(ConnectedClients));
        }

        public async Task CreateFeedback(RequestFeedBackRZ feedback)
        {
            var _feedback = await _feedbackService.CreateFeedBackRz(feedback);

            var accounts = await _accountService.SearchAccountRole("MANAGER_OFFICE");

            Console.WriteLine(JsonSerializer.Serialize(accounts));

            foreach (var account in accounts)
            {
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
                        .SendAsync("UpdateNotify", _notis);
                }
            }



            await Clients.Caller.SendAsync("Response", "You have successfully created a feedback");
        }

        public async Task CreateFixEquipmentJob(RequestUpdateStatusHistoryRZ job)
        {
            Console.WriteLine(JsonSerializer.Serialize(job));
            var accountId = ConnectedClients[Context.ConnectionId];
            var account = await _accountService.GetById(accountId);
            if (account.Role != "MANAGER_OFFICE")
            {
                await Clients.Caller.SendAsync("Error", "You do not have permission to call this function");
                return;
            }

            var _job = await _jobService.UpdateHistoryEquipmentRZ(job);

            await _notificationService.Create(new Notification()
            {
                AccountId = job.EmployeeId,
                Message = "321323",
                Title = $"A fix equipment task with id {_job.TaskId} has been assigned to you",
                NotificationId = Guid.NewGuid(),
            });

            foreach (var connectedClient in ConnectedClients)
            {
                var connectedAccountId = connectedClient.Value;
                var connectedAccount = await _accountService.GetById(connectedAccountId);

                var role = connectedAccount.Role;
                if (role != "STAFF") continue;

                var notis = await _notificationService.GetAllNotifications(connectedAccountId);
                var _notis = _mapper.Map<List<Notification>, List<NotificationDTO>>(notis);

                await Clients.Client(connectedClient.Key)
                    .SendAsync("UpdateNotify", _notis);
            }
            await Clients.Caller.SendAsync("Response", "You have successfully created a fix equipment task");
        }

        public async Task CreateEquipmentJob(RequestTaskEquipmentRZ job)
        {
            Console.WriteLine(JsonSerializer.Serialize(job));
            var accountId = ConnectedClients[Context.ConnectionId];
            var account = await _accountService.GetById(accountId);
            if (account.Role != "MANAGER_OFFICE")
            {
                await Clients.Caller.SendAsync("Error", "You do not have permission to call this function");
                return;
            }

            var _job = await _jobService.AddTaskEquipmentByResourceIdRZ(job);

            await _notificationService.Create(new Notification()
            {
                AccountId = job.EmployeeId,
                Message = "321323",
                Title = $"A create equipment task with id {_job.TaskId} has been assigned to you",
                NotificationId = Guid.NewGuid(),
            });

            foreach (var connectedClient in ConnectedClients)
            {
                var connectedAccountId = connectedClient.Value;
                var connectedAccount = await _accountService.GetById(connectedAccountId);

                var role = connectedAccount.Role;
                if (role != "STAFF") continue;

                var notis = await _notificationService.GetAllNotifications(connectedAccountId);
                var _notis = _mapper.Map<List<Notification>, List<NotificationDTO>>(notis);

                await Clients.Client(connectedClient.Key)
                    .SendAsync("UpdateNotify", _notis);
            }
            await Clients.Caller.SendAsync("Response", "You have successfully created an add equipment task");
        }

        public async Task CreateResourceJob(RequestTaskResourceRz job)
        {
            Console.WriteLine("ok" + JsonSerializer.Serialize(job));
            var accountId = ConnectedClients[Context.ConnectionId];
            var account = await _accountService.GetById(accountId);
            if (account.Role != "MANAGER_OFFICE")
            {
                await Clients.Caller.SendAsync("Error", "You do not have permission to call this function");
                return;
            }

            var _job = await _jobService.AddTaskResourceRz(job);

            await _notificationService.Create(new Notification()
            {
                AccountId = job.EmployeeId,
                Message = "321323",
                Title = $"A create resource task with id {_job.TaskId} has been assigned to you",
                NotificationId = Guid.NewGuid(),
            });

            foreach (var connectedClient in ConnectedClients)
            {
                var connectedAccountId = connectedClient.Value;
                var connectedAccount = await _accountService.GetById(connectedAccountId);

                var role = connectedAccount.Role;
                if (role != "STAFF") continue;

                var notis = await _notificationService.GetAllNotifications(connectedAccountId);
                var _notis = _mapper.Map<List<Notification>, List<NotificationDTO>>(notis);

                await Clients.Client(connectedClient.Key)
                    .SendAsync("UpdateNotify", _notis);
            }
            await Clients.Caller.SendAsync("Response", "You have successfully created an add resource task");
        }

    }
}
