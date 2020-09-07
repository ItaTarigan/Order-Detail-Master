using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Standarddetailtbl
    {
        public int StdDetailId { get; set; }
        public int StdId { get; set; }
        public int ElementId { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Elementservicestbl Element { get; set; }
        public virtual Standardtbl Std { get; set; }
    }
}
