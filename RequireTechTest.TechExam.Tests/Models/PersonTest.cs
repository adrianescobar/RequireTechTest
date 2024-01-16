using RequireTechTest.TechExam.Models;

namespace RequireTechTest.TechExam.Tests.Models
{
    public class PersonTest
    {
        [Fact]
        public void Should_Create_Person_Successfully()
        {
            /*
            Create an class called Person, create the properties name and date of birth. Then, create an object based on Person class, call the constructor, and assign some values to those properties
            */

            string name = "Jose Fererico";
            DateTime birthDate = new DateTime(1991, 08, 08);
            Person person = new Person(name, birthDate);
            
            Assert.Equal(name, person.Name);
            Assert.Equal(birthDate, person.BirthDate);
        }

        [Fact]
        public void Should_Return_Current_Age_Successfully()
        {
            /*
            Based on the previous exercise, create a function that returns the person's current age. Provide an example of how to use it. 
            */

            string name = "Jose Fererico";
            DateTime birthDate = new DateTime(1991, 08, 08);
            DateTime today = DateTime.Now;
            int expectedAge =today.Year - birthDate.Year;
            Person person = new Person(name, birthDate);
            
            Assert.Equal(expectedAge, person.Age);
        }
    }
}