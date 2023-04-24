using CarRental.Domain.Entities;
using CarRental.Domain.Repository;

namespace CarRental.EntityFrameworkCore
{

    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(EFContext context) : base(context)
        { 
        }
    }
}
