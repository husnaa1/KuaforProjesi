using KuaforProjesi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System;
using Azure;
using System.Net;
using Azure.Core;


namespace KuaforProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KisiContext _context;


        public HomeController(ILogger<HomeController> logger, KisiContext context)
        {
            _logger = logger;
            _context = context;
        }


        //dbden kisileri getiren controller
        [HttpGet]
        public IActionResult Index()
        {

            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if(Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }

            ViewBag.KisiListe = _context.Kisiler.ToList();

            return View();
        }


        //dbye kisileri ekleyen controller
        [HttpPost]
        public IActionResult Index(Kisiler kisi)

        {
            _context.Add(kisi);
            _context.SaveChanges();
            return RedirectToAction(nameof(kayitLogin));
        }


        [HttpPost]
        public IActionResult RandevuAl(Randevu randevu)

        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID",out id))
            {
                randevu.Kisi_ID = Convert.ToInt32(id);
                _context.Add(randevu);
                _context.SaveChanges();
            }


            return RedirectToAction(nameof(MüsteriSayfası));
        }


        [HttpPost]
        public IActionResult Yorum(Yorum yorum)

        {
            _context.Add(yorum);
            _context.SaveChanges();
            return RedirectToAction(nameof(Yorum));
        }


        [HttpPost]
        public IActionResult Fiyat(Fiyat fiyat2)

        {
            _context.Add(fiyat2);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        //dbden kisileri silen controller

        public async Task<IActionResult> Randevu_Sil(int ID)
        {

            var Silinecek_Randevu = await _context.Randevu.FindAsync(ID);
            _context.Remove(Silinecek_Randevu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(YoneticiMainPage));

        }

        public async Task<IActionResult> Fiyat_Sil(int ID)
        {

            var Silinecek_Fiyat = await _context.Fiyat.FindAsync(ID);
            _context.Remove(Silinecek_Fiyat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Kisi_Guncelle(int ID)
        {
            var Guncellenecek_Kisi = _context.Kisiler.Find(ID);


            return View(Guncellenecek_Kisi);
        }

        [HttpPost]
        public IActionResult Kisi_Guncelle(Kisiler kisi)
        {
            _context.Update(kisi);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult FiyatGüncelleme(int ID)
        {


            var Guncellenecek_Fiyat = _context.Fiyat.Find(ID);


            return View(Guncellenecek_Fiyat);
        }

        [HttpPost]
        public IActionResult FiyatGüncelleme(Fiyat fiy)
        {
            _context.Update(fiy);
            _context.SaveChanges();

            return RedirectToAction(nameof(YoneticiFiyatGuncellemesi));

        }
        public IActionResult hakkimizda()
        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if (Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }

            return View();
        }
        public IActionResult Randevu()
        {
            return View();
        }
        public IActionResult İletisim()
        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if (Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }

            return View();
        }
        public IActionResult Hizmetlerimiz()
        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if (Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }

            return View();
        }
        public IActionResult YolTarifi()
        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if (Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }

            return View();
        }
        public IActionResult FiyatListesi()
        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if (Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }
            ViewBag.FiyatListesi = _context.Fiyat.ToList();

            return View();
        }
        public IActionResult YoneticiFiyatGuncellemesi()
        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if (Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }

            ViewBag.FiyatListesi = _context.Fiyat.ToList();

            return View();
        }
        public IActionResult MüsteriSayfası()
        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if (Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Login(Kisiler k)
        {

            try
            {
                var bilgiler = _context.Kisiler.FirstOrDefault(x => x.Kisi_KulAd == k.Kisi_KulAd && x.Kisi_Sifre == k.Kisi_Sifre);



                if (bilgiler != null)
                {
                    var cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(1);
                    cookieOptions.Path = "/";

                    Response.Cookies.Append("Kisi_ID", bilgiler.Kisi_ID.ToString(), cookieOptions);
                    //TempData["Kisi_ID"] = bilgiler.Kisi_ID;
                    return RedirectToAction("MüsteriSayfası");
                }
                else
                {
                    return RedirectToAction("kayitLogin", new { hata = "Kullanıcı adı veya şifre hatalıdır. Lütfen tekrar deneyiniz." });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> RandevuAl()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}



        [HttpPost]
        public async Task<IActionResult> LoginManager(Kisiler k)
        {
            try
            {

                var bilgiler = _context.YöneticiKisiler.FirstOrDefault(x => x.YöneticiKisi_Name == k.Kisi_KulAd && x.YöneticiKisi_Sifre == k.Kisi_Sifre);

                if (bilgiler != null)
                {
                    var cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(1);
                    cookieOptions.Path = "/";

                    Response.Cookies.Append("Yonetici_ID", bilgiler.YöneticiKisi_ID.ToString(), cookieOptions);

                    return RedirectToAction("YoneticiMainPage");
                }
                else
                {
                    return RedirectToAction("kayitLogin", new { hata = "Kullanıcı adı veya şifre hatalıdır. Lütfen tekrar deneyiniz." });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IActionResult YoneticiMainPage()
        {
            string id;
            if (Request.Cookies.TryGetValue("Kisi_ID", out id))
            {
                ViewBag.KisiID = id;
                ViewBag.YoneticiId = null;
            }
            else if (Request.Cookies.TryGetValue("Yonetici_ID", out id))
            {
                ViewBag.YoneticiId = id;
                ViewBag.KisiID = null;
            }
            else
            {
                ViewBag.KisiID = null;
                ViewBag.YoneticiId = null;
            }

            ViewBag.RandevuListe = _context.Randevu.ToList();
            return View();

        }

        public IActionResult kayitLogin(string hata)
        {
            ViewBag.Error = null;
            if (hata != null)
            {
                ViewBag.Error = hata;
            }

            return View();
        }
        public IActionResult Cikis()
        {
            Response.Cookies.Delete("Kisi_ID");
            Response.Cookies.Delete("Yonetici_ID");
            return RedirectToAction("kayitLogin");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}