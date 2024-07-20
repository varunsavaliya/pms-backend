using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PMS.Model.Context;
using PMS.Repository.Implementation;
using PMS.Repository.Interface;
using PMS.Service.Implementation;
using PMS.Service.Interface;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllOrigins",
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddControllers();

// Add database context
builder.Services.AddDbContext<PMSDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlanRepository, PlanRepository>();

builder.Services.AddScoped<IPlanService, PlanService>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Register Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Response Formatting
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new CamelCaseNamingStrategy()
    };
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});

WebApplication app = builder.Build();

app.UseCors("AllowAllOrigins");

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
