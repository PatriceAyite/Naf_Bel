using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Naf_Bel.DATA.Repositories;
using Naf_Bel.SERVICE.Implematations;
using nafibel.DATA.Helpers;
using nafibel.DATA.Models.Identity;
using nafibel.SERVICE.Interfaces;
using Nafibel.Services.Implematations;
using Nafibel.Services.Implementations;
using Nafibel.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// =========================
// 1. JWT Configuration
// =========================
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
// =========================
// 2. Identity Configuration
// =========================
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// =========================
// 3. JWT Authentication
// =========================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false; // Set to true in production for secure communications
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

// =========================
// 4. Database Configuration
// =========================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Could not find a connection string named 'DefaultConnection'.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// =========================
// 5. Dependency Injection
// =========================
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IHairStyleService, HairStyleService>();
builder.Services.AddScoped<IHairDresserService, HairDresserService>();
builder.Services.AddScoped<IHairStylepPriceService, HairStylePriceService>();
builder.Services.AddScoped<IHairStyleNameLocaleService, HairStyleNameLocaleService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IHaircutService, HaircutService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// =========================
// 6. Health Checks
// =========================
builder.Services.AddHealthChecks().AddSqlServer(connectionString);

// =========================
// 7. CORS Configuration
// =========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Replace with actual client URL in production
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// =========================
// 8. Controllers and Swagger
// =========================
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =========================
// Application Pipeline Configuration
// =========================
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.UseCors("AllowAngularApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
