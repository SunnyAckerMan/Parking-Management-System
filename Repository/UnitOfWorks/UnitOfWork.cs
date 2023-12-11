using Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.DBContext;
using Repository.Repositories;

namespace Repository.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly ParkingManagementDbContext _context;
    public IBaseRepository<ParkingSpot> ParkingSpots { get; }
    public IBaseRepository<Billing> Billings { get; }
    public IBaseRepository<Rate> Rates { get; }
    public IBaseRepository<Ticket> Tickets { get; }

    public UnitOfWork(ParkingManagementDbContext context,
        IBaseRepository<ParkingSpot> ParkingSpotsRepo,
        IBaseRepository<Billing> BillingsRepo,
        IBaseRepository<Rate> RatesRepo,
        IBaseRepository<Ticket> TicketsRepo)
    {
        _context = context;
        ParkingSpots = ParkingSpotsRepo;
        Billings = BillingsRepo;
        Rates = RatesRepo;
        Tickets = TicketsRepo;
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public async Task<IDbContextTransaction> BeginTranscationAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}
