using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Laboratoriumtbl
    {
        public Laboratoriumtbl()
        {
            Employeetbl = new HashSet<Employeetbl>();
        }

        public int LaboratoriumId { get; set; }
        public string LaboratoriumName { get; set; }
        public string LaboratoriumStatus { get; set; }
        public string LaboratoriumSymbol { get; set; }

        public virtual ICollection<Employeetbl> Employeetbl { get; set; }
    }
}
