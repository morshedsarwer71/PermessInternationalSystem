using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class OrderRawMaterial
    {
        [Key]
        public int OrderRawMaterialId { get; set; }
        public int OrderId { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }
        public int ArticleId { get; set; }
        public string AltArticle { get; set; }
        public int WidthId { get; set; }
        public int ConstructionId { get; set; }
        public int SoftnessId { get; set; }
        public int SourceId { get; set; }
        public int ColorId { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public int IsProcess { get; set; }
        public DateTime CreationDate { get; set; }
    }
}