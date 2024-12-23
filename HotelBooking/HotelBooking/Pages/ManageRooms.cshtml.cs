//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using HotelBooking.Data;
//using HotelBooking.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

//namespace HotelBooking.Pages
//{
//    public class ManageRooms : PageModel
//    {
//       private readonly ApplicationDbContext _context;

//    public ManageRooms(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    [BindProperty]
//    public List<Room> Rooms { get; set; }

//    public async Task OnGetAsync()
//    {
//        Rooms = await _context.Rooms.ToListAsync();
//    }

//    public async Task<IActionResult> OnPostSaveAsync(int id)
//    {
//        var room = await _context.Rooms.FindAsync(id);
//        if (room != null)
//        {
//            // Получаем данные из формы
//            await TryUpdateModelAsync(room, "Rooms", r => r.HotelId, r => r.RoomType, r => r.Capacity,
//                r => r.PricePerNight, r => r.HasWifi, r => r.HasTV, r => r.HasAirConditioner, r => r.HasSafe, r => r.HasHairDryer);

//            await _context.SaveChangesAsync();
//        }
//        return RedirectToPage();
//    }

//    public async Task<IActionResult> OnPostDeleteAsync(int id)
//    {
//        var room = await _context.Rooms.FindAsync(id);
//        if (room != null)
//        {
//            _context.Rooms.Remove(room);
//            await _context.SaveChangesAsync();
//        }
//        return RedirectToPage();
//    }
//    }
//}



using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Pages
{
    public class ManageRoomsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ManageRoomsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Room> Rooms { get; set; }

        [BindProperty]
        public Room NewRoom { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Rooms = await _context.Rooms.ToListAsync();
            return Page();
        }





        // Сохранение изменений
        public async Task<IActionResult> OnPostSaveAsync()
        {
            foreach (var room in Rooms)
            {
                Console.WriteLine($"RoomId: {room.RoomId}, Wifi: {room.HasWifi}, AC: {room.HasAirConditioner}");
                var existingRoom = await _context.Rooms.FindAsync(room.RoomId);
                if (existingRoom != null)
                {
                    _context.Entry(existingRoom).CurrentValues.SetValues(room);
                }
            }
            foreach (var room in Rooms)
            {
                var existingRoom = await _context.Rooms.FindAsync(room.RoomId);
                if (existingRoom != null)
                {
                    _context.Entry(existingRoom).CurrentValues.SetValues(room);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // Добавление новой записи
        public async Task<IActionResult> OnPostAddAsync()
        {
            if (NewRoom != null)
            {
                _context.Rooms.Add(NewRoom);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        // Удаление записи
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
