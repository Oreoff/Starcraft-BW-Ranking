using System;
using System.Net.Http;
using System.Threading.Tasks;
using StarcraftRating.Controllers;
using Microsoft.EntityFrameworkCore;
using StarcraftRating.data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PlayerContext>(options =>
options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddRazorPages();
var app = builder.Build();
app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<PlayerContext>();
	var seedData = new SeedData(context);
	await seedData.AddPlayersAsync();
}
app.Run();