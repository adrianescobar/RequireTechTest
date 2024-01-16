namespace RequireTechTest.TechExam.Models
{
    public class Person
    {
        public Person(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age => DateTime.Now.Year - BirthDate.Year;
    }
}