using CarRental.Domain.Entities;
using CarRental.Domain.Repository;

namespace CarRental.EntityFrameworkCore
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EFContext context) : base(context)
        {
        }
    }
}
