using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagement
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string MadeBy { get; set; }
        public string VehicleName { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public static List<Vehicle> VehicleList = new List<Vehicle>()
            {
                new Vehicle(){ Id=1, MadeBy = "SUZUKI", Model = "2021", Price = 15.50m, VehicleName ="WAGON-R" },
                new Vehicle(){ Id=2, MadeBy = "SUZUKI", Model = "2021", Price = 16.65m, VehicleName ="CULTAS" },
                new Vehicle(){ Id=3, MadeBy = "SUZUKI", Model = "2018", Price = 17.80m, VehicleName ="WAGON-R" },
                new Vehicle(){ Id=4, MadeBy = "honda", Model = "2019", Price = 23.65m, VehicleName ="CI VIC." },
                new Vehicle(){ Id=5,MadeBy = "SUZUKI XXXXXXXXXXXXXXXX", Model = "2020", Price = 14.35m, VehicleName ="WAGON-R" },
                new Vehicle(){ Id=6,MadeBy = "SUZUKI", Model = "2019", Price = 12.11m, VehicleName ="CIVIC" },
            };
    }
}
