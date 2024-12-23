//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using HotelBooking.Data;
//using HotelBooking.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

//namespace HotelBooking.Pages.Admin
//{
//    public class ManageHotelsModel : PageModel
//    {
//        private readonly ApplicationDbContext _context;

//        public ManageHotelsModel(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public IList<Hotel> Hotels { get; set; }

//        [BindProperty]
//        public Hotel NewHotel { get; set; }

//        public async Task OnGetAsync()
//        {
//            Hotels = await _context.Hotels.ToListAsync();
//        }

//        public async Task<IActionResult> OnPostAddAsync()
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Hotels.Add(NewHotel);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToPage();
//        }

//        public async Task<IActionResult> OnPostEditAsync(int id, string name, string location)
//        {
//            var hotel = await _context.Hotels.FindAsync(id);
//            if (hotel != null)
//            {
//                hotel.Name = name;
//                hotel.Address = location;

//                await _context.SaveChangesAsync();
//            }

//            return RedirectToPage();
//        }

//        public async Task<IActionResult> OnPostDeleteAsync(int id)
//        {
//            var hotel = await _context.Hotels.FindAsync(id);
//            if (hotel != null)
//            {
//                _context.Hotels.Remove(hotel);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToPage();
//        }
//    }
//}
using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Pages.Admin
{
    public class ManageHotelsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ManageHotelsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Hotel> Hotels { get; set; }

        [BindProperty]
        public Hotel NewHotel { get; set; }

        // Получение списка отелей
        public async Task<IActionResult> OnGetAsync()
        {
            Hotels = await _context.Hotels.ToListAsync();
            return Page();
        }

        // Сохранение изменений для существующих отелей
        public async Task<IActionResult> OnPostSaveAsync()
        {
            foreach (var hotel in Hotels)
            {
                var existingHotel = await _context.Hotels.FindAsync(hotel.HotelId);
                if (existingHotel != null)
                {
                    _context.Entry(existingHotel).CurrentValues.SetValues(hotel);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // Добавление нового отеля
        public async Task<IActionResult> OnPostAddAsync()
        {
            if (NewHotel != null)
            {
                _context.Hotels.Add(NewHotel);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        // Удаление отеля
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}

