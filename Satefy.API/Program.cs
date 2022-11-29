using Microsoft.EntityFrameworkCore;
using Safety.Domain;
using Safety.Infraestructure;
using Safety.Infraestructure.Context;
using Satefy.API.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGuardianDomain, GuardianDomain>();
builder.Services.AddScoped<IGuardianRepository, GuardianRepository>();
builder.Services.AddScoped<IUrgencyDomain, UrgencyDomain >();
builder.Services.AddScoped<IUrgencyRepository, UrgencyRepository>();

var connectionString = builder.Configuration.GetConnectionString("SafetyConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));//VARIA DEACUERDO A LA VERSION

builder.Services.AddDbContext<SafetyDB>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

builder.Services.AddAutoMapper(
    typeof(ModelToResource),
    typeof(ResourceToModel)
);

var app = builder.Build();

using (var scope= app.Services.CreateScope())
    
using (var context =scope.ServiceProvider.GetService<SafetyDB>())//Validando si exite una BD sino la crea 4
{
    context.Database.EnsureCreated();
}


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