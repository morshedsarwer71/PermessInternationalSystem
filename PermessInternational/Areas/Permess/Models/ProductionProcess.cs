using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ProductionProcess
    {
        [Key]
        public int ProductionProcessId { get; set; }
        public int ProductionOrderId { get; set; }
        public decimal OpeninBalanceA { get; set; }
        public decimal OpeninBalanceB { get; set; }
        public decimal OpeninBalanceC { get; set; }
        public decimal ReceivFromWHouse { get; set; }
        public decimal ReceivFromA { get; set; }
        public decimal ReceivFromB { get; set; }
        public decimal Used { get; set; }
        public decimal Total { get; set; }
        public decimal GradeA { get; set; }
        public decimal ProcessLossA { get; set; }
        public decimal ProcessLossB { get; set; }
        public decimal GradeB { get; set; }
        public decimal GradeD { get; set; }
        public decimal Refund { get; set; }
        public decimal ReadyToUse { get; set; }
        public decimal GradeC { get; set; }
        public decimal SendB { get; set; }
        public decimal SendFinal { get; set; }
        public decimal ClosingA { get; set; }
        public decimal RejectedFinal { get; set; }
        public decimal Final { get; set; }
    }
}