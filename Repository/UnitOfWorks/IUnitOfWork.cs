using Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Repositories;

namespace Repository.UnitOfWorks;

public interface IUnitOfWork
{
    IBaseRepository<ParkingSpot> ParkingSpots { get; }
    IBaseRepository<Billing> Billings { get; }
    IBaseRepository<Rate> Rates { get; }
    IBaseRepository<Ticket> Tickets { get; }
    Task<int> SaveChangesAsync();
    Task<IDbContextTransaction> BeginTranscationAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
