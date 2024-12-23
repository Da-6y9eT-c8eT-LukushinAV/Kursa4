namespace HotelBooking.Models
{
    public class AspNetUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public AspNetUser User { get; set; }
        public AspNetRole Role { get; set; }
    }

}
