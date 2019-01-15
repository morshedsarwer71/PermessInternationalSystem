using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ProductionOrder
    {
        [Key]
        public int ProductionOrderId { get; set; }
        public string SICode { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }
        public int ArticleId { get; set; }
        public string AltArticleId { get; set; }
        public int WidthId { get; set; }
        public int ConstructionId { get; set; }
        public int SoftnessId { get; set; }
        public int SourceId { get; set; }
        public int ColorId { get; set; }
        public decimal RequiredAmount { get; set; }
        public int ProcessType { get; set; }
        public int GoodsType { get; set; }
        public string AssignedTime { get; set; }
        public int AssignTo { get; set; }
        public int ProductionStatus { get; set; }
        public int IsProcess { get; set; }
        public string Description { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }

    }
}