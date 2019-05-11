// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Stockdbf
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("Stockdbf")]
  public class Stockdbf
  {
    public int? CompanyID { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public int ItemID { get; set; }

    public int ItemVarientID { get; set; }

    public int LocationID { get; set; }

    public Decimal StockQty { get; set; }

    public int UnitID { get; set; }
  }
}
