using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class MyAspnetSitemap
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Roles { get; set; }
        public int? ParentId { get; set; }
    }
}
