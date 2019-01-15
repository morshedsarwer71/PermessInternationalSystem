using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ImportGood
    {
        [Key]
        public int ImportGoodId { get; set; }
        public int GoodsType { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }
        public int ArticleId { get; set; }
        public string AltArticleId { get; set; }
        public int WidthId { get; set; }
        public int ConstructionId { get; set; }
        public int SoftnessId { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int SourceId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public decimal Quantity { get; set; }
        public string PerformaCode { get; set; }
        public string LCNumber { get; set; }
        public string Supplier { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
    }
}