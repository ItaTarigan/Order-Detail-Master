using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class MyAspnetUsers
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Name { get; set; }
        public byte IsAnonymous { get; set; }
        public DateTime? LastActivityDate { get; set; }
    }
}
