using System.Reflection;
using System.Text;
using ClientManagerAPIV001.DataAccess;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ClientManagerAPIV001.Services;
using ClientManagerAPIV001.Repositories;
using ClientManagerAPIV001.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        }
    );
    option.AddSecurityRequirement(
        new OpenApiSecurityRequirement
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
                new string[] { }
            }
        }
    );
});

builder.Services.AddDbContext<SQLDBContext>();
builder.Services.AddAutoMapper(Assembly.Load("ClientManagerAPIV001.Dtos"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthanticationService, AuthanticationService>();
builder.Services.AddSwaggerGen();

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
string jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>() ?? string.Empty;
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
Console.WriteLine($"Key In Validation : {key}");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = false,
         ValidateAudience = false,
         ValidateLifetime = false,
         ValidateIssuerSigningKey = false,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = key
     };

     options.Events = new JwtBearerEvents
     {
         OnAuthenticationFailed = context =>
         {
             Console.WriteLine($"Authentication failed: {context.Exception.Message}");
             Console.WriteLine($"Key In Validation : {key}");
             return Task.CompletedTask;
         },
         OnChallenge = context =>
         {
             Console.WriteLine($"Challenge issued: {context.ErrorDescription}");
             return Task.CompletedTask;
         }
     };
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
