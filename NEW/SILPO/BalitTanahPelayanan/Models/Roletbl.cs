using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Roletbl
    {
        public Roletbl()
        {
            Accounttbl = new HashSet<Accounttbl>();
        }

        public string RoleName { get; set; }
        public string Description { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual ICollection<Accounttbl> Accounttbl { get; set; }
    }
}
