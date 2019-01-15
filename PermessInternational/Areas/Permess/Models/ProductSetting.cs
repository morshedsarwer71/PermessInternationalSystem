using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ProductSetting
    {
        [Key]
        public int ProductSettId { get; set; }
        public string Article { get; set; }
        public string Construction { get; set; }
        public string Width { get; set; }
        public string Softness { get; set; }
        public string Color { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
    }
}