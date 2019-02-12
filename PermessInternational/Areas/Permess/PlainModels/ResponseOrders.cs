using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.PlainModels
{
    public class ResponseOrders
    {
        public string SICode { get; set; }
        public DateTime IssueDate { get; set; }
        public string Date { get; set; }
        public string Companyname { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal OverInvoice { get; set; }
        public string BuyerRef { get; set; }
        public string LC { get; set; }
        public string Delivery { get; set; }
        public string PaymentMethod { get; set; }
        public string SIDocumentCode { get; set; }
        public string SIProductCode { get; set; }
        public decimal Quantity { get; set; }
    }
}