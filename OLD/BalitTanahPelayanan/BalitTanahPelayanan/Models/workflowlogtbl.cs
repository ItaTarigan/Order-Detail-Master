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
    
    public partial class workflowlogtbl
    {
        public int workflowLogNo { get; set; }
        public string resourceNo { get; set; }
        public string task { get; set; }
        public string taskDesctiption { get; set; }
        public string lastStatus { get; set; }
        public string message { get; set; }
        public string creaBy { get; set; }
        public Nullable<System.DateTime> creaDate { get; set; }
    }
}
