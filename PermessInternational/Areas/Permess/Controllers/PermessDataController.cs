using PermessInternational.Areas.Global.Interface;
using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.ValueInWords;
using PermessInternational.Areas.Permess.ViewModels;
using PermessInternational.PermessContext;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermessInternational.Areas.Permess.Controllers
{
    public class PermessDataController : Controller
    {
        public IBuyer _buyer;
        public IProduct _product;
        public IStock _stock;
        public IPermess _permess;
        private readonly ISalesInvoice _sales;
        private readonly ISystemUser _user;
        private PermessDbContext _context;
        public PermessDataController(IBuyer buyer, IProduct product, IStock stock, IPermess permess, ISalesInvoice sales, PermessDbContext context, ISystemUser user)
        {
            _buyer = buyer;
            _product = product;
            _stock = stock;
            _permess = permess;
            _sales = sales;
            _context = context;
            _user = user;
        }
        // GET: Permess/PermessData
        public ActionResult Index()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult Company()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Companies()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var company = _buyer.Companies(concernId);
                CompanyViewModels viewModels = new CompanyViewModels()
                {
                    Companies = company
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult CompanyById(int id)
        {
            var company = _buyer.Company(id);
            return Json(company, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddCompany()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddCompany(Company company)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _buyer.AddCompany(company, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Region()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult Regions()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var reg = _context.Regions.ToList();
                return View(reg);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult AddRegion()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult AddRegion(Region region)
        {            
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                region.CreationDate = DateTime.Now;
                region.ConcernId = userId;
                _context.Regions.Add(region);
                _context.SaveChanges();
                return RedirectToAction(nameof(Region));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult EditRegion(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var reg = _context.Regions.FirstOrDefault(x=>x.RegionId==id);
                return View(reg);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult EditRegion(int id,Region region)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var reg = _context.Regions.FirstOrDefault(x => x.RegionId == id);
                reg.RegionName = region.RegionName;
                reg.Creator = userId;
                _context.SaveChanges();
                return RedirectToAction(nameof(Region));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult Product()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult Products()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var product = _product.Products(concernId);
                ProductViewModels viewModels = new ProductViewModels()
                {
                    Products = product
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _product.AddProduct(product, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ProductSetting()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ProductSettings()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var product = _product.ArticleProductSettings(concernId);
                var Cons = _product.ConstructionProductSettings(concernId);
                var cat = _product.CategoryProductSettings(concernId);
                var soft = _product.SoftnessProductSettings(concernId);
                var width = _product.WidthProductSettings(concernId);
                var source = _product.SourceProductSettings(concernId);
                var col = _product.ColorProductSettings(concernId);
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    ProductSettings = product,
                    CategoryProductSettings = cat,
                    ColorProductSettings = col,
                    ConstructionProductSettings = Cons,
                    SoftnessProductSettings = soft,
                    SourceProductSettings = source,
                    WidthProductSettings = width
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult AddArticle()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddArticle(ProductSetting productSetting)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _product.AddProductSetting(productSetting, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddConstruction()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddConstruction(ProductSetting productSetting)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _product.AddProductSetting(productSetting, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddWidth()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddWidth(ProductSetting productSetting)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _product.AddProductSetting(productSetting, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddSoftness()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddSoftness(ProductSetting productSetting)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _product.AddProductSetting(productSetting, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddColor()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddColor(ProductSetting productSetting)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _product.AddProductSetting(productSetting, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddSource()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddSource(ProductSetting productSetting)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _product.AddProductSetting(productSetting, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddCategory(ProductSetting productSetting)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _product.AddProductSetting(productSetting, concernId, userId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ImportGood()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var product = _product.ArticleProductSettings(concernId);
                var Cons = _product.ConstructionProductSettings(concernId);
                var cat = _product.CategoryProductSettings(concernId);
                var soft = _product.SoftnessProductSettings(concernId);
                var width = _product.WidthProductSettings(concernId);
                var source = _product.SourceProductSettings(concernId);
                var col = _product.ColorProductSettings(concernId);
                var products = _product.Products(concernId);
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    ProductSettings = product,
                    CategoryProductSettings = cat,
                    ColorProductSettings = col,
                    ConstructionProductSettings = Cons,
                    SoftnessProductSettings = soft,
                    SourceProductSettings = source,
                    WidthProductSettings = width,
                    Products = products
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult ImportGood(ImportGood importGood)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _stock.ImportGoods(importGood, concernId, userId);
            return Json("Imported Stock Successfully", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult RawMaterials()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var rawId = 1;
                var goods = _stock.ResponseGoods(concernId, rawId);
                GoodsTypeViewModels viewModels = new GoodsTypeViewModels()
                {
                    ResponseGoods = goods
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult SemiFinishedGoods()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var semiFinished = 2;
                var goods = _stock.ResponseGoods(concernId, semiFinished);
                GoodsTypeViewModels viewModels = new GoodsTypeViewModels()
                {
                    ResponseGoods = goods
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult FinishedGoods()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var finished = 3;
                var goods = _stock.ResponseGoods(concernId, finished);
                GoodsTypeViewModels viewModels = new GoodsTypeViewModels()
                {
                    ResponseGoods = goods
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ExportIssue()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ExportIssues()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var permess = _permess.ExportIssues(concernId);
                ExportIssuesViewModels viewModels = new ExportIssuesViewModels()
                {
                    ExportIssues = permess
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult AddExportIssue()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var region = _sales.Regions(concernId);
            if (concernId > 0 && userId > 0)
            {
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    Regions = region
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult AddExportIssue(ExportIssue exportIssue)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _permess.AddExportIssue(exportIssue, concernId, userId);
                return RedirectToAction(nameof(ExportIssue));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult Stockes()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var stock = _stock.GeneralStocks();
                ResponseStocksViewModels viewModels = new ResponseStocksViewModels()
                {
                    ResponseStocks = stock
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult RawMaterialsStock()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var stock = _stock.RawMaterialsStocks();
                ResponseStocksViewModels viewModels = new ResponseStocksViewModels()
                {
                    ResponseStocks = stock
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult SemiFinishedGoodsStocks()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var stock = _stock.SemiFinishedStocks();
                ResponseStocksViewModels viewModels = new ResponseStocksViewModels()
                {
                    ResponseStocks = stock
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult FinishedGoodsStocks()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var stock = _stock.FinishedStocks();
                ResponseStocksViewModels viewModels = new ResponseStocksViewModels()
                {
                    ResponseStocks = stock
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult SortStockes()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var stock = _stock.GeneralStocks();
                ResponseStocksViewModels viewModels = new ResponseStocksViewModels()
                {
                    ResponseStocks = stock
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult Orders()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var order = _stock.ResponseOrders();
                OrdersViewModels viewModels = new OrdersViewModels()
                {
                    ResponseOrders = order
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult EditOrders()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var order = _stock.ResponseOrders();
                OrdersViewModels viewModels = new OrdersViewModels()
                {
                    ResponseOrders = order
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult DeleteOrders()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var order = _stock.ResponseOrders();
                OrdersViewModels viewModels = new OrdersViewModels()
                {
                    ResponseOrders = order
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult PrintOrders()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var order = _stock.ResponseOrders();
                OrdersViewModels viewModels = new OrdersViewModels()
                {
                    ResponseOrders = order
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult Print(int id)
        {
            var value = _context.SIDocumentDetails.FirstOrDefault(x=>x.SICode==id.ToString());
            if (value.DeliveryType == 2)
            {
                return RedirectToAction("Invoice", "PermessData",new {id=id });
            }
            return RedirectToAction("Proforma", "PermessData", new { id = id });
        }
        [HttpGet]
        public ActionResult Invoice(int id)
        {
            decimal total_price = 0;
            var order = _stock.ResponseOrdersByCode(id.ToString());
            var product = _sales.PrintProduct(id.ToString());
            foreach (var item in product)
            {
                total_price += item.Amount;

            }
            WordValues wordValues = new WordValues();
            int val = Convert.ToInt32(total_price);
            ViewBag.ValueInWords=wordValues.NumberToWords(val);
            OrdersViewModels viewModels = new OrdersViewModels()
            {
                ResponseOrders = order,
                Product= product
            };
            var report = new PartialViewAsPdf("Invoice", viewModels);
            return report;
        }
        [HttpGet]
        public ActionResult Proforma(int id)
        {
            decimal total_price = 0;
            var order = _stock.ResponseOrdersByCode(id.ToString());
            var product = _sales.PrintProduct(id.ToString());
            WordValues wordValues = new WordValues();
            foreach (var item in product)
            {
                total_price += item.Amount;

            }
            int val = Convert.ToInt32(total_price);
            ViewBag.ValueInWords = wordValues.NumberToWords(val);
            OrdersViewModels viewModels = new OrdersViewModels()
            {
                ResponseOrders = order,
                Product = product
            };
            var report = new PartialViewAsPdf("Proforma", viewModels);
            return report;
        }
        [HttpGet]
        public ActionResult DeleteOrder(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _sales.DeleteInvoice(id);
                return RedirectToAction(nameof(DeleteOrders));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult AddQuantity(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var code = id.ToString();
                var document = _context.SIDocumentDetails.FirstOrDefault(m => m.SICode == code);          
                ViewBag.Company = _context.Companies.ToList();
                SIDocumentDetails documentDetails = new SIDocumentDetails();
                documentDetails = document;
                return View();
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpPost]
        public ActionResult AddQuantity(int id, DeliveryQuantity delivery)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                //DeliveryQuantity deliveryQuantity = new DeliveryQuantity();
                var del = _context.DeliveryQuantities.FirstOrDefault(x=>x.SIProductDetailsCode== id.ToString());
                delivery.CreationDate = DateTime.Now;
                delivery.SIProductDetailsCode = id.ToString();
                delivery.Creator = userId;
                delivery.ConcernId = concernId;
                delivery.SIProductDetailsCode = del.SIProductDetailsCode;
                _context.DeliveryQuantities.Add(delivery);
                _context.SaveChanges();
                return RedirectToAction(nameof(Orders));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult CashDetails()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var cash = _stock.ResponseCashDetails();
                ResponseCashDetailsViewModels viewModels = new ResponseCashDetailsViewModels()
                {
                    ResponseCashDetails = cash
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult LCStatemets()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var lc = _stock.ResponseLCStatements();
                ResponseLCStatementsViewModels viewModels = new ResponseLCStatementsViewModels()
                {
                    LCStatements = lc
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }

        [HttpGet]
        public ActionResult RevisedData()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var order = _stock.ResponseOrders();
                OrdersViewModels viewModels = new OrdersViewModels()
                {
                    ResponseOrders = order
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult RevisedReport(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var order = _permess.PIReviseds(id.ToString());
                OrdersViewModels viewModels = new OrdersViewModels()
                {
                    PIReviseds = order
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult SalesReport()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {

                var product = _product.ArticleProductSettings(concernId);
                var products = _product.Products(concernId);
                var company = _buyer.Companies(concernId);
                var article = _product.ArticleProductSettings(concernId);
                var user = _user.Users(concernId);
                //ViewBag.value = value;
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    ProductSettings = product,
                    Products = products,
                    Companies = company,
                    ArticleProductSettings = article,
                    SystemUser = user
                };
                return View(viewModels);

            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult SalesReport(int productId=0, int userId=0, int customerId=0)
        {
            var result = _stock.ProductReport(productId, userId, customerId);
            OrdersViewModels viewModels = new OrdersViewModels()
            {
                ResponseOrders = result
            };
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ProductReport()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {

                var product = _product.ArticleProductSettings(concernId);
                var products = _product.Products(concernId);
                var company = _buyer.Companies(concernId);
                var article = _product.ArticleProductSettings(concernId);
                var user = _user.Users(concernId);
                //ViewBag.value = value;
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    ProductSettings = product,
                    Products = products,
                    Companies = company,
                    ArticleProductSettings = article,
                    SystemUser = user
                };
                return View(viewModels);

            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult ProductReport(int productId = 0, int userId = 0, int customerId = 0)
        {
            var result = _stock.ProductReport(productId, userId, customerId);
            OrdersViewModels viewModels = new OrdersViewModels()
            {
                ResponseOrders = result
            };
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

    }
}