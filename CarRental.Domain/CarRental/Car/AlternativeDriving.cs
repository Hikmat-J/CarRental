using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class AlternativeDriving :  BaseEntity
    {
        public int DriverId { get; set; }
        public int CarId { get; set; }
        public DateTime FromDate { get; set; } 
        public DateTime ToDate { get; set; }

        public Car Car { get; set; } = new();
        public Driver Driver { get; set; } = new();

        // More Details
    }
}
