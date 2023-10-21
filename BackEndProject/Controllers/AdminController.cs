using BackEndProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly BackEndContext _sql;

        public AdminController(BackEndContext sql)
        {
            _sql = sql;
        }
        public IActionResult Kurslar()
        {
            return View(_sql.Kurslars.ToList());
        }

        public IActionResult AdminKursEtrafli(int id)
        {
            return View(_sql.Kurslars.SingleOrDefault(x => x.KursId == id));
        }




        public IActionResult KursElaveEt()
        {
            return View(_sql.Kateqoriyalars.ToList());
        }


        [HttpPost]

        public IActionResult KursElaveEt(Kurslar x, IFormFile KursSekil)
        {
            string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(KursSekil.FileName);
            using (Stream stream = new FileStream("wwwroot/img/" + filename, FileMode.Create))
            {
                KursSekil.CopyTo(stream);
            }

            x.KursSekil = filename;

            _sql.Kurslars.Add(x);
            _sql.SaveChanges();

            return RedirectToAction("Kurslar");
        }


        public IActionResult KateqoriyaElaveEt()
        {
            return View();
        }

        [HttpPost]

        public IActionResult KateqoriyaElaveEt(Kateqoriyalar x)
        {
            _sql.Kateqoriyalars.Add(x);
            _sql.SaveChanges();
            return View();
        }


        public IActionResult KursSil(int id)
        {
            _sql.Kurslars.Remove(_sql.Kurslars.SingleOrDefault(x => x.KursId == id));
            _sql.SaveChanges();
            return RedirectToAction("Kurslar");
        }

        public IActionResult KursDuzelt(int id)
        {
            ViewBag.Kateqoriya = _sql.Kateqoriyalars.ToList();
            return View(_sql.Kurslars.SingleOrDefault(x => x.KursId == id));
        }

        [HttpPost]

        public IActionResult KursDuzelt(int id, Kurslar x, IFormFile KursSekil)
        {
            Kurslar kohnex = _sql.Kurslars.SingleOrDefault(x => x.KursId == id);
            if (KursSekil != null)
            {
                using (Stream stream = new FileStream("wwwroot/img/" + kohnex.KursSekil, FileMode.Create))
                {
                    KursSekil.CopyTo(stream);
                }
            }
            kohnex.KursAd = x.KursAd;
            kohnex.KursHaqqinda = x.KursHaqqinda;
            kohnex.KursKateqoriyaId = x.KursKateqoriyaId;

            _sql.SaveChanges();

            return RedirectToAction("Kurslar");
        }

        public IActionResult AdminElaqe()
        {
            return View(_sql.Elaqes.ToList());
        }

        public IActionResult ElaqeElaveEt()
        {
            return View();
        }

        [HttpPost]

        public IActionResult ElaqeElaveEt(Elaqe e)
        {
            _sql.Elaqes.Add(e);
            _sql.SaveChanges();

            return RedirectToAction("AdminElaqe");
        }

        public IActionResult ElaqeSil(int id)
        {
            _sql.Elaqes.Remove(_sql.Elaqes.SingleOrDefault(x => x.ElaqeId == id));
            _sql.SaveChanges();
            return RedirectToAction("AdminElaqe");
        }

        public IActionResult ElaqeDuzelt(int id)
        {
            return View(_sql.Elaqes.SingleOrDefault(x => x.ElaqeId == id));
        }

        [HttpPost]

        public IActionResult ElaqeDuzelt(int id, Elaqe e)
        {
            Elaqe kohnex = _sql.Elaqes.SingleOrDefault(x => x.ElaqeId == id);

            kohnex.Unvan = e.Unvan;
            kohnex.Saat = e.Saat;
            kohnex.Nomre = e.Nomre;

            _sql.SaveChanges();

            return RedirectToAction("AdminElaqe");
        }
    }
}
