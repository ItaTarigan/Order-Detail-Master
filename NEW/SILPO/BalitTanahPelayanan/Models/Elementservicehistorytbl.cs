using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Elementservicehistorytbl
    {
        public int ElementHistoryNo { get; set; }
        public DateTime? ActiveDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int ElementId { get; set; }
        public decimal? ServiceRate { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }

        public virtual Elementservicestbl Element { get; set; }
    }
}
