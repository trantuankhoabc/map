using Geo.Api.Business.Abstract;
using Geo.Api.Business.Concrete;
using Geo.Api.Entities.Entities;
using Geo.Api.Repositories.Abstract;
using Geo.Api.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.IO.Converters;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;
var isDevelopment = builder.Environment.IsDevelopment();

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env}.json", true);

var connectionString = builder.Configuration.GetConnectionString("City");

// Add services to the container.


builder.Services.AddControllers();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = new LowerCaseNamingPolicy();
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.Converters.Add(
        new GeoJsonConverterFactory()); //Makes actions can accept geojson objects as paramater
});
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<CityDbContext>(options =>
// {
//     options.UseNpgsql(
//             builder.Configuration.GetConnectionString("City"),
//             x => x.UseNetTopologySuite()
//         )
//         .UseLowerCaseNamingConvention();
// });

builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.Run();