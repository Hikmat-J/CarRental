using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Rent : BaseEntity
    {
        public Customer Customer { get; set; } = null!;

        public int CustomerId { get; set; }
        public Car Car { get; set; } = null!;
        public int CarId { get; set; }

        public DateTime Date { get; set; }

        //public bool WithSubstituteDriver { get; set; }

        //public int SubstituteDriverId { get; set; }

        //public Driver? SubstititeDriver { get; set; }



    }
}
