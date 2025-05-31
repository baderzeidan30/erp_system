using System;

namespace BusinessERP.Models
{
    public class AccTransfer : EntityBase
    {
        public Int64 Id { get; set; }
        public Int64 SenderId { get; set; }
        public Int64 ReceiverId { get; set; }
        public DateTime TransferDate { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}