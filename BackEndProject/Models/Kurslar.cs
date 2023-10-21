using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndProject.Models
{
    public partial class Kurslar
    {
        public int KursId { get; set; }
        public int? KursKateqoriyaId { get; set; }
        public string KursAd { get; set; }
        public string KursHaqqinda { get; set; }
        public string KursSekil { get; set; }

        public virtual Kateqoriyalar KursKateqoriya { get; set; }
    }
}
