using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class CashDetails
    {
        [Key]
        public int CashDetailsId { get; set; }
        public string SICode { get; set; }
        public int BillNo { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal TotalReceived { get; set; }
        public string ChalanInfo { get; set; }
        public string FromDestination { get; set; }
        public string ToDestination { get; set; }
        public decimal USD { get; set; }
        public decimal ComissionUSD { get; set; }
        public string Description { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }

    }
}