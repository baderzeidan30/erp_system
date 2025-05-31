using System;

namespace BusinessERP.Models
{
    public class DamageItemDeatils : EntityBase
    {
        public Int64 Id { get; set; }
        public Int64 ItemId { get; set; }
        public int TotalDamageItem { get; set; }
        public string ReasonOfDamage { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
