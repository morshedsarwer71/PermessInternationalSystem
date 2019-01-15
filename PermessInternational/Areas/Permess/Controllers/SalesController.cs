using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.ViewModels;
using PermessInternational.PermessContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermessInternational.Areas.Permess.Controllers
{
    public class SalesController : Controller
    {
        private readonly IBuyer _buyer;
        private readonly ISalesInvoice _sales;
        public IProduct _product;
        private readonly IPurchase _purchase;
        private readonly IStock _stock;
        private PermessDbContext _context;
        //string code = "";
        public SalesController(IBuyer buyer, ISalesInvoice sales, IProduct product, IPurchase purchase, PermessDbContext context, IStock stock)
        {
            _buyer = buyer;
            _sales = sales;
            _product = product;
            _purchase = purchase;
            _context = context;
            _stock = stock;
        }
        // GET: Permess/Sales
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SalesInvoiceInfo()
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
                var company = _buyer.Companies(concernId);
                var article = _product.ArticleProductSettings(concernId);
                var region = _sales.Regions(concernId);
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    ProductSettings = product,
                    CategoryProductSettings = cat,
                    ColorProductSettings = col,
                    ConstructionProductSettings = Cons,
                    SoftnessProductSettings = soft,
                    SourceProductSettings = source,
                    WidthProductSettings = width,
                    Products = products,
                    Companies = company,
                    ArticleProductSettings = article,
                    Regions = region
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }

        [HttpPost]
        public ActionResult SalesInvoiceInfo(SIDocumentDetails sIDocumentDetails)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _sales.AddSIDocumentDetails(sIDocumentDetails, userId, concernId);
            return Json(new
            {
                redirectUrl = Url.Action("Orders", "PermessData", new { Area = "Permess" }),
                isRedirect = true
            });
        }
        [HttpGet]
        public ActionResult UpdateSalesInvoiceInfo(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            ViewBag.Code = id.ToString();
            var stock = _stock.ResponseOrders();
            foreach (var item in stock)
            {
                if (item.SICode == id.ToString())
                {
                    ViewBag.delivery = item.Quantity;
                    ViewBag.order = item.OrderQuantity;
                    ViewBag.unit = item.NetPrice;
                }
            }
            if (concernId > 0 && userId > 0)
            {
                var SIDocument = _context.SIDocumentDetails.FirstOrDefault(m => m.SICode == id.ToString());
                var product = _product.ArticleProductSettings(concernId);
                var Cons = _product.ConstructionProductSettings(concernId);
                var cat = _product.CategoryProductSettings(concernId);
                var soft = _product.SoftnessProductSettings(concernId);
                var width = _product.WidthProductSettings(concernId);
                var source = _product.SourceProductSettings(concernId);
                var col = _product.ColorProductSettings(concernId);
                var products = _product.Products(concernId);
                var company = _buyer.Companies(concernId);
                var article = _product.ArticleProductSettings(concernId);
                var region = _sales.Regions(concernId);
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    ProductSettings = product,
                    CategoryProductSettings = cat,
                    ColorProductSettings = col,
                    ConstructionProductSettings = Cons,
                    SoftnessProductSettings = soft,
                    SourceProductSettings = source,
                    WidthProductSettings = width,
                    Products = products,
                    Companies = company,
                    ArticleProductSettings = article,
                    Regions = region,
                    Details = SIDocument
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult UpdateSalesInvoiceInfo(SIDocumentDetails sIDocument)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _sales.UpdateSIDocumentDetails(sIDocument,userId,concernId);
                return Json(new
                {
                    redirectUrl = Url.Action("Orders", "PermessData", new { Area = "Permess" }),
                    isRedirect = true
                });
            }
            return Json(new
            {
                redirectUrl = Url.Action("LogIn", "GlobalData", new { Area = "Global" }),
                isRedirect = true
            });
        }
        [HttpPost]
        public JsonResult UpdateSalesProductDetails(SIProductDetails sIProductDetails)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _sales.UpdateSIProductDetails(sIProductDetails,userId,concernId);
                return Json(new
                {
                    redirectUrl = Url.Action("Orders", "PermessData", new { Area = "Permess" }),
                    isRedirect = true
                });
            }
            return Json(new
            {
                redirectUrl = Url.Action("LogIn", "GlobalData", new { Area = "Global" }),
                isRedirect = true
            });
        }

        [HttpGet]
        public ActionResult SIDocument(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult SIDocument(int id, SIDocumentDetails sIDocument)
        {
            return View();
        }

        [HttpPost]
        public JsonResult SalesProductDetails(SIProductDetails sIProductDetails)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _sales.AddSIProductDetails(sIProductDetails, userId, concernId);
            //code = sIProductDetails.SICode;            
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetSalesProductDetails(string code)
        {
            var sales = _sales.SISessionproductDetails(code);
            SISessionproductDetailsViewModels viewModels = new SISessionproductDetailsViewModels()
            {
                SISessionproductDetails = sales
            };
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ClearSalesProductById(int id)
        {
            _sales.ClearSalesProductById(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddCashDeails(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var value = _context.CashDetails.FirstOrDefault(m=>m.SICode==id.ToString());
                if(value==null)
                {
                    ViewBag.PI = id;
                    var region = _sales.Regions(concernId);
                    ProductSettingViewModels viewModels = new ProductSettingViewModels()
                    {
                        Regions = region
                    };
                    return View(viewModels);
                }
                return RedirectToAction("Orders", "PermessData",new {Area="Permess"});
                
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult AddCashDeails(int id, CashDetails cashDetails)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _sales.AddCashDetails(cashDetails, concernId, userId, id);
            return RedirectToAction("Orders", "PermessData");
        }
        [HttpGet]
        public ActionResult AddLCStatement(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var value = _context.LCStatements.FirstOrDefault(m => m.SICode == id.ToString());
            if (concernId > 0 && userId > 0)
            {
                if (value == null)
                {
                    ViewBag.PI = id;
                    return View();
                }
                return RedirectToAction("Orders", "PermessData", new { Area = "Permess" });
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult AddLCStatement(LCStatement lCStatement, int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _sales.AddLCStatement(lCStatement, concernId, userId, id);
            return RedirectToAction("Orders", "PermessData");
        }
        [HttpGet]
        public ActionResult OrderDetails(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var value = _context.OrderDetails.FirstOrDefault(m => m.SICode == id.ToString());
            if (concernId > 0 && userId > 0)
            {
                if (value == null)
                {
                    ViewBag.PI = id;
                    return View();
                }
                return RedirectToAction("Orders", "PermessData", new { Area = "Permess" });
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult OrderDetails(int id, OrderDetails orderDetails)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _sales.AddOrderDetails(orderDetails, concernId, userId, id);
                return RedirectToAction("Orders", "PermessData");
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult MachinePurchase()
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
        public ActionResult MachinePurchases()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var model = _purchase.MachinePurchases(concernId);
                MachineViewModels viewModels = new MachineViewModels()
                {
                    MachinePurchases = model
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult AddMachinePurchase()
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
        public ActionResult AddMachinePurchase(MachinePurchase machinePurchase)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _purchase.AddMachine(concernId, userId, machinePurchase);
                return RedirectToAction(nameof(MachinePurchase));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult SalesReturn()
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
        public ActionResult SalesReturns()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var returns = _sales.SalesReturns(concernId);
                SalesReturnViewModels viewModels = new SalesReturnViewModels()
                {
                    Returns = returns
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult AddSalesReturn()
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
                var company = _buyer.Companies(concernId);
                var article = _product.ArticleProductSettings(concernId);
                var region = _sales.Regions(concernId);
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    ProductSettings = product,
                    CategoryProductSettings = cat,
                    ColorProductSettings = col,
                    ConstructionProductSettings = Cons,
                    SoftnessProductSettings = soft,
                    SourceProductSettings = source,
                    WidthProductSettings = width,
                    Products = products,
                    Companies = company,
                    ArticleProductSettings = article,
                    Regions = region
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddSalesReturn(SRIProductDetails productDetails)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _sales.AddSalesReturn(productDetails, concernId, userId);
            return Json(new
            {
                redirectUrl = Url.Action("SalesReturn", "Sales", new { Area = "Permess" }),
                isRedirect = true
            });
        }
        [HttpGet]
        public JsonResult GetSalesReturnProductDetails(string code)
        {
            var sales = _sales.SRISessionproductDetails(code);
            SISessionproductDetailsViewModels viewModels = new SISessionproductDetailsViewModels()
            {
                SISessionproductDetails = sales
            };
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ClearSalesReturnProductById(int id)
        {
            _sales.ClearSalesReturnProductById(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}