using Consultorio.DataAccess;
using Consultorio.Repository.Implementation;
using Consultorio.Repository.Interfaces;
using Consultorio.Repository.UnitOfWork.Implementation;
using Consultorio.Repository.UnitOfWork.Interfaces;
using Consultorio.Services;
using Consultorio.Services.Implementation;
using Consultorio.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddAutoMapper(config => config.AddProfile<Profiles>());

var connectionString = builder.Configuration.GetConnectionString("ConsultorioSampleDB");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.AddScoped<IPractitionerServices, PractitionerServices>();
builder.Services.AddScoped<IPatientServices, PatientServices>();

builder.Services.AddScoped<IPractitionerRepository,PractitionerRepository>();
builder.Services.AddScoped<IPatientRepository,PatientRepository>();

builder.Services.AddScoped<PractitionerUnitOfWork>();
builder.Services.AddScoped<PatientUnitOfWork>();

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
