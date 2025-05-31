using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessERP.Models
{
    /// <summary>
    /// Represents a Tenant in the system.
    /// A tenant is a isolated customer for the application
    /// which has it's own users, roles and other application entities.
    /// </summary>
    public class Tenant : EntityBase
    {
        public Int64 TenantId { get; set; }
        public const int MaxLogoMimeTypeLength = 64;

        public string FullName { get; set; }
        public string TenancyName { get; set; }
        public DateTime? SubscriptionEndDateUtc { get; set; }
        public bool IsActive { get; set; }
        public bool IsInTrialPeriod { get; set; }

        public virtual Guid? CustomCssId { get; set; }

        public virtual Guid? LogoId { get; set; }


        public Tenant()
        {

        }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EInvoiceCompanyID { get; set; }
        public string EInvoiceRegistrationName { get; set; }
        public string FatoraClientId { get; set; }
        public string FatoraSecretKey { get; set; }
        public string FatoraIncomeSource { get; set; }
        public string FatoraClientType { get; set; }

 
    }
}