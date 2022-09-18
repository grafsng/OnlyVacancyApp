using Microsoft.EntityFrameworkCore;
using OnlyVacancyApp.DAL;
using OnlyVacancyApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddTransient<IImportService, ImportService>();
builder.Services.AddTransient<IDepCountService, DepCountService>();
builder.Services.AddTransient<IOperationService, OperationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
