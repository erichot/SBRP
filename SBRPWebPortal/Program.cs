using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SBRPData.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettingsModel>(builder.Configuration.GetSection("AppSettings"));


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SBRPDbContextConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<CommonDbContext>(
               options => options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();




builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



#region "Common Repository & Services"
builder.Services.AddScoped<CompanyContactPersonRepository>();
builder.Services.AddScoped<CompanyContactPersonService>();
builder.Services.AddScoped<CompanyService>();

builder.Services.AddScoped<UserLoginHistoryRepository>();
builder.Services.AddScoped<UserLoginTokenRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserLoginService>();
builder.Services.AddScoped<IdentityService>();
#endregion



builder.Services.AddScoped<UserBindingService>();
builder.Services.AddScoped<UserLoginBindingService>();


builder.Services.AddScoped<WebSystemService>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();





builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.LoginPath = "/SystemLogin";
    });



builder.Services.AddRazorPages()
        .AddRazorRuntimeCompilation();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();

app.Run();
