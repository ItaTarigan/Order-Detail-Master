using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Ordermastertbl
    {
        public Ordermastertbl()
        {
            Orderanalysisdetailtbl = new HashSet<Orderanalysisdetailtbl>();
            Orderpricedetailtbl = new HashSet<Orderpricedetailtbl>();
            Ordersampletbl = new HashSet<Ordersampletbl>();
            Resulttbl = new HashSet<Resulttbl>();
        }

        public string OrderNo { get; set; }
        public string BatchId { get; set; }
        public int CustomerNo { get; set; }
        public int ComodityNo { get; set; }
        public string AnalysisType { get; set; }
        public int? SampleTotal { get; set; }
        public decimal? PriceTotal { get; set; }
        public string StatusType { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public decimal? Ppn { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Pic { get; set; }
        public string IsOnLab { get; set; }
        public string ApprPenyelia { get; set; }
        public string ApprEvaluator { get; set; }
        public string ApprManagerTeknis { get; set; }
        public string LhpattachmentUrl { get; set; }
        public string LhpfileName { get; set; }
        public string EvaluationFileUrl { get; set; }
        public string EvaluationFileName { get; set; }
        public string IsRecalculate { get; set; }
        public string CalculationFileUrl { get; set; }
        public string CalculationFilename { get; set; }
        public string IsReviewing { get; set; }
        public string PackageName { get; set; }
        public decimal? AdditionalPrice1 { get; set; }
        public decimal? AdditionalPrice2 { get; set; }
        public int? TotalGenus { get; set; }
        public decimal? DosePerHectare { get; set; }
        public string AdditionalPriceRemark { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Analysistypetbl AnalysisTypeNavigation { get; set; }
        public virtual Batchtbl Batch { get; set; }
        public virtual Comoditytbl ComodityNoNavigation { get; set; }
        public virtual Customertbl CustomerNoNavigation { get; set; }
        public virtual Employeetbl PicNavigation { get; set; }
        public virtual ICollection<Orderanalysisdetailtbl> Orderanalysisdetailtbl { get; set; }
        public virtual ICollection<Orderpricedetailtbl> Orderpricedetailtbl { get; set; }
        public virtual ICollection<Ordersampletbl> Ordersampletbl { get; set; }
        public virtual ICollection<Resulttbl> Resulttbl { get; set; }
    }
}
