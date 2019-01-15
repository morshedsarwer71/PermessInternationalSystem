using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class SalesReturn
    {
        public string ReturnCode { get; set; }
        public string SalesCode { get; set; }
        public int Items { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}