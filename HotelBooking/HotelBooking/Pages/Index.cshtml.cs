using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Room> FilteredRooms { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? City { get; set; }
    [BindProperty(SupportsGet = true)]
    public DateTime? ArrivalDate { get; set; }
    [BindProperty(SupportsGet = true)]
    public DateTime? DepartureDate { get; set; }
    [BindProperty(SupportsGet = true)]
    public int? Adults { get; set; }
    [BindProperty(SupportsGet = true)]
    public int? Children { get; set; }



    [BindProperty(SupportsGet = true)]
    public int? hasWifi { get; set; }
    [BindProperty(SupportsGet = true)]
    public int? hasAirConditioner { get; set; }
    [BindProperty(SupportsGet = true)]
    public int? hasSafe { get; set; }
    [BindProperty(SupportsGet = true)]
    public int? hasTV { get; set; }
    [BindProperty(SupportsGet = true)]
    public int? hasHairDryer { get; set; }


    
    public async Task OnGetAsync(DateTime? arrivalDate, DateTime? departureDate, int? adults, int? children, string sortOrder, int? starRating, int? hasWifi, int? hasAirConditioner, int? hasSafe, int? hasTV, int? hasHairDryer)
    {
        var query = _context.Rooms.Include(r => r.Hotel).AsQueryable();
        int totalGuests = (adults ?? 0) + (children ?? 0);

        // Сохранение значений фильтров для отображения
        ViewData["adults"] = adults;
        ViewData["children"] = children;
        ViewData["capacity"] = totalGuests;
        ViewData["sortOrder"] = sortOrder;
        ViewData["starRating"] = starRating;
        ViewData["hasWifi"] = hasWifi;
        ViewData["hasAirConditioner"] = hasAirConditioner;
        ViewData["hasSafe"] = hasSafe;
        ViewData["hasTV"] = hasTV;
        ViewData["hasHairDryer"] = hasHairDryer;

        
        // Фильтры
        if (!string.IsNullOrWhiteSpace(City))
        {
            query = query.Where(r => r.Hotel.Address == City);
        }

        query = sortOrder switch
        {
            "asc" => query.OrderBy(r => (double)r.PricePerNight),
            "desc" => query.OrderByDescending(r => (double)r.PricePerNight),
            _ => query
        };

        if (starRating.HasValue)
        {
            query = query.Where(r => r.Hotel.StarRating == starRating.Value);
        }

        if (totalGuests !=0)
        {
            query = query.Where(r => r.Capacity >= totalGuests);
        }
        if (arrivalDate.HasValue && departureDate.HasValue)
        {
            query = query
                .Where(r => !_context.Bookings.Any(b =>
                    b.RoomId == r.RoomId &&
                    b.CheckInDate < departureDate.Value && // Дата заезда бронирования < указанной даты выезда
                    b.CheckOutDate > arrivalDate.Value   // Дата выезда бронирования > указанной даты заезда
                ));
        }

        // Преобразуем int в bool для фильтров
        if (hasWifi.HasValue)
            query = query.Where(r => r.HasWifi == hasWifi.Value);
        if (hasAirConditioner.HasValue)
            query = query.Where(r => r.HasAirConditioner == hasAirConditioner.Value);
        if (hasSafe.HasValue)
            query = query.Where(r => r.HasSafe == hasSafe.Value);
        if (hasTV.HasValue)
            query = query.Where(r => r.HasTV == hasTV.Value);
        if (hasHairDryer.HasValue)
            query = query.Where(r => r.HasHairDryer == hasHairDryer.Value);

        FilteredRooms = await query.ToListAsync();
    }


}
