using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopSystem.Api.Extentions;
using System.Reflection;
using FluentValidation.AspNetCore;
using ShopSystem.Infrastructure;
using ShopSystem.Services.Validations;
using ShopSystem.Services;
using ShopSystem.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<ProductInputValidator>();
    });
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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IRepository<Product,int>), typeof(Repository<Product, int>));
//builder.Services.AddScoped(typeof(IRepository<Order, Guid>), typeof(Repository<Order, Guid>));
builder.Services.AddGenericRepositories();
builder.Services.AddScoped(typeof(IApplicationGenericServices<,,,,,>), typeof(ApplicationGenericServices<,,,,,>));

//builder.Services.AddScoped<ProductService>();
builder.Services.AddAutoServices();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.MapControllers();

app.Run();
