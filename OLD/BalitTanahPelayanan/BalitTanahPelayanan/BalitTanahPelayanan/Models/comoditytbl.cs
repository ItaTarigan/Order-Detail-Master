namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.comoditytbl")]
    public partial class comoditytbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comoditytbl()
        {
            ordermastertbls = new HashSet<ordermastertbl>();
            standardtbls = new HashSet<standardtbl>();
        }

        [Key]
        public int comodityNo { get; set; }

        [StringLength(255)]
        public string comodityName { get; set; }

        public int? derivativeTo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordermastertbl> ordermastertbls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<standardtbl> standardtbls { get; set; }
    }
}
