using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using PermessInternational.PermessContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Services
{
    public class ProductService : IProduct
    {
        private readonly PermessDbContext _context;
        public ProductService(PermessDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product, int concernId, int userId)
        {
            product.CreationDate = DateTime.Now;
            product.ConcernId = concernId;
            product.Creator = userId;
            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public void AddProductSetting(ProductSetting productSetting, int concernId, int userId)
        {
            productSetting.CreationDate = DateTime.Now;
            productSetting.ConcernId = concernId;
            productSetting.Creator = userId;
            _context.ProductSettings.Add(productSetting);
            _context.SaveChanges();
        }

        public IEnumerable<Product> Products(int concernId)
        {
            return _context.Products.Where(x=>x.ConcernId==concernId).ToList();
        }

        public IEnumerable<ResponseProductSetting> ArticleProductSettings(int concernId)
        {
            List<ResponseProductSetting> productSettings = new List<ResponseProductSetting>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Proc_ProductSettings_Article @Concern";
                command.Parameters.Add(new SqlParameter("@Concern", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            productSettings.Add(new ResponseProductSetting()
                            {
                                ItemId = Convert.ToInt32(result[0]),
                                ItemName = Convert.ToString(result[1]),
                                Description = Convert.ToString(result[2])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return productSettings;
        }

        public IEnumerable<ResponseProductSetting> ConstructionProductSettings(int concernId)
        {
            List<ResponseProductSetting> productSettings = new List<ResponseProductSetting>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Proc_ProductSettings_Construction @Concern";
                command.Parameters.Add(new SqlParameter("@Concern",concernId));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            productSettings.Add(new ResponseProductSetting()
                            {
                                ItemId=Convert.ToInt32(result[0]),
                                ItemName=Convert.ToString(result[1]),
                                Description=Convert.ToString(result[2])
                            });
                        }
                    }
                }
                    _context.Database.Connection.Close();
            }
                return productSettings;
        }

        public IEnumerable<ResponseProductSetting> WidthProductSettings(int concernId)
        {
            List<ResponseProductSetting> productSettings = new List<ResponseProductSetting>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Proc_ProductSettings_Width @Concern";
                command.Parameters.Add(new SqlParameter("@Concern", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            productSettings.Add(new ResponseProductSetting()
                            {
                                ItemId = Convert.ToInt32(result[0]),
                                ItemName = Convert.ToString(result[1]),
                                Description = Convert.ToString(result[2])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return productSettings;
        }

        public IEnumerable<ResponseProductSetting> SoftnessProductSettings(int concernId)
        {
            List<ResponseProductSetting> productSettings = new List<ResponseProductSetting>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Proc_ProductSettings_Softness @Concern";
                command.Parameters.Add(new SqlParameter("@Concern", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            productSettings.Add(new ResponseProductSetting()
                            {
                                ItemId = Convert.ToInt32(result[0]),
                                ItemName = Convert.ToString(result[1]),
                                Description = Convert.ToString(result[2])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return productSettings;
        }

        public IEnumerable<ResponseProductSetting> ColorProductSettings(int concernId)
        {
            List<ResponseProductSetting> productSettings = new List<ResponseProductSetting>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Proc_ProductSettings_Color @Concern";
                command.Parameters.Add(new SqlParameter("@Concern", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            productSettings.Add(new ResponseProductSetting()
                            {
                                ItemId = Convert.ToInt32(result[0]),
                                ItemName = Convert.ToString(result[1]),
                                Description = Convert.ToString(result[2])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return productSettings;
        }

        public IEnumerable<ResponseProductSetting> SourceProductSettings(int concernId)
        {
            List<ResponseProductSetting> productSettings = new List<ResponseProductSetting>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Proc_ProductSettings_Source @Concern";
                command.Parameters.Add(new SqlParameter("@Concern", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            productSettings.Add(new ResponseProductSetting()
                            {
                                ItemId = Convert.ToInt32(result[0]),
                                ItemName = Convert.ToString(result[1]),
                                Description = Convert.ToString(result[2])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return productSettings;
        }

        public IEnumerable<ResponseProductSetting> CategoryProductSettings(int concernId)
        {
            List<ResponseProductSetting> productSettings = new List<ResponseProductSetting>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Proc_ProductSettings_Category @Concern";
                command.Parameters.Add(new SqlParameter("@Concern", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            productSettings.Add(new ResponseProductSetting()
                            {
                                ItemId = Convert.ToInt32(result[0]),
                                ItemName = Convert.ToString(result[1]),
                                Description = Convert.ToString(result[2])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return productSettings;
        }
    }
}