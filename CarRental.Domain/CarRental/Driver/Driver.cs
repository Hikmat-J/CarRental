using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Shared.CarRental.Driver.Enums;
namespace CarRental.Domain.Entities
{
    public class Driver:BaseEntity
    {
        //working hour
        // FromHour { get; set; }
        // ToHour { get; set; }

        //working Day
        //FromDay {get; set;}
        //ToDay{get;set;}

        public DriverStatus Status { get; set; }
        public User User { get; set; } = null!;

        //public List<Rent>? SubstituteDriving {  get; set; }
        public Car? Car { get; set; }

        public List<Car>? AlternativeCars { get; set; }
        public List<AlternativeDriving>? AlternativeDriving { get; set; }

        // More Driver Details

    }
}
