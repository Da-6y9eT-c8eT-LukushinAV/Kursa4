using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBooking.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            // ������� ������
            HttpContext.Session.Clear();

            // ����� �� �������
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToPage("/Index");
        }
    }
}
