using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Ordernavigationtbl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string IsLeaf { get; set; }
        public int CommodityNo { get; set; }
        public int OrderNo { get; set; }
        public string IsVisible { get; set; }
    }
}
