using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Accounttbl
    {
        public Accounttbl()
        {
            Customertbl = new HashSet<Customertbl>();
            Employeetbl = new HashSet<Employeetbl>();
        }

        public int AccountNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public string IsEmailVerified { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
        public string ModBy { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual Roletbl RoleNameNavigation { get; set; }
        public virtual ICollection<Customertbl> Customertbl { get; set; }
        public virtual ICollection<Employeetbl> Employeetbl { get; set; }
    }
}
