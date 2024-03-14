using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.DataSerivce.Data;

public class AppDbContext : DbContext
{
  public virtual DbSet<Driver> Drivers { get; set; }
  public virtual DbSet<Achievement> Achievements { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    
    modelBuilder.Entity<Achievement>()
      .HasOne(x => x.Driver)
      .WithMany(x => x.Achievements)
      .HasForeignKey(x => x.DriverId)
      .OnDelete(DeleteBehavior.NoAction)
      .HasConstraintName("FK_Driver_Achievement");
    
    modelBuilder.Entity<Driver>()
      .HasMany(x => x.Achievements)
      .WithOne(x => x.Driver)
      .HasForeignKey(x => x.DriverId)
      .OnDelete(DeleteBehavior.NoAction)
      .HasConstraintName("FK_Achievement_Driver");
  }
}