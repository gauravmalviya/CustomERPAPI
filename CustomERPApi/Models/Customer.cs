// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Customer
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("Customer")]
  public class Customer
  {
    [StringLength(500)]
    public string CompAddress { get; set; }

    public int? CompanyID { get; set; }

    [StringLength(50)]
    public string CompanyName { get; set; }

    [StringLength(50)]
    public string CompEmail { get; set; }

    [StringLength(50)]
    public string ContEmail1 { get; set; }

    [StringLength(50)]
    public string ContEmail2 { get; set; }

    [StringLength(50)]
    public string ContFirstName1 { get; set; }

    [StringLength(50)]
    public string ContFirstName2 { get; set; }

    [StringLength(50)]
    public string ContPhone1 { get; set; }

    [StringLength(50)]
    public string ContPhone2 { get; set; }

    [StringLength(50)]
    public string ContPosition1 { get; set; }

    [StringLength(50)]
    public string ContPosition2 { get; set; }

    [StringLength(50)]
    public string ContSurname1 { get; set; }

    [StringLength(50)]
    public string ContSurname2 { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    [StringLength(500)]
    public string CustomerAddress { get; set; }

    [StringLength(150)]
    public string CustomerName { get; set; }

    [StringLength(50)]
    public string Designation { get; set; }

    [StringLength(50)]
    public string EmailID { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public short? IsActive { get; set; }

    [StringLength(500)]
    public string Note { get; set; }

    [StringLength(50)]
    public string PhoneNo1 { get; set; }

    [StringLength(50)]
    public string PhoneNo2 { get; set; }

    [StringLength(500)]
    public string ShippingAddress { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    [StringLength(50)]
    public string Website { get; set; }
  }
}
