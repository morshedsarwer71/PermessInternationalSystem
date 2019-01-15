using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class ResponseProductionOrder
    {
        public int Serial { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Time { get; set; }
        public string Article { get; set; }
        public string Construction { get; set; }
        public string Product { get; set; }
        public string Softness { get; set; }
        public string Source { get; set; }
        public string Width { get; set; }
        public string Assigned { get; set; }
        public string ProcessType { get; set; }
        public string Status { get; set; }
    }
}