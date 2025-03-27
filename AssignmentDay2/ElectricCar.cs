using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDay2
{
    public class ElectricCar : Car, IChargable
    {
        public void Charge(DateTime timeOfCharge)
        {
            Console.WriteLine($"ElectricCar {Make} {Model} recharged on {timeOfCharge:yyyy-MM-dd HH:mm}");
        }
    }
}