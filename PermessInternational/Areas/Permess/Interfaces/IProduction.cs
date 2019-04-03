using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermessInternational.Areas.Permess.Interfaces
{
    public interface IProduction
    {
        void AddProductionOrder(ProductionOrder productionOrder,int concernId,int userId);
        void AddOrderRawMaterial(OrderRawMaterial orderRawMaterial, int concernId, int userId,int orderId);
        void ProductionChange(int id);
        IEnumerable<ResponseProductionOrder> ProductionOrders(int concernId,int IsProcess);
        IEnumerable<ResponseProductionOrder> ProductionProcess();        
        void ProcessA(int id, ProductionProcessA productionProcessA, int concernId);
        void UpdateProcessA(int id, ProductionProcessA productionProcessA, int concernId);
        void ProcessB(int id, ProductionProcessB productionProcessB, int concernId);
        void UpdateProcessB(int id, ProductionProcessB productionProcessB, int concernId);
        void ProcessC(int id, ProductionProcessC productionProcessC, int concernId);
        void UpdateProcessC(int id, ProductionProcessC productionProcessC, int concernId);
    }
}
