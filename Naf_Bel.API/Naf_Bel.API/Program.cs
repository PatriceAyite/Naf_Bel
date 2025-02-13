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

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
// for identity tables and ApplicationUser table
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IAuthService, AuthService>();


var conStr = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(conStr))
{
    throw new InvalidOperationException(
                       "Could not find a connection string named 'DefaultConnection'.");
}
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            //ClockSkew = TimeSpan.Zero
        };
    });

// Add services to the container.
builder.Services.AddScoped<IHairStyleService, HairStyleService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
     options.UseSqlServer(conStr));


builder.Services.AddScoped<IHairDresserService, HairDresserService>();



builder.Services.AddScoped<IHairStylepPriceService, HairStylePriceService>();


builder.Services.AddScoped<IHairStyleNameLocaleService, HairStyleNameLocaleService>();

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IHaircutService, HaircutService>();

builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddHealthChecks().AddSqlServer(conStr); ;




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
app.MapHealthChecks("/health");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
