using QuizAPI.Repositories;
using QuizAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using JwtAuthenticationManager.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomJwtAuthentication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var _Configuration = builder.Configuration;
builder.Services.AddDbContext<QuizPortalDbContext>(options =>
{
    options.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IQuizRepository, QuizRepository>();
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
