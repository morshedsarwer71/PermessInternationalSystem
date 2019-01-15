using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public string SICode { get; set; }
        public string BuyerOrderRef { get; set; }
        public string OrderDetail { get; set; }
        public int DeliveryTypeId { get; set; }
        public int ApprovalId { get; set; }
        public int Creator { get; set; }
        public int ConcernId { get; set; }
        public DateTime CreationDate { get; set; }

    }
}