using Microsoft.Data.SqlClient;
using ProcurementPriceDynamics.Application.Interfaces;
using ProcurementPriceDynamics.Application.Services;
using ProcurementPriceDynamics.Infrastructure.Repositories.MSSql;
using ProcurementPriceDynamics.Presentation.ReportsToExcel;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<IDbConnection>((provider) => new SqlConnection(builder.Configuration.GetConnectionString("DataDB"))); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGetData, MSSqlRepository>();
builder.Services.AddScoped<ProcurementPriceDynamicsService>();
builder.Services.AddScoped<ExportingReportsToExcel>();
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
