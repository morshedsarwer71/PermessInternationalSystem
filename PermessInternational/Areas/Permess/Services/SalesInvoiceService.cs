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
    public class SalesInvoiceService : ISalesInvoice
    {
        private readonly PermessDbContext _context;
        public SalesInvoiceService(PermessDbContext context)
        {
            _context = context;
        }

        public void AddCashDetails(CashDetails cashDetails, int concernID, int userId, int code)
        {
            cashDetails.ConcernId = concernID;
            cashDetails.Creator = userId;
            cashDetails.CreationDate = DateTime.Now;
            cashDetails.SICode = code.ToString();
            _context.CashDetails.Add(cashDetails);
            _context.SaveChanges();
        }

        public void AddLCStatement(LCStatement lCStatement, int concernID, int userId, int code)
        {
            lCStatement.ConcernId = concernID;
            lCStatement.Creator = userId;
            lCStatement.CreationDate = DateTime.Now;
            lCStatement.SICode = code.ToString();
            _context.LCStatements.Add(lCStatement);
            _context.SaveChanges();
        }

        public void AddOrderDetails(OrderDetails orderDetails, int concernID, int userId, int code)
        {
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                orderDetails.ConcernId = concernID;
                orderDetails.SICode = code.ToString();
                orderDetails.Creator = userId;
                orderDetails.CreationDate = DateTime.Now;
                _context.OrderDetails.Add(orderDetails);
                _context.SaveChanges();
                var id = code.ToString();
                var data = _context.SIDocumentDetails.FirstOrDefault(m => m.SICode == id);
                data.DeliveryStatus = orderDetails.DeliveryTypeId;
                _context.SaveChanges();

                transaction.Commit();
            }

        }

        public void AddSalesReturn(SRIProductDetails productDetails, int concernId, int userId)
        {
            var code = productDetails.ProductId + "" + productDetails.ArticleId + "" + productDetails.WidthId + "" + productDetails.ConstructionId + "" + productDetails.SoftnessId + "" + productDetails.SourceId + "" + productDetails.ColorId;
            var productCode = _context.ProductNames.FirstOrDefault(m => m.ProductCode == code);
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                if (productCode == null)
                {
                    ProductName product = new ProductName();
                    product.ProductCode = code;
                    product.ProductId = productDetails.ProductId;
                    product.ArticleId = productDetails.ArticleId;
                    product.WidthId = productDetails.WidthId;
                    product.ConstructionId = productDetails.ConstructionId;
                    product.SoftnessId = productDetails.SoftnessId;
                    product.SourceId = productDetails.SourceId;
                    product.ColorId = productDetails.ColorId;
                    _context.ProductNames.Add(product);
                    _context.SaveChanges();

                    productDetails.ConcernId = concernId;
                    productDetails.Creator = userId;
                    productDetails.ProductCode = code;
                    productDetails.CreationDate = DateTime.Now;
                    _context.SRIProductDetails.Add(productDetails);
                    _context.SaveChanges();

                    transaction.Commit();

                }
                else
                {
                    productDetails.ConcernId = concernId;
                    productDetails.Creator = userId;
                    productDetails.ProductCode = code;
                    productDetails.CreationDate = DateTime.Now;
                    _context.SRIProductDetails.Add(productDetails);
                    _context.SaveChanges();

                    transaction.Commit();
                }
            }

        }

        public void AddSIDocumentDetails(SIDocumentDetails sIDocument, int userId, int concernId)
        {
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                sIDocument.ConcernId = concernId;
                sIDocument.CreationDate = DateTime.Now;
                sIDocument.Creator = userId;
                _context.SIDocumentDetails.Add(sIDocument);
                _context.SaveChanges();

                transaction.Commit();
            }

        }

        public void AddSIProductDetails(SIProductDetails sIProductDetails, int userId, int concernId)
        {
            var code = sIProductDetails.ProductId + "" + sIProductDetails.ArticleId + "" + sIProductDetails.WidthId + "" + sIProductDetails.ConstructionId + "" + sIProductDetails.SoftnessId + "" + sIProductDetails.SourceId + "" + sIProductDetails.ColorId;
            var productCode = _context.ProductNames.FirstOrDefault(m => m.ProductCode == code);
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                if (productCode == null)
                {
                    ProductName product = new ProductName();
                    product.ProductCode = code;
                    product.ProductId = sIProductDetails.ProductId;
                    product.ArticleId = sIProductDetails.ArticleId;
                    product.WidthId = sIProductDetails.WidthId;
                    product.ConstructionId = sIProductDetails.ConstructionId;
                    product.SoftnessId = sIProductDetails.SoftnessId;
                    product.SourceId = sIProductDetails.SourceId;
                    product.ColorId = sIProductDetails.ColorId;
                    _context.ProductNames.Add(product);
                    _context.SaveChanges();

                    sIProductDetails.ConcernId = concernId;
                    sIProductDetails.ProductCode = code;
                    sIProductDetails.CreationDate = DateTime.Now;
                    sIProductDetails.Creator = userId;
                    //sIProductDetails.DeliveryQuantity = 0;
                    _context.SIProductDetails.Add(sIProductDetails);
                    _context.SaveChanges();

                    DeliveryQuantity delivery = new DeliveryQuantity();

                    delivery.ConcernId = concernId;
                    delivery.ProductCode = sIProductDetails.SICode;
                    delivery.CreationDate = DateTime.Now;
                    delivery.Creator = userId;
                    delivery.Quantity = sIProductDetails.DeliveryQuantity;
                    _context.DeliveryQuantities.Add(delivery);
                    _context.SaveChanges();

                    transaction.Commit();

                }
                else
                {
                    sIProductDetails.ConcernId = concernId;
                    sIProductDetails.ProductCode = code;
                    sIProductDetails.CreationDate = DateTime.Now;
                    sIProductDetails.Creator = userId;
                    _context.SIProductDetails.Add(sIProductDetails);
                    _context.SaveChanges();

                    DeliveryQuantity delivery = new DeliveryQuantity();
                    delivery.ConcernId = concernId;
                    delivery.ProductCode = sIProductDetails.SICode;
                    delivery.CreationDate = DateTime.Now;
                    delivery.Creator = userId;
                    delivery.Quantity = sIProductDetails.DeliveryQuantity;
                    _context.DeliveryQuantities.Add(delivery);
                    _context.SaveChanges();

                    transaction.Commit();
                }
            }

        }

        public void ClearSalesProductById(int id)
        {
            var sales = _context.SIProductDetails.FirstOrDefault(m => m.SIProductDetId == id);
            _context.SIProductDetails.Remove(sales);
            _context.SaveChanges();
        }

        public void ClearSalesReturnProductById(int id)
        {
            var sales = _context.SRIProductDetails.FirstOrDefault(m => m.SRIProductDetId == id);
            _context.SRIProductDetails.Remove(sales);
            _context.SaveChanges();
        }

        public void DeleteInvoice(int id)
        {
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                var document = _context.SIDocumentDetails.FirstOrDefault(x=>x.SICode==id.ToString());
                var product = _context.SIProductDetails.FirstOrDefault(x=>x.SICode==id.ToString());
                var Order = _context.OrderDetails.FirstOrDefault(x=>x.SICode==id.ToString());
                var cash = _context.CashDetails.FirstOrDefault(x=>x.SICode==id.ToString());
                var lc = _context.LCStatements.FirstOrDefault(x=>x.SICode==id.ToString());
                var quantity = _context.DeliveryQuantities.Where(x=>x.ProductCode == id.ToString()).ToList();

                if (document != null)
                {
                    _context.SIDocumentDetails.Remove(document);
                    _context.SaveChanges();
                }
               if(product!=null)
                {
                    _context.SIProductDetails.Remove(product);
                    _context.SaveChanges();
                }
                if (Order != null)
                {
                    _context.OrderDetails.Remove(Order);
                    _context.SaveChanges();
                }
                if (cash != null)
                {
                    _context.CashDetails.Remove(cash);
                    _context.SaveChanges();
                }
                if (lc != null)
                {
                    _context.LCStatements.Remove(lc);
                    _context.SaveChanges();
                }
                if (quantity != null)
                {
                    _context.DeliveryQuantities.RemoveRange(quantity);
                    _context.SaveChanges();
                }
                transaction.Commit();

            }
        }

        public IEnumerable<Region> Regions(int concernId)
        {
            return _context.Regions.Where(m => m.ConcernId == concernId);
        }

        public IEnumerable<SalesReturn> SalesReturns(int concernId)
        {
            List<SalesReturn> salesReturns = new List<SalesReturn>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "SalesReturn_Index @concernId";
                command.Parameters.Add(new SqlParameter("@concernId", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            salesReturns.Add(new SalesReturn()
                            {
                                ReturnCode = Convert.ToString(result[0]),
                                SalesCode = Convert.ToString(result[1]),
                                Items = Convert.ToInt32(result[2]),
                                ReturnDate = Convert.ToDateTime(result[3])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return salesReturns;
        }

        public IEnumerable<SISessionproductDetails> SISessionproductDetails(string code)
        {
            List<SISessionproductDetails> details = new List<SISessionproductDetails>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Session_SIProductDetails @SICode";
                command.Parameters.Add(new SqlParameter("@SICode", code));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            details.Add(new SISessionproductDetails()
                            {
                                SIProductDetId = Convert.ToInt32(result[0]),
                                SICode = Convert.ToString(result[1]),
                                Article = Convert.ToString(result[2]),
                                Width = Convert.ToString(result[3]),
                                Softness = Convert.ToString(result[4]),
                                Construction = Convert.ToString(result[5]),
                                Color = Convert.ToString(result[6]),
                                Source = Convert.ToString(result[7]),
                                Lenght = Convert.ToString(result[8]),
                                OrderQuantity = Convert.ToDecimal(result[9]),
                                DeliveryQuantity = Convert.ToDecimal(result[10]),
                                UnitPrice = Convert.ToDecimal(result[11]),
                                Netprice = Convert.ToDecimal(result[12]),
                                OverInvoice = Convert.ToDecimal(result[13]),
                                NetOverInvoice = Convert.ToDecimal(result[14]),
                                ProductName = Convert.ToString(result[15]),
                                Serila = Convert.ToInt32(result[16]),
                                AltArticle = Convert.ToString(result[17])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return details;
        }

        public IEnumerable<SISessionproductDetails> SRISessionproductDetails(string code)
        {
            List<SISessionproductDetails> details = new List<SISessionproductDetails>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Session_SRIProductDetails @SICode";
                command.Parameters.Add(new SqlParameter("@SICode", code));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            details.Add(new SISessionproductDetails()
                            {
                                SIProductDetId = Convert.ToInt32(result[0]),
                                SICode = Convert.ToString(result[1]),
                                Article = Convert.ToString(result[2]),
                                Width = Convert.ToString(result[3]),
                                Softness = Convert.ToString(result[4]),
                                Construction = Convert.ToString(result[5]),
                                Color = Convert.ToString(result[6]),
                                Source = Convert.ToString(result[7]),
                                Lenght = Convert.ToString(result[8]),
                                OrderQuantity = Convert.ToDecimal(result[9]),
                                DeliveryQuantity = Convert.ToDecimal(result[10]),
                                UnitPrice = Convert.ToDecimal(result[11]),
                                Netprice = Convert.ToDecimal(result[12]),
                                OverInvoice = Convert.ToDecimal(result[13]),
                                NetOverInvoice = Convert.ToDecimal(result[14]),
                                ProductName = Convert.ToString(result[15]),
                                Serila = Convert.ToInt32(result[16]),
                                AltArticle = Convert.ToString(result[17])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return details;
        }

        public void UpdateCashDetails(CashDetails cashDetails, int concernID, int userId, int code)
        {
            var cash = _context.CashDetails.FirstOrDefault(x => x.SICode == code.ToString());
            cash.BillingDate = cashDetails.BillingDate;
            cash.BillNo = cashDetails.BillNo;
            cash.ChalanInfo = cashDetails.ChalanInfo;
            cash.ComissionUSD = cashDetails.ComissionUSD;
            cash.CreationDate = DateTime.Now;
            cash.Creator = userId;
            cash.Description = cashDetails.Description;
            cash.FromDestination = cashDetails.FromDestination;
            cash.ToDestination = cashDetails.ToDestination;
            _context.SaveChanges();
        }

        public void UpdateDeliveryQuantity(DeliveryQuantity deliveryQuantity, int userId, int concernId, int id)
        {

            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                var delivery = _context.DeliveryQuantities.FirstOrDefault(x => x.DeliveryQuantityID == id);
                delivery.Quantity = deliveryQuantity.Quantity;
                delivery.ConcernId = concernId;
                delivery.Creator = userId;
                delivery.ProductCode = deliveryQuantity.ProductCode;
                _context.SaveChanges();

                var product = _context.SRIProductDetails.FirstOrDefault(x => x.SICode == deliveryQuantity.ProductCode);
                product.DeliveryQuantity = deliveryQuantity.Quantity;
                _context.SaveChanges();

                transaction.Commit();

            }
        }

        public void UpdateLCStatement(LCStatement lCStatement, int concernID, int userId, int code)
        {
            var lc = _context.LCStatements.FirstOrDefault(x => x.SICode == code.ToString());
            lc.BankName = lCStatement.BankName;
            lc.BankSubDate = lCStatement.BankSubDate;
            lc.Comission = lCStatement.Comission;
            lc.Description = lCStatement.Description;
            lc.ExpiraionDate = lCStatement.ExpiraionDate;
            lc.FileNo = lCStatement.FileNo;
            lc.HSCode = lCStatement.HSCode;
            lc.LCDate = lCStatement.LCDate;
            lc.LCNumber = lCStatement.LCNumber;
            lc.LCStatus = lCStatement.LCStatus;
            lc.PartyName = lCStatement.PartyName;
            lc.PaymentClause = lCStatement.PaymentClause;
            lc.RealiseValue = lCStatement.RealiseValue;
            lc.ShipmentDate = lCStatement.ShipmentDate;
            lc.Tenor = lCStatement.Tenor;
            lc.Value = lCStatement.Value;
            _context.SaveChanges();
        }

        public void UpdateOrderDetails(OrderDetails orderDetails, int concernID, int userId, int code)
        {
            var order = _context.OrderDetails.FirstOrDefault(x => x.SICode == code.ToString());
            order.ApprovalId = orderDetails.ApprovalId;
            order.BuyerOrderRef = orderDetails.BuyerOrderRef;
            order.DeliveryTypeId = orderDetails.DeliveryTypeId;
            order.OrderDetail = orderDetails.OrderDetail;
            order.SICode = orderDetails.SICode;
            _context.SaveChanges();
        }

        public void UpdateSIDocumentDetails(SIDocumentDetails sIDocument, int userId, int concernId, string code)
        {
            var doc = _context.SIDocumentDetails.FirstOrDefault(m => m.SICode == code);
            doc.ApprovedStatus = sIDocument.ApprovedStatus;
            doc.Bank = sIDocument.Bank;
            doc.Buyer = sIDocument.Buyer;
            doc.BuyerOrderRef = sIDocument.BuyerOrderRef;
            doc.CommisionAmount = sIDocument.CommisionAmount;
            doc.CommisionStatus = sIDocument.CommisionStatus;
            doc.CompanyId = sIDocument.CompanyId;
            doc.ContactPerson = sIDocument.ContactPerson;
            doc.DeliveryAddress = sIDocument.DeliveryAddress;
            doc.DeliveryDate = sIDocument.DeliveryDate;
            doc.DeliveryStatus = sIDocument.DeliveryStatus;
            doc.DeliveryType = sIDocument.DeliveryType;
            doc.Description = sIDocument.Description;
            doc.DocumentStatus = sIDocument.DocumentStatus;
            doc.HSCode = sIDocument.HSCode;
            doc.IssueDate = sIDocument.IssueDate;
            doc.IssuedBy = sIDocument.IssuedBy;
            doc.ItemNo = sIDocument.ItemNo;
            doc.LCStatus = sIDocument.LCStatus;
            doc.OrderDetails = sIDocument.OrderDetails;
            doc.PaymentMethod = sIDocument.PaymentMethod;
            doc.PONumber = sIDocument.PONumber;
            doc.Revised = sIDocument.Revised;
            doc.SICode = sIDocument.SICode;
            doc.SIName = sIDocument.SIName;
            doc.Style = sIDocument.Style;
            _context.SaveChanges();
        }

        public void UpdateSIProductDetails(SIProductDetails sIProductDetails, int userId, int concernId, string Code)
        {
            var code = sIProductDetails.ProductId + "" + sIProductDetails.ArticleId + "" + sIProductDetails.WidthId + "" + sIProductDetails.ConstructionId + "" + sIProductDetails.SoftnessId + "" + sIProductDetails.SourceId + "" + sIProductDetails.ColorId;
            var productCode = _context.ProductNames.FirstOrDefault(m => m.ProductCode == code);
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                if (productCode == null)
                {
                    ProductName product = new ProductName();
                    product.ProductCode = code;
                    product.ProductId = sIProductDetails.ProductId;
                    product.ArticleId = sIProductDetails.ArticleId;
                    product.WidthId = sIProductDetails.WidthId;
                    product.ConstructionId = sIProductDetails.ConstructionId;
                    product.SoftnessId = sIProductDetails.SoftnessId;
                    product.SourceId = sIProductDetails.SourceId;
                    product.ColorId = sIProductDetails.ColorId;
                    _context.ProductNames.Add(product);
                    _context.SaveChanges();

                    var prop = _context.SIProductDetails.FirstOrDefault(m => m.SICode == Code);
                    prop.AltArticle = sIProductDetails.AltArticle;
                    prop.ArticleId = sIProductDetails.ArticleId;
                    prop.ColorId = sIProductDetails.ColorId;
                    prop.ConstructionId = sIProductDetails.ConstructionId;
                    prop.DeliveryQuantity = sIProductDetails.DeliveryQuantity;
                    prop.Description = sIProductDetails.Description;
                    prop.LenghtId = sIProductDetails.LenghtId;
                    prop.OrderQuantity = sIProductDetails.OrderQuantity;
                    prop.OverInvoice = sIProductDetails.OverInvoice;
                    prop.ProductId = sIProductDetails.ProductId;
                    //prop.SICode = sIProductDetails.SICode;
                    prop.SoftnessId = sIProductDetails.SoftnessId;
                    prop.SourceId = sIProductDetails.SourceId;
                    prop.UnitPrice = sIProductDetails.UnitPrice;
                    prop.WidthId = sIProductDetails.WidthId;
                    _context.SaveChanges();

                    var quantity = _context.DeliveryQuantities.FirstOrDefault(x => x.ProductCode == Code);
                    quantity.Quantity = sIProductDetails.DeliveryQuantity;
                    _context.SaveChanges();
                    transaction.Commit();

                }
                else
                {
                    var prop = _context.SIProductDetails.FirstOrDefault(m => m.SICode == sIProductDetails.SICode);
                    prop.AltArticle = sIProductDetails.AltArticle;
                    prop.ArticleId = sIProductDetails.ArticleId;
                    prop.ColorId = sIProductDetails.ColorId;
                    prop.ConstructionId = sIProductDetails.ConstructionId;
                    prop.DeliveryQuantity = sIProductDetails.DeliveryQuantity;
                    prop.Description = sIProductDetails.Description;
                    prop.LenghtId = sIProductDetails.LenghtId;
                    prop.OrderQuantity = sIProductDetails.OrderQuantity;
                    prop.OverInvoice = sIProductDetails.OverInvoice;
                    prop.ProductId = sIProductDetails.ProductId;
                    //prop.SICode = sIProductDetails.SICode;
                    prop.SoftnessId = sIProductDetails.SoftnessId;
                    prop.SourceId = sIProductDetails.SourceId;
                    prop.UnitPrice = sIProductDetails.UnitPrice;
                    prop.WidthId = sIProductDetails.WidthId;

                    _context.SaveChanges();

                    var quantity = _context.DeliveryQuantities.FirstOrDefault(x => x.ProductCode == Code);
                    quantity.Quantity = sIProductDetails.DeliveryQuantity;
                    _context.SaveChanges();

                    transaction.Commit();
                }
            }
        }
    }
}