using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermessInternational.Areas.Permess.Interfaces
{
    public interface IStock
    {
        void ImportGoods(ImportGood importGood,int concernId,int userId);
        IEnumerable<ResponseGoodsReport> ResponseGoods(int concernId,int goodsType);
        IEnumerable<ResponseStocks> ResponseStocks();
        IEnumerable<ResponseStocks> GeneralStocks();
        IEnumerable<ResponseStocks> RawMaterialsStocks();
        IEnumerable<ResponseStocks> SemiFinishedStocks();
        IEnumerable<ResponseStocks> FinishedStocks();
        IEnumerable<ResponseOrders> ResponseOrders();
        IEnumerable<ResponseOrders> ResponseOrdersByCode(string code);
        IEnumerable<ResponseOrders> OrdersReport(string fromDate,string toDate,int lcId,int deliveryId,int paymentMethodId,int companyId);
        IEnumerable<ResponseCashDetails> ResponseCashDetails();
        IEnumerable<ResponseLCStatements> ResponseLCStatements();
        IEnumerable<ResponseOrders> ProductReport(int productId,int userId,int customerId);
    }
}
