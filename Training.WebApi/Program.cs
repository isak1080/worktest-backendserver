using Microsoft.EntityFrameworkCore;

using Training.Data;
using Training.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add database support
builder.Services.AddDbContext<TrainingDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// code to seed data into the database (can be run here, or in a dedicated endpoint)
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<TrainingDbContext>();
//     await TrainingDataSeed.SeedData(db);
// }
app.MapGet("/", () => "Hello World!");
app.MapGet("/seed", async (TrainingDbContext db) =>
{
    await TrainingDataSeed.SeedData(db);
});
app.Run();
