using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args).Inject();

builder.Services.AddControllers().AddInject();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseInject();

app.MapControllers();

app.Run();