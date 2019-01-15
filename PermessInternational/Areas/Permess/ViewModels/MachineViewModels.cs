using PermessInternational.Areas.Permess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.ViewModels
{
    public class MachineViewModels
    {
        public IEnumerable<MachinePurchase> MachinePurchases { get; set; }
    }
}