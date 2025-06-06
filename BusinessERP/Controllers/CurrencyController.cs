using BusinessERP.Data;
using BusinessERP.Models;
using BusinessERP.Models.CurrencyViewModel;
using BusinessERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace BusinessERP.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class CurrencyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurrencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = Pages.MainMenu.Currency.RoleName)]
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
                    _GetGridItem = _GetGridItem.Where(obj => obj.Id.ToString().Contains(searchValue)
                    || obj.Name.ToLower().Contains(searchValue)
                    || obj.Code.ToLower().Contains(searchValue)
                    || obj.Symbol.ToLower().Contains(searchValue)
                    || obj.Country.ToLower().Contains(searchValue)
                    || obj.Description.ToLower().Contains(searchValue)

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

        private IQueryable<CurrencyCRUDViewModel> GetGridItem()
        {
            try
            {
                var result = (from _Currency in _context.Currency
                              where _Currency.Cancelled == false
                              select new CurrencyCRUDViewModel
                              {
                                  Id = _Currency.Id,
                                  Name = _Currency.Name,
                                  Code = _Currency.Code,
                                  Symbol = _Currency.Symbol,
                                  Country = _Currency.Country,
                                  Description = _Currency.Description,
                                  IsDefaultDisplay = _Currency.IsDefault == true ? "Yes" : "No",
                                  CreatedDate = _Currency.CreatedDate,
                              }).OrderByDescending(x => x.Id);

                return result;
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
            CurrencyCRUDViewModel vm = await _context.Currency.FirstOrDefaultAsync(m => m.Id == id);
            if (vm == null) return NotFound();
            return PartialView("_Details", vm);
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            CurrencyCRUDViewModel vm = new();
            if (id > 0) vm = await _context.Currency.Where(x => x.Id == id).FirstOrDefaultAsync();
            return PartialView("_AddEdit", vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(CurrencyCRUDViewModel vm)
        {
            try
            {
                Currency _Currency = new();
                if (vm.Id > 0)
                {
                    _Currency = await _context.Currency.FindAsync(vm.Id);

                    vm.IsDefault = _Currency.IsDefault;
                    vm.CreatedDate = _Currency.CreatedDate;
                    vm.CreatedBy = _Currency.CreatedBy;
                    vm.ModifiedDate = DateTime.Now;
                    vm.ModifiedBy = HttpContext.User.Identity.Name;
                    _context.Entry(_Currency).CurrentValues.SetValues(vm);
                    await _context.SaveChangesAsync();

                    var _AlertMessage = "Currency Updated Successfully. ID: " + _Currency.Id;
                    return new JsonResult(_AlertMessage);
                }
                else
                {
                    _Currency = vm;
                    _Currency.CreatedDate = DateTime.Now;
                    _Currency.ModifiedDate = DateTime.Now;
                    _Currency.CreatedBy = HttpContext.User.Identity.Name;
                    _Currency.ModifiedBy = HttpContext.User.Identity.Name;
                    _context.Add(_Currency);
                    await _context.SaveChangesAsync();

                    var _AlertMessage = "Currency Created Successfully. ID: " + _Currency.Id;
                    return new JsonResult(_AlertMessage);
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(Int64 id)
        {
            try
            {
                var _Currency = await _context.Currency.FindAsync(id);
                _Currency.ModifiedDate = DateTime.Now;
                _Currency.ModifiedBy = HttpContext.User.Identity.Name;
                _Currency.Cancelled = true;

                _context.Update(_Currency);
                await _context.SaveChangesAsync();
                return new JsonResult(_Currency);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
