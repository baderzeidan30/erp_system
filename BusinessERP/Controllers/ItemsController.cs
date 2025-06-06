﻿using BusinessERP.Data;
using BusinessERP.Helpers;
using BusinessERP.Models;
using BusinessERP.Models.CommonViewModel;
using BusinessERP.Models.ItemsHistoryViewModel;
using BusinessERP.Models.ItemsViewModel;
using BusinessERP.Services;
using LumenWorks.Framework.IO.Csv;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Linq.Dynamic.Core;

namespace BusinessERP.Controllers
{
    //[Authorize]
    [Route("[controller]/[action]")]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _iCommon;
        private readonly IWebHostEnvironment _iHostingEnvironment;

        public ItemsController(ApplicationDbContext context, ICommon iCommon, IWebHostEnvironment iHostingEnvironment)
        {
            _context = context;
            _iCommon = iCommon;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [Authorize(Roles = Pages.MainMenu.Items.RoleName)]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetDataTabelData()
        {
            return GetItemGridList(false, false);
        }

        [Authorize(Roles = Pages.MainMenu.OutOfStock.RoleName)]
        [HttpGet]
        public IActionResult OutofStockItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetOutofStockItem()
        {
            return GetItemGridList(true, false);
        }
        [Authorize(Roles = Pages.MainMenu.LowInStock.RoleName)]
        [HttpGet]
        public IActionResult LowInStockItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetLowInStock()
        {
            return GetItemGridList(false, true);
        }
        [HttpPost]
        private IActionResult GetItemGridList(bool IsOutOfStock, bool IsLowInStock)
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

                var _GetGridItem = _iCommon.GetItemsGridList();

                if (IsOutOfStock)
                    _GetGridItem = _GetGridItem.Where(x => x.Quantity < 1);
                else if (IsLowInStock)
                    _GetGridItem = _GetGridItem.Where(x => x.Quantity > 0).OrderBy(x => x.Quantity);
                else
                {
                    _GetGridItem = _GetGridItem.Where(x => x.Quantity > 0);
                    //Sorting
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnAscDesc)))
                    {
                        _GetGridItem = _GetGridItem.OrderBy(sortColumn + " " + sortColumnAscDesc);
                    }
                }


                //Search
                if (!string.IsNullOrEmpty(searchValue))
                {
                    searchValue = searchValue.ToLower();
                    _GetGridItem = _GetGridItem.Where(obj => obj.Id.ToString().Contains(searchValue)
                    || obj.Name.ToLower().Contains(searchValue)
                    || obj.Code.ToLower().Contains(searchValue)
                    || obj.StockKeepingUnit.ToLower().Contains(searchValue)
                    || obj.CategoriesDisplay.ToLower().Contains(searchValue)
                    || obj.SupplierDisplay.ToLower().Contains(searchValue)
                    || obj.MeasureDisplay.ToLower().Contains(searchValue)
                    || obj.CostPrice.ToString().Contains(searchValue)
                    || obj.NormalPrice.ToString().Contains(searchValue)
                    || obj.Quantity.ToString().Contains(searchValue)
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
        public IActionResult ViewItem(Int64 Id)
        {
            var result = _iCommon.GetViewItemById(Id);
            return PartialView("_ItemInfo", result);
        }

        [HttpGet]
        public IActionResult AddEdit(Int64 id)
        {
            LoadddlItems();
            ItemsCRUDViewModel _ItemCRUDViewModel = new();
            if (id > 0)
            {
                _ItemCRUDViewModel = _context.Items.Find(id);
            }
            else
            {
                //_ItemCRUDViewModel = _context.Items.Where(x => x.Id == 17).FirstOrDefault();
                //_ItemCRUDViewModel.Id = 0;
                _ItemCRUDViewModel.Code = StaticData.RandomDigits(6);
                _ItemCRUDViewModel.ImageURL = "/upload/blank-item.png";
                //_ItemCRUDViewModel.Barcode = _Utility.GenerateBarCode(_ItemCRUDViewModel.Code);

            }

            //_ItemCRUDViewModel.VatPercentage = _context.VatPercentage.Where(x => x.IsDefault == true).FirstOrDefault().Percentage;
            return PartialView("_AddEdit", _ItemCRUDViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> AddEdit(ItemsCRUDViewModel _ItemCRUDViewModel)
        {
            JsonResultViewModel _JsonResultViewModel = new();
            try
            {
                ItemsHistoryCRUDViewModel _ItemHistoryCRUDViewModel = new ItemsHistoryCRUDViewModel();
                if (_ItemCRUDViewModel.Id > 0)
                {
                    var _OldItem = _context.Items.Where(x => x.Id == _ItemCRUDViewModel.Id).FirstOrDefault();
                    int _OldQuantity = _OldItem.Quantity;

                    if (_ItemCRUDViewModel.ImageURLDetails == null)
                    {
                        _ItemCRUDViewModel.ImageURL = _OldItem.ImageURL;
                    }
                    else
                    {
                        _ItemCRUDViewModel.ImageURL = "/upload/" + _iCommon.UploadedFile(_ItemCRUDViewModel.ImageURLDetails);
                    }

                    _ItemCRUDViewModel.OldUnitPrice = _OldItem.CostPrice;
                    _ItemCRUDViewModel.OldSellPrice = _OldItem.NormalPrice;
                    _ItemCRUDViewModel.ModifiedDate = DateTime.Now;
                    _ItemCRUDViewModel.ModifiedBy = HttpContext.User.Identity.Name;

                    _context.Entry(_OldItem).CurrentValues.SetValues(_ItemCRUDViewModel);
                    await _context.SaveChangesAsync();

                    _ItemHistoryCRUDViewModel = _ItemCRUDViewModel;
                    _ItemHistoryCRUDViewModel.Id = 0;
                    if (_OldQuantity > _ItemCRUDViewModel.Quantity)
                    {
                        _ItemHistoryCRUDViewModel.TranQuantity = _OldQuantity - _ItemCRUDViewModel.Quantity;
                        _ItemHistoryCRUDViewModel.Action = "Update Item with minus-" + _ItemCRUDViewModel.Name;
                    }
                    else if (_OldQuantity == _ItemCRUDViewModel.Quantity)
                    {
                        _ItemHistoryCRUDViewModel.TranQuantity = _ItemCRUDViewModel.Quantity - _OldQuantity;
                        _ItemHistoryCRUDViewModel.Action = "Update Item information only-" + _ItemCRUDViewModel.Name;
                    }
                    else
                    {
                        _ItemHistoryCRUDViewModel.TranQuantity = _ItemCRUDViewModel.Quantity - _OldQuantity;
                        _ItemHistoryCRUDViewModel.Action = "Update Item with addition-" + _ItemCRUDViewModel.Name;
                    }
                    _ItemHistoryCRUDViewModel.OldQuantity = _OldQuantity;
                    _ItemHistoryCRUDViewModel.NewQuantity = _ItemCRUDViewModel.Quantity;
                    ItemsHistory _ItemHistory = new ItemsHistory();
                    _ItemHistory = _ItemHistoryCRUDViewModel;
                    _context.Add(_ItemHistory);
                    await _context.SaveChangesAsync();

                    _JsonResultViewModel.AlertMessage = "Item Updated Successfully. Item Name: " + _ItemCRUDViewModel.Name;
                    _JsonResultViewModel.CurrentURL = _ItemCRUDViewModel.CurrentURL;
                    _JsonResultViewModel.IsSuccess = true;
                    return new JsonResult(_JsonResultViewModel);
                }
                else
                {
                    if (_ItemCRUDViewModel.Id == -1)
                        _ItemCRUDViewModel.Id = 0;
                    _ItemCRUDViewModel.CreatedDate = DateTime.Now;
                    _ItemCRUDViewModel.ModifiedDate = DateTime.Now;
                    _ItemCRUDViewModel.CreatedBy = HttpContext.User.Identity.Name;
                    _ItemCRUDViewModel.ModifiedBy = HttpContext.User.Identity.Name;

                    _ItemCRUDViewModel.OldUnitPrice = _ItemCRUDViewModel.CostPrice;
                    _ItemCRUDViewModel.OldSellPrice = _ItemCRUDViewModel.NormalPrice;
                    string _CurrentURL = _ItemCRUDViewModel.CurrentURL;

                    var _ImageURL = _iCommon.UploadedFile(_ItemCRUDViewModel.ImageURLDetails);
                    _ImageURL = _ImageURL != null ? _ImageURL : "blank-item.png";

                    _ItemCRUDViewModel.ImageURL = "/upload/" + _ImageURL;

                    Items _Item = new Items();
                    _Item = _ItemCRUDViewModel;
                    _context.Add(_Item);
                    await _context.SaveChangesAsync();

                    _ItemHistoryCRUDViewModel = _ItemCRUDViewModel;
                    _ItemHistoryCRUDViewModel.ItemId = _Item.Id;
                    _ItemHistoryCRUDViewModel.Id = 0;
                    _ItemHistoryCRUDViewModel.Action = "Create New Item-" + _ItemCRUDViewModel.Name;
                    _ItemHistoryCRUDViewModel.TranQuantity = 0;
                    _ItemHistoryCRUDViewModel.OldQuantity = _ItemCRUDViewModel.Quantity;
                    _ItemHistoryCRUDViewModel.NewQuantity = _ItemCRUDViewModel.Quantity;

                    _ItemHistoryCRUDViewModel.CreatedBy = "Admin";
                    _ItemHistoryCRUDViewModel.ModifiedBy = "Admin";
                    var result = await _iCommon.AddItemHistory(_ItemHistoryCRUDViewModel);

                    _JsonResultViewModel.AlertMessage = "Item Created Successfully. Item Name: " + _ItemCRUDViewModel.Name;
                    _JsonResultViewModel.CurrentURL = _ItemCRUDViewModel.CurrentURL;
                    _JsonResultViewModel.IsSuccess = true;
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
        public IActionResult UpdateQuantity(Int64 id)
        {
            ItemsCRUDViewModel _ItemCRUDViewModel = new ItemsCRUDViewModel();
            if (id > 0) _ItemCRUDViewModel = _context.Items.Find(id);
            return PartialView("_UpdateQuantity", _ItemCRUDViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUpdateQuantity(ItemsCRUDViewModel vm)
        {
            JsonResultViewModel _JsonResultViewModel = new();
            try
            {
                var _Item = _context.Items.Find(vm.Id);
                int _OldQuantity = _Item.Quantity;
                _Item.Quantity = _Item.Quantity + vm.AddNewQuantity;
                _Item.UpdateQntType = vm.UpdateQntType;
                _Item.UpdateQntNote = vm.UpdateQntNote;
                _Item.ModifiedDate = DateTime.Now;
                _Item.ModifiedBy = HttpContext.User.Identity.Name;
                _context.Update(_Item);
                await _context.SaveChangesAsync();

                int _AddNewQuantity = vm.AddNewQuantity;
                vm = _Item;
                ItemsHistoryCRUDViewModel _ItemHistoryCRUDViewModel = vm;
                _ItemHistoryCRUDViewModel.Action = "Update Quantity with addition-" + _Item.Name;


                _ItemHistoryCRUDViewModel.TranQuantity = _AddNewQuantity;
                _ItemHistoryCRUDViewModel.OldQuantity = _OldQuantity;
                _ItemHistoryCRUDViewModel.NewQuantity = _OldQuantity + _AddNewQuantity;

                ItemsHistory _ItemHistory = new();
                _ItemHistory = _ItemHistoryCRUDViewModel;
                _context.Add(_ItemHistory);
                await _context.SaveChangesAsync();
                _JsonResultViewModel.IsSuccess = true;
                _JsonResultViewModel.AlertMessage = "Item Quantity Updated Successfully. Item Name: " + _Item.Name;
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
        public async Task<IActionResult> Delete(Int64 id)
        {
            var _Item = _context.Items.Find(id);
            _Item.ModifiedDate = DateTime.Now;
            _Item.ModifiedBy = HttpContext.User.Identity.Name;
            _Item.Cancelled = true;
            _context.Update(_Item);
            await _context.SaveChangesAsync();

            ItemsHistoryCRUDViewModel _ItemHistoryCRUDViewModel = new ItemsHistoryCRUDViewModel();
            ItemsCRUDViewModel vm = _Item;
            _ItemHistoryCRUDViewModel = vm;
            _ItemHistoryCRUDViewModel.Action = "Delete";
            _ItemHistoryCRUDViewModel.TranQuantity = 0;
            _ItemHistoryCRUDViewModel.OldQuantity = vm.Quantity;
            _ItemHistoryCRUDViewModel.NewQuantity = vm.Quantity;

            ItemsHistory _ItemHistory = new ItemsHistory();
            _ItemHistory = _ItemHistoryCRUDViewModel;
            _context.Add(_ItemHistory);
            return new JsonResult(_Item);
        }

        [HttpGet]
        public IActionResult AddBulkItem()
        {
            return PartialView("_BulkItemAdd", new BulkItemViewModel());
        }

        [HttpPost]
        public async Task<JsonResult> SaveBulkItem(BulkItemViewModel _BulkItemViewModel)
        {
            try
            {
                //string filePath = Path.Combine(_iHostingEnvironment.ContentRootPath, "wwwroot/upload/BulkUploadItems/data.csv");
                var _DataTable = new DataTable();
                using (var _CsvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(_BulkItemViewModel.FilePath)), true))
                {
                    _DataTable.Load(_CsvReader);
                }
                var _LoadCSVItemDataMapping = LoadCSVItemDataMapping(_DataTable);

                Int64 TotalItemadded = 0;
                foreach (var item in _LoadCSVItemDataMapping)
                {
                    var result = _context.Items.Where(x => x.Code == item.Code).Count();
                    if (result < 1)
                    {
                        _context.Add(item);
                        await _context.SaveChangesAsync();
                        TotalItemadded++;
                    }
                }

                return new JsonResult(TotalItemadded);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<Items> LoadCSVItemDataMapping(DataTable _DataTable)
        {
            try
            {
                List<Items> _Items = new List<Items>();
                for (int i = 0; i < _DataTable.Rows.Count; i++)
                {
                    _Items.Add(new Items
                    {
                        //Id = Convert.ToInt64(_DataTable.Rows[i][0]),
                        Code = _DataTable.Rows[i][1].ToString(),
                        Name = _DataTable.Rows[i][2].ToString(),
                        OldUnitPrice = Convert.ToInt64(_DataTable.Rows[i][3].ToString()),
                        OldSellPrice = Convert.ToInt64(_DataTable.Rows[i][4].ToString()),
                        Quantity = Convert.ToInt16(_DataTable.Rows[i][5].ToString()),

                        CategoriesId = Convert.ToInt16(_DataTable.Rows[i][6].ToString()),
                        WarehouseId = Convert.ToInt16(_DataTable.Rows[i][7].ToString()),
                        SupplierId = Convert.ToInt64(_DataTable.Rows[i][8].ToString()),
                        MeasureId = Convert.ToInt64(_DataTable.Rows[i][9].ToString()),
                        MeasureValue = Convert.ToInt64(_DataTable.Rows[i][10].ToString()),
                        Note = _DataTable.Rows[i][11].ToString(),

                        //UpdateQntType = _DataTable.Rows[i][12].ToString(),
                        //UpdateQntNote = _DataTable.Rows[i][13].ToString(),
                        StockKeepingUnit = _DataTable.Rows[i][12].ToString(),
                        ManufactureDate = Convert.ToDateTime(_DataTable.Rows[i][13].ToString()),
                        ExpirationDate = Convert.ToDateTime(_DataTable.Rows[i][14].ToString()),
                        Barcode = _DataTable.Rows[i][15].ToString(),
                        ProductLevel = _DataTable.Rows[i][16].ToString(),

                        CostPrice = Convert.ToInt64(_DataTable.Rows[i][17].ToString()),
                        NormalPrice = Convert.ToInt64(_DataTable.Rows[i][18].ToString()),
                        TradePrice = Convert.ToInt64(_DataTable.Rows[i][19].ToString()),
                        PremiumPrice = Convert.ToInt64(_DataTable.Rows[i][20].ToString()),
                        OtherPrice = Convert.ToInt64(_DataTable.Rows[i][21].ToString()),

                        CostVAT = Convert.ToInt64(_DataTable.Rows[i][22].ToString()),
                        NormalVAT = Convert.ToInt64(_DataTable.Rows[i][23].ToString()),
                        PremiumVAT = Convert.ToInt64(_DataTable.Rows[i][24].ToString()),
                        TradeVAT = Convert.ToInt64(_DataTable.Rows[i][25].ToString()),
                        OtherVAT = Convert.ToInt64(_DataTable.Rows[i][26].ToString()),
                        VatPercentage = Convert.ToInt64(_DataTable.Rows[i][27].ToString()),


                        ImageURL = "/upload/blank-item.png",
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        CreatedBy = _DataTable.Rows[i][21].ToString(),
                        ModifiedBy = _DataTable.Rows[i][22].ToString(),
                    });
                }

                return _Items;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LoadddlItems()
        {
            ViewBag.VatPercentageList = new SelectList(_iCommon.GetTableData<VatPercentage>(x => x.Cancelled == false).OrderBy(x => x.Id), "Percentage", "Name");

            ViewBag.CategorieList = new SelectList(_iCommon.GetTableData<Categories>(x => x.Cancelled == false), "Id", "Name");
            ViewBag.SupplierList = new SelectList(_iCommon.GetTableData<Supplier>(x => x.Cancelled == false), "Id", "Name");
            ViewBag.UnitsofMeasureList = new SelectList(_iCommon.GetTableData<UnitsofMeasure>(x => x.Cancelled == false), "Id", "Name");
            ViewBag.WarehouseList = new SelectList(_iCommon.GetTableData<Warehouse>(x => x.Cancelled == false), "Id", "Name");
        }
    }
}
