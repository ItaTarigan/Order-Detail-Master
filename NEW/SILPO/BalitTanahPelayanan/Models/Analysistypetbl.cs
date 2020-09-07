using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BalitTanahPelayanan.Models
{
    public partial class Analysistypetbl
    {
        public Analysistypetbl()
        {
            Elementservicestbl = new HashSet<Elementservicestbl>();
            Ordermastertbl = new HashSet<Ordermastertbl>();
            Packagetbl = new HashSet<Packagetbl>();
        }

        [Required(ErrorMessage = "Silahkan isi tipe analisis"), StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string AnalysisTypeName { get; set; }
        [Required(ErrorMessage = "Silahkan isi deskripsi")]
        public string Description { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual ICollection<Elementservicestbl> Elementservicestbl { get; set; }
        public virtual ICollection<Ordermastertbl> Ordermastertbl { get; set; }
        public virtual ICollection<Packagetbl> Packagetbl { get; set; }
    }
}
