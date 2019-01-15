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
    public class ProductionController : Controller
    {
        private readonly ISalesInvoice _sales;
        public IProduct _product;
        private readonly IBuyer _buyer;
        private readonly IProduction _production;
        private readonly PermessDbContext _context;
        public IStock _stock;
        public ProductionController(ISalesInvoice sales, IProduct product, IBuyer buyer, IProduction production, PermessDbContext context, IStock stock)
        {
            _sales = sales;
            _product = product;
            _buyer = buyer;
            _production = production;
            _context = context;
            _stock = stock;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProductionOrder()
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
        public ActionResult ProductionOrders()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var model = _production.ProductionOrders(concernId, 0);
                //var stock = _stock.GeneralStocks();
                ProductionOrderViewModels viewModels = new ProductionOrderViewModels()
                {
                    ProductionOrders = model
                    //ResponseStocks=stock
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ProductionChange(int id)
        {
            decimal value = 0;
            var quantity = _stock.GeneralStocks();
            var order = _context.ProductionOrders.FirstOrDefault(m => m.ProductionOrderId == id);
            var materials = _context.OrderRawMaterials.FirstOrDefault(m => m.OrderId == id);
            foreach (var item in quantity)
            {
                if (item.ProductCode == order.ProductCode)
                {
                    value = item.Quantity;
                }
            }
            if (value >= materials.Quantity)
            {
                _production.ProductionChange(id);
                return RedirectToAction(nameof(ProductionProces));
            }
            else
            {
                return RedirectToAction(nameof(ProductionOrder));
            }
        }
        [HttpGet]
        public ActionResult OrderRawMaterial(int id)
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
                    //ViewBag.value = value;
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
        public ActionResult OrderRawMaterial(OrderRawMaterial orderRawMaterial, int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var code = orderRawMaterial.ProductId + "" + orderRawMaterial.ArticleId + "" + orderRawMaterial.WidthId + "" + orderRawMaterial.ConstructionId + "" + orderRawMaterial.SoftnessId + "" + orderRawMaterial.SourceId + "" + orderRawMaterial.ColorId;
                var quantity = _stock.GeneralStocks();
                decimal value = 0;
                foreach (var item in quantity)
                {
                    if (item.ProductCode == code)
                    {
                        value = item.Quantity;
                    }
                    else
                    {
                        value = -1;
                    }
                }
                if (value >= 0)
                {
                    _production.AddOrderRawMaterial(orderRawMaterial, concernId, userId, id);
                    _production.ProductionChange(id);
                    return RedirectToAction(nameof(ProductionProces));
                }
                else
                {
                    TempData["sort"] = "your stock is sort";
                    return RedirectToAction(nameof(ProductionOrder));
                }
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ProductionProces()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var model = _production.ProductionProcess();
                ProductionOrderViewModels viewModels = new ProductionOrderViewModels()
                {
                    ProductionOrders = model
                };
                return View(viewModels);
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult AddProductionOrder()
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
        public ActionResult AddProductionOrder(ProductionOrder productionOrder)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _production.AddProductionOrder(productionOrder, concernId, userId);
                return RedirectToAction(nameof(productionOrder));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ProcessA(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var orderValue = _context.OrderRawMaterials.FirstOrDefault(m => m.OrderId == id);
            ViewBag.quantity = orderValue.Quantity;
            if (concernId > 0 && userId > 0)
            {
                var procA = _context.AProductions.FirstOrDefault(m => m.OrderId == id);
                if (procA == null)
                {
                    return View();
                }
                ViewBag.data = "Data Inserted";
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult ProcessA(int id, ProductionProcessA productionProcess)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _production.ProcessA(id, productionProcess, concernId);
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult UpdateProcessA(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var procA = _context.AProductions.FirstOrDefault(m => m.OrderId == id);
                if (procA != null)
                {
                    return View(procA);
                }
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult UpdateProcessA(int id, ProductionProcessA productionProcess)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _production.UpdateProcessA(id, productionProcess, concernId);
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult UpdateProcessB(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var procA = _context.BProductions.FirstOrDefault(m => m.OrderId == id);
                if (procA != null)
                {
                    return View(procA);
                }
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult UpdateProcessB(int id, ProductionProcessB productionProcess)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _production.UpdateProcessB(id, productionProcess, concernId);
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult UpdateProcessC(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var procA = _context.CProductions.FirstOrDefault(m => m.OrderId == id);
                if (procA != null)
                {
                    return View(procA);
                }
                return RedirectToAction(nameof(ProductionProces));

            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult UpdateProcessC(int id, ProductionProcessC productionProcess)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _production.UpdateProcessC(id, productionProcess, concernId);
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ProcessB(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var value = _context.AProductions.FirstOrDefault(m => m.OrderId == id);
                var procB = _context.BProductions.FirstOrDefault(m => m.OrderId == id);
                if (procB == null && value != null)
                {
                    return View(value);
                }
                ViewBag.data = "Data Inserted";
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult ProcessB(int id, ProductionProcessB productionProcess)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _production.ProcessB(id, productionProcess, concernId);
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ProcessC(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var value = _context.BProductions.FirstOrDefault(m => m.OrderId == id);
                var procA = _context.CProductions.FirstOrDefault(m => m.OrderId == id);
                if (procA == null && value != null)
                {
                    return View(value);
                }
                ViewBag.data = "Data Inserted";
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public ActionResult ProcessC(int id, ProductionProcessC productionProcess)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                _production.ProcessC(id, productionProcess, concernId);
                return RedirectToAction(nameof(ProductionProces));
            }
            return RedirectToAction("LogIn", "GlobalData", new { Area = "Global" });
        }
    }
}