namespace CarRental.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }
        IAlternativeDrivingRepository AlternativeDrivers { get; }
        IUserRepository Users { get; }
        ICustomerRepository Customers { get; }
        IDriverRepository Drivers { get; }
        IRentRepository Rents { get; }
        int Complete();
    }
}
