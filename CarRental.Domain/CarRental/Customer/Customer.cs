using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public User User { get; set; } = null!;
        public List<Car> Cars { get; } = new();
        public List<Rent> RentCars { get; } = new();


        //public ICollection<Rent> Rents { get; set; }

        // More Customer Details

    }
}
