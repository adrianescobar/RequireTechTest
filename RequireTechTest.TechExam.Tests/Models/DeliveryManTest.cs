using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RequireTechTest.TechExam.Models;
using Xunit;

namespace RequireTechTest.TechExam.Tests.Models
{
    public class DeliveryManTest
    {
        [Fact]
        public void Should_Create_A_DeliveryMan_Successfully()
        {
            /*
                Provide an example of Hierarchy. Implement a base class, and then, at least two, derived classes. 
            */

            string name = "Miguel Villanueva";
            DateTime birthDate = new DateTime(2000, 01, 25);
            int pendingDeliveries = 16;
            //This is a Person derived class
            DeliveryMan deliveryMan = new DeliveryMan(name, birthDate, pendingDeliveries);
            
            Assert.Equal(name, deliveryMan.Name);
            Assert.Equal(birthDate, deliveryMan.BirthDate);
            Assert.Equal(pendingDeliveries, deliveryMan.PendingDeliveries);
        }
    }
}