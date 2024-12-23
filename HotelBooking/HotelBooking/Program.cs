using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Настройка контекста базы данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



// Добавление Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizePage("/Booking"); // Пример: доступ к странице бронирования только для авторизованных пользователей
        options.Conventions.AllowAnonymousToPage("/Register"); // Разрешить доступ к странице логина для всех пользователей
    });

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Login";  // Путь для страницы логина
//    options.LogoutPath = "/Logout";  // Путь для выхода
//    options.AccessDeniedPath = "/AccessDenied";  // Путь при отказе в доступе
//    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
//    options.Events.OnRedirectToLogin = context =>
//    {
//        // Если запрашивается страница, требующая авторизации, перенаправляем на страницу логина
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
        options.LoginPath = "/Login"; // Путь для страницы входа
        options.LogoutPath = "/Logout"; // Путь для выхода
        options.AccessDeniedPath = "/AccessDenied"; // Путь для отказа в доступе
    });




// Добавление кэша для сессий
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(); // Добавляем поддержку сессий
builder.Services.AddDistributedMemoryCache(); // Хранилище сессий в памяти



var app = builder.Build();

app.UseSession(); // Добавляем middleware для работы с сессиями
app.UseRouting();


app.UseStaticFiles();


// Middleware для аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();


