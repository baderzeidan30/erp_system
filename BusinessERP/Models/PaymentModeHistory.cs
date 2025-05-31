using System;

namespace BusinessERP.Models
{
    public class PaymentModeHistory : EntityBase
    {
        public Int64 Id { get; set; }
        public Int64 PaymentId { get; set; }
        public int PaymentType { get; set; }
        public string ModeOfPayment { get; set; }
        public double? Amount { get; set; }
        public string ReferenceNo { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
