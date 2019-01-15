using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class ResponseGoodsReport
    {
        public int Serial { get; set; }
        public string ReceivedDate { get; set; }
        public decimal Quantity { get; set; }
        public string PerformerCode { get; set; }
        public string Supplier { get; set; }
        public string LCNumber { get; set; }
        public string Article { get; set; }
        public string Width { get; set; }
        public string AltArticle { get; set; }
        public string Construction { get; set; }
        public string Color { get; set; }
        public string ProductName { get; set; }
        public string Softness { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
    }
}