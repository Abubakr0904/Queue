using app.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app.Data;

public class AppDbContext : IdentityDbContext 
{
    public DbSet<Queue> Queues { get; set; }
    public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }
}