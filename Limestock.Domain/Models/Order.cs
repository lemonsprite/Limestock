using System;
using System.Collections.Generic;
using System.Text;

namespace Limestock.Domain.Models
{
    public class Order : modelID
    {
        public string NamaKonsumen { get; set; }

        public DateTime TglOrder { get; set; }

        // Relasi
        public User User { get; set; }
        public Konsumen Konsumen { get; set; }

    }
}
