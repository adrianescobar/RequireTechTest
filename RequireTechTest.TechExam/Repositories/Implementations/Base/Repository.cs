using Microsoft.EntityFrameworkCore;
using RequireTechTest.TechExam.Repositories.Context;
using RequireTechTest.TechExam.Repositories.Interfaces.Base;

namespace RequireTechTest.TechExam.Repositories.Implementations.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TechExamDbContext _context;
        public Repository(TechExamDbContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
             _context.Remove(entity);
        }

        public Task<T?> FindById(long Id, CancellationToken canceletationToken)
        {
            return _context.Set<T>().FindAsync(new object?[] { Id }, cancellationToken: canceletationToken).AsTask();
        }

        public Task Insert(T entity, CancellationToken canceletationToken)
        {
            return _context.Set<T>().AddAsync(entity, canceletationToken).AsTask();
             
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}