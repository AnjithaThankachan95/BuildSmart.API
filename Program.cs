using System;
using BuildSmart.API.Data;
using BuildSmart.API.Services;
using BuildSmart.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
var app = builder.Build();
app.UseCors("AllowLocalhost");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITimesheetService, TimeSheetService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Register DbContext with Azure SQL connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
