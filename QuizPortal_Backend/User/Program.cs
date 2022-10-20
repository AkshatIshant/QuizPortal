using UserMicroserviceAPI.Data;
using UserMicroserviceAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserMicroserviceAPI.Repositories.Interfaces;
using ExamPortal.Services;
using UserMicroserviceAPI.Services;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Extensions;

var builder = WebApplication.CreateBuilder(args);

//var key = "this is the complex string";
//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
//        ValidateIssuer = false,
//        ValidateAudience = false,
//    };
//});


// Add services to the container.
builder.Services.AddDbContext<UserMicroserviceAPIDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCustomJwtAuthentication();
builder.Services.AddSingleton<JwtTokenHandler>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

//var scope = builder.Services.BuildServiceProvider();
//var userRepo = scope.CreateScope().ServiceProvider.GetService<IUserRepository>();
//builder.Services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key, userRepo));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
