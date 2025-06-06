using BusinessERP.Data;
using BusinessERP.Models;
using BusinessERP.Models.CommonViewModel;
using BusinessERP.Models.SupplierViewModel;
using BusinessERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using static BusinessERP.Pages.MainMenu;
using Supplier = BusinessERP.Models.Supplier;

namespace BusinessERP.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _iCommon;
        private readonly IFunctional _iFunctional;

        public SupplierController(ApplicationDbContext context, ICommon iCommon, IFunctional iFunctional)
        {
            _context = context;
            _iCommon = iCommon;
            _iFunctional = iFunctional;
        }

        [Authorize(Roles = Pages.MainMenu.Supplier.RoleName)]
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
                var _GetGridItem = GetGridItem(LoginTenantId);
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
                    || obj.ContactPerson.ToLower().Contains(searchValue)
                    || obj.Email.ToLower().Contains(searchValue)
                    || obj.Phone.ToLower().Contains(searchValue)
                    || obj.Address.ToLower().Contains(searchValue)
                    || obj.CreatedDate.ToString().ToLower().Contains(searchValue)

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

        private IQueryable<SupplierCRUDViewModel> GetGridItem(Int64 tenantId)
        {
            try
            {
                return (from _Supplier in _context.Supplier
                where _Supplier.Cancelled == false
                && ((_Supplier.TenantId == tenantId && tenantId > 0) || (tenantId == 0 && !_Supplier.TenantId.HasValue))
                select new SupplierCRUDViewModel
                {
                            Id = _Supplier.Id,
                            Name = _Supplier.Name,
                            ContactPerson = _Supplier.ContactPerson,
                            Email = _Supplier.Email,
                            Phone = _Supplier.Phone,
                            Address = _Supplier.Address,
                            CreatedDate = _Supplier.CreatedDate,

                        }).OrderByDescending(x => x.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();
            SupplierCRUDViewModel vm = await _context.Supplier.FirstOrDefaultAsync(m => m.Id == id);
            if (vm == null) return NotFound();
            return PartialView("_Details", vm);
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            SupplierCRUDViewModel vm = new SupplierCRUDViewModel();
            if (id > 0) vm = await _context.Supplier.Where(x => x.Id == id).FirstOrDefaultAsync();
            return PartialView("_AddEdit", vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(SupplierCRUDViewModel vm)
        {
            JsonResultViewModel _JsonResultViewModel = new();
            try
            {
                Supplier _Supplier = new();
                if (vm.Id > 0)
                {
                    _Supplier = await _context.Supplier.FindAsync(vm.Id);

                    vm.CreatedDate = _Supplier.CreatedDate;
                    vm.CreatedBy = _Supplier.CreatedBy;
                    vm.ModifiedDate = DateTime.Now;
                    vm.ModifiedBy = HttpContext.User.Identity.Name;
                    _context.Entry(_Supplier).CurrentValues.SetValues(vm);
                    await _context.SaveChangesAsync();
                    _JsonResultViewModel.AlertMessage = "Supplier Updated Successfully. ID: " + _Supplier.Id;
                }
                else
                {
                    _Supplier = vm;
                    _Supplier.CreatedDate = DateTime.Now;
                    _Supplier.ModifiedDate = DateTime.Now;
                    _Supplier.CreatedBy = HttpContext.User.Identity.Name;
                    _Supplier.ModifiedBy = HttpContext.User.Identity.Name;
                    _context.Add(_Supplier);
                    await _context.SaveChangesAsync();

                    vm.Id = _Supplier.Id;
                    _JsonResultViewModel.AlertMessage = "Supplier Created Successfully. ID: " + _Supplier.Id;
                }

                _JsonResultViewModel.IsSuccess = true;
                _JsonResultViewModel.CurrentURL = vm.CurrentURL;
                return new JsonResult(_JsonResultViewModel);
            }
            catch (Exception ex)
            {
                _JsonResultViewModel.IsSuccess = false;
                _JsonResultViewModel.AlertMessage = ex.Message;
                return new JsonResult(_JsonResultViewModel);
                throw;
            }
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(Int64 id)
        {
            try
            {
                var _Supplier = await _context.Supplier.FindAsync(id);
                _Supplier.ModifiedDate = DateTime.Now;
                _Supplier.ModifiedBy = HttpContext.User.Identity.Name;
                _Supplier.Cancelled = true;

                _context.Update(_Supplier);
                await _context.SaveChangesAsync();
                return new JsonResult(_Supplier);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
