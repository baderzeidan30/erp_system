using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace BusinessERP.Models
{
    public class SendEmailHistory : EntityBase
    {
        public Int64 Id { get; set; }
        public Int64 InvoiceId { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string Result { get; set; }
        public Int64? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
