var builder = WebApplication.CreateBuilder(args).Inject();

var app = builder.Build();

app.MapControllers();
app.Run();