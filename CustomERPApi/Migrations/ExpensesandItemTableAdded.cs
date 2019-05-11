// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Migrations.ExpensesandItemTableAdded
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
  public sealed class ExpensesandItemTableAdded : DbMigration, IMigrationMetadata
  {
    private readonly ResourceManager Resources = new ResourceManager(typeof (ExpensesandItemTableAdded));

    public override void Up()
    {
      this.CreateTable("dbo.Expenses", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Cost = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Currency = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ExpenseDate = c.DateTime(new bool?(false), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ExpenseName = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsActive = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Item = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemVarientID = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Note = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PaidBy = c.Int(new bool?(false), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        USDCost = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null),
        Wallet = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, (string) null, false, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.Item", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CategoryID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        cmHeight = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        cmLength = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        cmWidth = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Description = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        inchHeight = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        inchLength = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        inchWidth = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsActive = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemImage = c.String(new bool?(), new int?(), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ItemName = c.String(new bool?(), new int?(150), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        kgWeight = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        lbsWeight = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Note = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UpdateBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UpdatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
    }

    public override void Down()
    {
      this.DropTable("dbo.Item", (object) null);
      this.DropTable("dbo.Expenses", (object) null);
    }

    string IMigrationMetadata.Id
    {
      get
      {
        return "201904281154256_ExpensesandItemTableAdded";
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
