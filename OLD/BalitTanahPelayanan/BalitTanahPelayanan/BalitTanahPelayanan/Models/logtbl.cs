namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.logtbl")]
    public partial class logtbl
    {
        [Key]
        public int logId { get; set; }

        [StringLength(255)]
        public string source { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }
    }
}
