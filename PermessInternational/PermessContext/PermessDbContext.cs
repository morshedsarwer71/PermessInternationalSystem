using PermessInternational.Areas.Global.Models;
using PermessInternational.Areas.Permess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PermessInternational.PermessContext
{
    public class PermessDbContext:DbContext
    {
        public PermessDbContext() : base("PermessDBContext") { }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ProductSetting> ProductSettings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ImportGood> ImportGoods { get; set; }
        public DbSet<SIDocumentDetails> SIDocumentDetails { get; set; }
        public DbSet<SIProductDetails> SIProductDetails { get; set; }  
        public DbSet<Region> Regions { get; set; }
        public DbSet<LCStatement> LCStatements { get; set; }
        public DbSet<CashDetails> CashDetails { get; set; }
        public DbSet<ExportIssue> ExportIssues { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<MachinePurchase> MachinePurchase { get; set; }
        public DbSet<SRIProductDetails> SRIProductDetails { get; set; }
        public DbSet<ProductionProcessA> AProductions { get; set; }
        public DbSet<ProductionProcessB> BProductions { get; set; }
        public DbSet<ProductionProcessC> CProductions { get; set; }
        public DbSet<OrderRawMaterial> OrderRawMaterials { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ProductName> ProductNames { get; set; }
        public DbSet<DeliveryQuantity> DeliveryQuantities { get; set; }
        public DbSet<PIRevised> PIReviseds { get; set; }
    }
}