using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class MyAspnetSessioncleanup
    {
        public DateTime LastRun { get; set; }
        public int IntervalMinutes { get; set; }
        public int ApplicationId { get; set; }
    }
}
