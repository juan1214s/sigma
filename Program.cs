using Microsoft.EntityFrameworkCore;
using technical_test_sigma.Application.Interfaces.Customer;
using technical_test_sigma.Application.Services.CustomerService;
using technical_test_sigma.Infrastructure.Data;
using technical_test_sigma.Infrastructure.Repositories.Customers;
using DotNetEnv;

// Carga las variables desde el archivo .env
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb")));

//Inyeccion de dependencias
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddHttpClient<ICrmService, HubSpotCrmService>();

var hubspotBaseUrl = Environment.GetEnvironmentVariable("HUBSPOT_BASE_URL");
var hubspotToken = Environment.GetEnvironmentVariable("HUBSPOT_ACCESS_TOKEN");

builder.Services.AddControllers();
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
