using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProje1.Models;
namespace WebProje1.Controllers
{
    public class BookingController : Controller
    {
        private readonly Context c;

        public BookingController(Context context)
        {
            c = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Bookings.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult NewIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewIndex(Booking d)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            c.Bookings.Add(d);
            c.SaveChanges();
            return RedirectToAction("RoomIndex");
        }

        public IActionResult BookingDel(int id)
        {
            var rez = c.Bookings.Find(id);
            c.Bookings.Remove(rez);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BookingGet(int id)
        {
            var booking = c.Bookings.Find(id);
            return View("BookingGet", booking);
        }
        public IActionResult BookingUpdate(Booking d)
        {
            var booking = c.Bookings.Find(d.MusteriId);
            booking.MusteriId = d.MusteriId;
            booking.MusteriTelNo = d.MusteriTelNo;
            booking.MusteriAdresi = d.MusteriAdresi;
            booking.KalacakKisiSayisi = d.KalacakKisiSayisi;
            booking.GirisTarihi = d.GirisTarihi;
            booking.CikisTarihi = d.CikisTarihi;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult RoomIndex()
        {
            return View();
        }

    }
}