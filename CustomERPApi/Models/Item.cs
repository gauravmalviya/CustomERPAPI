// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Item
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("Item")]
  public class Item
  {
    public int? CategoryID { get; set; }

    [NotMapped]
    public string CategoryName { get; set; }

    [StringLength(50)]
    public string cmHeight { get; set; }

    [StringLength(50)]
    public string cmLength { get; set; }

    [StringLength(50)]
    public string cmWidth { get; set; }

    public int? CompanyID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    [StringLength(50)]
    public string inchHeight { get; set; }

    [StringLength(50)]
    public string inchLength { get; set; }

    [StringLength(50)]
    public string inchWidth { get; set; }

    public short? IsActive { get; set; }

    [NotMapped]
    public int IsImage { get; set; }

    public string ItemImage { get; set; }

    [StringLength(150)]
    public string ItemName { get; set; }

    [NotMapped]
    public List<ItemVarient> ItemVarients { get; set; }

    [StringLength(50)]
    public string kgWeight { get; set; }

    [StringLength(50)]
    public string lbsWeight { get; set; }

    [StringLength(500)]
    public string Note { get; set; }

    [NotMapped]
    public int? ShanghaiTotal { get; set; }

    [NotMapped]
    public Decimal Total { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
  }
}
