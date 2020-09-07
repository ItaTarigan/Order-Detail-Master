namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.orderdetailtbl")]
    public partial class orderdetailtbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orderdetailtbl()
        {
            fileattachmenttbls = new HashSet<fileattachmenttbl>();
        }

        [Key]
        public int orderDetailNo { get; set; }

        public int orderNo { get; set; }

        [Required]
        [StringLength(25)]
        public string sampleNo { get; set; }

        [Required]
        [StringLength(255)]
        public string elementCode { get; set; }

        public int? parametersNo { get; set; }

        [StringLength(255)]
        public string elementValue { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public int? pic { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        public virtual elementservicestbl elementservicestbl { get; set; }

        public virtual employeetbl employeetbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fileattachmenttbl> fileattachmenttbls { get; set; }

        public virtual parameterstbl parameterstbl { get; set; }

        public virtual sampletbl sampletbl { get; set; }
    }
}
