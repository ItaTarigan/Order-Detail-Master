using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Parameterstbl
    {
        public Parameterstbl()
        {
            Orderanalysisdetailtbl = new HashSet<Orderanalysisdetailtbl>();
        }

        public int ParametersNo { get; set; }
        public string String0 { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public string String3 { get; set; }
        public string String4 { get; set; }
        public string String5 { get; set; }
        public string String6 { get; set; }
        public string String7 { get; set; }
        public string String8 { get; set; }
        public string String9 { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual ICollection<Orderanalysisdetailtbl> Orderanalysisdetailtbl { get; set; }
    }
}
