
namespace RequireTechTest.TechExam.Models
{
    public class Customer : Person
    {
        public Customer(string name, DateTime birthDate) : base(name, birthDate)
        {
        }

        public long Id { get; set; }
    }
}