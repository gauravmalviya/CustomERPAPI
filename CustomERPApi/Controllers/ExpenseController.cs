// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.ExpenseController
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
  public class ExpenseController : ApiController
  {
    [HttpPost]
    public HttpResponseMessage CreateExpense(Expenses expense_requests)
    {
      ExpenseManager expenseManager = new ExpenseManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (expense_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        expense_requests.CreatedBy = new int?(1);
        expense_requests.CreatedDate = new DateTime?(DateTime.Now);
        cls_common_responses expenses = expenseManager.CreateExpenses("Proc_Expense_Save", expense_requests);
        int responseCode = expenses.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, expenses);
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
    public HttpResponseMessage DeleteExpense(int ExpenseID)
    {
      ExpenseManager expenseManager = new ExpenseManager();
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      HttpResponseMessage response;
      try
      {
        cls_common_responses clsCommonResponses2 = expenseManager.DeleteExpense(ExpenseID);
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
    public HttpResponseMessage GetExpenses()
    {
      ExpenseManager expenseManager = new ExpenseManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<Expenses>>(HttpStatusCode.OK, expenseManager.GetExpenses());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
