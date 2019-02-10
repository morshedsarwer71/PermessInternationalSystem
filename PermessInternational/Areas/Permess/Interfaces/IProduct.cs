using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using PermessInternational.Areas.Permess.StaticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermessInternational.Areas.Permess.Interfaces
{
    public interface IProduct
    {
        void AddProduct(Product product,int concernId,int userId);        
        void AddProductSetting(ProductSetting productSetting,int concernId, int userId);
        IEnumerable<Product> Products(int concernId);
        IEnumerable<ResponseProductSetting> ArticleProductSettings(int concernId);
        IEnumerable<ResponseProductSetting> ConstructionProductSettings(int concernId);
        IEnumerable<ResponseProductSetting> WidthProductSettings(int concernId);
        IEnumerable<ResponseProductSetting> SoftnessProductSettings(int concernId);
        IEnumerable<ResponseProductSetting> ColorProductSettings(int concernId);
        IEnumerable<ResponseProductSetting> SourceProductSettings(int concernId);
        IEnumerable<ResponseProductSetting> CategoryProductSettings(int concernId);
        IEnumerable<YesNoModel> YesNoModels();
        IEnumerable<PaymentMethod> PaymentMethods();
        IEnumerable<Bank> Banks();
        IEnumerable<Status> Statuses();
        IEnumerable<Length> Lengths();
        IEnumerable<DeliveryType> DeliveryTypes();
    }
}
