var builder = WebApplication.CreateBuilder(args);
builder.Inject();

var app = builder.Build();
app.Run();