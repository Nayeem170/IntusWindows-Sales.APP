namespace Sales.DAL.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T? Get(Guid uid);
        T Add(T entity);
        T Edit(T entity);
        IEnumerable<T> Edit(IEnumerable<T> entities);
        bool Delete(T entity);
        void Detach(T entity);
    }
}
