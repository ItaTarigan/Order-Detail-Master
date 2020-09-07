namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.elementservicestbl")]
    public partial class elementservicestbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public elementservicestbl()
        {
            orderdetailtbls = new HashSet<orderdetailtbl>();
            standarddetailtbls = new HashSet<standarddetailtbl>();
        }

        [Key]
        [StringLength(255)]
        public string elementCode { get; set; }

        [Required]
        [StringLength(255)]
        public string analysisTypeName { get; set; }

        [StringLength(255)]
        public string serviceGroup { get; set; }

        public decimal serviceRate { get; set; }

        [StringLength(255)]
        public string serviceStatus { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        public virtual analysistypetbl analysistypetbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderdetailtbl> orderdetailtbls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<standarddetailtbl> standarddetailtbls { get; set; }
    }
}
