using FataakAPI.Models;
using FataakAPI.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FataakDatabaseSettings>(
    builder.Configuration.GetSection(nameof(FataakDatabaseSettings)));

builder.Services.AddSingleton<IFataakDatabaseSettings>(sp =>
          sp.GetRequiredService<IOptions<FataakDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
     new MongoClient(builder.Configuration.GetValue<string>("FataakDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IFataakService, FataakService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
