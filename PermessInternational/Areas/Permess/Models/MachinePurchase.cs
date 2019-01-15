using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class MachinePurchase
    {
        [Key]
        public int MachinePurchaseId { get; set; }
        public string MachineName { get; set; }
        public string Specification { get; set; }
        public int Quantity { get; set; }
        public string Retension { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }

    }
}