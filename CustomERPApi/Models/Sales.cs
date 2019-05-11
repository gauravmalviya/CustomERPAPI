// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Sales
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("Sales")]
  public class Sales
  {
    public Decimal BBShippment { get; set; }

    public int? CompanyID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string Currency { get; set; }

    public int CustomerID { get; set; }

    [NotMapped]
    public string CustomerName { get; set; }

    public Decimal Deposite { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public string Incoterms { get; set; }

    public int PaymentType { get; set; }

    [NotMapped]
    public List<CustomERPApi.Models.SalesDetails> SalesDetails { get; set; }

    public string ShippingAddress { get; set; }

    public Decimal ShippingCost { get; set; }

    public string ShippingName { get; set; }

    public DateTime SODate { get; set; }

    public string SONO { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal Total { get; set; }

    public Decimal TotalQty { get; set; }
  }
}
