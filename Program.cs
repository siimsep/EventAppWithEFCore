using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventAppEFCore.Data;
using EventAppEFCore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EventAppEFCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventAppEFCoreContext") ?? throw new InvalidOperationException("Connection string 'EventAppEFCoreContext' not found.")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
