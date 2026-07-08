using DataFrom1C.Application.Interfaces;
using DataFrom1C.Application.Services;
using DataFrom1C.Infrastructure.DataSource.OneC;
using DataFrom1C.Infrastructure.Repositories;
using DataFrom1C.Infrastructure.Repositories.MSSql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataDB"))); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Base1CConfiguration>(builder.Configuration.GetSection(Base1CConfiguration.Section));
builder.Services.AddScoped<ISaveData, MSSqlRepository>();
builder.Services.AddScoped<IGetData, GetData1C>();
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
