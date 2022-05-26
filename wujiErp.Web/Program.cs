using System.Reflection;
using wujiErp.Model;

var builder = WebApplication.CreateBuilder(args)
            .AddFreeSqlSetup(typeof(Program).Assembly)
            .Inject();
var app = builder.Build();
app.Run();