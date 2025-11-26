using Microsoft.EntityFrameworkCore;
using ShopSystem.infrastructure.AppDbContext;
using ShopSystem.infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShopSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    , options => options.EnableRetryOnFailure(
        maxRetryCount: 5, // Example: Number of retries
        maxRetryDelay: TimeSpan.FromSeconds(10), // Example: Delay between retries
        errorNumbersToAdd: null // Example: Additional error numbers to retry on
    )));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
