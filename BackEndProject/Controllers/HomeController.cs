using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BackEndProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly BackEndContext _sql;

        public HomeController(BackEndContext sql)
        {
            _sql = sql;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Haqqimizda()
        {
            return View();
        }

        public IActionResult Kurslarimiz()
        {
            ViewBag.Kateqoriya = _sql.Kateqoriyalars.ToList();
            return View(_sql.Kurslars.ToList());
        }

        public IActionResult KursEtrafli(int id)
        {
            return View(_sql.Kurslars.SingleOrDefault(x => x.KursId == id));
        }

        public IActionResult Gorus()
        {
            ViewBag.Kateqoriya = _sql.Kateqoriyalars.ToList();
            return View(_sql.Kurslars.ToList());
        }

        public IActionResult Elaqe()
        {
            return View(_sql.Elaqes.ToList());
        }
    }
}
