using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Packagedetailtbl
    {
        public int PackageDetailTbl1 { get; set; }
        public string PackageName { get; set; }
        public int? ElementId { get; set; }
        public string Compulsive { get; set; }

        public virtual Elementservicestbl Element { get; set; }
        public virtual Packagetbl PackageNameNavigation { get; set; }
    }
}
