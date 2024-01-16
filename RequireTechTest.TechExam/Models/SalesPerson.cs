namespace RequireTechTest.TechExam.Models
{
    public class SalesPerson : Person
    {
        public SalesPerson(string name, DateTime birthDate, decimal totalSalesAmount) : base(name, birthDate)
        {
            TotalSalesAmount = totalSalesAmount;
        }

        public decimal TotalSalesAmount { get; set; }
    }
}