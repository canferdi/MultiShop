using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Context;

public class DapperContext : DbContext
{
    private readonly string? _connectionString;

    public DapperContext(DbContextOptions<DapperContext> options, IConfiguration configuration)
        : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public DbSet<Coupon> Coupons { get; set; }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
