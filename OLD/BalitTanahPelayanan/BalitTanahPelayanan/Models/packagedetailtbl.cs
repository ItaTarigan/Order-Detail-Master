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
    
    public partial class packagedetailtbl
    {
        public int PackageDetailTbl1 { get; set; }
        public string packageName { get; set; }
        public Nullable<int> elementId { get; set; }
        public string compulsive { get; set; }
    
        public virtual elementservicestbl elementservicestbl { get; set; }
        public virtual packagetbl packagetbl { get; set; }
    }
}
