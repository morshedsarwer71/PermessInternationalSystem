using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermessInternational.Areas.Permess.Interfaces
{
    public interface ISalesInvoice
    {
        void AddSIDocumentDetails(SIDocumentDetails sIDocument,int userId,int concernId);
        void UpdateSIDocumentDetails(SIDocumentDetails sIDocument,int userId,int concernId, string code);
        void AddSIProductDetails(SIProductDetails sIProductDetails, int userId, int concernId);
        void UpdateSIProductDetails(SIProductDetails sIProductDetails, int userId, int concernId, string Code);
        IEnumerable<SISessionproductDetails> SISessionproductDetails(string code);
        IEnumerable<SISessionproductDetails> SRISessionproductDetails(string code);
        void ClearSalesProductById(int id);
        void ClearSalesReturnProductById(int id);
        void AddLCStatement(LCStatement lCStatement,int concernID,int userId, int code);
        void UpdateLCStatement(LCStatement lCStatement,int concernID,int userId, int code);
        void AddCashDetails(CashDetails cashDetails, int concernID, int userId, int code);
        void UpdateCashDetails(CashDetails cashDetails, int concernID, int userId, int code);
        void AddOrderDetails(OrderDetails orderDetails, int concernID, int userId, int code);
        void UpdateOrderDetails(OrderDetails orderDetails, int concernID, int userId, int code);
        IEnumerable<Region> Regions(int concernId);
        void AddSalesReturn(SRIProductDetails productDetails,int concernId,int userId);
        IEnumerable<SalesReturn> SalesReturns(int concernId);
        void UpdateDeliveryQuantity(DeliveryQuantity deliveryQuantity,int userId,int concernId,int id);
        void DeleteInvoice(int id);
    }
}
