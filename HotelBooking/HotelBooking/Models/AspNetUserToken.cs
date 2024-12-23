namespace HotelBooking.Models
{
    public class AspNetUserToken
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public AspNetUser User { get; set; }
    }

}
