using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelBooking.Data;
using HotelBooking.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HotelBooking.Pages.Admin
{
    public class AddRoomModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddRoomModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room NewRoom { get; set; }

        public IActionResult OnGet()
        {
            // �������� ������� ������ � ���� ��������������
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            if (string.IsNullOrEmpty(isAdmin) || isAdmin != "true")
            {
                return RedirectToPage("/Index"); // ��������������� �� ������� ��������
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // �������� �� ���������� ������
            if (!ModelState.IsValid)
                return Page();

            // ��������� ����� ����� � ���� ������
            _context.Rooms.Add(NewRoom);
            await _context.SaveChangesAsync();

            return RedirectToPage("/RoomList");
        }
    }
}
