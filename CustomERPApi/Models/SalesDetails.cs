// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.SalesDetails
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("SalesDetails")]
  public class SalesDetails
  {
    [NotMapped]
    public string Color { get; set; }

    public int? CompanyID { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public int ItemID { get; set; }

    [NotMapped]
    public string ItemName { get; set; }

    public int ItemVarientID { get; set; }

    public Decimal Price { get; set; }

    [NotMapped]
    public string ProductImage { get; set; }

    public Decimal Qty { get; set; }

    public int SalesID { get; set; }

    [NotMapped]
    public string SKU { get; set; }

    public Decimal TotalAmount { get; set; }

    public int UnitID { get; set; }

    [NotMapped]
    public string UPC { get; set; }
  }
}
