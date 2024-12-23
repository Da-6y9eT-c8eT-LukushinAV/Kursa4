using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; } // Автоматически увеличиваемый ID

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } // Пароль в зашифрованном виде

        public bool Admin { get; set; }
    }
}
