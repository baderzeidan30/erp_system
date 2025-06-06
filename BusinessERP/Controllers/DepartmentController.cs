using BusinessERP.Data;
using BusinessERP.Models;
using BusinessERP.Models.DepartmentViewModel;
using BusinessERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BusinessERP.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _iCommon;

        public DepartmentController(ApplicationDbContext context, ICommon iCommon)
        {
            _context = context;
            _iCommon = iCommon;
        }

        [Authorize(Roles = Pages.MainMenu.Department.RoleName)]
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

        private IQueryable<DepartmentGridViewModel> GetGridItem()
        {
            try
            {
                return (from _Department in _context.Department
                        where _Department.Cancelled == false
                        select new DepartmentGridViewModel
                        {
                            Id = _Department.Id,
                            Name = _Department.Name,
                            Description = _Department.Description,
                            CreatedDate = _Department.CreatedDate,                           
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
            DepartmentCRUDViewModel vm = await _context.Department.FirstOrDefaultAsync(m => m.Id == id);
            if (vm == null) return NotFound();
            return PartialView("_Details", vm);
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            DepartmentCRUDViewModel vm = new DepartmentCRUDViewModel();
            if (id > 0) vm = await _context.Department.Where(x => x.Id == id).FirstOrDefaultAsync();
            return PartialView("_AddEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(DepartmentCRUDViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Department _Department = new Department();
                        if (vm.Id > 0)
                        {
                            _Department = await _context.Department.FindAsync(vm.Id);

                            vm.CreatedDate = _Department.CreatedDate;
                            vm.CreatedBy = _Department.CreatedBy;
                            vm.ModifiedDate = DateTime.Now;
                            vm.ModifiedBy = HttpContext.User.Identity.Name;
                            _context.Entry(_Department).CurrentValues.SetValues(vm);
                            await _context.SaveChangesAsync();
                            TempData["successAlert"] = "Department Updated Successfully. ID: " + _Department.Id;
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            _Department = vm;
                            _Department.CreatedDate = DateTime.Now;
                            _Department.ModifiedDate = DateTime.Now;
                            _Department.CreatedBy = HttpContext.User.Identity.Name;
                            _Department.ModifiedBy = HttpContext.User.Identity.Name;
                            _context.Add(_Department);
                            await _context.SaveChangesAsync();
                            TempData["successAlert"] = "Department Created Successfully. ID: " + _Department.Id;
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    TempData["errorAlert"] = "Operation failed.";
                    return View("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                var _Department = await _context.Department.FindAsync(id);
                _Department.ModifiedDate = DateTime.Now;
                _Department.ModifiedBy = HttpContext.User.Identity.Name;
                _Department.Cancelled = true;

                _context.Update(_Department);
                await _context.SaveChangesAsync();
                return new JsonResult(_Department);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsExists(long id)
        {
            return _context.Department.Any(e => e.Id == id);
        }
    }
}
