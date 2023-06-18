using Furion;
using Furion.DatabaseAccessor;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace wujiErp.Model;

[AppStartup(100)]
public sealed class WujiStartup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true)
                .AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);
        // 配置数据库上下文，支持N个数据库
        services.AddDatabaseAccessor(options =>
        {
            // 配置默认数据库
            options.AddDbPool<WujiDbContext>(DbProvider.SqlServer);

            // 配置多个数据库，多个数据库必须指定数据库上下文定位器
            //  options.AddDbPool<SqliteDbContext, SqliteDbContextLocaotr>();
        }, "wujiErp.Model");
    }
}