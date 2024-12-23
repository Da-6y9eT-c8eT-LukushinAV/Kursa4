using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBooking.Pages
{
    public class PrivacyModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Проверка наличия сессии и прав администратора
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            if (string.IsNullOrEmpty(isAdmin) || isAdmin != "true")
            {
                return RedirectToPage("/Index"); // Перенаправление на главную страницу
            }

            return Page(); // Разрешение доступа к странице
        }
    }
}

