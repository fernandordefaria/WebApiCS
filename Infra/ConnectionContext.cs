using Microsoft.EntityFrameworkCore;
using WebApiCS.Domain.Models;

namespace WebApiCS.Infra;

public class ConnectionContext: DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;" +
            "Database=api_csharp;" +
            "User Id=postgres;" +
            "Password=faria;"
        );
}