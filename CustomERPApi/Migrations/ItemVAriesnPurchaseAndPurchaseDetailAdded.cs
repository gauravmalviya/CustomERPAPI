// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Migrations.ItemVAriesnPurchaseAndPurchaseDetailAdded
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace CustomERPApi.Migrations
{
  [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
  public sealed class ItemVAriesnPurchaseAndPurchaseDetailAdded : DbMigration, IMigrationMetadata
  {
    private readonly ResourceManager Resources = new ResourceManager(typeof (ItemVAriesnPurchaseAndPurchaseDetailAdded));

    public override void Up()
    {
      this.CreateTable("dbo.ItemVarient", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Color = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Cost = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, "numeric", false, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Inventory = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        IsActive = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemImage = c.Boolean(new bool?(), new bool?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Size = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SKU = c.String(new bool?(), new int?(150), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UPC = c.String(new bool?(), new int?(150), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UpdateBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UpdatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        WarehouseID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.Purchase", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        BBShippment = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Currency = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Deposite = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        Incoterms = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PaymentType = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PODate = c.DateTime(new bool?(false), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PONo = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ShippingAddress = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ShippingCost = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        ShippingName = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SubTotal = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        SupplierID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Total = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        TotalQty = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.PurchaseDetails", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemVarientID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Price = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        PurchaseID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Qty = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        TotalAmount = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        UnitID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
    }

    public override void Down()
    {
      this.DropTable("dbo.PurchaseDetails", (object) null);
      this.DropTable("dbo.Purchase", (object) null);
      this.DropTable("dbo.ItemVarient", (object) null);
    }

    string IMigrationMetadata.Id
    {
      get
      {
        return "201904281155236_ItemVAriesnPurchaseAndPurchaseDetailAdded";
      }
    }

    string IMigrationMetadata.Source
    {
      get
      {
        return (string) null;
      }
    }

    string IMigrationMetadata.Target
    {
      get
      {
        return this.Resources.GetString("Target");
      }
    }
  }
}
