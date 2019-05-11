// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Company
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("Company")]
  public class Company
  {
    [StringLength(500)]
    public string Address { get; set; }

    [StringLength(100)]
    public string City { get; set; }

    [StringLength(40)]
    public string Code { get; set; }

    [StringLength(80)]
    public string EmailID { get; set; }

    [Column(TypeName = "numeric")]
    [Key]
    public Decimal IDNUMBER { get; set; }

    public short? IsActivated { get; set; }

    public short? IsActive { get; set; }

    public short? IsExpired { get; set; }

    public short? IsVerified { get; set; }

    [StringLength(20)]
    public string MobileNo { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(20)]
    public string PinCode { get; set; }

    [StringLength(100)]
    public string State { get; set; }
  }
}
