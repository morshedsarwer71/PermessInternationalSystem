using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using PermessInternational.PermessContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Services
{
    public class ProductionService : IProduction
    {
        private readonly PermessDbContext _context;
        public ProductionService(PermessDbContext context)
        {
            _context = context;
        }

        public void AddOrderRawMaterial(OrderRawMaterial orderRawMaterial, int concernId, int userId, int orderId)
        {
            var code = orderRawMaterial.ProductId + "" + orderRawMaterial.ArticleId + "" + orderRawMaterial.WidthId + "" + orderRawMaterial.ConstructionId + "" + orderRawMaterial.SoftnessId + "" + orderRawMaterial.SourceId + "" + orderRawMaterial.ColorId;
            var productCode = _context.ProductNames.FirstOrDefault(m => m.ProductCode == code);
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                if (productCode == null)
                {
                    ProductName product = new ProductName();
                    product.ProductCode = code;
                    product.ProductId = orderRawMaterial.ProductId;
                    product.ArticleId = orderRawMaterial.ArticleId;
                    product.WidthId = orderRawMaterial.WidthId;
                    product.ConstructionId = orderRawMaterial.ConstructionId;
                    product.SoftnessId = orderRawMaterial.SoftnessId;
                    product.SourceId = orderRawMaterial.SourceId;
                    product.ColorId = orderRawMaterial.ColorId;
                    _context.ProductNames.Add(product);
                    _context.SaveChanges();

                    orderRawMaterial.ConcernId = concernId;
                    orderRawMaterial.ProductCode = code;
                    orderRawMaterial.Creator = userId;
                    orderRawMaterial.CreationDate = DateTime.Now;
                    orderRawMaterial.OrderId = orderId;
                    _context.OrderRawMaterials.Add(orderRawMaterial);
                    _context.SaveChanges();

                    transaction.Commit();

                }
                else
                {
                    orderRawMaterial.ConcernId = concernId;
                    orderRawMaterial.ProductCode = code;
                    orderRawMaterial.Creator = userId;
                    orderRawMaterial.CreationDate = DateTime.Now;
                    orderRawMaterial.OrderId = orderId;
                    _context.OrderRawMaterials.Add(orderRawMaterial);
                    _context.SaveChanges();

                    transaction.Commit();
                }
            }
        }

        public void AddProductionOrder(ProductionOrder productionOrder, int concernId, int userId)
        {
            var code = productionOrder.ProductId + "" + productionOrder.ArticleId + "" + productionOrder.WidthId + "" + productionOrder.ConstructionId + "" + productionOrder.SoftnessId + "" + productionOrder.SourceId + "" + productionOrder.ColorId;
            var productCode = _context.ProductNames.FirstOrDefault(m => m.ProductCode == code);
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                if (productCode==null)
                {
                    ProductName product = new ProductName();
                    product.ProductCode = code;
                    product.ProductId = productionOrder.ProductId;
                    product.ArticleId = productionOrder.ArticleId;
                    product.WidthId = productionOrder.WidthId;
                    product.ConstructionId = productionOrder.ConstructionId;
                    product.SoftnessId = productionOrder.SoftnessId;
                    product.SourceId = productionOrder.SourceId;
                    product.ColorId = productionOrder.ColorId;
                    _context.ProductNames.Add(product);
                    _context.SaveChanges();

                    productionOrder.ConcernId = concernId;
                    productionOrder.ProductCode = code;
                    productionOrder.Creator = userId;
                    productionOrder.GoodsType = 3;
                    productionOrder.CreationDate = DateTime.Now;
                    _context.ProductionOrders.Add(productionOrder);
                    _context.SaveChanges();

                    transaction.Commit();
                    
                }
                else
                {
                    productionOrder.ConcernId = concernId;
                    productionOrder.ProductCode = code;
                    productionOrder.Creator = userId;
                    productionOrder.GoodsType = 3; 
                    productionOrder.CreationDate = DateTime.Now;
                    _context.ProductionOrders.Add(productionOrder);
                    _context.SaveChanges();

                    transaction.Commit();
                }
            }

        }

        public void ProcessA(int id, ProductionProcessA productionProcessA, int concernId)
        {
            productionProcessA.OrderId = id;
            productionProcessA.CreationDate = DateTime.Now;
            productionProcessA.ConcernId = concernId;
            _context.AProductions.Add(productionProcessA);
            _context.SaveChanges();
        }

        public void ProcessB(int id, ProductionProcessB productionProcessB, int concernId)
        {
            productionProcessB.OrderId = id;
            productionProcessB.CreationDate = DateTime.Now;
            productionProcessB.ConcernId = concernId;
            _context.BProductions.Add(productionProcessB);
            _context.SaveChanges();
        }

        public void ProcessC(int id, ProductionProcessC productionProcessC, int concernId)
        {
            productionProcessC.OrderId = id;
            productionProcessC.CreationDate = DateTime.Now;
            productionProcessC.ConcernId = concernId;
            _context.CProductions.Add(productionProcessC);
            _context.SaveChanges();
        }

        public void ProductionChange(int id)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var order = _context.ProductionOrders.FirstOrDefault(m => m.ProductionOrderId == id);
                order.IsProcess = 1;
                order.ProductionStatus = 1;
                _context.SaveChanges();

                var process = _context.OrderRawMaterials.FirstOrDefault(m => m.OrderId == id);
                process.IsProcess = 1;
                _context.SaveChanges();

                dbContextTransaction.Commit();
            }

        }

        public IEnumerable<ResponseProductionOrder> ProductionOrders(int concernId, int IsProcess)
        {
            List<ResponseProductionOrder> orders = new List<ResponseProductionOrder>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permess_Production_Order @concernId,@IsProcess";
                command.Parameters.Add(new SqlParameter("@concernId", concernId));
                command.Parameters.Add(new SqlParameter("@IsProcess", IsProcess));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            orders.Add(new ResponseProductionOrder()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                OrderId = Convert.ToInt32(result[1]),
                                Amount = Convert.ToDecimal(result[2]),
                                Time = Convert.ToString(result[3]),
                                Article = Convert.ToString(result[4]),
                                Construction = Convert.ToString(result[5]),
                                Product = Convert.ToString(result[6]),
                                Softness = Convert.ToString(result[7]),
                                Source = Convert.ToString(result[8]),
                                Width = Convert.ToString(result[9]),
                                Assigned = Convert.ToString(result[10]),
                                ProcessType = Convert.ToString(result[11]),
                                Status = Convert.ToString(result[12]),

                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return orders;
        }

        public IEnumerable<ResponseProductionOrder> ProductionProcess()
        {
            List<ResponseProductionOrder> orders = new List<ResponseProductionOrder>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permess_Production_Process";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            orders.Add(new ResponseProductionOrder()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                OrderId = Convert.ToInt32(result[1]),
                                Amount = Convert.ToDecimal(result[2]),
                                Article = Convert.ToString(result[3]),
                                Construction = Convert.ToString(result[4]),
                                Product = Convert.ToString(result[5]),
                                Softness = Convert.ToString(result[6]),
                                Source = Convert.ToString(result[7]),
                                Width = Convert.ToString(result[8]),
                                Time = Convert.ToString(result[9])                                

                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return orders;
        }

        public void UpdateProcessA(int id, ProductionProcessA productionProcessA, int concernId)
        {
            var update = _context.AProductions.FirstOrDefault(m=>m.OrderId==id);
            update.OpeninBalance = productionProcessA.OpeninBalance;
            update.ClosingBalance = productionProcessA.ClosingBalance;
            update.ProcessLoss = productionProcessA.ProcessLoss;
            update.ReceivFromWHouse = productionProcessA.ReceivFromWHouse;
            update.Refund = productionProcessA.Refund;
            update.SendB = productionProcessA.SendB;
            update.Used = productionProcessA.Used;
            update.ThirdPartyStatus = productionProcessA.ThirdPartyStatus;
            _context.SaveChanges();
        }

        public void UpdateProcessB(int id, ProductionProcessB productionProcessB, int concernId)
        {
            var update = _context.BProductions.FirstOrDefault(m => m.OrderId == id);
            update.ClosingBalance = productionProcessB.ClosingBalance;
            update.OpeninBalance = productionProcessB.OpeninBalance;
            update.ProcessLoss = productionProcessB.ProcessLoss;
            update.ReadyToUse = productionProcessB.ReadyToUse;
            update.ReceivFromA = productionProcessB.ReceivFromA;
            update.SendFinal = productionProcessB.SendFinal;
            update.Total = productionProcessB.Total;
            update.ThirdPartyStatus = productionProcessB.ThirdPartyStatus;
            _context.SaveChanges();
        }

        public void UpdateProcessC(int id, ProductionProcessC productionProcessC, int concernId)
        {
            var update = _context.CProductions.FirstOrDefault(m => m.OrderId == id);
            update.GradeA = productionProcessC.GradeA;
            update.GradeB = productionProcessC.GradeB;
            update.GradeC = productionProcessC.GradeC;
            update.GradeD = productionProcessC.GradeD;
            update.IsFinal = productionProcessC.IsFinal;
            update.OpeninBalance = productionProcessC.OpeninBalance;
            update.ReceivFromB = productionProcessC.ReceivFromB;
            update.Refected = productionProcessC.Refected;
            update.SenDFinal = productionProcessC.SenDFinal;
            update.ThirdPartyStatus = productionProcessC.ThirdPartyStatus;
            _context.SaveChanges();
        }
    }
}