
using QuestionGroupMicroserviceAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using QuestionGroupMicroserviceAPI.Data;
using QuestionGroupMicroserviceAPI.Repositories.Interfaces;
using QuestionGroupMicroserviceAPI.Repositories;
using JwtAuthenticationManager.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomJwtAuthentication();
builder.Services.AddDbContext<QuestionGroupDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<IQuestionGroupRepository, QuestionGroupRepository>();
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