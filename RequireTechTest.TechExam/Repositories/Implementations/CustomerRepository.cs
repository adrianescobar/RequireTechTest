using Microsoft.EntityFrameworkCore;
using RequireTechTest.TechExam.Models;
using RequireTechTest.TechExam.Repositories.Context;
using RequireTechTest.TechExam.Repositories.Implementations.Base;
using RequireTechTest.TechExam.Repositories.Interfaces;

namespace RequireTechTest.TechExam.Repositories.Implementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TechExamDbContext context) : base(context)
        {
        }

        public Task<List<Customer>> FindCustomersByBirthDate(DateTime birthDate)
        {
            return _context.Customers.Where(customer => customer.BirthDate == birthDate).ToListAsync();
        }
    }
}