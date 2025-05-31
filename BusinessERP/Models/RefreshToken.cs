using System;

namespace BusinessERP.Models
{
    public class RefreshToken : EntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevorked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
        //[ForeignKey(nameof(UserId))]
        //public IdentityUser User {get;set;}
    }
}