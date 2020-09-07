namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.resulttbl")]
    public partial class resulttbl
    {
        [Key]
        public int resultNo { get; set; }

        [Required]
        [StringLength(30)]
        public string orderNo { get; set; }

        public int? reviewingNo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string url { get; set; }

        [StringLength(255)]
        public string fileName { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        [StringLength(255)]
        public string modBy { get; set; }

        public DateTime? modDate { get; set; }

        public virtual ordermastertbl ordermastertbl { get; set; }
    }
}
