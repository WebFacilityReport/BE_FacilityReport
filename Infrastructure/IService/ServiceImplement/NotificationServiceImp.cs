using AutoMapper;
using Domain.Entity;
using Infrastructure.IUnitofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.ServiceImplement
{
    public class NotificationServiceImp : INotificationService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public NotificationServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task Create(Notification notification)
        {
            _unitofWork.Notification.Add(notification);
            _unitofWork.Commit();
        }
        public async Task<List<Notification>> GetAllNotifications(Guid accountId)
        {
            return await _unitofWork.Notification.GetAll(accountId);
        }
    }
}
