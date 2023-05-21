using Serilog;
using NewUpstorm.Web.Helpers;
using NewUpstorm.Web.Extensions;
using NewUpstorm.Data.DbContexts;
using NewUpstorm.Service.Mappers;
using NewUpstorm.Web.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

// adding configuration db path
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
// add custom services
builder.Services.AddCustomServices();
// Add services to the container.
builder.Services.AddControllers();
// set up swagger 
builder.Services.AddSwaggerService();
// JWT servies
builder.Services.AddJwtService(builder.Configuration);
// Logger
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// convert api url name to dash case
builder.Services.AddControllers(options => options.Conventions
    .Add(new RouteTokenTransformerConvention(new RouteConfiguration())));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
