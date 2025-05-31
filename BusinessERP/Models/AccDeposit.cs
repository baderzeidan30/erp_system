using System;

namespace BusinessERP.Models
{
    public class AccDeposit : EntityBase
    {
        public Int64 Id { get; set; }
        public Int64 AccountId { get; set; }
        public DateTime DepositDate { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}