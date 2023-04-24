using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Dtos
{
    public class UpdateCarDto
    {
        public int Id { get; set; }

        public long Number { get; set; }
        public string Type { get; set; } = string.Empty;
        public int EnginCapacity { get; set; }
        public string Color { get; set; } = string.Empty;
        public double DailyFare { get; set; }
        public bool WithDriver { get; set; }
        public int? DriverId { get; set; }
    }
}
