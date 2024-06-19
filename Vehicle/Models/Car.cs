using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChassisNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public string Manufacturer { get; set; }
    }
}
