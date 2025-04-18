using Microsoft.EntityFrameworkCore.SqlServer;
using AutoMapper;
//using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;


using System.Text.Json.Serialization;
using SBRPBusinessTms.Services.KATES;
using SBRPAPITms.BindingServices.KATES;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<AppSettingsModel>(
    builder.Configuration.GetSection("AppSettings"));


var katesConnectionString = builder.Configuration.GetConnectionString("KatesConnection");

// ========================================================================
// Add services to the container.
builder.Services.AddDbContext<KatesDbContext>(options =>
    options.UseSqlServer(katesConnectionString
        , providerOptions =>
        {
            providerOptions.CommandTimeout(30);
        })
    );

builder.Services.AddScoped<S_ControllerRepository>();
builder.Services.AddScoped<S_SystemSettingRepository>();
builder.Services.AddScoped<SystemSettingService>();
builder.Services.AddScoped<SystemSettingBindingService>();



builder.Services.AddScoped<ApiSystemService>();
builder.Services.AddScoped<ExcelBookService>();
builder.Services.AddScoped<FileManagementService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





builder.Services.AddScoped<CF_UserImportHeadRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserBindingService>();

builder.Services.AddScoped<OR_TransactionRepository>();
builder.Services.AddScoped<CF_TransactionImportHeadRepository>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<TransactionBindingService>();



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            //builder.WithOrigins(WEB_RootUrl);
            //builder.WithOrigins("http://10.118.4.60;");
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            // Specifying AllowAnyOrigin and AllowCredentials is an insecure m_Configuration and can result in cross-site request forgery

            // System.InvalidOperationException: The CORS protocol does not allow specifying a wildcard (any) origin and credentials at the same time. Configure the CORS policy by listing individual origins if credentials needs to be supported.
            //  removed AllowCredentials() that fixed the issue for me.
            //builder.AllowCredentials();
        });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews()
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                  options.JsonSerializerOptions.PropertyNamingPolicy = null;
                  //options.JsonSerializerOptions.MaxDepth = 3;
              });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v0.3",
        Title = "",
        Description = "",
        //TermsOfService = new Uri("https://igouist.github.io/"),
        //Contact = new OpenApiContact
        //{
        //    Name = "",
        //    Email = string.Empty,
        //    Url = new Uri("https://igouist.github.io/about/"),
        //},
        //License = new OpenApiLicense
        //{
        //    Name = "",
        //    Url = new Uri("https://igouist.github.io/about/"),
        //}
    });


    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});



// ======================================================================================
var app = builder.Build();




if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    // UseSwaggerUI is called only in Development.
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //options.RoutePrefix = string.Empty;
    });
}


app.UseCors();
app.MapControllers();
// Configure the HTTP request pipeline.

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
