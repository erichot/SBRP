

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.WebEncoders;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Unicode;


using SBRPDataPsi.Repositories;
using SBRPLogPsi.Repositories;
//using SBRPDataRmshq.Repositories;
//using SBRPDataRmshq.Services;



var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<AppSettingsModel>(builder.Configuration.GetSection("AppSettings"));
//var SSO_WEB_Url_SystemLogin = builder.Configuration["AppSettings:Portal_WEB_RootUrl"] 




var connectionString = builder.Configuration.GetConnectionString("SBRPDbContextConnection") ?? throw new InvalidOperationException("Connection string 'SBRPDbContextConnection' not found.");
//var logConnectionString = builder.Configuration.GetConnectionString("SBRPDbLogContextConnection") ?? throw new InvalidOperationException("Connection string 'SBRPDbContextConnection' not found.");
var rmshqConnectionString = builder.Configuration.GetConnectionString("RmshqConnection") ?? throw new InvalidOperationException("Connection string 'RmshqConnectionConnection' not found.");
var connectionTimeout = int.Parse(builder.Configuration["AppSettings:SqlServerDbCommandTimeout"]);
var PSI_API_RootUrl = builder.Configuration["AppSettings:PSI_API_RootUrl"];

//builder.Services.AddDbContext<SBRPDbContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddAuthentication("Identity.Application").AddCookie();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SBRPDbContext>();
builder.Services.AddDbContext<SBRPData.Models.CommonDbContext>(
               options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<PsiDbContext>(
               options =>
               {
                   options.UseSqlServer(connectionString);                   
                   //  為了解決：An error was generated for warning 'Microsoft.EntityFrameworkCore.Migrations.PendingModelChangesWarning': The model for context 'PsiDbContext' has pending changes. Add a new migration before updating the database. This exception can be suppressed or logged by passing event ID 'RelationalEventId.PendingModelChangesWarning' to the 'ConfigureWarnings' method in 'DbContext.OnConfiguring' or 'AddDbContext'.
                   options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
               }) ;


builder.Services.AddDbContext<SBRPLogPsi.Models.LogDbContext>(
               options =>
               {
                   options.UseSqlServer(
                       builder.Configuration.GetConnectionString("SBRPDbLogContextConnection")
                       );
                   //  為了解決：An error was generated for warning 'Microsoft.EntityFrameworkCore.Migrations.PendingModelChangesWarning': The model for context 'PsiDbContext' has pending changes. Add a new migration before updating the database. This exception can be suppressed or logged by passing event ID 'RelationalEventId.PendingModelChangesWarning' to the 'ConfigureWarnings' method in 'DbContext.OnConfiguring' or 'AddDbContext'.
                   options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
               });


// Register IServiceScopeFactory
//builder.Services.AddSingleton<IServiceScopeFactory>(provider => provider.GetRequiredService<IServiceScopeFactory>());

// 2025/01/03   @value ??_解?ASP.NET Core MVC的Razor??渲染中文??的??
builder.Services.Configure<WebEncoderOptions>(options => options.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All));

builder.Services.AddScoped<ApiRequestService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpClient(name: ClientCallRequestModel.HttpClientName,
              configureClient: options =>
              {
                  options.BaseAddress = new Uri(PSI_API_RootUrl);
                  options.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue(
                           "application/json", 1.0));
              })
               .ConfigurePrimaryHttpMessageHandler(h =>
               {
                   var handler = new HttpClientHandler();

                   handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                   return handler;
               })
               ;


#region "Common Repository & Services"
builder.Services.AddScoped<SBRPData.Repositories.CompanyContactPersonRepository>();
builder.Services.AddScoped<SBRPBusiness.Services.CompanyContactPersonService>();
builder.Services.AddScoped<SBRPBusiness.Services.CompanyService>();

builder.Services.AddScoped<SBRPData.Repositories.PersonRepository>();
builder.Services.AddScoped<SBRPBusiness.Services.PersonService>();

builder.Services.AddScoped<SBRPData.Repositories.PersonContactAddressRepository>();
builder.Services.AddScoped<SBRPBusiness.Services.PersonContactAddressService>();

builder.Services.AddScoped<SBRPData.Repositories.PersonContactPhoneRepository>();
builder.Services.AddScoped<SBRPBusiness.Services.PersonContactPhoneService>();


builder.Services.AddScoped<SBRPData.Repositories.PersonContactEmailRepository>();
builder.Services.AddScoped<SBRPBusiness.Services.PersonContactEmailService>();


builder.Services.AddScoped<SBRPData.Repositories.UserLoginHistoryRepository>();
builder.Services.AddScoped<SBRPData.Repositories.UserLoginTokenRepository>();
builder.Services.AddScoped<SBRPData.Repositories.UserRepository>();

builder.Services.AddScoped<SBRPBusiness.Services.UserService>();
builder.Services.AddScoped<SBRPBusiness.Services.UserLoginService>();
builder.Services.AddScoped<SBRPBusiness.Services.IdentityService>();
#endregion




#region "PSI Repository & Services"
builder.Services.AddScoped<AppUserRepository>();
builder.Services.AddScoped<AppUserService>();
builder.Services.AddScoped<AppUserBindingService>();

builder.Services.AddScoped<AppUserLoginService>();
builder.Services.AddScoped<AppUserLoginBindingService>();

