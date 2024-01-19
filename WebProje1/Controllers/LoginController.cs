using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebProje1.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebProje1.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        public async Task<IActionResult> GirisYap(Admin p)
        {
            var bilgiler = _context.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);

            if (bilgiler != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, p.Kullanici)
        };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("AdminIndex", "Booking");
            }

            return View();
        }

    }
}
    
