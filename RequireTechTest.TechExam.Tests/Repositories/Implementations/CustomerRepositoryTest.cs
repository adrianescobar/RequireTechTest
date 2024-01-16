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
            /*
                Using Entity Framework, set up a data model (you can use Person from previous exercises), and provide an example of Add a new person to the database, retrieve a person based on their ID, update the information, deleting the person. 
            */
            // Arrange
            TechExamDbContext context = GetTechExamDbContextInMemory("test_insert");
            CustomerRepository customerRepository = new CustomerRepository(context);
            Customer customer = createCustomer();
            CancellationToken cancellationToken = GetCancellationToken();
            
            // Act
            await customerRepository.Insert(customer, cancellationToken);

            await context.SaveChangesAsync();

            // Assert
            Assert.True(customer.Id > 0);
        }

        [Fact]
        public async void Should_FindById_Returns_A_Customer_From_Database_Successfully()
        {
            // Arrange
            TechExamDbContext context = GetTechExamDbContextInMemory("test_find");
            CancellationToken cancellationToken = GetCancellationToken();
            Customer customer = createCustomer();
            CustomerRepository customerRepository = new CustomerRepository(context);
            await AddNewCustomer(context, customer, cancellationToken);

            // Act
            Customer? customerReturned = await customerRepository.FindById(customer.Id, cancellationToken);

            // Assert
            Assert.NotNull(customerReturned);
            Assert.Equal(customer.Id, customerReturned.Id);
            Assert.Equal(customer.Name, customerReturned.Name);
            Assert.Equal(customer.BirthDate, customerReturned.BirthDate);
        }

        [Fact]
        public async void Should_Be_Removed_A_Customer_From_Database_Successfully()
        {
            // Arrange
            TechExamDbContext context = GetTechExamDbContextInMemory("test_delete");
            CancellationToken cancellationToken = GetCancellationToken();
            Customer customer = createCustomer();
            CustomerRepository customerRepository = new CustomerRepository(context);
            
            await AddNewCustomer(context, customer, cancellationToken);
            
            Customer? customerFromDb = await customerRepository.FindById(customer.Id, cancellationToken);
            Assert.NotNull(customerFromDb);

            // Act
            customerRepository.Delete(customerFromDb);
            
            await context.SaveChangesAsync();
            // Assert
            Customer? customerRemoved = await customerRepository.FindById(customer.Id, cancellationToken);
            Assert.Null(customerRemoved);
        }

        [Fact]
        public async void Should_Be_Updated_A_Customer_From_Database_Successfully()
        {
            // Arrange
            TechExamDbContext context = GetTechExamDbContextInMemory("test_update");
            CancellationToken cancellationToken = GetCancellationToken();
            Customer customer = createCustomer();
            CustomerRepository customerRepository = new CustomerRepository(context);

            await AddNewCustomer(context, customer, cancellationToken);
            string newName = "Jose Maria Villalejos";

            Customer? customerFromDb = await customerRepository.FindById(customer.Id, cancellationToken);
            Assert.NotNull(customerFromDb);

            customerFromDb.Name = newName;

            // Act
            customerRepository.Update(customerFromDb);
            await context.SaveChangesAsync();

            // Assert
            Customer? customerUpdated = await customerRepository.FindById(customer.Id, cancellationToken);

            Assert.NotNull(customerUpdated);
            Assert.Equal(newName, customerUpdated.Name);
        }

        [Fact]
        public async void Should_Find_Customers_By_BirhDay_From_Database_Successfully()
        {
            /*
            Using Linq, provide the code to get the persons that the date of birth is January 1, 2011.
            */

            // Arrange
            TechExamDbContext context = GetTechExamDbContextInMemory("test_by_birthday");
            CancellationToken cancellationToken = GetCancellationToken();
            DateTime expectedBirthday = new DateTime(2011, 01, 01);

            List<Customer> customerWithBirthdayMatch = new List<Customer> {
                createCustomer("Matilda Mirella", expectedBirthday),
                createCustomer("Ramona Hidalgo Villaleon", expectedBirthday),
                createCustomer("Angelines Fernandez", expectedBirthday)
            };
            
            List<Customer> customerWithoutBirthdayMatch = new List<Customer> {
                createCustomer("Rosa Maria Gutierrez", new DateTime(1992, 06, 11)),
                createCustomer("Maria Antonieta de las Nieves", new DateTime(2003, 01, 20))
            };

            customerWithBirthdayMatch.ForEach( async customer => await AddNewCustomer(context, customer, cancellationToken));
            customerWithoutBirthdayMatch.ForEach( async customer => await AddNewCustomer(context, customer, cancellationToken));

            CustomerRepository customerRepository = new CustomerRepository(context);
            
            // Act
            List<Customer> customersMatched = await customerRepository.FindCustomersByBirthDate(expectedBirthday);

            // Assert
            Assert.Equal(customerWithBirthdayMatch.Count, customersMatched.Count);
            Assert.All(customersMatched, customer => Assert.Equal(expectedBirthday, customer.BirthDate));
        }

        private static Customer createCustomer(string name = "", DateTime? birthDate = null)
        {

            if(birthDate.HasValue) {
                return new Customer(name, birthDate.Value);
            }

           return new Customer(name, new DateTime(1991, 08, 08));
            
        }

        private static CancellationToken GetCancellationToken()
        {
            return new CancellationTokenSource().Token;
        }

        private static async Task AddNewCustomer(TechExamDbContext context, Customer customer, CancellationToken cancellationToken)
        {
            await context.Customers.AddAsync(customer, cancellationToken);
            await context.SaveChangesAsync();
        }

        private TechExamDbContext GetTechExamDbContextInMemory(string name = "test")
        {
            var options = new DbContextOptionsBuilder<TechExamDbContext>()
                            .UseInMemoryDatabase(name)
                            .EnableDetailedErrors()
                            .Options;

            return new TechExamDbContext(options);
        }
    }
}