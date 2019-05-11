// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Users
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  public class Users
  {
    public DateTime? BOD { get; set; }

    [Column(TypeName = "numeric")]
    public int? CompanyID { get; set; }

    [StringLength(80)]
    public string EmailID { get; set; }

    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IDNUMBER { get; set; }

    public short? IsActive { get; set; }

    public short? IsSuperUser { get; set; }

    [StringLength(20)]
    public string MobileNo { get; set; }

    [StringLength(100)]
    public string pswd { get; set; }

    [StringLength(20)]
    public string UserID { get; set; }

    [StringLength(50)]
    public string UserName { get; set; }

    public short? UserType { get; set; }
  }
}
