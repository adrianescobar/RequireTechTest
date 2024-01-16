using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RequireTechTest.TechExam.Models;

namespace RequireTechTest.TechExam.Repositories.Context
{
    public class TechExamDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public TechExamDbContext(DbContextOptions<TechExamDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TechExamDbContext))));
        }
    }
}