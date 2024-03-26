using System.Globalization;
using AutoRecon.Application;
using AutoRecon.Domain.Entities;
using AutoRecon.Infrastructure;
using AutoRecon.Infrastructure.Auth;
using AutoRecon.Infrastructure.Data.Context;
using Fido2NetLib;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("AutoReconDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AutoReconDbContextConnection' not found.");

// builder.Services.AddDbContext<AutoReconDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AutoReconDbContext>().AddTokenProvider<Fido2UserTwoFactorTokenProvider>("FIDO2");

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.Secure = CookieSecurePolicy.Always;
    options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
    //options.OnAppendCookie = cookieContext =>
    //    CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
    //options.OnDeleteCookie = cookieContext =>
    //    CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
});

// Add services to the container.
builder.Services.AddRazorPages()
    .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization().AddRazorPagesOptions(opts =>
    {
        opts.Conventions.AddPageRoute("/Dashboard", "/");
        opts.Conventions.AddPageRoute("/Dashboard", "home");
        opts.Conventions.AddPageRoute("/Dashboard", "index");
        opts.Conventions.AddAreaPageRoute("Account", "/Login", "/Account/Login");
    });

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

builder.Services.Configure<Fido2Configuration>(builder.Configuration.GetSection("fido2"));
builder.Services.AddScoped<Fido2Store>();

var parseTimeout = int.TryParse(Environment.GetEnvironmentVariable("COOKIE_CACHE_TIMEOUT"), out var timeout);
if (!parseTimeout) timeout = 10;
;
// Adds a default in-memory implementation of IDistributedCache.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(timeout);
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
// Add services from other layers
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("de-DE"),
        new CultureInfo("en-US")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US", "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAuthenticatedUser", policy => { policy.RequireAuthenticatedUser(); });

    options.AddPolicy("RequireScanLogAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        // Add additional requirements as needed, e.g., role-based or claims-based authorization
    });
});


builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<AutoReconDbContext>().AddApiEndpoints();
builder.Services.AddSingleton(TimeProvider.System);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapIdentityApi<User>();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapRazorPages();

//     endpoints.MapControllerRoute(
//         name: "scan-log",
//         pattern: "scans/{id}/log",
//         defaults: new { controller = "Scan", action = "GetScanLog" }
//     ).RequireAuthorization("RequireScanLogAccess");

//     // Add other endpoint mappings here
// });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();