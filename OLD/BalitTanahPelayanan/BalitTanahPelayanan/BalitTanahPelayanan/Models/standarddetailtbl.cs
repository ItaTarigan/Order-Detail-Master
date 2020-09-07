namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.standarddetailtbl")]
    public partial class standarddetailtbl
    {
        [Key]
        public int stdDetailId { get; set; }

        public int stdId { get; set; }

        [Required]
        [StringLength(255)]
        public string elementCode { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        public virtual elementservicestbl elementservicestbl { get; set; }

        public virtual standardtbl standardtbl { get; set; }
    }
}
