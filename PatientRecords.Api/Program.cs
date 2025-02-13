using Microsoft.EntityFrameworkCore;
using PatientRecords.AppService.Interfaces;
using PatientRecords.AppService.Services;
using PatientRecords.Core.Interfaces;
using PatientRecords.Repo;
using PatientRecords.Repo.SQLite;
using System;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPatientService, PatientAppService>();
builder.Services.AddScoped<IPatientDbRepo, SQLiteDBRepo>();
builder.Services.AddDbContext<SQLiteDbContext>(opt => opt.UseSqlite("Data Source=patients.db"));


var app = builder.Build();
// Run Migrations Automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SQLiteDbContext>();
    dbContext.Database.Migrate(); // Apply Migrations
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
