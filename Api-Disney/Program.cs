using Api_Disney.Data;
using Api_Disney.Services;
using Api_Disney.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()    // Permitir cualquier origen
              .AllowAnyMethod()    // Permitir cualquier método (GET, POST, etc.)
              .AllowAnyHeader();   // Permitir cualquier encabezado
    });
});
// Add services to the container.

var strConection = builder.Configuration.GetConnectionString("CadenaSql").ToString();

builder.Services.AddDbContext<DbDisneyContext>(options => options.UseSqlServer(strConection));

builder.Services.AddTransient<IGenreServices, GenreServices>();
builder.Services.AddTransient<IMoviesServices, MoviesServices>();
builder.Services.AddTransient<ICharactersServices, CharactersServices>();



builder.Services.AddAuthentication(
    
    JwtBearerDefaults.AuthenticationScheme)
    
    .AddJwtBearer(options =>
{
    //options.RequireHttpsMetadata = false;
    //options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddControllers();


builder.Services.AddScoped<IUsersServices, UsersServices>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Disney", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {

        In= ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name= "Authorization",
        Type= SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
}
);






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirTodo"); 


app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
