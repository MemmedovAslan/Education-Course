using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndProject.Models
{
    public partial class Kateqoriyalar
    {
        public Kateqoriyalar()
        {
            Kurslars = new HashSet<Kurslar>();
        }

        public int KateqoriyaId { get; set; }
        public string KateqoriyaAd { get; set; }

        public virtual ICollection<Kurslar> Kurslars { get; set; }
    }
}
