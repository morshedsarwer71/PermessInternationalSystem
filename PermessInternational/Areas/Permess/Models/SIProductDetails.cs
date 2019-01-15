using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class SIProductDetails
    {
        [Key]
        public int SIProductDetId { get; set; }
        public string SICode { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }
        public int ArticleId { get; set; }
        public string AltArticle { get; set; }
        public int WidthId { get; set; }
        public int ConstructionId { get; set; }
        public int SoftnessId { get; set; }
        public int SourceId { get; set; }
        public int ColorId { get; set; }
        public int LenghtId { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal DeliveryQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OverInvoice { get; set; }
        public int IsConfirmed { get; set; }
        public string Description { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
    }
}