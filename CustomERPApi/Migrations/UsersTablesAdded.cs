// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Migrations.UsersTablesAdded
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
  public sealed class UsersTablesAdded : DbMigration, IMigrationMetadata
  {
    private readonly ResourceManager Resources = new ResourceManager(typeof (UsersTablesAdded));

    public override void Up()
    {
      this.CreateTable("dbo.Supplier", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        AccountNumber = c.String(new bool?(), new int?(150), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        BankAddress = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        BankName = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompAddress = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyName = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompEmail = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContEmail1 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContEmail2 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContFirstName1 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContFirstName2 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContPhone1 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContPhone2 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContPosition1 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContPosition2 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContSurname1 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ContSurname2 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Designation = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        EmailID = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IBAN = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsActive = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Note = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PhoneNo1 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PhoneNo2 = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        ShippingAddress = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SupplierAddress = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SupplierName = c.String(new bool?(), new int?(150), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        SWIFT = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UpdatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UpdatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Website = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.Users", c => new
      {
        IDNUMBER = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 0), new Decimal?(), (string) null, (string) null, "numeric", true, (IDictionary<string, AnnotationValues>) null),
        BOD = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Decimal(new bool?(), new byte?((byte) 18), new byte?((byte) 0), new Decimal?(), (string) null, (string) null, "numeric", false, (IDictionary<string, AnnotationValues>) null),
        EmailID = c.String(new bool?(), new int?(80), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsActive = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsSuperUser = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        MobileNo = c.String(new bool?(), new int?(20), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        pswd = c.String(new bool?(), new int?(100), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UserID = c.String(new bool?(), new int?(20), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UserName = c.String(new bool?(), new int?(50), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UserType = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.UserType", c => new
      {
        IDNUMBER = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, "numeric", false, (IDictionary<string, AnnotationValues>) null),
        IsActive = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsSuperType = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UserTypeName = c.String(new bool?(), new int?(20), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
      this.CreateTable("dbo.Warehouse", c => new
      {
        IDNUMBER = c.Int(new bool?(false), true, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Address = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CompanyID = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        CreatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsActive = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UpdatedBy = c.Int(new bool?(), false, new int?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        UpdatedDate = c.DateTime(new bool?(), new byte?(), new DateTime?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        WarehouseName = c.String(new bool?(), new int?(150), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
    }

    public override void Down()
    {
      this.DropTable("dbo.Warehouse", (object) null);
      this.DropTable("dbo.UserType", (object) null);
      this.DropTable("dbo.Users", (object) null);
      this.DropTable("dbo.Supplier", (object) null);
    }

    string IMigrationMetadata.Id
    {
      get
      {
        return "201904281200013_UsersTablesAdded";
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
