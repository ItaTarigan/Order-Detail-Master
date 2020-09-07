using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BalitTanahPelayanan.Models
{
    public partial class Customertbl
    {
        public Customertbl()
        {
            Ordermastertbl = new HashSet<Ordermastertbl>();
        }

        public int CustomerNo { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string CustomerName { get; set; }
        [EmailAddress(ErrorMessage = "Email anda salah."), StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string CustomerEmail { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string CompanyPhone { get; set; }
        [EmailAddress(ErrorMessage = "Email anda salah."), StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string CompanyEmail { get; set; }
        public int? AccountNo { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Accounttbl AccountNoNavigation { get; set; }
        public virtual ICollection<Ordermastertbl> Ordermastertbl { get; set; }
    }
}
