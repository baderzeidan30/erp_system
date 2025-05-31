using System;

namespace BusinessERP.Models
{
    public class CustomerBalance : EntityBase
    {
        public Int64 Id { get; set; }
        public string InvoiceNo { get; set; }
        public string ReceiptId { get; set; }
        public string Type { get; set; }
        public Int64 InvAmount { get; set; }
        public Int64 PaidAmount { get; set; }
        public Int64 Balance { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
