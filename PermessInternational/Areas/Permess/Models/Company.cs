using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactPerson { get; set; }
        public string MobileNo { get; set; }
        public string Buyer { get; set; }
        public int ConcerinId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
    }
}