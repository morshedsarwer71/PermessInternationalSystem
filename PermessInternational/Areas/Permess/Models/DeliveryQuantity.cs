using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class DeliveryQuantity
    {
        [Key]
        public int DeliveryQuantityID { get; set; }
        public string SIProductDetailsCode { get; set; }
        public decimal Quantity { get; set; }
        public string ProductCode { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
    }
}