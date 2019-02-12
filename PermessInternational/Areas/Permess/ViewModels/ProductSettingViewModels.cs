using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using PermessInternational.Areas.Permess.StaticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.ViewModels
{
    public class ProductSettingViewModels
    {
        public IEnumerable<ResponseProductSetting> ProductSettings { get; set; }
        public IEnumerable<ResponseProductSetting> ConstructionProductSettings { get; set; }
        public IEnumerable<ResponseProductSetting> ColorProductSettings { get; set; }
        public IEnumerable<ResponseProductSetting> SoftnessProductSettings { get; set; }
        public IEnumerable<ResponseProductSetting> SourceProductSettings { get; set; }
        public IEnumerable<ResponseProductSetting> WidthProductSettings { get; set; }
        public IEnumerable<ResponseProductSetting> CategoryProductSettings { get; set; }
        public IEnumerable<ResponseProductSetting> ArticleProductSettings { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Region> Regions { get; set; }
        public SIDocumentDetails Details { get; set; }
        public SIProductDetails ProductDetails { get; set; }
        public CashDetails CashDetails { get; set; }
        public LCStatement LCStatements { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public IEnumerable<YesNoModel> YesNoModels { get;set;}
        public IEnumerable<PaymentMethod> PaymentMethods { get;set;}
        public IEnumerable<Bank> Banks { get;set;}
        public IEnumerable<Status> Statuses { get;set;}
        public IEnumerable<Length> Lengths { get;set;}
        public IEnumerable<DeliveryType> DeliveryTypes { get;set;}
        public IEnumerable<PaymentClause> PaymentClauses { get;set;}
        public IEnumerable<Tenor> Tenors { get;set;}
    }
}