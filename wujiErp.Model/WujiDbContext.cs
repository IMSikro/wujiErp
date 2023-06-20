using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace wujiErp.Model;

/// <summary>
/// PostgreSQL数据库
/// </summary>
[AppDbContext("WujiPostgreSQLConnString", DbProvider.Npgsql)]
public class NpgsqlDbContext : AppDbContext<NpgsqlDbContext>
{
    public NpgsqlDbContext(DbContextOptions<NpgsqlDbContext> options) : base(options)
    {
        InsertOrUpdateIgnoreNullValues = true;
    }
}

/// <summary>
/// SqlServer数据库
/// </summary>
[AppDbContext("WujiSqlServerConnString", DbProvider.SqlServer)]
public class SqlServerDbContext : AppDbContext<SqlServerDbContext>
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {
        InsertOrUpdateIgnoreNullValues = true;
    }
}

/// <summary>
/// Sqlite数据库
/// </summary>
[AppDbContext("WujiSqliteConnString", DbProvider.SqlServer)]
public class SqliteDbContext : AppDbContext<SqliteDbContext>
{
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
        InsertOrUpdateIgnoreNullValues = true;
    }
}