global using Microsoft.EntityFrameworkCore;
global using Hackathon_MV.Server.Models;
global using Hackathon_MV.Server.DTOS.User;
global using Hackathon_MV.Server.DTOS.Account;
global using Hackathon_MV.Server.DTOS.Transaction;
global using Hackathon_MV.Server.Services.Users;
global using Microsoft.EntityFrameworkCore;
using Hackathon_MV.Server.Data;
using Hackathon_MV.Server.Services.Accounts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountsService, AccountsService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
