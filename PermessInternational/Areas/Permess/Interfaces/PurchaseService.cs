using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.PermessContext;

namespace PermessInternational.Areas.Permess.Interfaces
{
    public class PurchaseService : IPurchase
    {
        private readonly PermessDbContext _context;
        public PurchaseService(PermessDbContext context)
        {
            _context = context;
        }
        public void AddMachine(int concernId, int userId, MachinePurchase machinePurchase)
        {
            machinePurchase.ConcernId = concernId;
            machinePurchase.Creator = userId;
            machinePurchase.CreationDate = DateTime.Now;
            _context.MachinePurchase.Add(machinePurchase);
            _context.SaveChanges();
        }

        public IEnumerable<MachinePurchase> MachinePurchases(int concernId)
        {
            return _context.MachinePurchase.Where(x=>x.ConcernId==concernId);
        }
    }
}