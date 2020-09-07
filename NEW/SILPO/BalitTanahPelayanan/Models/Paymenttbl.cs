using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class Paymenttbl
    {
        public long PaymentId { get; set; }
        public string Status { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string PaymentReceiptUrl { get; set; }
        public decimal? Amount { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
