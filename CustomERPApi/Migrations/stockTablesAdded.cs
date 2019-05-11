// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Migrations.stockTablesAdded
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
  public sealed class stockTablesAdded : DbMigration, IMigrationMetadata
  {
    private readonly ResourceManager Resources = new ResourceManager(typeof (stockTablesAdded));

    public override void Up()
    {
      this.CreateTable("dbo.SalesDetails", c => new
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
      this.CreateTable("dbo.Stockdbf", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemVarientID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        LocationID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        StockQty = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        UnitID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.StockDetails", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemVarientID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        LocationID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        StockID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        StockQty = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        StockRate = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        TranBook = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        TranCode = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        TranNo = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UnitID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
    }

    public override void Down()
    {
      this.DropTable("dbo.StockDetails", (object) null);
      this.DropTable("dbo.Stockdbf", (object) null);
      this.DropTable("dbo.SalesDetails", (object) null);
    }

    string IMigrationMetadata.Id
    {
      get
      {
        return "201904281157119_stockTablesAdded";
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
