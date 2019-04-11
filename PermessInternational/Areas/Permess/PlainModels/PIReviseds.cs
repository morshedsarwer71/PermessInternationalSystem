using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class PIReviseds
    {
        public int Count { get; set; }
        public string PICode { get; set; }
        public string UserId { get; set; }
        public DateTime RevisedDate { get; set; }
        public string Time { get; set; }
        public string RevisedDocs { get; set; }
    }
}