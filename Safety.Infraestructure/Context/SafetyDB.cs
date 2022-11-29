using Microsoft.EntityFrameworkCore;
using Safety.Infraestructure.Models;

namespace Safety.Infraestructure.Context;

public class SafetyDB : DbContext
{
    public DbSet<Guardian> Guardians { get; set; }
    
    public DbSet<Urgency> Urgencies { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) //Aqui valido otra vez si mi BD esta configurado, sino lo vuelvo a configurar 5 Y HACEMOS LA MIGRACION 6 NUGET:Entity framework core tools
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=safetydb; ",serverVersion);
        }
    }
    public SafetyDB() : base() //Entity Framework me dice que debo tener constructores
    {
      
    }
    public SafetyDB(DbContextOptions<SafetyDB> options) : base(options) //Entity Framework me dice que debo tener constructores
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Guardian>().ToTable("Guardians");
        builder.Entity<Guardian>().HasKey(p => p.id);
        builder.Entity<Guardian>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Guardian>().Property(p => p.username).IsRequired().HasMaxLength(30);
        builder.Entity<Guardian>().Property(p => p.email).IsRequired().HasMaxLength(30);
        builder.Entity<Guardian>().Property(p => p.firstName).HasMaxLength(60);
        builder.Entity<Guardian>().Property(p => p.lastName).HasMaxLength(60);
        builder.Entity<Guardian>().Property(p => p.gender).IsRequired();
        builder.Entity<Guardian>().Property(p => p.address);
        builder.Entity<Guardian>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Guardian>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Urgency>().ToTable("Urgencies");
        builder.Entity<Urgency>().HasKey(p => p.id);
        builder.Entity<Urgency>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Urgency>().Property(p => p.title).IsRequired();
        builder.Entity<Urgency>().Property(p => p.summary);
        builder.Entity<Urgency>().Property(p => p.latitude).IsRequired();                                                          
        builder.Entity<Urgency>().Property(p => p.longitude).IsRequired();
        builder.Entity<Urgency>().Property(p => p.reportedAt).HasDefaultValue(DateTime.Now);
        builder.Entity<Urgency>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Urgency>().Property(p => p.IsActive).HasDefaultValue(true);

    }

}