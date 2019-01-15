using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ProductName
    {
        [Key]
        public int ProductNameId { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }
        public int ArticleId { get; set; }
        public string AltArticleId { get; set; }
        public int WidthId { get; set; }
        public int ConstructionId { get; set; }
        public int SoftnessId { get; set; }
        public int SourceId { get; set; }
        public int ColorId { get; set; }
    }
}