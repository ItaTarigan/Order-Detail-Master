using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Employeetbl
    {
        public Employeetbl()
        {
            BatchtblPicAnalisNavigation = new HashSet<Batchtbl>();
            BatchtblPicPenyeliaNavigation = new HashSet<Batchtbl>();
            Orderanalysisdetailtbl = new HashSet<Orderanalysisdetailtbl>();
            Ordermastertbl = new HashSet<Ordermastertbl>();
        }

        public int EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public string EmployeeEmail { get; set; }
        public int? DerivativeToEmployee { get; set; }
        public int? AccountNo { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }
        public int? LaboratoriumId { get; set; }

        public virtual Accounttbl AccountNoNavigation { get; set; }
        public virtual Laboratoriumtbl Laboratorium { get; set; }
        public virtual ICollection<Batchtbl> BatchtblPicAnalisNavigation { get; set; }
        public virtual ICollection<Batchtbl> BatchtblPicPenyeliaNavigation { get; set; }
        public virtual ICollection<Orderanalysisdetailtbl> Orderanalysisdetailtbl { get; set; }
        public virtual ICollection<Ordermastertbl> Ordermastertbl { get; set; }
    }
}
