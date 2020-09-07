namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.customertbl")]
    public partial class customertbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customertbl()
        {
            ordermastertbls = new HashSet<ordermastertbl>();
        }

        [Key]
        public int customerNo { get; set; }

        [StringLength(255)]
        public string customerName { get; set; }

        [StringLength(255)]
        public string customerEmail { get; set; }

        [StringLength(255)]
        public string companyName { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string companyAddress { get; set; }

        [StringLength(25)]
        public string companyPhone { get; set; }

        [StringLength(255)]
        public string companyEmail { get; set; }

        public int? accountNo { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        public virtual accounttbl accounttbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordermastertbl> ordermastertbls { get; set; }
    }
}
