using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Reviewingtbl
    {
        public Reviewingtbl()
        {
            Resulttbl = new HashSet<Resulttbl>();
        }

        public int ReviewingNo { get; set; }
        public string OrderNo { get; set; }
        public string ElementCodeList { get; set; }
        public DateTime? ReviewingDate { get; set; }
        public string IsLabUtilitySurfficient { get; set; }
        public string IsHumanResourceSurfficient { get; set; }
        public string IsChemicalMaterialSurfficent { get; set; }
        public string IsVolumeCorrect { get; set; }
        public int? Workdays { get; set; }
        public string IsMethode { get; set; }
        public string IsQualityStandard { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual ICollection<Resulttbl> Resulttbl { get; set; }
    }
}
