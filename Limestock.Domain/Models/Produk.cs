using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Limestock.Domain.Models
{
    public class Produk : modelID
    {
        [MaxLength(100)]
        public string NamaProduk { get; set; }

        [MaxLength(10)]
        public int StokBarang { get; set; }

        [MaxLength(10)]
        public string SatuanBarang { get; set; }

        [MaxLength(5)]
        public string SimbolSatuan { get; set; }

        [MaxLength(10)]
        public double HargaProduk { get; set; }
        public bool KetersediaanBarang { get; set; }



    }
}
