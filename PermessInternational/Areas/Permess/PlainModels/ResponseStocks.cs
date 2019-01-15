using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class ResponseStocks
    {        
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Article { get; set; }
        public string Construction { get; set; }
        public string Width { get; set; }
        public string Softness { get; set; }
        public string Color { get; set; }
        public string Sources { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}