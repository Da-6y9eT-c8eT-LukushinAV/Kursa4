using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Pages
{
    public class AccountModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AccountModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Booking> UserBookings { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                // Если пользователь не авторизован, перенаправляем на главную
                return RedirectToPage("/Index");
            }

            // Получаем все бронирования данного пользователя
            UserBookings = await _context.Bookings
                .Where(b => b.UserId == int.Parse(userId))
                .Include(b => b.Room)
                .ToListAsync();

            return Page();
        }
    }
}
