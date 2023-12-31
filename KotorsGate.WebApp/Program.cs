using KotorsGate.Infrastructure;
using KotorsGate.WebApp;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddWebAppServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Do CORS for now
    app.UseCors(options => {
        var origin = builder.Configuration.GetValue<string>("TestingOrigin");

        if (origin != null)
            options.WithOrigins(origin).AllowAnyHeader().AllowAnyMethod();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
