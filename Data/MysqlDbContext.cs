using Microsoft.EntityFrameworkCore;
using Pedrito.Models;
namespace Pedrito.Data;

public class MysqlDbContext : DbContext
{
    public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
    {
    }

    public DbSet<User> users { get; set; }

}