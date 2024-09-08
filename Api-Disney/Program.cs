using Api_Disney.Data;
using Api_Disney.Services;
using Api_Disney.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var strConection = builder.Configuration.GetConnectionString("CadenaSql").ToString();

builder.Services.AddDbContext<DbDisneyContext>(options => options.UseSqlServer(strConection));

builder.Services.AddTransient<IGenreServices, GenreServices>();
builder.Services.AddTransient<IMoviesServices, MoviesServices>();
builder.Services.AddTransient<ICharactersServices, CharactersServices>();



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
