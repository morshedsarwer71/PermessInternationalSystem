using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class ResponseLCStatements
    {
        public string SICode { get; set; }
        public string LcNumber { get; set; }
        public DateTime LCDate { get; set; }
        public string BankName { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Party { get; set; }
        public DateTime ExpDate { get; set; }
        public string Bill { get; set; }
    }
}