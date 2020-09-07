namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.employeetbl")]
    public partial class employeetbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employeetbl()
        {
            orderdetailtbls = new HashSet<orderdetailtbl>();
            ordermastertbls = new HashSet<ordermastertbl>();
        }

        [Key]
        public int employeeNo { get; set; }

        [StringLength(255)]
        public string employeeName { get; set; }

        [StringLength(255)]
        public string position { get; set; }

        [StringLength(255)]
        public string employeeEmail { get; set; }

        public int? derivativeToEmployee { get; set; }

        public int? accountNo { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        public virtual accounttbl accounttbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderdetailtbl> orderdetailtbls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordermastertbl> ordermastertbls { get; set; }
    }
}
