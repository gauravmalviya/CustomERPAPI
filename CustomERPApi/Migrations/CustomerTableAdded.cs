// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Migrations.CustomerTableAdded
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
  public sealed class CustomerTableAdded : DbMigration, IMigrationMetadata
  {
    private readonly ResourceManager Resources = new ResourceManager(typeof (CustomerTableAdded));

    public override void Up()
    {
      this.CreateTable("dbo.Company", c => new
      {
        IDNUMBER = c.Decimal(new bool?(false), new byte?((byte) 18), new byte?((byte) 2), new Decimal?(), (string) null, (string) null, "numeric", false, (IDictionary<string, AnnotationValues>) null),
        Address = c.String(new bool?(), new int?(500), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        City = c.String(new bool?(), new int?(100), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Code = c.String(new bool?(), new int?(40), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        EmailID = c.String(new bool?(), new int?(80), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsActivated = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsActive = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsExpired = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        IsVerified = c.Short(new bool?(), false, new short?(), (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        MobileNo = c.String(new bool?(), new int?(20), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        Name = c.String(new bool?(), new int?(100), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        PinCode = c.String(new bool?(), new int?(20), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null),
        State = c.String(new bool?(), new int?(100), new bool?(), new bool?(), (string) null, (string) null, (string) null, (string) null, (IDictionary<string, AnnotationValues>) null)
      }, (object) null).PrimaryKey(t => t.IDNUMBER, (string) null, true, (object) null);
    }

    public override void Down()
    {
      this.DropTable("dbo.Company", (object) null);
    }

    string IMigrationMetadata.Id
    {
      get
      {
        return "201904281148236_CustomerTableAdded";
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
