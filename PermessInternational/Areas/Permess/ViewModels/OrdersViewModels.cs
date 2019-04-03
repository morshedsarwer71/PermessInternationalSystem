using PermessInternational.Areas.Permess.PlainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.ViewModels
{
    public class OrdersViewModels
    {
        public IEnumerable<ResponseOrders> ResponseOrders { get; set; }
        public IEnumerable<ResponseProductionOrder> Product { get; set; }
    }
}