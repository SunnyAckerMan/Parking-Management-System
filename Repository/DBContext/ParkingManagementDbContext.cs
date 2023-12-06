using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.DBContext;

public class ParkingManagementDbContext : DbContext
{
    public ParkingManagementDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<ParkingSpot> ParkingSpots { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Billing> Billings { get; set; }
    public DbSet<Rate> Rates { get; set; }
}
