using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Workflowlogtbl
    {
        public int WorkflowLogNo { get; set; }
        public string ResourceNo { get; set; }
        public string Task { get; set; }
        public string TaskDesctiption { get; set; }
        public string LastStatus { get; set; }
        public string Message { get; set; }
        public string CreaBy { get; set; }
        public DateTime? CreaDate { get; set; }
    }
}
