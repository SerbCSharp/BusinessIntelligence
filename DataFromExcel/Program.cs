using DataFromExcel.Application.Interfaces;
using DataFromExcel.Application.Services;
using DataFromExcel.Infrastructure.DataSource.Excel;
using DataFromExcel.Infrastructure.Repositories.MSSql;
using DataFromExcel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ObjectOfSaleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataDB")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.Configure<FilePathConfiguration>(builder.Configuration.GetSection(FilePathConfiguration.Section));
builder.Services.AddScoped<ISaveData, MSSqlRepository>();
builder.Services.AddScoped<IGetData, GetDataExcel>();
builder.Services.AddScoped<UpdateDataService>();
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
