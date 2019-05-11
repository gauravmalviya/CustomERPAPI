// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.ItemVarient
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("ItemVarient")]
  public class ItemVarient
  {
    [StringLength(50)]
    public string Color { get; set; }

    public int? CompanyID { get; set; }

    [Column(TypeName = "numeric")]
    public Decimal Cost { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public Decimal Inventory { get; set; }

    public short? IsActive { get; set; }

    public int ItemID { get; set; }

    public bool? ItemImage { get; set; }

    [NotMapped]
    public string ItemName { get; set; }

    [NotMapped]
    public string ItemVarientName { get; set; }

    [NotMapped]
    public string ProductImage { get; set; }

    [StringLength(50)]
    public string Size { get; set; }

    [StringLength(150)]
    public string SKU { get; set; }

    [StringLength(150)]
    public string UPC { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? WarehouseID { get; set; }
  }
}
