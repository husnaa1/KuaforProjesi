using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using KuaforProjesi.Models;
using System.Security.Claims;

namespace KuaforProjesi.Controllers
{
    public class LoginController : Controller
    {

        KisiContext c = new KisiContext();

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        public async Task<IActionResult> GirisYap(Kisiler k)
        {
            var bilgiler = c.Kisiler.FirstOrDefault(x => x.Kisi_KulAd == k.Kisi_KulAd && x.Kisi_Sifre == k.Kisi_Sifre);

            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,k.Kisi_KulAd)


                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("İletisim");
            }
            return View();
        }

    }
}
