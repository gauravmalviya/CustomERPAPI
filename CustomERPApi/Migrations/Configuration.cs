// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Migrations.Configuration
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Models;
using System.Data.Entity.Migrations;

namespace CustomERPApi.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<CustomERPEntities>
  {
    public Configuration()
    {
      this.AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(CustomERPEntities context)
    {
    }
  }
}
