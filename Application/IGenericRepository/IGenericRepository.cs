namespace Application.IGenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
    }
}
