using PermessInternational.Areas.Permess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.ViewModels
{
    public class ProductViewModels
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductSetting> ProductSettings { get; set; }
    }
}