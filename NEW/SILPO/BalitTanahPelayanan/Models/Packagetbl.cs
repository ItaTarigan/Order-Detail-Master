using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Packagetbl
    {
        public Packagetbl()
        {
            Packagedetailtbl = new HashSet<Packagedetailtbl>();
        }

        public string PackageName { get; set; }
        public int? ComodityNo { get; set; }
        public string AnalysisTypeName { get; set; }
        public string MultipleSelectedItem { get; set; }
        public decimal? BundlePrice { get; set; }
        public decimal? AdditionalPrice1 { get; set; }
        public decimal? AdditionalPrice2 { get; set; }
        public string AdditionalPriceDesc1 { get; set; }
        public string AdditionalPriceDesc2 { get; set; }

        public virtual Analysistypetbl AnalysisTypeNameNavigation { get; set; }
        public virtual Comoditytbl ComodityNoNavigation { get; set; }
        public virtual ICollection<Packagedetailtbl> Packagedetailtbl { get; set; }
    }
}
