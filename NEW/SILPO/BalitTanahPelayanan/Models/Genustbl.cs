using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Genustbl
    {
        public int GenusId { get; set; }
        public string GenusName { get; set; }
        public decimal Cost { get; set; }
        public int ComodityNo { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Comoditytbl ComodityNoNavigation { get; set; }
    }
}
