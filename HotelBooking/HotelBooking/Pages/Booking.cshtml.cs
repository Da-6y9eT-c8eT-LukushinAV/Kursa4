//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using HotelBooking.Models;
//using System.Threading.Tasks;
//using HotelBooking.Data;

//namespace HotelBooking.Pages
//{
//    public class BookingModel : PageModel
//    {
//        private readonly ApplicationDbContext _context;

//        public BookingModel(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public Booking NewBooking { get; set; }
//        public Room Room { get; set; }

//        public async Task<IActionResult> OnGetAsync(int roomId)
//        {
//            Room = await _context.Rooms.FindAsync(roomId);
//            if (Room == null)
//                return NotFound();

//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            Console.WriteLine($"UserId: {HttpContext.Session.GetString("UserId")}");
//            Console.WriteLine($"RoomId: {NewBooking.RoomId}");
//            // ��������� ���
//            if (NewBooking.CheckInDate >= NewBooking.CheckOutDate)
//            {
//                ModelState.AddModelError(string.Empty, "���� ������ ������ ���� ����� ���� ������.");
//                return Page();
//            }

//            // ��������� UserId �� ������
//            string userId = HttpContext.Session.GetString("UserId");
//            if (string.IsNullOrEmpty(userId))
//            {
//                ModelState.AddModelError(string.Empty, "������������ �� �����������.");
//                return Page();
//            }

//            // ��������� Room �� ���� ������ �� RoomId
//            Room = await _context.Rooms.FindAsync(NewBooking.RoomId);
//            if (Room == null)
//            {
//                ModelState.AddModelError(string.Empty, "����� �� ������.");
//                return Page();
//            }

//            // ���������� ������ � ������������
//            NewBooking.TotalPrice = CalculateTotalPrice(NewBooking.CheckInDate, NewBooking.CheckOutDate, Room.PricePerNight);
//            NewBooking.UserId = int.Parse(userId);
//            NewBooking.RoomId = Room.RoomId;

//            _context.Bookings.Add(NewBooking);
//            await _context.SaveChangesAsync();

//            return RedirectToPage("/Success");
//        }

//        public decimal CalculateTotalPrice(DateTime checkIn, DateTime checkOut, decimal pricePerNight)
//        {
//            int days = (checkOut - checkIn).Days;
//            return days * pricePerNight;
//        }
//    }
//}
///////////////////////////////////////////////////////

//using HotelBooking.Data;
//using HotelBooking.Models;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc;

//public class BookingModel : PageModel
//{
//    private readonly ApplicationDbContext _context;

//    public BookingModel(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    [BindProperty]
//    public int RoomId { get; set; }

//    [BindProperty]
//    public DateTime ArrivalDate { get; set; }

//    [BindProperty]
//    public DateTime DepartureDate { get; set; }

//    public Room SelectedRoom { get; set; }
//    public decimal TotalPrice { get; set; }

//    public void OnGet(int roomId)
//    {
//        // �������� ����� �� RoomId
//        SelectedRoom = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
//    }

//    public void OnPost()
//    {
//        // �������� �����
//        SelectedRoom = _context.Rooms.FirstOrDefault(r => r.RoomId == RoomId);

//        // ������ ���������� ���� � ����� ���������
//        if (ArrivalDate != DateTime.MinValue && DepartureDate != DateTime.MinValue)
//        {
//            int totalDays = (DepartureDate - ArrivalDate).Days;
//            if (totalDays > 0 && SelectedRoom != null)
//            {
//                TotalPrice = totalDays * SelectedRoom.PricePerNight;
//            }
//        }
//    }
//}

///////////////////////////////////////////////////////////////
///

using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace HotelBooking.Pages
{
    public class BookingModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BookingModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int RoomId { get; set; }


        [BindProperty]
        public DateTime? ArrivalDate { get; set; } // Nullable, ����� ���� ���� ������

        [BindProperty]
        public DateTime? DepartureDate { get; set; }

        public Room SelectedRoom { get; set; }
        public decimal TotalPrice { get; set; }
        public bool PriceCalculated { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int roomId)
        {
            SelectedRoom = await _context.Rooms.FindAsync(roomId);
            if (SelectedRoom == null)
                return NotFound();

            RoomId = roomId;
            return Page();
        }

        public async Task<IActionResult> OnPostCalculateAsync()
        {
            // ������� �������������� ���������
            ModelState.Clear();

            SelectedRoom = await _context.Rooms.FindAsync(RoomId);
            if (SelectedRoom == null)
                return NotFound();

            if (ArrivalDate != null && DepartureDate != null && ArrivalDate < DepartureDate)
            {
                int totalDays = (DepartureDate.Value - ArrivalDate.Value).Days;
                TotalPrice = totalDays * SelectedRoom.PricePerNight;
                PriceCalculated = true;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "��������� ����: ���� ������ ������ ���� ����� ���� ������.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostBookAsync()
        {
            ModelState.Clear();

            SelectedRoom = await _context.Rooms.FindAsync(RoomId);
            if (SelectedRoom == null)
                return NotFound();

            if (ArrivalDate == null || DepartureDate == null || ArrivalDate >= DepartureDate)
            {
                ModelState.AddModelError(string.Empty, "��������� ����: ���� ������ ������ ���� ����� ���� ������.");
                return Page();
            }

            string userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError(string.Empty, "������������ �� �����������.");
                return Page();
            }

            var booking = new Booking
            {
                UserId = int.Parse(userId),
                RoomId = SelectedRoom.RoomId,
                CheckInDate = ArrivalDate.Value,
                CheckOutDate = DepartureDate.Value,
                TotalPrice = (DepartureDate.Value - ArrivalDate.Value).Days * SelectedRoom.PricePerNight
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Success");
        }
    }
}

////////////////////////////////////////////////////////////////////////////



