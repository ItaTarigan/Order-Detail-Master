using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Batchtbl
    {
        public Batchtbl()
        {
            Ordermastertbl = new HashSet<Ordermastertbl>();
        }

        public string BatchId { get; set; }
        public string Filename { get; set; }
        public string Status { get; set; }
        public string Fileurl { get; set; }
        public int? PicAnalis { get; set; }
        public int? PicPenyelia { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Employeetbl PicAnalisNavigation { get; set; }
        public virtual Employeetbl PicPenyeliaNavigation { get; set; }
        public virtual ICollection<Ordermastertbl> Ordermastertbl { get; set; }
    }
}
