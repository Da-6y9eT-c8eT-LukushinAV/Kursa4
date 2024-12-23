using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace HotelBooking.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [MaxLength(50)]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            [MaxLength(100)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [MaxLength(100)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Проверка уникальности email и имени пользователя
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == Input.UserName);
           

            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с таким именем или email уже существует.");
                return Page();
            }

            // Создание нового пользователя
            var user = new User
            {
                UserName = Input.UserName,
                Email = Input.Email,
                Password = Input.Password // Пароль здесь сохраняется в незашифрованном виде
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Перенаправление после успешной регистрации
            return RedirectToPage("/Index");
        }
    }
}
