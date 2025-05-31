using System;

namespace BusinessERP.Models.TenantViewModel
{
    public class TenantGridViewModel : EntityBase
    {
        public Int64 Id { get; set; }
        public string FullName { get; set; }
        public string TenancyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


    }
}

