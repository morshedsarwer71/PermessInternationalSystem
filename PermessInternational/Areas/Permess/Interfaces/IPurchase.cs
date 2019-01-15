using PermessInternational.Areas.Permess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermessInternational.Areas.Permess.Interfaces
{
    public interface IPurchase
    {
        void AddMachine(int concernId,int userId, MachinePurchase machinePurchase);
        IEnumerable<MachinePurchase> MachinePurchases(int concernId);
    }
}
