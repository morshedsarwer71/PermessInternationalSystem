using PermessInternational.Areas.Permess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermessInternational.Areas.Permess.Interfaces
{
    public interface IBuyer
    {
        void AddCompany(Company company,int concernId,int userId);
        IEnumerable<Company> Companies(int concernId);
        Company Company(int companyId);
    }
}
