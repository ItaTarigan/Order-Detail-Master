using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class MyAspnetProfiles
    {
        public int UserId { get; set; }
        public string Valueindex { get; set; }
        public string Stringdata { get; set; }
        public byte[] Binarydata { get; set; }
        public DateTimeOffset? LastUpdatedDate { get; set; }
    }
}
