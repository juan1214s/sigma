using Microsoft.EntityFrameworkCore;
using technical_test_sigma.Application.Interfaces.Customer;
using technical_test_sigma.Application.Services.CustomerService;
using technical_test_sigma.Infrastructure.Data;
using technical_test_sigma.Infrastructure.Repositories.Customers;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Cargar variables del .env
Env.Load();

// 🔹 Leer variables de entorno
var hubspotBaseUrl = Environment.GetEnvironmentVariable("HUBSPOT_BASE_URL");
var hubspotToken = Environment.GetEnvironmentVariable("HUBSPOT_ACCESS_TOKEN");

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionDb"))
);

// 🔹 Inyección de dependencias
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// 🔹 HttpClient para HubSpot
builder.Services.AddHttpClient<ICrmService, HubSpotCrmService>(client =>
{
    client.BaseAddress = new Uri(hubspotBaseUrl);
    client.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", hubspotToken);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
