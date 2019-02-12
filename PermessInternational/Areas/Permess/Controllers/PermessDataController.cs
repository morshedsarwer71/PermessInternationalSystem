using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.ViewModels;
using PermessInternational.PermessContext;
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
        private PermessDbContext _context;
        public PermessDataController(IBuyer buyer, IProduct product, IStock stock, IPermess permess, ISalesInvoice sales, PermessDbContext context)
        {
            _buyer = buyer;
            _product = product;
            _stock = stock;
            _permess = permess;
            _sales = sales;
            _context = context;
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
                return View(documentDetails);
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
                delivery.CreationDate = DateTime.Now;
                delivery.ProductCode = id.ToString();
                delivery.Creator = userId;
                delivery.ConcernId = concernId;
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

    }
}