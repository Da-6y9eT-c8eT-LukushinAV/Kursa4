using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public string ImageFileName { get; set; }

        // Удобства
        //public bool HasWifi { get; set; }//
        //public bool HasAirConditioner { get; set; }
        //public bool HasSafe { get; set; }
        //public bool HasTV { get; set; }
        //public bool HasHairDryer { get; set; }
        public int HasWifi { get; set; }
        public int HasAirConditioner { get; set; }
        public int HasSafe { get; set; }
        public int HasTV { get; set; }
        public int HasHairDryer { get; set; }


        public Hotel Hotel { get; set; }
        //public ICollection<AmenityRoom> AmenityRooms { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }

}
