namespace RequireTechTest.TechExam.Models
{
    public class DeliveryMan : Person
    {
        public DeliveryMan(string name, DateTime birthDate, int pendingDeliveries) : base(name, birthDate)
        {
            PendingDeliveries = pendingDeliveries;
        }

        public int PendingDeliveries { get; set; }
    }
}