namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.workflowlogtbl")]
    public partial class workflowlogtbl
    {
        [Key]
        public int workflowLogNo { get; set; }

        [Required]
        [StringLength(30)]
        public string resourceNo { get; set; }

        [StringLength(255)]
        public string task { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string taskDesctiption { get; set; }

        [StringLength(255)]
        public string lastStatus { get; set; }

        [StringLength(255)]
        public string message { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }
    }
}
