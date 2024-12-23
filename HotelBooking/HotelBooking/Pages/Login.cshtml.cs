////using Microsoft.AspNetCore.Mvc;
////using Microsoft.AspNetCore.Authentication;
////using Microsoft.AspNetCore.Mvc.RazorPages;
////using Microsoft.EntityFrameworkCore;
////using HotelBooking.Data; // ������������ ���� ��� ApplicationDbContext
////using HotelBooking.Models; // ������������ ���� ��� User

////namespace HotelBooking.Pages
////{
////    public class LoginModel : PageModel
////    {
////        private readonly ApplicationDbContext _context;

////        public LoginModel(ApplicationDbContext context)
////        {
////            _context = context;
////        }

////        [BindProperty]
////        public InputModel Input { get; set; }

////        public string ErrorMessage { get; set; }

////        public class InputModel
////        {
////            public string UserName { get; set; }
////            public string Password { get; set; }
////        }

////        public IActionResult OnGet()
////        {
////            return Page();
////        }

////        public async Task<IActionResult> OnPostAsync()
////        {
////            if (!ModelState.IsValid)
////            {
////                return Page();
////            }

////            // ����� ������������ � ���� ������
////            var user = await _context.Users
////                .FirstOrDefaultAsync(u => u.UserName == Input.UserName && u.Password == Input.Password);

////            if (user == null)
////            {
////                ErrorMessage = "�������� ��� ������������ ��� ������.";
////                return Page();
////            }

////            // ������������� ��� ������������ � ������
////            HttpContext.Session.SetString("UserName", user.UserName);
////            HttpContext.Session.SetString("IsAdmin", user.Admin ? "true" : "false");


////            return RedirectToPage("/Index"); // ��������������� �� ������� ��������
////        }
////    }
////}




//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Identity;
//using HotelBooking.Data;
//using HotelBooking.Models;
//using System.Security.Claims;

//namespace HotelBooking.Pages
//{
//    public class LoginModel : PageModel
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<User> _userManager;
//        private readonly SignInManager<User> _signInManager;

//        public LoginModel(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
//        {
//            _context = context;
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }

//        [BindProperty]
//        public InputModel Input { get; set; }

//        public string ErrorMessage { get; set; }

//        public class InputModel
//        {
//            public string UserName { get; set; }
//            public string Password { get; set; }
//        }

//        public IActionResult OnGet()
//        {
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            // ����� ������������ � ���� ������
//            var user = await _userManager.FindByNameAsync(Input.UserName);

//            if (user == null)
//            {
//                ErrorMessage = "�������� ��� ������������ ��� ������.";
//                return Page();
//            }

//            // �������� ������
//            var passwordCheck = await _userManager.CheckPasswordAsync(user, Input.Password);

//            if (!passwordCheck)
//            {
//                ErrorMessage = "�������� ��� ������������ ��� ������.";
//                return Page();
//            }

//            // �������� ������ ������ (Claims) ��� ������������
//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.Name, user.UserName),
//                new Claim(ClaimTypes.Role, user.Admin ? "Admin" : "User")
//            };

//            var identity = new ClaimsIdentity(claims, "Cookies");
//            var principal = new ClaimsPrincipal(identity);

//            // �������������� ������������ � �������������� ����
//            await HttpContext.SignInAsync("Cookies", principal);

//            return RedirectToPage("/Index"); // ��������������� ����� ��������� �����
//        }
//    }
//}





using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelBooking.Data;
using HotelBooking.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public class InputModel
        {
           
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // ����� ������������ � ���� ������
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == Input.UserName && u.Password == Input.Password);

            if (user == null)
            {
                ErrorMessage = "�������� ��� ������������ ��� ������.";
                return Page();
            }

            // ������������� ��� ������������ � ������
            HttpContext.Session.SetString("UserId", user.ID.ToString());
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("IsAdmin", user.Admin ? "true" : "false");

            var claims = new[]
            {
        new System.Security.Claims.Claim("name", user.UserName),
        new System.Security.Claims.Claim("isAdmin", user.Admin.ToString())
    };

            var identity = new System.Security.Claims.ClaimsIdentity(claims, "Cookies");
            var principal = new System.Security.Claims.ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("Cookies", principal); // �������������� ������������ ����� ����

            return RedirectToPage("/Index");
        }
    }
}