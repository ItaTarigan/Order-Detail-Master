//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ordersampletbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ordersampletbl()
        {
            this.orderanalysisdetailtbls = new HashSet<orderanalysisdetailtbl>();
        }
    
        public string noBalittanah { get; set; }
        public string orderNo { get; set; }
        public Nullable<int> countNumber { get; set; }
        public string sampleCode { get; set; }
        public string sampleDescription { get; set; }
        public Nullable<System.DateTime> samplingDate { get; set; }
        public string village { get; set; }
        public string subDistrict { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string landUse { get; set; }
        public string isReceived { get; set; }
        public string creaBy { get; set; }
        public Nullable<System.DateTime> creaDate { get; set; }
        public string modBy { get; set; }
        public Nullable<System.DateTime> modDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderanalysisdetailtbl> orderanalysisdetailtbls { get; set; }
        public virtual ordermastertbl ordermastertbl { get; set; }
    }
}