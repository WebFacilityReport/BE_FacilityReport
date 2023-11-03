using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.RepositoryImp
{
    public class NotificationRepositoryImp : GenericRepositoryImp<Notification>, INotificationRepository
    {
        public NotificationRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public async Task<List<Notification>> GetAll(Guid accountId)
        {
            return await _context.Notifications.Where(noti => noti.AccountId.ToString().ToUpper().Equals(accountId.ToString().ToUpper())).ToListAsync();
        }
    }
}
