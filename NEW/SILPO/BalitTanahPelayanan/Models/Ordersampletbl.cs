using BalitTanahPelayanan.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BalitTanahPelayanan.Models
{
    public partial class Ordersampletbl
    {
        public Ordersampletbl()
        {
            Orderanalysisdetailtbl = new HashSet<Orderanalysisdetailtbl>();
        }

        public string NoBalittanah { get; set; }
        [StringLength(30, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string OrderNo { get; set; }
        [Required(ErrorMessage = "Silahkan isi nomor urut")]
        public int? CountNumber { get; set; }
        [Required(ErrorMessage = "Silahkan isi kode contoh"), StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string SampleCode { get; set; }
        [Required(ErrorMessage = "Silahkan isi deskripsi"), StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string SampleDescription { get; set; }
        [Required(ErrorMessage = "Silahkan isi Tanggal Pengambilan contoh")]
        public DateTime? SamplingDate { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string Village { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string SubDistrict { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string District { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string Province { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string Longitude { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string Latitude { get; set; }
        [StringLength(255, ErrorMessage = "Jumlah karakter terlalu panjang.")]
        public string LandUse { get; set; }
        public string IsReceived { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Ordermastertbl OrderNoNavigation { get; set; }
        public virtual ICollection<Orderanalysisdetailtbl> Orderanalysisdetailtbl { get; set; }
    }
}
