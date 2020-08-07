using System;
using System.Collections.Generic;
using System.Text;

namespace Limestock.Domain.Models
{
    public class User : modelID
    {
        //model untuk tabel user
        public string namaLengkap { get; set; }
        public string userEmail { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public DateTime createdTime { get; set; }
    }
}
