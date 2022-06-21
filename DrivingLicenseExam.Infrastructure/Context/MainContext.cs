using DrivingLicenseExam.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrivingLicenseExam.Infrastructure.Context;

public class MainContext : DbContext
{
    public DbSet<Image> Image { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Answer> Answer { get; set; }

    public MainContext()
    {
    }

    public MainContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.DrivingLicenseExam.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>()
            .HasOne(x => x.Image)
            .WithOne(x => x.Question)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Question>()
            .HasMany(x => x.Answers)
            .WithOne(x => x.Question)
            .OnDelete(DeleteBehavior.Cascade);
    }
}