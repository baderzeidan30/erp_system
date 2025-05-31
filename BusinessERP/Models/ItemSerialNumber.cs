﻿using System;

namespace BusinessERP.Models
{
    public class ItemSerialNumber : EntityBase
    {
        public Int64 Id { get; set; }
        public Int64 PaymentDetailId { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
