using Microsoft.EntityFrameworkCore;
using RequireTechTest.TechExam.Models;
using RequireTechTest.TechExam.Repositories.Context;
using RequireTechTest.TechExam.Repositories.Implementations;

namespace RequireTechTest.TechExam.Tests.Repositories.Implementations
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public async void Should_Insert_A_Customer_In_Database_Successfully()
        {
            TechExamDbContext context = GetDocumentContext("test_insert");
            CustomerRepository customerRepository = new CustomerRepository(context);
            Customer customer = new Customer("Jose Maria Villanueva", new DateTime(1991,08,08));
            CancellationToken  cancellationToken = new CancellationTokenSource().Token;
          
            await customerRepository.Insert(customer, cancellationToken);
            await context.SaveChangesAsync();

            Assert.True(customer.Id > 0);
        }

        [Fact]
        public async void Should_FindById_Returns_A_Customer_From_Database_Successfully()
        {
            TechExamDbContext context = GetDocumentContext("test_find");
            CancellationToken  cancellationToken = new CancellationTokenSource().Token;
            Customer customer = new Customer("Jose Maria Villanueva", new DateTime(1991,08,08));
            CustomerRepository customerRepository = new CustomerRepository(context);

            await context.Customers.AddAsync(customer, cancellationToken);
            await context.SaveChangesAsync();
            
            Customer? customerReturned = await customerRepository.FindById(customer.Id, cancellationToken);
            
            Assert.NotNull(customerReturned);
            Assert.Equal(customer.Id, customerReturned.Id);
            Assert.Equal(customer.Name, customerReturned.Name);
            Assert.Equal(customer.BirthDate, customerReturned.BirthDate);
        }

        [Fact]
        public async void Should_Be_Removed_A_Customer_From_Database_Successfully()
        {
            TechExamDbContext context = GetDocumentContext("test_delete");
            CancellationToken  cancellationToken = new CancellationTokenSource().Token;
            Customer customer = new Customer("Jose Maria Villanueva", new DateTime(1991,08,08));
            CustomerRepository customerRepository = new CustomerRepository(context);

            await context.Customers.AddAsync(customer, cancellationToken);
            await context.SaveChangesAsync();
            
            Customer? customerFromDb = await customerRepository.FindById(customer.Id, cancellationToken);
            Assert.NotNull(customerFromDb);

            customerRepository.Delete(customerFromDb);
            await context.SaveChangesAsync();

            Customer? customerRemoved = await customerRepository.FindById(customer.Id, cancellationToken);
            Assert.Null(customerRemoved);
        }

        [Fact]
        public async void Should_Be_Updated_A_Customer_From_Database_Successfully()
        {
            TechExamDbContext context = GetDocumentContext("test_update");
            CancellationToken  cancellationToken = new CancellationTokenSource().Token;
            Customer customer = new Customer("Jose Maria Villanueva", new DateTime(1991,08,08));
            CustomerRepository customerRepository = new CustomerRepository(context);
            await context.Customers.AddAsync(customer, cancellationToken);
            await context.SaveChangesAsync();
            string newName = "Jose Maria Villalejos";

            Customer? customerFromDb = await customerRepository.FindById(customer.Id, cancellationToken);
            Assert.NotNull(customerFromDb);

            customerFromDb.Name = newName;

            customerRepository.Update(customerFromDb);
            await context.SaveChangesAsync();

            Customer? customerUpdated = await customerRepository.FindById(customer.Id, cancellationToken);
            Assert.NotNull(customerUpdated);

            Assert.Equal(newName, customerUpdated.Name);
            
        }

        private TechExamDbContext GetDocumentContext(string name = "test")
        {
            var options = new DbContextOptionsBuilder<TechExamDbContext>()
                            .UseInMemoryDatabase(name)
                            .EnableDetailedErrors()
                            .Options;

            return new TechExamDbContext(options);
        }
    }
}