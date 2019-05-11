// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.CustomerController
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
  public class CustomerController : ApiController
  {
    [HttpPost]
    public HttpResponseMessage CreateCustomer(Customer customer_requests)
    {
      CustomerManager customerManager = new CustomerManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (customer_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        customer_requests.CreatedBy = new int?(1);
        customer_requests.CreatedDate = new DateTime?(DateTime.Now);
        customer_requests.UpdatedBy = new int?(1);
        customer_requests.UpdatedDate = new DateTime?(DateTime.Now);
        cls_common_responses customer = customerManager.CreateCustomer("Proc_Customer_Save", customer_requests);
        int responseCode = customer.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, customer);
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
    public HttpResponseMessage DeleteCustomer(int CustomerID)
    {
      CustomerManager customerManager = new CustomerManager();
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      HttpResponseMessage response;
      try
      {
        cls_common_responses clsCommonResponses2 = customerManager.DeleteCustomer(CustomerID);
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
    public HttpResponseMessage GetCustomers()
    {
      CustomerManager customerManager = new CustomerManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<Customer>>(HttpStatusCode.OK, customerManager.GetCustomers());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
