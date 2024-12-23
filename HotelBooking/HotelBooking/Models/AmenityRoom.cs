namespace HotelBooking.Models
{
    public class AmenityRoom
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
    }

}
