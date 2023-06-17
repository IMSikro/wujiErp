using System.Threading.Tasks;
using System.IO;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Prometheus;

namespace wujiErp.Model
{
    public class Startup : AppStartup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddFreeSqlSetup();

            services.AddCorsAccessor();
            services.AddControllersWithViews()
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
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddInjectWithUnifyResult();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseHttpMetrics();
            app.UseCorsAccessor();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseInject();
            app.UseUnifyResultStatusCodes();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapMetrics("/wujierp/metrics");
                endpoints.MapControllers();
                endpoints.MapFallback(async (context) =>
                {
                    if (context.Request.Path.ToString().ToLower().StartsWith("/erp/wuji"))
                    {
                        var phpath = Path.Join(env.WebRootPath, context.Request.Path);
                        var name = Path.Combine(Path.GetDirectoryName(phpath)!, "index.html");
                        if (File.Exists(name))
                        {
                            context.Response.StatusCode = 200;
                            await context.Response.SendFileAsync(name);
                        }
                    }
                    else
                    {
                        context.Response.Redirect("/Erp/Wuji");
                    }
                });
            });
        }
    }
}
