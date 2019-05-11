// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Models.Employee
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomERPApi.Models
{
  [Table("Employee")]
  public class Employee
  {
    public int? CompanyID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    [StringLength(50)]
    public string EmailID { get; set; }

    [StringLength(50)]
    public string EmpFirstName { get; set; }

    [StringLength(500)]
    public string EmployeeAddress { get; set; }

    public DateTime? EmployeeEnd { get; set; }

    public DateTime? EmploymentStart { get; set; }

    [StringLength(50)]
    public string EmpSurName { get; set; }

    [Key]
    public int IDNUMBER { get; set; }

    public short? IsActive { get; set; }

    public short? IsEmployeement { get; set; }

    [StringLength(500)]
    public string Notes { get; set; }

    [StringLength(50)]
    public string PhoneNo { get; set; }

    [StringLength(50)]
    public string Position { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
  }
}
