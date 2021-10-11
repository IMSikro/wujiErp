using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace wujiErp.Model.DBContext
{
	[AppDbContext("WujiSqliteConnString", DbProvider.Sqlite)]
	public class WujiContext : AppDbContext<WujiContext>
	{
		public WujiContext(DbContextOptions<WujiContext> options) : base(options) { }
	}
}