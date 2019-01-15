using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Global.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public int ConcernId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Creator { get; set; }
    }
}