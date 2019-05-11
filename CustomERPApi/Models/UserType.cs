// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.UserType
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("UserType")]
  public class UserType
  {
    [Column(TypeName = "numeric")]
    [Key]
    public Decimal IDNUMBER { get; set; }

    public short? IsActive { get; set; }

    public short? IsSuperType { get; set; }

    [StringLength(20)]
    public string UserTypeName { get; set; }
  }
}
