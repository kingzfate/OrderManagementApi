using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderManagementApi.Settings;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));
builder.Services.AddScoped<IPostamatRepository, PostamatRepository>();
builder.Services.AddControllers();

ConfigureDataBase();
ConfigureMapper();

/// <summary>
/// Configuration database
/// </summary>
void ConfigureDataBase()
{
    builder.Services.AddDbContext<MainContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")));
}

/// <summary>
/// Configuration automapper
/// </summary>
/// <param name="services">Specifies the contract for a collection of service descriptors.</param>
void ConfigureMapper()
{
    MapperConfiguration config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new AutoMapperProfile());
    });
    IMapper mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
            });
});

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "API";
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
