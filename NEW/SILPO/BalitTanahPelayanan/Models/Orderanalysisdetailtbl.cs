using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Orderanalysisdetailtbl
    {
        public int OrderDetailNo { get; set; }
        public string OrderNo { get; set; }
        public string SampleNo { get; set; }
        public int ElementId { get; set; }
        public int? ParametersNo { get; set; }
        public string ElementValue { get; set; }
        public string Status { get; set; }
        public string Recalculate { get; set; }
        public int? Pic { get; set; }
        public string FileAttachmentUrl { get; set; }
        public string FileName { get; set; }
        public string LabToolAttachmentUrl { get; set; }
        public string LabToolFileName { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Elementservicestbl Element { get; set; }
        public virtual Ordermastertbl OrderNoNavigation { get; set; }
        public virtual Parameterstbl ParametersNoNavigation { get; set; }
        public virtual Employeetbl PicNavigation { get; set; }
        public virtual Ordersampletbl SampleNoNavigation { get; set; }
    }
}