builder.Services.AddScoped<BaseWebPageSIGRepository>();
builder.Services.AddScoped<BaseWebPageService>();

builder.Services.AddScoped<IdentityService>();


builder.Services.AddScoped<InboundStockOrderDetailRepository>();
builder.Services.AddScoped<InboundStockOrderRepository>();
builder.Services.AddScoped<InboundStockOrderService>();
builder.Services.AddScoped<InboundStockOrderBindingService>();



builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<MemberService>();
builder.Services.AddScoped<MemberBindingService>();



builder.Services.AddScoped<MenuitemRepository>();
builder.Services.AddScoped<MenuitemService>();
builder.Services.AddScoped<MenuitemBindingService>();


builder.Services.AddScoped<OperationClassStockRepository>();
builder.Services.AddScoped<OperationClassStockService>();
builder.Services.AddScoped<OperationClassStockBindingService>();



builder.Services.AddScoped<ProductGeneralCategoryDefinitionRepository>();
builder.Services.AddScoped<ProductGeneralCategoryDefinitionService>();
builder.Services.AddScoped<ProductGeneralCategoryDefinitionBindingService>();

builder.Services.AddScoped<ProductGeneralCategoryItemRepository>();
builder.Services.AddScoped<ProductGeneralCategoryItemService>();
builder.Services.AddScoped<ProductGeneralCategoryItemBindingService>();

builder.Services.AddScoped<ProductIdStructureDefinitionRepository>();
builder.Services.AddScoped<ProductIdStructureDefinitionService>();
builder.Services.AddScoped<ProductIdStructureDefinitionBindingService>();

builder.Services.AddScoped<ProductSupplierRepository>();

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductBindingService>();

builder.Services.AddScoped<ProductCostRepository>();
builder.Services.AddScoped<ProductCostDefinitionRepository>();
builder.Services.AddScoped<ProductCostService>();
builder.Services.AddScoped<ProductCostBindingService>();

builder.Services.AddScoped<ProductPriceRepository>();
builder.Services.AddScoped<ProductPriceDefinitionRepository>();
builder.Services.AddScoped<ProductPriceService>();
builder.Services.AddScoped<ProductPriceBindingService>();


builder.Services.AddScoped<ProductStockRepository>();
builder.Services.AddScoped<ProductStockService>();
builder.Services.AddScoped<ProductStockBindingService>();


builder.Services.AddScoped<SaleOrderRepository>();
builder.Services.AddScoped<SaleOrderDetailRepository>();
builder.Services.AddScoped<SaleOrderService>();
builder.Services.AddScoped<SaleOrderBindingService>();


builder.Services.AddScoped<StockRepository>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<StockBindingService>();


builder.Services.AddScoped<StockTransferOrderRepository>();
builder.Services.AddScoped<StockTransferOrderDetailRepository>();
builder.Services.AddScoped<StockTransferOrderService>();
builder.Services.AddScoped<StockTransferOrderBindingService>();


builder.Services.AddScoped<StoreRepository>();
builder.Services.AddScoped<StoreService>();
builder.Services.AddScoped<StoreBindingService>();


builder.Services.AddScoped<SupplierGroupRepository>();
builder.Services.AddScoped<SupplierGroupService>();

builder.Services.AddScoped<SupplierRepository>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<SupplierBindingService>();

builder.Services.AddScoped<WebSystemService>();
#endregion



#region "Rmshq"
builder.Services.AddDbContext<SBRPDataRmshq.Models.RmshqDbContext>(options => options.UseSqlServer(rmshqConnectionString));
builder.Services.AddSingleton<SBRPDataRmshq.Models.RmshqDapperContext>(x => new SBRPDataRmshq.Models.RmshqDapperContext(rmshqConnectionString));
builder.Services.AddSingleton<SBRPDataRmshq.Models.RmshqSqlConnection>(x => new SBRPDataRmshq.Models.RmshqSqlConnection(rmshqConnectionString, connectionTimeout));



builder.Services.AddScoped<SBRPDataRmshq.Repositories.S_SystemCustomerAndStoreRepository>();
builder.Services.AddScoped<SBRPDataRmshq.Repositories.BF_StoreRepository>();
builder.Services.AddScoped<SBRPDataRmshq.Services.StoreService>();
builder.Services.AddScoped<SBRPWebPsi.BindingServices.Rmshq.StoreBindingService>();
builder.Services.AddScoped<SBRPDataRmshq.Services.SaleOrderService>();
#endregion





#region "Log"
builder.Services.AddScoped<InboundStockOrderLogRepository>();
builder.Services.AddScoped<InboundStockOrderDetailLogRepository>();


builder.Services.AddScoped<StockTransferOrderLogRepository>();
builder.Services.AddScoped<StockTransferOrderDetailLogRepository>();
#endregion




// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation()
    .AddJsonOptions(options =>
    {
        //原本是 JsonNamingPolicy.CamelCase，強制頭文字轉小寫，我偏好維持原樣，設為null
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        //允許基本拉丁英文及中日韓文字維持原字元
        options.JsonSerializerOptions.Encoder =
            JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs);
    });


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.LoginPath = "/SystemLoginSso";
    });

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!(app.Environment.IsDevelopment() || app.Environment.IsStaging()))
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
//app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
