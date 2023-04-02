using FlightBookingSystemFolder.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using FlightBookingSystemFolder.Repository;
using AutoMapper;
using FlightBookingSystemFolder.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<flightContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlightConnection"));
}
);
builder.Services.AddScoped<ITokenHandler, FlightBookingSystemFolder.Repository.TokenHandler>();
builder.Services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);
builder.Services.AddTransient(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));
builder.Services.AddSwaggerGen(options =>
{
 var securityScheme = new OpenApiSecurityScheme
 {
 Name = "JWT Authentication",
  Description = "Enter a valid JWT bearer token",
 In = ParameterLocation.Header,
 Type = SecuritySchemeType.Http,
 Scheme = "bearer",
 BearerFormat = "JWT",
 Reference = new OpenApiReference
 {
 Id = JwtBearerDefaults.AuthenticationScheme,
 Type = ReferenceType.SecurityScheme
  }
 };options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
 options.AddSecurityRequirement(new OpenApiSecurityRequirement
{
{securityScheme, new string[] {} }
});
});

builder.Services.AddAuthentication(x=>
{
    x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x=>
{
    x.RequireHttpsMetadata= false;
    x.SaveToken= true;
    x.TokenValidationParameters=new TokenValidationParameters{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey= true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience=builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
    )  
    };
});

/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options =>
Options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey= true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience=builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
    )
});*/
  builder.Services.AddDistributedMemoryCache();
     builder.Services.AddSession(options =>
    {
        options.Cookie.Name = "FlightBookingSystem.Session";
        options.IdleTimeout = TimeSpan.FromSeconds(3600);
    });
builder.Services.AddCors();//(options =>
/*{
    options.AddPolicy("EnableCORS", builder => 
    { 
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod(); 
    });
});*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder=>builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
