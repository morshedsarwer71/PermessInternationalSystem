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
        private readonly IPermess _permess;
        private readonly IStock _stock;
        private PermessDbContext _context;
        //string code = "";
        public SalesController(IBuyer buyer, ISalesInvoice sales, IProduct product, IPurchase purchase, PermessDbContext context, IStock stock, IPermess permess)
        {
            _buyer = buyer;
            _sales = sales;
            _product = product;
            _purchase = purchase;
            _context = context;
            _stock = stock;
            _permess = permess;
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
                var method = _product.PaymentMethods();
                var bank = _product.Banks();
                var status = _product.Statuses();
                var lenght = _product.Lengths();
                var delivery = _product.DeliveryTypes();
                var yesNo = _product.YesNoModels();
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
                    PaymentMethods = method,
                    Banks = bank,
                    Statuses = status,
                    DeliveryTypes = delivery,
                    Lengths = lenght,
                    YesNoModels = yesNo
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
        public ActionResult EditSIDocument(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var SIDocument = _context.SIDocumentDetails.FirstOrDefault(m => m.SICode == id.ToString());

            if (concernId > 0 && userId > 0)
            {
                if (SIDocument !=null)
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
                    var method = _product.PaymentMethods();
                    var bank = _product.Banks();
                    var status = _product.Statuses();
                    var lenght = _product.Lengths();
                    var delivery = _product.DeliveryTypes();
                    var yesNo = _product.YesNoModels();
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
                        PaymentMethods = method,
                        Banks = bank,
                        Statuses = status,
                        DeliveryTypes = delivery,
                        Lengths = lenght,
                        YesNoModels = yesNo,
                        Details = SIDocument
                    };
                    return View(viewModels);
                }
                else
                {
                    return RedirectToAction("EditOrders", "PermessData", new { Areas = "Permess" });
                }
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult EditSIDocument(SIDocumentDetails sIDocument,int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                PIRevised pIRevised = new PIRevised();
                pIRevised.PICode = id.ToString();
                pIRevised.UserId = userId;
                pIRevised.ConcernId = concernId;
                pIRevised.RevisedDate = DateTime.Now;
                pIRevised.RevisedDocs = "Document";
                _permess.AddRevisedData(pIRevised);

                _sales.UpdateSIDocumentDetails(sIDocument, userId, concernId, id.ToString());
                return RedirectToAction("EditOrders","PermessData",new { Areas="Permess"});
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult EditSIProduct(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var SIProduct = _context.SIProductDetails.FirstOrDefault(m => m.SIProductDetId == id);
            if (concernId > 0 && userId > 0)
            {
                if (SIProduct != null)
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
                    var method = _product.PaymentMethods();
                    var bank = _product.Banks();
                    var status = _product.Statuses();
                    var lenght = _product.Lengths();
                    var delivery = _product.DeliveryTypes();
                    var yesNo = _product.YesNoModels();
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
                        PaymentMethods = method,
                        Banks = bank,
                        Statuses = status,
                        DeliveryTypes = delivery,
                        Lengths = lenght,
                        YesNoModels = yesNo,
                        ProductDetails = SIProduct
                    };
                    return View(viewModels);
                }
                else
                {
                    return RedirectToAction("EditOrders", "PermessData", new { Areas = "Permess" });
                }
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult EditSIProduct(SIProductDetails sIProductDetails,int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                PIRevised pIRevised = new PIRevised();
                pIRevised.PICode = id.ToString();
                pIRevised.UserId = userId;
                pIRevised.ConcernId = concernId;
                pIRevised.RevisedDate = DateTime.Now;
                pIRevised.RevisedDocs = "Product";
                _permess.AddRevisedData(pIRevised);
                _sales.UpdateSIProductDetails(sIProductDetails, userId, concernId, id);
                return RedirectToAction("EditOrders", "PermessData", new { Areas = "Permess" });
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }

        [HttpGet]
        public ActionResult DeliveryQuantities(int id)
        {
            var quantity = _context.DeliveryQuantities.Where(x => x.SIProductDetailsCode == id.ToString()).ToList();
            return View(quantity);
        }
        [HttpGet]
        public ActionResult EditDeliveryQuantity(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var quantity = _context.DeliveryQuantities.FirstOrDefault(x=>x.DeliveryQuantityID==id);
                return View(quantity);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult EditDeliveryQuantity(DeliveryQuantity deliveryQuantity,int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _sales.UpdateDeliveryQuantity(deliveryQuantity, userId, concernId, id);
                return RedirectToAction("Orders", "PermessData", new { Area = "Permess" });
            }            
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult EditCash(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var cash = _context.CashDetails.FirstOrDefault(x => x.SICode == id.ToString());
            if (concernId > 0 && userId > 0)
            {
                if (cash != null)
                {
                    ProductSettingViewModels viewModels = new ProductSettingViewModels()
                    {
                        CashDetails = cash
                    };
                    return View(viewModels);
                }
                else
                {
                    return RedirectToAction("EditOrders", "PermessData", new { Areas = "Permess" });
                }
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult EditCash(int id, CashDetails cashDetails)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _sales.UpdateCashDetails(cashDetails, concernId, userId, id);
                return RedirectToAction("EditOrders", "PermessData", new { Areas = "Permess" });
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult EditLCStatement(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var cash = _context.LCStatements.FirstOrDefault(x => x.SICode == id.ToString());
            if (concernId > 0 && userId > 0)
            {
                if (cash != null)
                {
                    var tenor = _product.Tenors();
                    var clause = _product.PaymentClauses();
                    var yesnoModels = _product.YesNoModels();
                    ProductSettingViewModels viewModels = new ProductSettingViewModels()
                    {
                        LCStatements = cash,
                        Tenors = tenor,
                        PaymentClauses = clause,
                        YesNoModels = yesnoModels
                    };
                    return View(viewModels);

                }
                else
                {
                    return RedirectToAction("EditOrders", "PermessData", new { Areas = "Permess" });
                }
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult EditLCStatement(int id, LCStatement lCStatement)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _sales.UpdateLCStatement(lCStatement, concernId, userId, id);
                return RedirectToAction("EditOrders", "PermessData", new { Areas = "Permess" });
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
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
                var value = _context.CashDetails.FirstOrDefault(m => m.SICode == id.ToString());
                if (value == null)
                {
                    ViewBag.PI = id;
                    var region = _sales.Regions(concernId);
                    ProductSettingViewModels viewModels = new ProductSettingViewModels()
                    {
                        Regions = region
                    };
                    return View(viewModels);
                }
                return RedirectToAction("Orders", "PermessData", new { Area = "Permess" });

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
                    var cash = _context.LCStatements.FirstOrDefault(x => x.SICode == id.ToString());
                    var tenor = _product.Tenors();
                    var clause = _product.PaymentClauses();
                    var yesnoModels = _product.YesNoModels();
                    ProductSettingViewModels viewModels = new ProductSettingViewModels()
                    {
                        LCStatements = cash,
                        Tenors = tenor,
                        PaymentClauses = clause,
                        YesNoModels = yesnoModels
                    };
                    return View(viewModels);
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
                    var yes = _product.YesNoModels();
                    var method = _product.Statuses();
                    ProductSettingViewModels viewModels = new ProductSettingViewModels()
                    {
                        YesNoModels= yes,
                        Statuses= method
                    };
                    ViewBag.PI = id;
                    return View(viewModels);
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
        public ActionResult EditOrderDetails(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var value = _context.OrderDetails.FirstOrDefault(m => m.SICode == id.ToString());
            if (concernId > 0 && userId > 0)
            {
                if (value != null)
                {
                    var yes = _product.YesNoModels();
                    var method = _product.Statuses();
                    //var details=
                    ProductSettingViewModels viewModels = new ProductSettingViewModels()
                    {
                        YesNoModels = yes,
                        Statuses = method,
                        OrderDetails= value
                    };
                    return View(viewModels);
                }
                return RedirectToAction("EditOrders", "PermessData", new { Area = "Permess" });
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult EditOrderDetails(int id, OrderDetails orderDetails)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _sales.UpdateOrderDetails(orderDetails, concernId, userId, id);
                return RedirectToAction("EditOrders", "PermessData");
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

        [HttpGet]
        public ActionResult OrdersReport()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId>0 && userId>0)
            {                
                var company = _buyer.Companies(concernId);                
                var method = _product.PaymentMethods();                
                var delivery = _product.Statuses();
                var payment = _product.PaymentMethods();
                var lc = _product.YesNoModels();
                ProductSettingViewModels viewModels = new ProductSettingViewModels()
                {
                    Companies = company,                   
                    PaymentMethods = method,                    
                    Statuses = delivery,
                    YesNoModels=lc
                    
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult OrdersReport(string fDate,string toDate,int delivery,int payment,int companyId)
        {
            int lc = 0;
            var order = _stock.OrdersReport(fDate, toDate, lc, delivery, payment, companyId);
            OrdersViewModels viewModels = new OrdersViewModels()
            {
                ResponseOrders = order
            };
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
    }
}