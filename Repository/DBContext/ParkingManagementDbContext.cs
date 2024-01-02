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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure ParkingSpot <-> Ticket one-to-one relationship
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.ParkingSpot)
            .WithOne()
            .HasForeignKey<Ticket>(t => t.ParkingSpotIdFk)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Ticket <-> Rate one-to-one relationship
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Rate)
            .WithOne()
            .HasForeignKey<Ticket>(t => t.RateIdFk)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Ticket <-> Billing one-to-one relationship
        modelBuilder.Entity<Billing>()
            .HasOne(b => b.Ticket)
            .WithOne()
            .HasForeignKey<Billing>(b => b.TicketIdFk)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure ParkingSpot <-> Rate one-to-one relationship
        modelBuilder.Entity<Rate>()
            .HasOne(r => r.ParkingSpot)
            .WithOne()
            .HasForeignKey<Rate>(r => r.ParkingSpotIdFk)
            .OnDelete(DeleteBehavior.Restrict);

    }

}
