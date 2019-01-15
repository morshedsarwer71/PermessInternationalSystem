using PermessInternational.Areas.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Global.ViewModels
{
    public class RoleUserViewModels
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}