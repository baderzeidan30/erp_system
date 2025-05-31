using BusinessERP.Data;
using BusinessERP.Models;
using BusinessERP.Models.CommonViewModel;
using BusinessERP.Models.TenantViewModel;
using BusinessERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace BusinessERP.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TenantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _iCommon;

        public TenantController(ApplicationDbContext context, ICommon iCommon)
        {
            _context = context;
            _iCommon = iCommon;
        }

        [Authorize(Roles = Pages.MainMenu.Tenant.RoleName)]
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

                var _GetGridItem = GetGridItem();
                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnAscDesc)))
                {
                    _GetGridItem = _GetGridItem.OrderBy(sortColumn + " " + sortColumnAscDesc);
                }

                //Search
                if (!string.IsNullOrEmpty(searchValue))
                {
                    searchValue = searchValue.ToLower();
                    _GetGridItem = _GetGridItem.Where(obj => obj.TenantId.ToString().Contains(searchValue)
                    || obj.FullName.ToLower().Contains(searchValue)
                    || obj.TenancyName.ToLower().Contains(searchValue)
       
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

        private IQueryable<TenantCRUDViewModel> GetGridItem()
        {
            try
            {
                return (from _Tenant in _context.Tenant
                        where _Tenant.Cancelled == false
                        select new TenantCRUDViewModel
                        {
                            TenantId = _Tenant.TenantId,
                            FullName = _Tenant.FullName,
                            TenancyName = _Tenant.TenancyName,
                            City = _Tenant.City,
                            State = _Tenant.State,
                            PhoneNumber = _Tenant.PhoneNumber,
                            CreatedDate = _Tenant.CreatedDate,

                        }).OrderByDescending(x => x.TenantId);
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
            TenantCRUDViewModel vm = await _context.Tenant.FirstOrDefaultAsync(m => m.TenantId == id);
            if (vm == null) return NotFound();
            return PartialView("_Details", vm);
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            TenantCRUDViewModel vm = new TenantCRUDViewModel();
            if (id > 0) vm = await _context.Tenant.Where(x => x.TenantId == id).FirstOrDefaultAsync();
            return PartialView("_AddEdit", vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(TenantCRUDViewModel vm)
        {
            JsonResultViewModel _JsonResultViewModel = new();
            try
            {
                Tenant _Tenant = new();
                if (vm.TenantId > 0)
                {
                    _Tenant = await _context.Tenant.FindAsync(vm.TenantId);

                    vm.CreatedDate = _Tenant.CreatedDate;
                    vm.CreatedBy = _Tenant.CreatedBy;
                    vm.ModifiedDate = DateTime.Now;
                    vm.ModifiedBy = HttpContext.User.Identity.Name;
                    _context.Entry(_Tenant).CurrentValues.SetValues(vm);
                    await _context.SaveChangesAsync();
                    _JsonResultViewModel.AlertMessage = "Tenant Updated Successfully. ID: " + _Tenant.TenantId;
                }
                else
                {
                    _Tenant = vm;
                    _Tenant.CreatedDate = DateTime.Now;
                    _Tenant.ModifiedDate = DateTime.Now;
                    _Tenant.CreatedBy = HttpContext.User.Identity.Name;
                    _Tenant.ModifiedBy = HttpContext.User.Identity.Name;
                    _context.Add(_Tenant);
                    await _context.SaveChangesAsync();

                    vm.TenantId = _Tenant.TenantId;
                    _JsonResultViewModel.AlertMessage = "Tenant Created Successfully. ID: " + _Tenant.TenantId;
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
                var _Tenant = await _context.Tenant.FindAsync(id);
                _Tenant.ModifiedDate = DateTime.Now;
                _Tenant.ModifiedBy = HttpContext.User.Identity.Name;
                _Tenant.Cancelled = true;

                _context.Update(_Tenant);
                await _context.SaveChangesAsync();
                return new JsonResult(_Tenant);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
