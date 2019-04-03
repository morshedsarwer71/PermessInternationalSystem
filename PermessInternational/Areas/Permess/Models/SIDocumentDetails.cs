using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class SIDocumentDetails
    {
        [Key]
        public int SIDocumentDetId { get; set; }
        public string SICode { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssuedBy { get; set; }
        public string SIName { get; set; }
        public string PONumber { get; set; }
        public string Style { get; set; }
        public int DeliveryStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ItemNo { get; set; }
        public int DeliveryType { get; set; }
        public string Buyer { get; set; }
        public int PaymentMethod { get; set; }
        public int Bank { get; set; }
        public int CompanyId { get; set; }
        public int DocumentStatus { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactPerson { get; set; }
        public int Revised { get; set; }
        public int ApprovedStatus { get; set; }
        public int CommisionStatus { get; set; }
        public decimal CommisionAmount { get; set; }
        public int LCStatus { get; set; }
        public string HSCode { get; set; }
        public string BuyerOrderRef { get; set; }
        public DateTime GoodsReqDate { get; set; }
        public string OrderDetails { get; set; }
        public string Description { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }


    }
}