// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Common.cls_Employee_requests
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;

namespace CustomERPApi.Common
{
  public class cls_Employee_requests
  {
    public int CompanyID { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string EmailID { get; set; }

    public string EmpFirstName { get; set; }

    public string EmployeeAddress { get; set; }

    public DateTime EmployeeEnd { get; set; }

    public DateTime EmploymentStart { get; set; }

    public string EmpSurName { get; set; }

    public int IDNUMBER { get; set; }

    public int IsActive { get; set; }

    public int IsEmployeement { get; set; }

    public string Notes { get; set; }

    public string PhoneNo { get; set; }

    public string Position { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
  }
}
