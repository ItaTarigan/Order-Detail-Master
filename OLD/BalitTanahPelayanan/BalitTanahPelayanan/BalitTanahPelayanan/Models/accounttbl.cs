namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.accounttbl")]
    public partial class accounttbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public accounttbl()
        {
            customertbls = new HashSet<customertbl>();
            employeetbls = new HashSet<employeetbl>();
        }

        [Key]
        public int accountNo { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string roleName { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string isEmailVerified { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        public virtual roletbl roletbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customertbl> customertbls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employeetbl> employeetbls { get; set; }
    }
}
