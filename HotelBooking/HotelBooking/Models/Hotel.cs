namespace HotelBooking.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StarRating { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }

}
