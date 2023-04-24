using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.EntityFrameworkCore;

namespace CarRental.Domain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _context;

        public ICarRepository Cars { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IAlternativeDrivingRepository AlternativeDrivers { get; private set; }
        public IUserRepository Users { get; private set; }
        public IDriverRepository Drivers { get; private set; }
        public IRentRepository Rents { get; private set; }

        public UnitOfWork(EFContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Cars = new CarRepository(_context);
            Drivers = new DriverRepository(_context);
            Rents = new RentRepository(_context);
            AlternativeDrivers = new AlternativeDrivingRepository(_context);
            Users = new UserRepository(_context);
        }
      
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
