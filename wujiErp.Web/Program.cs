// using System.Reflection;
// using wujiErp.Model;

var builder = WebApplication.CreateBuilder(args);
// builder.AddFreeSqlSetup(typeof(Program).Assembly)
builder.Inject();
var app = builder.Build();
app.Run();