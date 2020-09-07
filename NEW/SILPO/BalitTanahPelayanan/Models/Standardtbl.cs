using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BalitTanahPelayanan.Models
{
    public partial class Standardtbl
    {
        public Standardtbl()
        {
            Standarddetailtbl = new HashSet<Standarddetailtbl>();
        }

        public int StdId { get; set; }
        [Required(ErrorMessage = "Nomor Standard Harus Diisi."), StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string StdNo { get; set; }
        public int? ComodityNo { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Comoditytbl ComodityNoNavigation { get; set; }
        public virtual ICollection<Standarddetailtbl> Standarddetailtbl { get; set; }
    }
}
