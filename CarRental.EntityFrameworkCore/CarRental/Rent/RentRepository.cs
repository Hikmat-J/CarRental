using CarRental.Domain.Entities;
using CarRental.Domain.Repository;

namespace CarRental.EntityFrameworkCore
{
    public class RentRepository : GenericRepository<Rent>, IRentRepository
    {
        public RentRepository(EFContext context) : base(context)
        {
        }
    }
}
