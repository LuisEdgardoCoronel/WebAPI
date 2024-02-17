using WebAPI.Middleware;
using WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyeccion de dependencias:
//builder.Services.AddScoped<IFirstService, FirstService>();
//inyectando la clase:
//builder.Services.AddScoped<IFirstService>(p=> new FirstService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors();

app.UseAuthorization();

//app.UseWelcomePage();

app.UseTimeMiddleware();

app.MapControllers();

app.Run();
