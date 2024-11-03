using Consultorio.DataAccess;
using Consultorio.DataAccess.Users;
using Consultorio.Models;
using Consultorio.Repository.Implementation;
using Consultorio.Repository.Interfaces;
using Consultorio.Repository.UnitOfWork.Implementation;
using Consultorio.Repository.UnitOfWork.Interfaces;
using Consultorio.Services;
using Consultorio.Services.Implementation;
using Consultorio.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();


builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.Configure<Appsettings>(builder.Configuration);
builder.Services.AddAutoMapper(config => config.AddProfile<Profiles>());

var connectionString = builder.Configuration.GetConnectionString("ConsultorioSampleDB");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


var connectionstringAuthentication = builder.Configuration.GetConnectionString("AuthenticationConsultorioSampleDB");

builder.Services.AddDbContext<AuthenticationConsultaDbContext>(options =>
{
    options.UseSqlServer(connectionstringAuthentication);
});
// Security

builder.Services.AddIdentity<ConsultorioUser,IdentityRole>(policies =>
{

    // politicas de password
    policies.Password.RequireDigit = false;
    policies.Password.RequireLowercase = false;
    policies.Password.RequireUppercase = true;
    policies.Password.RequireNonAlphanumeric = true;
    policies.Password.RequiredLength = 8;

    policies.User.RequireUniqueEmail = true;

    // politicas de bloqueo
    policies.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    policies.Lockout.MaxFailedAccessAttempts = 5;

    

})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
//Authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ??
        throw new InvalidOperationException("No se configuro el secret Key"));

    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Emisor"],
        ValidAudience = builder.Configuration["Jwt:localhost"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
    };
});

builder.Services.AddScoped<IPractitionerServices, PractitionerServices>();
builder.Services.AddScoped<IPatientServices, PatientServices>();
builder.Services.AddScoped<IConsultaServices, ConsultaServices>();
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IEmailServices, EmailService>(); 

builder.Services.AddScoped<IPractitionerRepository,PractitionerRepository>();
builder.Services.AddScoped<IPatientRepository,PatientRepository>();
builder.Services.AddScoped<IConsultorioRespository,ConsultorioRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();

builder.Services.AddScoped<PractitionerUnitOfWork>();
builder.Services.AddScoped<PatientUnitOfWork>();
builder.Services.AddScoped<ConsultaUnitOfWork>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following : `Bearer Generated-JWT-Token`",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },new string[]{ }
        }
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    await UserDataSeeder.Seed(scope.ServiceProvider);
}

app.Run();
