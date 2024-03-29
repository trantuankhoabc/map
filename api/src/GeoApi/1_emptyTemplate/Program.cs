var builder = WebApplication.CreateBuilder(args);


// Service (Container)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

if (app.Environment.IsDevelopment()) // use swagger if in development mode, otherwise don't use
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();