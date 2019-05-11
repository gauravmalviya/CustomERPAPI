// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Migrations.SalesSalesContractSalesContractDetailTableAdded
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
  public sealed class SalesSalesContractSalesContractDetailTableAdded : DbMigration, IMigrationMetadata
  {
    private readonly ResourceManager Resources = new ResourceManager(typeof (SalesSalesContractSalesContractDetailTableAdded));

    public override void Up()
    {
      this.CreateTable("dbo.Sales", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        BBShippment = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Currency = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CustomerID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Deposite = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        Incoterms = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PaymentType = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ShippingAddress = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ShippingCost = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        ShippingName = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SODate = c.DateTime(new bool?(false), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SONO = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SubTotal = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        Total = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        TotalQty = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.SalesContract", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        BBShippment = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Currency = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CustomerID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Deposite = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        Incoterms = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PaymentType = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SCDate = c.DateTime(new bool?(false), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SCNO = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ShippingAddress = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ShippingCost = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        ShippingName = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SubTotal = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        Total = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        TotalQty = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.SalesContractDetails", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemVarientID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Price = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        Qty = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        SalesID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        TotalAmount = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        UnitID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
    }

    public override void Down()
    {
      this.DropTable("dbo.SalesContractDetails", (object) null);
      this.DropTable("dbo.SalesContract", (object) null);
      this.DropTable("dbo.Sales", (object) null);
    }

    string IMigrationMetadata.Id
    {
      get
      {
        return "201904281156262_SalesSalesContractSalesContractDetailTableAdded";
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
