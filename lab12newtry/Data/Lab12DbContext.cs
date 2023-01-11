using lab12newtry.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace lab12newtry.Data;

public class Lab12DbContext : DbContext
{
    public Lab12DbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Pation> Pations { get; set; }
    public DbSet<Doctor> Doctors{ get; set; }
    public DbSet<Nurse> Nurses { get; set; }
}