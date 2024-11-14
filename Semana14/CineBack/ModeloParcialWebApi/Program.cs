using Microsoft.EntityFrameworkCore;
using ModeloParcialWebApi.Models;
using ModeloParcialWebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});


// Add services to the container.
builder.Services.AddDbContext<CineDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));
builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();


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
app.UseCors("CORS");
app.UseAuthorization();

app.MapControllers();

app.Run();
