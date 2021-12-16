using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace wujiErp.Model.DBContext
{
	//[AppDbContext("WujiSqliteConnString", DbProvider.Sqlite)]
	[AppDbContext("WujiSqlServerConnString", DbProvider.SqlServer)]
	//[AppDbContext("WujiMysqlConnString", DbProvider.MySql)]
	public class WujiContext : AppDbContext<WujiContext>
	{
		public WujiContext(DbContextOptions<WujiContext> options) : base(options)
		{
			InsertOrUpdateIgnoreNullValues = true;
		}
	}
}