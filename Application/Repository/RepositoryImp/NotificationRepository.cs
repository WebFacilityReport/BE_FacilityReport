using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.RepositoryImp;

public class NotificationRepository : GenericRepositoryImp<Notification>, INotificationRepository
{
    public NotificationRepository(FacilityReportContext context) : base(context)
    {
    }

    public async Task<List<Notification>> GetAll()
    {
        return await _context
            .Set<Notification>()
            .Include(c => c.Account)
            .OrderByDescending(c => c.CreateAt)
            .ToListAsync();
    }

    public async Task<List<Notification>> GetAll(Guid accountId)
    {
        return await _context.Set<Notification>().Where(noti => noti.AccountId.ToString().ToUpper().Equals(accountId.ToString().ToUpper())).ToListAsync();
    }

    public async Task<Notification> GetById(Guid id)
    {
        var notification = await _context
            .Set<Notification>()
            .Include(c => c.Account)
            .OrderByDescending(c => c.CreateAt)
            .FirstOrDefaultAsync(c => c.NotificationId == id);
        if (notification == null)
        {
            throw new Exception("Khong tim thay notificationId");
        }
        return notification;

    }
}
