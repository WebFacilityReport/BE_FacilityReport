using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface INotificationService
    {
        public Task Create(Notification notification);
        public Task<List<Notification>> GetAllNotifications(Guid accountId);
    }
}
