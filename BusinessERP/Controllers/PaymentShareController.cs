using BusinessERP.ConHelper;
using BusinessERP.Data;
using BusinessERP.Helpers;
using BusinessERP.Models.CommonViewModel;
using BusinessERP.Models.EmailConfigViewModel;
using BusinessERP.Models.ReturnLogViewModel;
using BusinessERP.Models.SendEmailHistoryViewModel;
using BusinessERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessERP.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class PaymentShareController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _iCommon;
        private readonly ISalesService _iSalesService;
        private readonly IPaymentService _iDBOperation;
        private readonly IEmailSender _emailSender;
        private readonly IFunctional _iFunctional;

        public PaymentShareController(ApplicationDbContext context, ICommon iCommon, IPaymentService iPaymentService, ISalesService iSalesService, IEmailSender emailSender, IFunctional iFunctional)
        {
            _context = context;
            _iCommon = iCommon;
            _iSalesService = iSalesService;
            _iDBOperation = iPaymentService;
            _emailSender = emailSender;
            _iFunctional = iFunctional;
        }

        [Authorize(Roles = Pages.MainMenu.Invoice.RoleName)]
        [HttpGet]
        public IActionResult OpenSendMailPaymentInvoice(Int64 _PaymentId, Int64 _InvoiceDocType, Int64 _HideCompanyInfo)
        {
            ViewBag.GetddlEmailConfig = new SelectList(_iCommon.GetddlEmailConfig(), "Id", "Name");
            ViewBag.GetddlUserEmail = new SelectList(_iCommon.GetddlCustomerEmail(), "Id", "Name");

            SendEmailViewModel _SendEmailViewModel = new();
            var _Payment = _context.Payment.FirstOrDefault(x => x.Id == _PaymentId);
            _SendEmailViewModel.InvoiceId = _Payment.Id;
            _SendEmailViewModel.ReceiverEmailId = _Payment.CustomerId;

            _SendEmailViewModel.Subject = EmailContent.Subject;
            _SendEmailViewModel.Body = EmailContent.Body;

            _SendEmailViewModel.IsHideCompanyInfo = _HideCompanyInfo;
            _SendEmailViewModel.InvoiceDocType = _InvoiceDocType;
            return PartialView("_Share", _SendEmailViewModel);
        }
        [HttpPost]
        public async Task<JsonResult> SendMailPaymentInvoice(SendEmailViewModel vm)
        {
            JsonResultViewModel _JsonResultViewModel = new();
            SendEmailHistoryCRUDViewModel _SendEmailHistoryCRUDViewModel = new();
            try
            {
                var _PrintPaymentInvoice = await _iSalesService.PrintPaymentInvoice(vm.InvoiceId);
                _PrintPaymentInvoice.SendEmailViewModel = vm;

                EmailConfigCRUDViewModel _EmailConfigCRUDViewModel = await _context.EmailConfig.FindAsync(vm.SenderEmailId);
                SendEmailViewModel _SendEmailViewModel = _EmailConfigCRUDViewModel;
                _SendEmailViewModel.Subject = vm.Subject;
                _SendEmailViewModel.Body = vm.Body;
                _SendEmailViewModel.ReceiverEmail = vm.ReceiverEmail;
                _SendEmailViewModel.IsSSL = _EmailConfigCRUDViewModel.SSLEnabled;


                var _FileName = "Invoice_" + vm.InvoiceId + "_" + DateTime.Now + ".pdf";
                byte[] pdfBytes = _iSalesService.GetInvoiceReportPdfBytes(vm.pdfDataUri).Item1;
                Stream _Stream = new MemoryStream(pdfBytes);
                _SendEmailViewModel.FileStream = _Stream;
                _SendEmailViewModel.FileName = _FileName;
                _SendEmailViewModel.FileType = "content/pdf";
                var result = await _emailSender.SendEmailByGmailAsync(_SendEmailViewModel);

                _SendEmailHistoryCRUDViewModel.InvoiceId = vm.InvoiceId;
                _SendEmailHistoryCRUDViewModel.SenderEmail = _SendEmailViewModel.SenderEmail;
                _SendEmailHistoryCRUDViewModel.ReceiverEmail = _SendEmailViewModel.ReceiverEmail;
                _SendEmailHistoryCRUDViewModel.UserName = HttpContext.User.Identity.Name;

                if (result.Status == TaskStatus.RanToCompletion)
                {
                    //await AddDocumentHistory(vm.Id, _Document.AssignEmployeeId, "Document Shared Using Email.");
                    _JsonResultViewModel.AlertMessage = "Email Send Successfully. Invoice Id: " + vm.InvoiceId;
                    _JsonResultViewModel.Id = vm.InvoiceId;
                    _SendEmailHistoryCRUDViewModel.Result = "Success";
                }
                else
                {
                    _JsonResultViewModel.AlertMessage = "Email Send Failed. Status: " + result.Status;
                    _SendEmailHistoryCRUDViewModel.Result = "Failed, status: " + result.Status;
                }

                var objUser = _iFunctional.GetSharedTenantData(User).Result;
                _SendEmailHistoryCRUDViewModel.TenantId = objUser.TenantId ?? 0;

                await _iDBOperation.AddSendEmailHistory(_SendEmailHistoryCRUDViewModel);
                return new JsonResult(_JsonResultViewModel);
            }
            catch (Exception ex)
            {
                Syslog.Write(Syslog.Level.Warning, "BusinessERPCustomlog", ex.Message);
                _JsonResultViewModel.IsSuccess = false;
                _JsonResultViewModel.AlertMessage = ex.Message;
                _SendEmailHistoryCRUDViewModel.Result = "Failed, status: " + ex.Message;
                var objUser = _iFunctional.GetSharedTenantData(User).Result;
                _SendEmailHistoryCRUDViewModel.TenantId = objUser.TenantId ?? 0;
                await _iDBOperation.AddSendEmailHistory(_SendEmailHistoryCRUDViewModel);
                return new JsonResult(_JsonResultViewModel);
                throw;
            }
        }
    }
}
