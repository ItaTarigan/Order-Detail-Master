namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.ordermastertbl")]
    public partial class ordermastertbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ordermastertbl()
        {
            resulttbls = new HashSet<resulttbl>();
            sampletbls = new HashSet<sampletbl>();
        }

        [Key]
        [StringLength(30)]
        public string orderNo { get; set; }

        public int customerNo { get; set; }

        public int comodityNo { get; set; }

        public int? sampelTotal { get; set; }

        public decimal? priceTotal { get; set; }

        [StringLength(100)]
        public string status { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string isPayed { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string isAppr { get; set; }

        public int? pic { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        public virtual comoditytbl comoditytbl { get; set; }

        public virtual customertbl customertbl { get; set; }

        public virtual employeetbl employeetbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resulttbl> resulttbls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sampletbl> sampletbls { get; set; }
    }
}
