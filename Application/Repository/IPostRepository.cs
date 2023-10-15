using Application.IGenericRepository;
using Domain.Entity;


namespace Application.Repository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<Post>> GetAll();
        Task<Post> GetById(Guid id);
    }
}
