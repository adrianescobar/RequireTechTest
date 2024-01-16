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
        }
    }
}