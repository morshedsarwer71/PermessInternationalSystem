using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class ResponseCashDetails
    {
        public string SICode { get; set; }
        public DateTime IssuedDate { get; set; }
        public string Company { get; set; }
        public string Delivery { get; set; }
        public string Bill { get; set; }
        public DateTime BilllingDate { get; set; }
        public decimal Commision { get; set; }
        public decimal TotalReceived { get; set; }
    }
}