namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.parameterstbl")]
    public partial class parameterstbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public parameterstbl()
        {
            orderdetailtbls = new HashSet<orderdetailtbl>();
        }

        [Key]
        public int parametersNo { get; set; }

        [StringLength(255)]
        public string string0 { get; set; }

        [StringLength(255)]
        public string string1 { get; set; }

        [StringLength(255)]
        public string string2 { get; set; }

        [StringLength(255)]
        public string string3 { get; set; }

        [StringLength(255)]
        public string string4 { get; set; }

        [StringLength(255)]
        public string string5 { get; set; }

        [StringLength(255)]
        public string string6 { get; set; }

        [StringLength(255)]
        public string string7 { get; set; }

        [StringLength(255)]
        public string string8 { get; set; }

        [StringLength(255)]
        public string srting9 { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderdetailtbl> orderdetailtbls { get; set; }
    }
}
