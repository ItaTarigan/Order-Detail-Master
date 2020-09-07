namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.roletbl")]
    public partial class roletbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public roletbl()
        {
            accounttbls = new HashSet<accounttbl>();
        }

        [Key]
        [StringLength(255)]
        public string roleName { get; set; }

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
        public virtual ICollection<accounttbl> accounttbls { get; set; }
    }
}
