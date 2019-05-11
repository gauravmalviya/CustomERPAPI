// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Expenses
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("Expenses")]
  public class Expenses
  {
    public int? CompanyID { get; set; }

    public Decimal Cost { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    [StringLength(50)]
    public string Currency { get; set; }

    public DateTime ExpenseDate { get; set; }

    [StringLength(50)]
    public string ExpenseName { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public int IsActive { get; set; }

    public string Item { get; set; }

    public int ItemID { get; set; }

    public int ItemVarientID { get; set; }

    public string Note { get; set; }

    public int PaidBy { get; set; }

    public Decimal USDCost { get; set; }

    public Decimal Wallet { get; set; }
  }
}
