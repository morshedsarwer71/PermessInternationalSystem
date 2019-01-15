using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ProductionProcessB
    {
        [Key]
        public int ProcessBId { get; set; }
        public int OrderId { get; set; }
        public decimal OpeninBalance { get; set; }
        public decimal ReceivFromA { get; set; }
        public decimal Total { get; set; }
        public decimal ProcessLoss { get; set; }
        public decimal ReadyToUse { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal SendFinal { get; set; }
        public int Creator { get; set; }
        public int ConcernId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}