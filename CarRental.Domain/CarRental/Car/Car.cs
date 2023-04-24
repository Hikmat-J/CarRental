using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Car : BaseEntity
    {
        public long Number { get; set; }
        public string Type { get; set; } = string.Empty;
        public int EnginCapacity { get; set; }
        public string Color { get; set; } = string.Empty;
        public double DailyFare { get; set; }
        public bool WithDriver { get; set; }
        public int? DriverId { get; set; }
        public Driver? Driver { get; set; }

        public List<Customer> Customers { get; } = new(); 
        public List<Rent> Rents { get; } = new();

        public List<Driver>? AlternativeDrivers { get; set; }
        public List<AlternativeDriving>? AlternativeDrivering { get; set; }

        //public ICollection<Rent> Rents { get; set; }

    }
}
