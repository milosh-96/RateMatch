using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Data.IdentityEntities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.UI.Services;
using RateMatch.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IEmailSender, RateMatch.Mvc.Services.Mailing.EmailSender>();
// Add services to the container.
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// service layer services //
builder.Services.AddScoped<MatchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseExceptionHandler("/Error");

}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseCookiePolicy();
    app.UseStatusCodePages();
}
//app.UseStatusCodePagesWithRedirects("/Error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
app.MapRazorPages();

app.Run();
