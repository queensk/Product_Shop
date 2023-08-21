using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Product_Shop.Models;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public string ConnectionString { get; }

    public ProductContext()
    {
        // Read connection string from appsettings.json file
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        ConnectionString = configuration.GetConnectionString("MSSQLDemoDatabase");
    }

    // The following configures EF to use MSSQL as the database provider
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString);
}
