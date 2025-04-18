using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using SBRPDataPsi.Repositories;
using SBRPLogPsi.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettingsModel>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<JwtSettingEntity>(builder.Configuration.GetSection("JwtSettings"));


var connectionString = builder.Configuration.GetConnectionString("SBRPDbContextConnection") ?? throw new InvalidOperationException("Connection string 'SBRPDbContextConnection' not found.");
var connectionStringLog = builder.Configuration.GetConnectionString("SBRPDBLOGContextConnection") ?? throw new InvalidOperationException("Connection string 'SBRPDbContextConnection' not found.");
builder.Services.AddDbContext<SBRPData.Models.CommonDbContext>(
               options => options.UseSqlServer(connectionString));


builder.Services.AddDbContext<SBRPLogPsi.Models.LogDbContext>(
               options =>
               {
                   options.UseSqlServer(connectionStringLog);
               });


builder.Services.AddDbContext<PsiDbContext>(
               options =>
               {
                   options.UseSqlServer(connectionString);
                   //  為了解決：An error was generated for warning 'Microsoft.EntityFrameworkCore.Migrations.PendingModelChangesWarning': The model for context 'PsiDbContext' has pending changes. Add a new migration before updating the database. This exception can be suppressed or logged by passing event ID 'RelationalEventId.PendingModelChangesWarning' to the 'ConfigureWarnings' method in 'DbContext.OnConfiguring' or 'AddDbContext'.
                   options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
               });


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


//builder.Services.AddScoped<IdentityService>();

builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var PSI_WEB_RootUrl = builder.Configuration["AppSettings:PSI_WEB_RootUrl"];
// 移除最末端slash，避免WithOrigins參數不成功
if (PSI_WEB_RootUrl.LastIndexOf("/") == PSI_WEB_RootUrl.Length - 1)
    PSI_WEB_RootUrl = PSI_WEB_RootUrl.Substring(0, PSI_WEB_RootUrl.Length - 1);


var WEB_Portal_RootUrl = builder.Configuration["AppSettings:Portal_WEB_RootUrl"];
// 移除最末端slash，避免WithOrigins參數不成功
if (WEB_Portal_RootUrl.LastIndexOf("/") == WEB_Portal_RootUrl.Length - 1)
    WEB_Portal_RootUrl = WEB_Portal_RootUrl.Substring(0, WEB_Portal_RootUrl.Length - 1);



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(PSI_WEB_RootUrl);
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            // Specifying AllowAnyOrigin and AllowCredentials is an insecure m_Configuration and can result in cross-site request forgery
            //builder.AllowCredentials();
        });
});

var issuer = builder.Configuration["JwtSettings:Issuer"];
var audience = builder.Configuration["JwtSettings:Audience"];
var secretKey = builder.Configuration["JwtSettings:SecretKey"];

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidIssuer = issuer,
        ValidAudience = audience,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ClientIpCheckActionFilter>(container =>
{
    var loggerFactory = container.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger<ClientIpCheckActionFilter>();
    var isDevelopment = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") ? true : false;

    return new ClientIpCheckActionFilter(
        builder.Configuration["AdminSafeList"], logger
            , isDevelopment);
});
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        //options.JsonSerializerOptions.MaxDepth = 3;
    });






#region "Common Repository & Services"
builder.Services.AddScoped<SBRPData.Repositories.CompanyContactPersonRepository>();
builder.Services.AddScoped<SBRPBusiness.Services.CompanyContactPersonService>();
builder.Services.AddScoped<SBRPBusiness.Services.CompanyService>();

builder.Services.AddScoped<SBRPData.Repositories.UserLoginHistoryRepository>();
builder.Services.AddScoped<SBRPData.Repositories.UserLoginTokenRepository>();
builder.Services.AddScoped<SBRPData.Repositories.UserRepository>();

builder.Services.AddScoped<SBRPBusiness.Services.UserService>();
builder.Services.AddScoped<SBRPBusiness.Services.UserLoginService>();
builder.Services.AddScoped<SBRPBusiness.Services.IdentityService>();
#endregion





#region "Log"
builder.Services.AddScoped<InboundStockOrderLogRepository>();
builder.Services.AddScoped<InboundStockOrderDetailLogRepository>();

builder.Services.AddScoped<SaleOrderDetailLogRepository>();
builder.Services.AddScoped<SaleOrderLogRepository>();

builder.Services.AddScoped<StockTransferOrderLogRepository>();
builder.Services.AddScoped<StockTransferOrderDetailLogRepository>();
#endregion



#region "PSI Repository & Services"
builder.Services.AddScoped<AppUserRepository>();
builder.Services.AddScoped<AppUserService>();
builder.Services.AddScoped<AppUserBindingService>();

builder.Services.AddScoped<InboundStockOrderRepository>();
builder.Services.AddScoped<InboundStockOrderDetailRepository>();
builder.Services.AddScoped<InboundStockOrderService>();
builder.Services.AddScoped<InboundStockOrderBindingService>();

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductBindingService>();


builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<MemberService>();
builder.Services.AddScoped<MemberBindingService>();

builder.Services.AddScoped<ProductGeneralCategoryDefinitionRepository>();
builder.Services.AddScoped<ProductGeneralCategoryDefinitionService>();
//builder.Services.AddScoped<ProductGeneralCategoryDefinitionBindingService>();


builder.Services.AddScoped<ProductGeneralCategoryItemRepository>();
builder.Services.AddScoped<ProductGeneralCategoryItemService>();
builder.Services.AddScoped<ProductGeneralCategoryItemBindingService>();

builder.Services.AddScoped<IdentityService>();

builder.Services.AddScoped<SaleOrderRepository>();
builder.Services.AddScoped<SaleOrderDetailRepository>();
builder.Services.AddScoped<SaleOrderService>();
builder.Services.AddScoped<SaleOrderBindingService>();

builder.Services.AddScoped<StockTransferOrderRepository>();
builder.Services.AddScoped<StockTransferOrderDetailRepository>();
builder.Services.AddScoped<StockTransferOrderService>();
builder.Services.AddScoped<StockTransferOrderBindingService>();


builder.Services.AddScoped<StockRepository>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<StockBindingService>();


builder.Services.AddScoped<SupplierRepository>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<SupplierBindingService>();
#endregion






// ========================================================
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();




app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();
