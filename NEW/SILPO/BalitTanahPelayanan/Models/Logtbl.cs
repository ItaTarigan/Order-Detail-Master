using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Logtbl
    {
        public int LogId { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
    }
}
