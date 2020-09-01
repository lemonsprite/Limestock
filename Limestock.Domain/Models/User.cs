using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Limestock.Domain.Models
{
    public class User : modelID
    {
        [MaxLength(150)]
        public string NamaLengkap { get; set; }
        
        [MaxLength(100)]
        public string UserName { get; set; }
        
        [MaxLength(50)] 
        public string UserMail { get; set; }
        
        [MaxLength(16)]
        public string UserPass { get; set; }

        public DateTime TanggalBerubah { get; set; }

        public DateTime TanggalDibuat { get; set; }


        // Relasi
        public List<Order> Orders { get; set; }
    }
}
