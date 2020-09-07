using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Resulttbl
    {
        public int ResultNo { get; set; }
        public string OrderNo { get; set; }
        public int? ReviewingNo { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Ordermastertbl OrderNoNavigation { get; set; }
        public virtual Reviewingtbl ReviewingNoNavigation { get; set; }
    }
}
