namespace RequireTechTest.TechExam.Repositories.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T?> FindById(long Id, CancellationToken canceletationToken);

        Task Insert(T entity, CancellationToken canceletationToken);

        void Update(T entity);

        void Delete(T entity);
    }
}