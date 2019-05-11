// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.StockDetails
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("StockDetails")]
  public class StockDetails
  {
    public int? CompanyID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public int ItemID { get; set; }

    public int ItemVarientID { get; set; }

    public int LocationID { get; set; }

    public int StockID { get; set; }

    public Decimal StockQty { get; set; }

    public Decimal StockRate { get; set; }

    public string TranBook { get; set; }

    public string TranCode { get; set; }

    public string TranNo { get; set; }

    public int UnitID { get; set; }
  }
}
