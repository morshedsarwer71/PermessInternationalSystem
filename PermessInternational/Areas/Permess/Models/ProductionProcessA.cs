using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ProductionProcessA
    {
        [Key]
        public int ProcessAId { get; set; }
        public int OrderId { get; set; }
        public decimal OpeninBalance { get; set; }
        public decimal ReceivFromWHouse { get; set; }
        public decimal Used { get; set; }
        public decimal ProcessLoss { get; set; }
        public decimal Refund { get; set; }
        public decimal SendB { get; set; }
        public decimal ClosingBalance { get; set; }
        public int Creator { get; set; }
        public int ConcernId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}