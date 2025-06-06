﻿using System;

namespace BusinessERP.Models
{
    public class Attendance: EntityBase
    {
        public Int64 Id { get; set; }
        public Int64 EmployeeId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public TimeSpan StayTime { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}