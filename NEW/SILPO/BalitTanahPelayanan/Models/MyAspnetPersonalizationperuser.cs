using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class MyAspnetPersonalizationperuser
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string PathId { get; set; }
        public int? UserId { get; set; }
        public byte[] PageSettings { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
