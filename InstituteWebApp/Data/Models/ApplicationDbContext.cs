using InstituteWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InstituteWebApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<StudentsModels> StudentsRecord { get; set; }
}

