using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Comoditytbl
    {
        public Comoditytbl()
        {
            Genustbl = new HashSet<Genustbl>();
            Ordermastertbl = new HashSet<Ordermastertbl>();
            Packagetbl = new HashSet<Packagetbl>();
            Standardtbl = new HashSet<Standardtbl>();
        }

        public int ComodityNo { get; set; }
        public string ComodityName { get; set; }
        public int? DerivativeTo { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Notes { get; set; }
        public string IsPackage { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }
        public string IsGenusAvailable { get; set; }
        public decimal? PriceGenusPerSample { get; set; }
        public string IsHeavyMetalAvailable { get; set; }
        public decimal? LimitDoseForFreeOfHeavyMetal { get; set; }
        public decimal? PriceHeavyMetalPerSample { get; set; }

        public virtual ICollection<Genustbl> Genustbl { get; set; }
        public virtual ICollection<Ordermastertbl> Ordermastertbl { get; set; }
        public virtual ICollection<Packagetbl> Packagetbl { get; set; }
        public virtual ICollection<Standardtbl> Standardtbl { get; set; }
    }
}
