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
    public class StockServices : IStock
    {
        private readonly PermessDbContext _context;
        public StockServices(PermessDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ResponseStocks> FinishedStocks()
        {
            List<ResponseStocks> responses = new List<ResponseStocks>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Update_Final_Stocks_Finished_Goods";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseStocks()
                            {
                                ProductCode = Convert.ToString(result[0]),
                                Article = Convert.ToString(result[1]),
                                Construction = Convert.ToString(result[2]),
                                Width = Convert.ToString(result[3]),
                                Softness = Convert.ToString(result[4]),
                                Color = Convert.ToString(result[5]),
                                Sources = Convert.ToString(result[6]),
                                ProductName = Convert.ToString(result[7]),
                                Quantity = Convert.ToDecimal(result[8])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }

        public IEnumerable<ResponseStocks> GeneralStocks()
        {
            List<ResponseStocks> responses = new List<ResponseStocks>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Update_Final_Stocks";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseStocks()
                            {
                                ProductCode = Convert.ToString(result[0]),
                                Article= Convert.ToString(result[1]),
                                Construction = Convert.ToString(result[2]),
                                Width = Convert.ToString(result[3]),
                                Softness = Convert.ToString(result[4]),
                                Color = Convert.ToString(result[5]),
                                Sources = Convert.ToString(result[6]),
                                ProductName = Convert.ToString(result[7]),
                                Quantity = Convert.ToDecimal(result[8])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }

        public void ImportGoods(ImportGood importGood, int concernId, int userId)
        {
            var code = importGood.ProductId + "" + importGood.ArticleId + "" + importGood.WidthId + "" + importGood.ConstructionId + "" + importGood.SoftnessId + "" + importGood.SourceId + "" + importGood.ColorId;
            var productCode = _context.ProductNames.FirstOrDefault(m => m.ProductCode == code);
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                if (productCode == null)
                {
                    ProductName product = new ProductName();
                    product.ProductCode = code;
                    product.ProductId = importGood.ProductId;
                    product.ArticleId = importGood.ArticleId;
                    product.WidthId = importGood.WidthId;
                    product.ConstructionId = importGood.ConstructionId;
                    product.SoftnessId = importGood.SoftnessId;
                    product.SourceId = importGood.SourceId;
                    product.ColorId = importGood.ColorId;
                    _context.ProductNames.Add(product);
                    _context.SaveChanges();

                    importGood.ConcernId = concernId;
                    importGood.Creator = userId;
                    importGood.ProductCode = code;
                    importGood.CreationDate = DateTime.Now;
                    _context.ImportGoods.Add(importGood);
                    _context.SaveChanges();

                    transaction.Commit();

                }
                else
                {
                    importGood.ConcernId = concernId;
                    importGood.Creator = userId;
                    importGood.ProductCode = code;
                    importGood.CreationDate = DateTime.Now;
                    _context.ImportGoods.Add(importGood);
                    _context.SaveChanges();

                    transaction.Commit();
                }
            }            
        }

        public IEnumerable<ResponseOrders> OrdersReport(string fromDate, string toDate, int lcId, int deliveryId, int paymentMethodId, int companyId)
        {
            List<ResponseOrders> responses = new List<ResponseOrders>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permess_Order_Reporting @fromDate,@toDate,@LcId,@DeliveryId,@PaymentMethod,@companyId";
                command.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                command.Parameters.Add(new SqlParameter("@toDate", toDate));
                command.Parameters.Add(new SqlParameter("@LcId", lcId));
                command.Parameters.Add(new SqlParameter("@DeliveryId", deliveryId));
                command.Parameters.Add(new SqlParameter("@PaymentMethod", paymentMethodId));
                command.Parameters.Add(new SqlParameter("@companyId", companyId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseOrders()
                            {
                                SICode = Convert.ToString(result[0]),
                                Date = Convert.ToString(result[1]),
                                Companyname = Convert.ToString(result[2]),
                                OrderQuantity = Convert.ToDecimal(result[3]),
                                NetPrice = Convert.ToDecimal(result[4]),
                                OverInvoice = Convert.ToDecimal(result[5]),
                                BuyerRef = Convert.ToString(result[6]),
                                LC = Convert.ToString(result[7]),
                                Delivery = Convert.ToString(result[8]),
                                PaymentMethod = Convert.ToString(result[9]),
                                Quantity = Convert.ToDecimal(result[10])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }

        public IEnumerable<ResponseStocks> RawMaterialsStocks()
        {
            List<ResponseStocks> responses = new List<ResponseStocks>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Update_Final_Stocks_Raw_Material";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseStocks()
                            {
                                ProductCode = Convert.ToString(result[0]),
                                Article = Convert.ToString(result[1]),
                                Construction = Convert.ToString(result[2]),
                                Width = Convert.ToString(result[3]),
                                Softness = Convert.ToString(result[4]),
                                Color = Convert.ToString(result[5]),
                                Sources = Convert.ToString(result[6]),
                                ProductName = Convert.ToString(result[7]),
                                Quantity = Convert.ToDecimal(result[8])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }

        public IEnumerable<ResponseCashDetails> ResponseCashDetails()
        {
            List<ResponseCashDetails> responses = new List<ResponseCashDetails>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permess_CashTT";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                        while (result.Read())
                        {
                            responses.Add(new ResponseCashDetails()
                            {
                                SICode = Convert.ToString(result[0]),
                                IssuedDate = Convert.ToDateTime(result[1]),
                                Company = Convert.ToString(result[2]),
                                Delivery = Convert.ToString(result[3]),
                                Bill = Convert.ToString(result[4]),
                                BilllingDate = Convert.ToDateTime(result[5]),
                                Commision = Convert.ToDecimal(result[6]),
                                TotalReceived = Convert.ToDecimal(result[7]),
                            });
                        }
                }
                    _context.Database.Connection.Close();
            }
                return responses;
            
        }

        public IEnumerable<ResponseGoodsReport> ResponseGoods(int concernId, int goodsType)
        {
            List<ResponseGoodsReport> responses = new List<ResponseGoodsReport>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permess_Goods_Stock_By_GoodsTypeId @concernId,@goodsType";
                command.Parameters.Add(new SqlParameter("@concernId", concernId));
                command.Parameters.Add(new SqlParameter("@goodsType", goodsType));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseGoodsReport()
                            {
                                ReceivedDate = Convert.ToString(result[0]),
                                Quantity = Convert.ToDecimal(result[1]),
                                PerformerCode = Convert.ToString(result[2]),                                
                                Supplier = Convert.ToString(result[3]),
                                Article = Convert.ToString(result[4]),
                                Width = Convert.ToString(result[5]),
                                AltArticle = Convert.ToString(result[6]),
                                Construction = Convert.ToString(result[7]),
                                ProductName = Convert.ToString(result[8]),
                                Softness = Convert.ToString(result[9]),
                                Source = Convert.ToString(result[10]),
                                Description = Convert.ToString(result[11]),
                                Serial = Convert.ToInt32(result[12]),
                                LCNumber = Convert.ToString(result[13]),
                                Color = Convert.ToString(result[14])

                            });
                        }
                    }
                }
                    _context.Database.Connection.Close();
            }
                return responses;
        }

        public IEnumerable<ResponseLCStatements> ResponseLCStatements()
        {
            List<ResponseLCStatements> responses = new List<ResponseLCStatements>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permess_LC";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                        while (result.Read())
                        {
                            responses.Add(new ResponseLCStatements() {
                                SICode = Convert.ToString(result[0]),
                                LcNumber = Convert.ToString(result[1]),
                                LCDate = Convert.ToDateTime(result[2]),
                                BankName = Convert.ToString(result[3]),
                                SubmitDate = Convert.ToDateTime(result[4]),
                                Party = Convert.ToString(result[5]),
                                ExpDate = Convert.ToDateTime(result[6]),
                            });
                        }
                }
                    _context.Database.Connection.Close();
            }
                return responses;
        }

        public IEnumerable<ResponseOrders> ResponseOrders()
        {
            List<ResponseOrders> responses = new List<ResponseOrders>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permes_Orders";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseOrders()
                            {
                                SICode = Convert.ToString(result[0]),
                                IssueDate = Convert.ToDateTime(result[1]),
                                Companyname = Convert.ToString(result[2]),
                                OrderQuantity = Convert.ToDecimal(result[3]),
                                NetPrice = Convert.ToDecimal(result[4]),
                                OverInvoice = Convert.ToDecimal(result[5]),
                                BuyerRef = Convert.ToString(result[6]),
                                LC = Convert.ToString(result[7]),
                                Delivery = Convert.ToString(result[8]),
                                PaymentMethod= Convert.ToString(result[9]),
                                SIDocumentCode= Convert.ToString(result[10]),
                                SIProductCode= Convert.ToString(result[11]),
                                Quantity= Convert.ToDecimal(result[12])
                                
                            });
                        }
                    }
                }
                    _context.Database.Connection.Close();
            }
                return responses;
        }
        public IEnumerable<ResponseOrders> ResponseOrdersByCode(string code)
        {
            List<ResponseOrders> responses = new List<ResponseOrders>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Permes_Orders_Print @Code";
                command.Parameters.Add(new SqlParameter("@Code", code));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseOrders()
                            {
                                SICode = Convert.ToString(result[0]),
                                IssueDate = Convert.ToDateTime(result[1]),
                                Companyname = Convert.ToString(result[2]),
                                OrderQuantity = Convert.ToDecimal(result[3]),
                                NetPrice = Convert.ToDecimal(result[4]),
                                OverInvoice = Convert.ToDecimal(result[5]),
                                BuyerRef = Convert.ToString(result[6]),
                                LC = Convert.ToString(result[7]),
                                Delivery = Convert.ToString(result[8]),
                                PaymentMethod = Convert.ToString(result[9]),
                                SIDocumentCode = Convert.ToString(result[10]),
                                SIProductCode = Convert.ToString(result[11]),
                                Quantity = Convert.ToDecimal(result[12]),
                                CompanyAddress = Convert.ToString(result[13]),
                                DeliveryAddress = Convert.ToString(result[14]),
                                ContactPerson = Convert.ToString(result[15]),
                                IssuedBy = Convert.ToString(result[16]),
                                PoNumber = Convert.ToString(result[17]),
                                Buyer = Convert.ToString(result[18]),
                                GoodsReqDate = Convert.ToDateTime(result[19]),
                                HSCode = Convert.ToString(result[20])

                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }

        public IEnumerable<ResponseStocks> ResponseStocks()
        {
            List<ResponseStocks> responses = new List<ResponseStocks>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Update_Final_Stocks";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseStocks() {
                                ProductName = Convert.ToString(result[0]),
                                ProductId = Convert.ToInt32(result[1]),
                                Quantity = Convert.ToDecimal(result[2])
                            });
                        }
                    }
                }
                    _context.Database.Connection.Close();
            }
                return responses;
        }

        public IEnumerable<ResponseStocks> SemiFinishedStocks()
        {
            List<ResponseStocks> responses = new List<ResponseStocks>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Update_Final_Stocks_Semi_Finished_Goods";
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseStocks()
                            {
                                ProductCode = Convert.ToString(result[0]),
                                Article = Convert.ToString(result[1]),
                                Construction = Convert.ToString(result[2]),
                                Width = Convert.ToString(result[3]),
                                Softness = Convert.ToString(result[4]),
                                Color = Convert.ToString(result[5]),
                                Sources = Convert.ToString(result[6]),
                                ProductName = Convert.ToString(result[7]),
                                Quantity = Convert.ToDecimal(result[8])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }
    }
}