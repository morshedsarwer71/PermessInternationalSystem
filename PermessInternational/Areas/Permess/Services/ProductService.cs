using PermessInternational.Areas.Permess.Interfaces;
using PermessInternational.Areas.Permess.Models;
using PermessInternational.Areas.Permess.PlainModels;
using PermessInternational.Areas.Permess.StaticModels;
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

        public IEnumerable<YesNoModel> YesNoModels()
        {
            List<YesNoModel> yesNoModels = new List<YesNoModel>()
            {
                new YesNoModel()
                {
                    Id=2,
                    Name="No"
                },
                new YesNoModel()
                {
                    Id=1,
                    Name="Yes"
                }
            };
            return yesNoModels;
        }

        public IEnumerable<PaymentMethod> PaymentMethods()
        {
            List<PaymentMethod> yesNoModels = new List<PaymentMethod>()
            {
                new PaymentMethod()
                {
                    Id=1,
                    Name="Cash"
                },
                new PaymentMethod()
                {
                    Id=2,
                    Name="Cheque"
                },                
                new PaymentMethod()
                {
                    Id=3,
                    Name="LC Payment"
                },
                new PaymentMethod()
                {
                    Id=4,
                    Name="TT Payment"
                },
                new PaymentMethod()
                {
                    Id=5,
                    Name="LC 90 Days"
                },
                new PaymentMethod()
                {
                    Id=6,
                    Name="LC AT SIGHT"
                },
                new PaymentMethod()
                {
                    Id=7,
                    Name="Open Credit of 60 Days from B/L Date"
                },
                new PaymentMethod()
                {
                    Id=8,
                    Name="Open Credit of 90 Days from B/L Date"
                },
            };
            return yesNoModels;
        }

        public IEnumerable<Bank> Banks()
        {
            List<Bank> yesNoModels = new List<Bank>()
            {
                new Bank()
                {
                    Id=1,
                    Name="Islami Bank"
                },
                new Bank()
                {
                    Id=2,
                    Name="UCBL Principal Branch Motijheel"
                }
            };
            return yesNoModels;
        }

        public IEnumerable<Status> Statuses()
        {
            List<Status> yesNoModels = new List<Status>()
            {
                new Status()
                {
                    Id=1,
                    Name="Pending"
                },
                new Status()
                {
                    Id=2,
                    Name="Pertial"
                },
                new Status()
                {
                    Id=3,
                    Name="Complete"
                }
            };
            return yesNoModels;
        }

        public IEnumerable<Length> Lengths()
        {
            List<Length> yesNoModels = new List<Length>()
            {
                new Length()
                {
                    Id=1,
                    Name="Meters"
                },
                new Length()
                {
                    Id=2,
                    Name="Yards"
                }
            };
            return yesNoModels;
        }

        public IEnumerable<DeliveryType> DeliveryTypes()
        {
            List<DeliveryType> yesNoModels = new List<DeliveryType>()
            {
                new DeliveryType()
                {
                    Id=1,
                    Name="Foreign"
                },
                new DeliveryType()
                {
                    Id=2,
                    Name="Local"
                }
            };
            return yesNoModels;
        }

        public IEnumerable<PaymentClause> PaymentClauses()
        {
            List<PaymentClause> yesNoModels = new List<PaymentClause>()
            {
                new PaymentClause()
                {
                    Id=1,
                    Name="BDT"
                },
                new PaymentClause()
                {
                    Id=2,
                    Name="USD"
                }
            };
            return yesNoModels;
        }

        public IEnumerable<Tenor> Tenors()
        {
            List<Tenor> yesNoModels = new List<Tenor>()
            {
                new Tenor()
                {
                    Id=1,
                    Name="60 Days"
                },
                new Tenor()
                {
                    Id=2,
                    Name="90 Days"
                }
            };
            return yesNoModels;
        }
    }
}