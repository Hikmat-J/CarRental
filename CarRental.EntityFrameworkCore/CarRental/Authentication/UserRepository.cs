using CarRental.Domain.Entities;
using CarRental.Domain.Repository;

namespace CarRental.EntityFrameworkCore
{

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EFContext context) : base(context)
        {
        }
    }
}
