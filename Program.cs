using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventAppEFCore.Data;
using EventAppEFCore.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Next line changes default Index.
builder.Services.AddRazorPages().AddRazorPagesOptions(options => { options.Conventions.AddPageRoute("/Events/Index", ""); });
//builder.Services.AddDbContext<EventAppEFCoreContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("EventAppEFCoreContext") ?? throw new InvalidOperationException("Connection string 'EventAppEFCoreContext' not found.")));
builder.Services.AddDbContext<EventAppEFCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventAppEFCoreContext") ?? throw new InvalidOperationException("Connection string 'EventAppEFCoreContext' not found."),
    sqlServerOptionsAction: sqlOptions => sqlOptions.EnableRetryOnFailure())
);

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
