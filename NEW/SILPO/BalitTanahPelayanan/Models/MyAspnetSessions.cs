using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class MyAspnetSessions
    {
        public string SessionId { get; set; }
        public int ApplicationId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public DateTime LockDate { get; set; }
        public int LockId { get; set; }
        public int Timeout { get; set; }
        public byte Locked { get; set; }
        public byte[] SessionItems { get; set; }
        public int Flags { get; set; }
    }
}
