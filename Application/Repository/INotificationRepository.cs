

using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository;

public interface INotificationRepository:IGenericRepository<Notification>
{
    Task<List<Notification>> GetAll();
    Task<Notification> GetById(Guid id);
}
