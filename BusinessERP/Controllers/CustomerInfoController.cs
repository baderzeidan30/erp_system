using BusinessERP.Data;
using BusinessERP.Models;
using BusinessERP.Models.CommonViewModel;
using BusinessERP.Models.CustomerInfoViewModel;
using BusinessERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace BusinessERP.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class CustomerInfoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _iCommon;
        private readonly ISalesService _iSalesService;
        private readonly IFunctional _iFunctional;
        public CustomerInfoController(ApplicationDbContext context, ICommon iCommon, ISalesService iSalesService, IFunctional iFunctional)
        {
            _context = context;
            _iCommon = iCommon;
            _iSalesService = iSalesService;
            _iFunctional = iFunctional;
        }

        [Authorize(Roles = Pages.MainMenu.CustomerInfo.RoleName)]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetDataTabelData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();

                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnAscDesc = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int resultTotal = 0;

                var objUser = _iFunctional.GetSharedTenantData(User).Result;
                Int64 LoginTenantId = objUser.TenantId ?? 0;
                var _GetGridItem = _iCommon.GetCustomerList(LoginTenantId);
                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnAscDesc)))
                {
                    _GetGridItem = _GetGridItem.OrderBy(sortColumn + " " + sortColumnAscDesc);
                }

                //Search
                if (!string.IsNullOrEmpty(searchValue))
                {
                    searchValue = searchValue.ToLower();
                    _GetGridItem = _GetGridItem.Where(obj => obj.Id.ToString().Contains(searchValue)
                    || obj.Name.ToLower().Contains(searchValue)
                    || obj.Phone.ToLower().Contains(searchValue)
                    || obj.Email.ToLower().Contains(searchValue)
                    || obj.BillingAddress.ToLower().Contains(searchValue)
                    || obj.CreatedDate.ToString().Contains(searchValue));
                }

                resultTotal = _GetGridItem.Count();

                var result = _GetGridItem.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = resultTotal, recordsTotal = resultTotal, data = result });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Int64 id)
        {
            var objUser = _iFunctional.GetSharedTenantData(User).Result;
            Int64 LoginTenantId = objUser.TenantId ?? 0;
            CustomerInfoCRUDViewModel vm = await _iCommon.GetCustomerList(LoginTenantId).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (vm == null) return NotFound();
            return PartialView("_Details", vm);
        }
        [HttpGet]
        public IActionResult CustomerTranHistory(long? id)
        {
            if (id == null) return NotFound();
            var objUser = _iFunctional.GetSharedTenantData(User).Result;
            Int64 LoginTenantId = objUser.TenantId ?? 0;
            var result = _iSalesService.GetPaymentGridData(LoginTenantId).Where(x => x.CustomerId == id);
            if (result == null) return NotFound();
            return PartialView("_CustomerTranHistory", result);
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            CustomerInfoCRUDViewModel vm = new CustomerInfoCRUDViewModel();
            ViewBag.GetddlCustomerType = new SelectList(_iCommon.GetddlCustomerType(), "Id", "Name");
            if (id > 0) vm = await _context.CustomerInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
            return PartialView("_AddEdit", vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(CustomerInfoCRUDViewModel vm)
        {
            JsonResultViewModel _JsonResultViewModel = new();

            var objUser = _iFunctional.GetSharedTenantData(User).Result;
            Int64 LoginTenantId = objUser.TenantId ?? 0;
            try
            {
                if (vm.UseThisAsBillingAddress)
                {
                    vm.BillingAddress = vm.Address;
                    vm.BillingAddressPostcode = vm.AddressPostcode;
                }

                CustomerInfo _CustomerInfoInfo = new();
                if (vm.Id > 0)
                {
                    _CustomerInfoInfo = await _context.CustomerInfo.FindAsync(vm.Id);

                    vm.CreatedDate = _CustomerInfoInfo.CreatedDate;
                    vm.CreatedBy = _CustomerInfoInfo.CreatedBy;
                    vm.ModifiedDate = DateTime.Now;
                    vm.ModifiedBy = HttpContext.User.Identity.Name;
                    _context.Entry(_CustomerInfoInfo).CurrentValues.SetValues(vm);
                    if (LoginTenantId > 0) _CustomerInfoInfo.TenantId = LoginTenantId;
                    await _context.SaveChangesAsync();

                    _JsonResultViewModel.Id = _CustomerInfoInfo.Id;
                    _JsonResultViewModel.IsSuccess = true;
                    _JsonResultViewModel.AlertMessage = "Customer Info Updated Successfully. ID: " + _CustomerInfoInfo.Id;
                    return new JsonResult(_JsonResultViewModel);
                }
                else
                {
                    //Check Duplicate: Phone and Email
                    var _CheckCompanyPhone = await CheckCompanyPhone(vm.Phone);
                    var _CheckCompanyEmail = await CheckCompanyEmail(vm.Email);
                    if (_CheckCompanyPhone == true)
                    {
                        _JsonResultViewModel.IsSuccess = false;
                        _JsonResultViewModel.AlertMessage = "Phone Number Already Exist. Phone: " + vm.Phone;
                        return new JsonResult(_JsonResultViewModel);
                    }
                    if (_CheckCompanyEmail == true)
                    {
                        _JsonResultViewModel.IsSuccess = false;
                        _JsonResultViewModel.AlertMessage = "Email Address Already Exist. Email: " + vm.Email;
                        return new JsonResult(_JsonResultViewModel);
                    }

                    _CustomerInfoInfo = vm;
                    _CustomerInfoInfo.CreatedDate = DateTime.Now;
                    _CustomerInfoInfo.ModifiedDate = DateTime.Now;
                    _CustomerInfoInfo.CreatedBy = HttpContext.User.Identity.Name;
                    _CustomerInfoInfo.ModifiedBy = HttpContext.User.Identity.Name;
                    if (LoginTenantId > 0) _CustomerInfoInfo.TenantId = LoginTenantId;
                    _context.Add(_CustomerInfoInfo);
                    await _context.SaveChangesAsync();

                    _JsonResultViewModel.Id = _CustomerInfoInfo.Id;
                    _JsonResultViewModel.IsSuccess = true;
                    _JsonResultViewModel.AlertMessage = "Customer Info Created Successfully. ID: " + _CustomerInfoInfo.Id;
                    return new JsonResult(_JsonResultViewModel);
                }
            }
            catch (Exception ex)
            {
                _JsonResultViewModel.IsSuccess = false;
                _JsonResultViewModel.AlertMessage = ex.Message;
                return new JsonResult(_JsonResultViewModel);
                throw;
            }
        }

        [HttpGet]
        public JsonResult GetAllCustomerForDDL()
        {
            try
            {
                var _LoadddlCustomerInfo = _iCommon.LoadddlCustomerInfo();
                ViewBag._LoadddlCustomerInfo = new SelectList(_iCommon.LoadddlCustomerInfo(), "Id", "Name");
                return new JsonResult(_LoadddlCustomerInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(Int64 id)
        {
            try
            {
                var _CustomerInfoInfo = await _context.CustomerInfo.FindAsync(id);
                _CustomerInfoInfo.ModifiedDate = DateTime.Now;
                _CustomerInfoInfo.ModifiedBy = HttpContext.User.Identity.Name;
                _CustomerInfoInfo.Cancelled = true;

                _context.Update(_CustomerInfoInfo);
                await _context.SaveChangesAsync();
                return new JsonResult(_CustomerInfoInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<bool> CheckCompanyPhone(string _Phone)
        {
            bool result = false;
            if (_Phone == null)
            {
                return result;
            }
            else
            {
                var _CustomerInfo = await _context.CustomerInfo.Where(x => x.Phone.Contains(_Phone.Trim())).ToListAsync();
                if (_CustomerInfo.Count > 0)
                    result = true;
                return result;
            }
        }
        private async Task<bool> CheckCompanyEmail(string _Email)
        {
            bool result = false;
            if (_Email == null)
            {
                return result;
            }
            else
            {
                var _CustomerInfo = await _context.CustomerInfo.Where(x => x.Email.Contains(_Email.Trim())).ToListAsync();
                if (_CustomerInfo.Count > 0)
                    result = true;
                return result;
            }
        }
    }
}
