using RequireTechTest.TechExam.Models;

namespace RequireTechTest.TechExam.Tests.Models
{
    public class SalesPersonTest
    {
        [Fact]
        public void Should_Create_A_SalesPerson_Successfully()
        {
            /*
                Provide an example of Hierarchy. Implement a base class, and then, at least two, derived classes. 
            */

            string name = "Roberto Pastoriza";
            DateTime birthDate = new DateTime(1998, 05, 01);
            decimal totalSalesAmount = 25200;
            //This is a Person derived class
            SalesPerson salesPerson = new SalesPerson(name, birthDate, totalSalesAmount);
            
            Assert.Equal(name, salesPerson.Name);
            Assert.Equal(birthDate, salesPerson.BirthDate);
            Assert.Equal(totalSalesAmount, salesPerson.TotalSalesAmount);
        }
    }
}