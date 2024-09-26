using FitFlexApp.BLL.Services.Interface;
using FitFlexApp.BLL.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using FitFlexApp.DAL.Repository.Interface;
using FitFlexApp.DAL.Repository;
using FitFlexApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/info.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "UsersAppAPI", Version = "v1" });
    /*options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authentication",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });*/
});
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

/* Automapper persistance */
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/* Token authentication */
/*builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });*/

/* Services persistance */
builder.Services.AddScoped<IUserService, UserService>();
/*builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();*/

/* Repository persistance */
builder.Services.AddScoped<IUserRepository, UserRepository>();

/* EF persistence on azsql */
builder.Services.AddDbContext<FitFlexAppContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZ_FitFlexDB"));
    options.EnableSensitiveDataLogging();
});

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// Catch any exception
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(end =>
{
    end.MapControllers();
});

app.Run();