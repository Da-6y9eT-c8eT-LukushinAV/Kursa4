using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



// ���������� Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizePage("/Booking"); // ������: ������ � �������� ������������ ������ ��� �������������� �������������
        options.Conventions.AllowAnonymousToPage("/Register"); // ��������� ������ � �������� ������ ��� ���� �������������
    });

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Login";  // ���� ��� �������� ������
//    options.LogoutPath = "/Logout";  // ���� ��� ������
//    options.AccessDeniedPath = "/AccessDenied";  // ���� ��� ������ � �������
//    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
//    options.Events.OnRedirectToLogin = context =>
//    {
//        // ���� ������������� ��������, ��������� �����������, �������������� �� �������� ������
//        if (!context.Request.Path.StartsWithSegments("/Identity"))
//        {
//            context.Response.Redirect("/Login");
//        }
//        return Task.CompletedTask;
//    };
//});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // ���� ��� �������� �����
        options.LogoutPath = "/Logout"; // ���� ��� ������
        options.AccessDeniedPath = "/AccessDenied"; // ���� ��� ������ � �������
    });




// ���������� ���� ��� ������
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(); // ��������� ��������� ������
builder.Services.AddDistributedMemoryCache(); // ��������� ������ � ������



var app = builder.Build();

app.UseSession(); // ��������� middleware ��� ������ � ��������
app.UseRouting();


app.UseStaticFiles();


// Middleware ��� �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();


