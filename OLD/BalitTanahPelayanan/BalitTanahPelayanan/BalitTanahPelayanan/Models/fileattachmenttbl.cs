namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlpob.fileattachmenttbl")]
    public partial class fileattachmenttbl
    {
        [Key]
        public int attachmentNo { get; set; }

        public int orderDetailNo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string url { get; set; }

        [StringLength(255)]
        public string fileName { get; set; }

        [StringLength(255)]
        public string creaBy { get; set; }

        public DateTime? creaDate { get; set; }

        public virtual orderdetailtbl orderdetailtbl { get; set; }
    }
}
