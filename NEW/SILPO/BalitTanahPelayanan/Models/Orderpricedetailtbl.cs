using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Orderpricedetailtbl
    {
        public int OrderPriceDetailNo { get; set; }
        public string OrderNo { get; set; }
        public int? ElementId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Elementservicestbl Element { get; set; }
        public virtual Ordermastertbl OrderNoNavigation { get; set; }
    }
}
