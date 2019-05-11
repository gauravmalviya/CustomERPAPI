// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.EmployeeManager
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace CustomERPApi.Managers
{
  public class EmployeeManager
  {
    public cls_common_responses CreateEmployee(
      string sp_name,
      Employee employee_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmEmpFirstName, @prmEmpSurName, @prmEmployeeAddress, @prmPhoneNo, @prmEmailID, @prmPosition,@prmEmploymentStart, @prmEmployeeEnd, @prmNotes, @prmIsEmployeement, @prmIsActive, @prmCreatedBy, @prmCreatedDate, @prmUpdatedBy, @prmUpdatedDate", (object) new SqlParameter("@prmIDNUMBER", (object) employee_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) employee_requests.CompanyID), (object) new SqlParameter("@prmEmpFirstName", (object) employee_requests.EmpFirstName), (object) new SqlParameter("@prmEmpSurName", (object) employee_requests.EmpSurName), (object) new SqlParameter("@prmEmployeeAddress", (object) employee_requests.EmployeeAddress), (object) new SqlParameter("@prmPhoneNo", (object) employee_requests.PhoneNo), (object) new SqlParameter("@prmEmailID", (object) employee_requests.EmailID), (object) new SqlParameter("@prmPosition", (object) employee_requests.Position), (object) new SqlParameter("@prmEmploymentStart", (object) employee_requests.EmploymentStart), (object) new SqlParameter("@prmEmployeeEnd", (object) employee_requests.EmployeeEnd), (object) new SqlParameter("@prmNotes", (object) employee_requests.Notes), (object) new SqlParameter("@prmIsEmployeement", (object) employee_requests.IsEmployeement), (object) new SqlParameter("@prmIsActive", (object) employee_requests.IsActive), (object) new SqlParameter("@prmCreatedBy", (object) employee_requests.CreatedBy), (object) new SqlParameter("@prmCreatedDate", (object) employee_requests.CreatedDate), (object) new SqlParameter("@prmUpdatedBy", (object) employee_requests.UpdatedBy), (object) new SqlParameter("@prmUpdatedDate", (object) employee_requests.UpdatedDate)))
          {
            if (clsCommonResponses3.ResponseCode == 200)
            {
              clsCommonResponses1.ResponseGenID = clsCommonResponses3.ResponseGenID;
              clsCommonResponses1.ResponseCode = clsCommonResponses3.ResponseCode;
              clsCommonResponses1.ResponseMessage = clsCommonResponses3.ResponseMessage;
            }
            else if (clsCommonResponses3.ResponseCode != 400)
            {
              clsCommonResponses1.ResponseGenID = clsCommonResponses3.ResponseGenID;
              clsCommonResponses1.ResponseCode = 400;
              clsCommonResponses1.ResponseMessage = clsCommonResponses3.ResponseMessage;
            }
            else
            {
              clsCommonResponses1.ResponseGenID = clsCommonResponses3.ResponseGenID;
              clsCommonResponses1.ResponseCode = clsCommonResponses3.ResponseCode;
              clsCommonResponses1.ResponseMessage = clsCommonResponses3.ResponseMessage;
            }
          }
          clsCommonResponses2 = clsCommonResponses1;
        }
      }
      catch (Exception ex)
      {
        clsCommonResponses1.ResponseGenID = 0;
        clsCommonResponses1.ResponseCode = 400;
        clsCommonResponses1.ResponseMessage = "Something went wrong, please try again later.";
        clsCommonResponses2 = clsCommonResponses1;
      }
      return clsCommonResponses2;
    }

    public cls_common_responses DeleteEmployee(int EmployeeID)
    {
      cls_common_responses clsCommonResponses = new cls_common_responses();
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          Employee entity = customErpEntities.Employee.Where<Employee>((Expression<Func<Employee, bool>>) (u => u.IDNUMBER == EmployeeID)).FirstOrDefault<Employee>();
          if (entity == null)
          {
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 400;
            clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
          }
          else
          {
            customErpEntities.Employee.Remove(entity);
            customErpEntities.SaveChanges();
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 200;
            clsCommonResponses.ResponseMessage = "Record Delete SuccessFully!!";
          }
        }
      }
      catch (Exception ex)
      {
        clsCommonResponses.ResponseGenID = 0;
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
      }
      return clsCommonResponses;
    }

    public List<Employee> GetEmployees()
    {
      List<Employee> employeeList1 = new List<Employee>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<Employee> employeeList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Employee> list = customErpEntities.Employee.Select<Employee, Employee>((Expression<Func<Employee, Employee>>) (emp => emp)).ToList<Employee>();
          if (list.Count > 0)
            employeeList1 = list;
          employeeList2 = employeeList1;
        }
      }
      catch (Exception ex)
      {
        employeeList2 = employeeList1;
      }
      return employeeList2;
    }
  }
}
