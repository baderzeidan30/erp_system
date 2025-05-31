using System.ComponentModel.DataAnnotations;

namespace BusinessERP.Models.TenantViewModel
{
    public class TenantCRUDViewModel : EntityBase
    {
        [Display(Name = "SL")]
        [Required]
        public Int64 TenantId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Tenancy Name")]
        public string TenancyName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string FaxNumber { get; set; }
        [Required]
        public string EInvoiceCompanyID { get; set; }
        [Required]
        public string EInvoiceRegistrationName { get; set; }
        [Required]
        public string FatoraClientId { get; set; }
        [Required]
        public string FatoraSecretKey { get; set; }
        [Required]
        public string FatoraIncomeSource { get; set; }
        [Required]
        public string FatoraClientType { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CurrentURL { get; set; }
        public bool IsActive { get; set; }
        public bool IsInTrialPeriod { get; set; }
        public static implicit operator TenantCRUDViewModel(Tenant _Tenant)
        {
            return new TenantCRUDViewModel
            {
                TenantId = _Tenant.TenantId,
                FullName = _Tenant.FullName,
                TenancyName = _Tenant.TenancyName,
                IsActive=_Tenant.IsActive,
                IsInTrialPeriod = _Tenant.IsInTrialPeriod,
                City = _Tenant.City,
                State = _Tenant.State,
                ZipCode = _Tenant.ZipCode,
                FaxNumber = _Tenant.FaxNumber,
                EInvoiceCompanyID = _Tenant.EInvoiceCompanyID,
                PhoneNumber = _Tenant.PhoneNumber,
                Address1 = _Tenant.Address1,
                Address2 = _Tenant.Address2,
                EInvoiceRegistrationName = _Tenant.EInvoiceRegistrationName,
                FatoraClientId = _Tenant.FatoraClientId,
                FatoraSecretKey = _Tenant.FatoraSecretKey,
                FatoraIncomeSource = _Tenant.FatoraIncomeSource,
                FatoraClientType = _Tenant.FatoraClientType,

                CreatedDate = _Tenant.CreatedDate,
                ModifiedDate = _Tenant.ModifiedDate,
                CreatedBy = _Tenant.CreatedBy,
                ModifiedBy = _Tenant.ModifiedBy,
                Cancelled = _Tenant.Cancelled,
            };
        }

        public static implicit operator Tenant(TenantCRUDViewModel vm)
        {
            return new Tenant
            {
                TenantId = vm.TenantId,
                FullName = vm.FullName,
                TenancyName = vm.TenancyName,
                IsActive=vm.IsActive,
                IsInTrialPeriod=vm.IsInTrialPeriod,
                City = vm.City,
                PhoneNumber = vm.PhoneNumber,
                Address1 = vm.Address1,
                Address2 = vm.Address2, 
                State = vm.State,
                ZipCode = vm.ZipCode,
                FaxNumber = vm.FaxNumber,
                EInvoiceCompanyID = vm.EInvoiceCompanyID,
                EInvoiceRegistrationName = vm.EInvoiceRegistrationName,
                FatoraClientId = vm.FatoraClientId,
                FatoraSecretKey = vm.FatoraSecretKey,
                FatoraIncomeSource = vm.FatoraIncomeSource,
                FatoraClientType = vm.FatoraClientType,
                CreatedDate = vm.CreatedDate,
                ModifiedDate = vm.ModifiedDate,
                CreatedBy = vm.CreatedBy,
                ModifiedBy = vm.ModifiedBy,
                Cancelled = vm.Cancelled,
            };
        }
    }
}
