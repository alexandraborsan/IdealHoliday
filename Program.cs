using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IdealHoliday.Data;
using Microsoft.AspNetCore.Identity;
using IdealHoliday;
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Holidays");
    options.Conventions.AllowAnonymousToPage("/Holidays/Index");
    options.Conventions.AllowAnonymousToPage("/Holidays/Details");
    options.Conventions.AuthorizeFolder("/Customers", "AdminPolicy");



});

builder.Services.AddDbContext<IdealHolidayContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdealHolidayContext") ?? throw new InvalidOperationException("Connection string 'IdealHolidayContext' not found.")));

builder.Services.AddDbContext<AgencyIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdealHolidayContext") ?? throw new InvalidOperationException("Connection string 'IdealHolidayContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AgencyIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
