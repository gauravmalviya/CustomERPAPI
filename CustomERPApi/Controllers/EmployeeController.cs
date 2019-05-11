// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.EmployeeController
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Managers;
using CustomERPApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomERPApi.Controllers
{
  public class EmployeeController : ApiController
  {
    [HttpPost]
    public HttpResponseMessage CreateEmployee(Employee employee_requests)
    {
      EmployeeManager employeeManager = new EmployeeManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (employee_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        employee_requests.CreatedBy = new int?(1);
        employee_requests.CreatedDate = new DateTime?(DateTime.Now);
        employee_requests.UpdatedBy = new int?(1);
        employee_requests.UpdatedDate = new DateTime?(DateTime.Now);
        cls_common_responses employee = employeeManager.CreateEmployee("Proc_Employee_Save", employee_requests);
        int responseCode = employee.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, employee);
      }
      catch (Exception ex)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      return response;
    }

    [HttpGet]
    public HttpResponseMessage DeleteEmployee(int EmployeeID)
    {
      EmployeeManager employeeManager = new EmployeeManager();
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      HttpResponseMessage response;
      try
      {
        cls_common_responses clsCommonResponses2 = employeeManager.DeleteEmployee(EmployeeID);
        int responseCode = clsCommonResponses2.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses2);
      }
      catch (Exception ex)
      {
        clsCommonResponses1.ResponseCode = 400;
        clsCommonResponses1.ResponseMessage = "Something went wrong, please try again later.";
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses1);
      }
      return response;
    }

    [HttpGet]
    public HttpResponseMessage GetEmployees()
    {
      EmployeeManager employeeManager = new EmployeeManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<Employee>>(HttpStatusCode.OK, employeeManager.GetEmployees());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
