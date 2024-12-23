using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBooking.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            // Очистка сессии
            HttpContext.Session.Clear();

            // Выход из системы
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToPage("/Index");
        }
    }
}
