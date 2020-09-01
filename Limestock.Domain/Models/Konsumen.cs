using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Limestock.Domain.Models
{
    public class Konsumen : modelID
    {
        [MaxLength(64)]
        public string NamaKonsumen { get; set; }

        [MaxLength(150)]
        public string AlamatKonsumen { get; set; }

        [MaxLength(15)]
        public int TelpKonsumen { get; set; }

        // Relasi
        public List<Order> Orders { get; set; }
    }
}
