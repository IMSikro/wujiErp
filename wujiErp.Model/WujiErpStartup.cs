using System.IO;
using Furion;
using Furion.DatabaseAccessor;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace wujiErp.Model;

[AppStartup(100)]
public sealed class WujiStartup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCorsAccessor();

        services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // 该配置应用于 Swagger 文档生成
                    // Swagger 文档内部默认使用System.Text.Json
                    // 所以加了这段配置
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddInjectWithUnifyResult();

        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true).AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);

        // 配置数据库上下文，支持N个数据库
        services.AddDatabaseAccessor(options =>
        {
            // 配置默认数据库
            options.AddDbPool<NpgsqlDbContext>();

            // 配置多个数据库，多个数据库必须指定数据库上下文定位器
            //  options.AddDbPool<SqliteDbContext, SqliteDbContextLocaotr>();
        }, "wujiErp.ModelMigragions");


    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseInject();
        app.UseUnifyResultStatusCodes();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallback(async (context) =>
                {
                    var phpath = Path.Join(env.WebRootPath, context.Request.Path);
                    var name = Path.Combine(Path.GetDirectoryName(phpath)!, "index.html");
                    if (File.Exists(name))
                    {
                        context.Response.StatusCode = 200;
                        await context.Response.SendFileAsync(name);
                    }
                });
        });
    }
}