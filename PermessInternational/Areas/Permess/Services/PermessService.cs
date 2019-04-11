using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using PermessInternational.PermessContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public void AddRevisedData(PIRevised pIRevised)
        {
            _context.PIReviseds.Add(pIRevised);
            _context.SaveChanges();
        }

        public IEnumerable<ExportIssue> ExportIssues(int concernId)
        {
            return _context.ExportIssues.Where(m=>m.ConcernId==concernId);
        }

        public IEnumerable<PIReviseds> PIReviseds(string code)
        {
            List<PIReviseds> reviseds = new List<PIReviseds>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permess_Revised @code";
                command.Parameters.Add(new SqlParameter("@code", code));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            reviseds.Add(new PlainModels.PIReviseds()

                            {
                                UserId = Convert.ToString(result[0]),
                                RevisedDate = Convert.ToDateTime(result[1]),
                                Time = Convert.ToString(result[2]),
                                PICode = Convert.ToString(result[3]),
                                Count = Convert.ToInt32(result[4])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }

                return reviseds;
        }
    }
}