using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Autonumbertbl
    {
        public int Id { get; set; }
        public string NameSet { get; set; }
        public long LastCounter { get; set; }
    }
}
