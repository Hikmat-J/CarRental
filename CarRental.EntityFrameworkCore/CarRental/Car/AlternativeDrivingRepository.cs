using CarRental.Domain.Entities;
using CarRental.Domain.Repository;

namespace CarRental.EntityFrameworkCore
{

    public class AlternativeDrivingRepository : GenericRepository<AlternativeDriving>, IAlternativeDrivingRepository
    {
        public AlternativeDrivingRepository(EFContext context) : base(context)
        {
        }
    }
}
