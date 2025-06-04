using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DatabaseContext : DbContext
{
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<MyProgram> Programs { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>()
        {
            new AvailableProgram(){Price = 100.99m,ProgramId = 1,WashingMachineId = 1,AvailableProgramId = 1},
            new AvailableProgram(){Price = 120.99m,ProgramId = 2,WashingMachineId = 1,AvailableProgramId = 2},
        });
        
        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer(){CustomerId = 1,FirstName = "John",LastName = "Doe",PhoneNumber = "999999999"},
            new Customer(){CustomerId = 2,FirstName = "Jane",LastName = "Doe",PhoneNumber = "999999999"},
        });
        modelBuilder.Entity<MyProgram>().HasData(new List<MyProgram>()
        {
            new MyProgram() { DurationMinutes = 2, Name = "Program1", ProgramId = 1, TemperatureCelsius = 12 },
            new MyProgram() { DurationMinutes = 10, Name = "Program2", ProgramId = 2, TemperatureCelsius = 12 },
        });
        modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>()
        {
            new PurchaseHistory(){AvailableProgramId = 1,CustomerId = 1,PurchaseDate = DateTime.Parse("2025-05-04"),Rating = 12},
            new PurchaseHistory(){AvailableProgramId = 2,CustomerId =2, PurchaseDate = DateTime.Parse("2024-05-04"),Rating = 10}
        });
        modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>()
        {
            new WashingMachine(){WashingMachineId = 1,MaxWeight = 50.5m,SerialNumber = "12345678"},
            new WashingMachine(){WashingMachineId = 2,MaxWeight = 10.5m,SerialNumber = "987654321"}
        });


    }
}