// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.CustomERPEntities
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System.Data.Entity;

namespace CustomERPApi.Models
{
  public class CustomERPEntities : DbContext
  {
    public virtual DbSet<CustomERPApi.Models.Category> Category { get; set; }

    public virtual DbSet<CustomERPApi.Models.Company> Company { get; set; }

    public virtual DbSet<CustomERPApi.Models.Customer> Customer { get; set; }

    public virtual DbSet<CustomERPApi.Models.Employee> Employee { get; set; }

    public virtual DbSet<CustomERPApi.Models.Expenses> Expenses { get; set; }

    public virtual DbSet<CustomERPApi.Models.Item> Item { get; set; }

    public virtual DbSet<CustomERPApi.Models.ItemVarient> ItemVarient { get; set; }

    public virtual DbSet<CustomERPApi.Models.Purchase> Purchase { get; set; }

    public virtual DbSet<CustomERPApi.Models.PurchaseDetails> PurchaseDetails { get; set; }

    public virtual DbSet<CustomERPApi.Models.Sales> Sales { get; set; }

    public virtual DbSet<CustomERPApi.Models.SalesContract> SalesContract { get; set; }

    public virtual DbSet<CustomERPApi.Models.SalesContractDetails> SalesContractDetails { get; set; }

    public virtual DbSet<CustomERPApi.Models.SalesDetails> SalesDetails { get; set; }

    public virtual DbSet<CustomERPApi.Models.Stockdbf> Stockdbf { get; set; }

    public virtual DbSet<CustomERPApi.Models.StockDetails> StockDetails { get; set; }

    public virtual DbSet<CustomERPApi.Models.Supplier> Supplier { get; set; }

    public virtual DbSet<CustomERPApi.Models.Users> Users { get; set; }

    public virtual DbSet<CustomERPApi.Models.UserType> UserType { get; set; }

    public virtual DbSet<CustomERPApi.Models.Warehouse> Warehouse { get; set; }

    public CustomERPEntities()
      : base("name=CustomERPEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    }
  }
}
