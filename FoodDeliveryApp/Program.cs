using FoodDeliveryApp.Models;
using FoodDeliveryApp.Repository;
using FoodDeliveryApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDBContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("Default");
    options.UseMySql(connString, ServerVersion.AutoDetect(connString));
});

builder.Services.AddTransient<IFoodRepository, FoodRepository>();

builder.Services.AddTransient<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
