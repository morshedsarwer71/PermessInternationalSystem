using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class SISessionproductDetails
    {
        public int Serila { get; set; }
        public int SIProductDetId { get; set; }
        public string ProductName { get; set; }
        public string SICode { get; set; }
        public string Article { get; set; }
        public string AltArticle { get; set; }
        public string Width { get; set; }
        public string Softness { get; set; }
        public string Construction { get; set; }
        public string Color { get; set; }
        public string Source { get; set; }
        public string Lenght { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal DeliveryQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Netprice { get; set; }
        public decimal OverInvoice { get; set; }
        public decimal NetOverInvoice { get; set; }
    }
}