using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.PermessContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Services
{
    public class PermessService : IPermess
    {
        private readonly PermessDbContext _context;
        public PermessService(PermessDbContext context)
        {
            _context = context;
        }
        public void AddExportIssue(ExportIssue exportIssue, int concernId, int userId)
        {
            exportIssue.ConcernId = concernId;
            exportIssue.CreationDate = DateTime.Now;
            exportIssue.Creator = userId;
            _context.ExportIssues.Add(exportIssue);
            _context.SaveChanges();
        }

        public IEnumerable<ExportIssue> ExportIssues(int concernId)
        {
            return _context.ExportIssues.Where(m=>m.ConcernId==concernId);
        }
    }
}