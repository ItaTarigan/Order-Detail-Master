namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.sampletbl")]
    public partial class sampletbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sampletbl()
        {
            orderdetailtbls = new HashSet<orderdetailtbl>();
        }

        [Key]
        [StringLength(25)]
        public string noBalittanah { get; set; }

        [Required]
        [StringLength(30)]
        public string orderNo { get; set; }

        [Required]
        [StringLength(255)]
        public string sampleCode { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string sampleDescription { get; set; }

        public DateTime? samplingDate { get; set; }

        [StringLength(255)]
        public string village { get; set; }

        [StringLength(255)]
        public string subDistrict { get; set; }

        [StringLength(255)]
        public string district { get; set; }

        [StringLength(255)]
        public string provice { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string gpsCoordeinate { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string isReceived { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderdetailtbl> orderdetailtbls { get; set; }

        public virtual ordermastertbl ordermastertbl { get; set; }
    }
}
