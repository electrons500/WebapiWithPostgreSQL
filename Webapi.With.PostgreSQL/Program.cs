using Microsoft.EntityFrameworkCore;
using Webapi.With.PostgreSQL.Models.Data.EmployeeDBContext;
using Webapi.With.PostgreSQL.Models.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeDbContext>(o =>
{
    o.UseNpgsql(builder.Configuration.GetConnectionString("Conn"));
});

builder.Services.AddScoped<EmployeeService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
