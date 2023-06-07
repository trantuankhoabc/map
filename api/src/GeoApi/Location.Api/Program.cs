using Location.Api.Extensions;
using Location.Api.Presentation;
using NetTopologySuite;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

/*
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));*/


//cors
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));


builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly)
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(4326);
        options.SerializerSettings.Converters.Add(new GeometryConverter(geometryFactory));
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Logging.ClearProviders(); // default logging configuration var
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

/* extensions get folder
// introduced ioc and dbcontext - it reduces the dependency on DbContext of different classes in the application.
builder.Services.AddDbContext<RepositoryContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("sqlConnection")));*/

var app = builder.Build();


app.UseCors();
app.UseHttpsRedirection();


app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();