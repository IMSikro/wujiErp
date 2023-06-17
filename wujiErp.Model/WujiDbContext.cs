using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace wujiErp.Model;

[AppDbContext("WujiSqlServerConnString", DbProvider.SqlServer)]
public class WujiDbContext : AppDbContext<WujiDbContext>
{
    public WujiDbContext(DbContextOptions<WujiDbContext> options) : base(options)
    {
    }
}