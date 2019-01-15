using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.PermessContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Services
{
    public class BuyerService : IBuyer
    {
        public PermessDbContext _context;
        public BuyerService(PermessDbContext context)
        {
            _context = context;
        }
        public void AddCompany(Company company, int concernId, int userId)
        {
            company.ConcerinId = concernId;
            company.Creator = userId;
            company.CreationDate = DateTime.Now;
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public IEnumerable<Company> Companies(int concernId)
        {
            return _context.Companies.Where(x => x.ConcerinId == concernId).ToList();
        }

        public Company Company(int companyId)
        {
            return _context.Companies.FirstOrDefault(x=>x.CompanyId==companyId);
        }
    }
}