using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Elementservicestbl
    {
        public Elementservicestbl()
        {
            Elementservicehistorytbl = new HashSet<Elementservicehistorytbl>();
            Orderanalysisdetailtbl = new HashSet<Orderanalysisdetailtbl>();
            Orderpricedetailtbl = new HashSet<Orderpricedetailtbl>();
            Packagedetailtbl = new HashSet<Packagedetailtbl>();
            Standarddetailtbl = new HashSet<Standarddetailtbl>();
        }

        public int Elementid { get; set; }
        public string ElementCode { get; set; }
        public int ComodityNo { get; set; }
        public string AnalysisTypeName { get; set; }
        public string ValueUnit { get; set; }
        public string ServiceGroup { get; set; }
        public decimal ServiceRate { get; set; }
        public string ServiceStatus { get; set; }
        public string Category { get; set; }
        public int? SortedNo { get; set; }
        public string IsMandatory { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }
        public string NotParameterProcess { get; set; }
        public string ExtractionId { get; set; }

        public virtual Analysistypetbl AnalysisTypeNameNavigation { get; set; }
        public virtual ICollection<Elementservicehistorytbl> Elementservicehistorytbl { get; set; }
        public virtual ICollection<Orderanalysisdetailtbl> Orderanalysisdetailtbl { get; set; }
        public virtual ICollection<Orderpricedetailtbl> Orderpricedetailtbl { get; set; }
        public virtual ICollection<Packagedetailtbl> Packagedetailtbl { get; set; }
        public virtual ICollection<Standarddetailtbl> Standarddetailtbl { get; set; }
    }
}
