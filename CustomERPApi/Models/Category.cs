// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Category
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("Category")]
  public class Category
  {
    [StringLength(150)]
    public string CategoryName { get; set; }

    public int? CompanyID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public short? IsActive { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedBy { get; set; }
  }
}
