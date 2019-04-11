using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermessInternational.Areas.Permess.Interfaces
{
    public interface IPermess
    {
        void AddExportIssue(ExportIssue exportIssue,int concernId,int userId);
        IEnumerable<ExportIssue> ExportIssues(int concernId);
        IEnumerable<PIReviseds> PIReviseds(string code);
        void AddRevisedData(PIRevised pIRevised);
    }
}
