using PermessInternational.Areas.Global.Interface;
using PermessInternational.Areas.Global.Service;
using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PermessInternational
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ISystemUser, SystemUserService>();
            container.RegisterType<IBuyer, BuyerService>();
            container.RegisterType<IProduct, ProductService>();
            container.RegisterType<IStock, StockServices>();
            container.RegisterType<ISalesInvoice, SalesInvoiceService>();
            container.RegisterType<IPurchase, PurchaseService>();
            container.RegisterType<IPermess, PermessService>();
            container.RegisterType<IProduction, ProductionService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}