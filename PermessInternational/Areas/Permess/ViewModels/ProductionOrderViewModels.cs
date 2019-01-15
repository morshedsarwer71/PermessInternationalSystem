using PermessInternational.Areas.Permess.PlainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.ViewModels
{
    public class ProductionOrderViewModels
    {
        public IEnumerable<ResponseProductionOrder> ProductionOrders { get; set; }
        public IEnumerable<ResponseStocks> ResponseStocks { get; set; }
    }
}