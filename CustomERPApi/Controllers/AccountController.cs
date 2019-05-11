// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.AccountController
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Managers;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomERPApi.Controllers
{
  public class AccountController : ApiController
  {
    [ActionName("UserLogin")]
    [HttpPost]
    public HttpResponseMessage UserLogin(cls_login_requests login_requests)
    {
      AccountManager accountManager = new AccountManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (login_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "Please enter login credentials";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      if (string.IsNullOrEmpty(login_requests.Email))
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "User ID is required";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      if (string.IsNullOrEmpty(login_requests.Password))
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "Password is required";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        cls_login_responses clsLoginResponses = accountManager.LogIn("Proc_UserLogin", login_requests);
        int responseCode = clsLoginResponses.ResponseCode;
        response = this.Request.CreateResponse<cls_login_responses>(HttpStatusCode.OK, clsLoginResponses);
      }
      catch (Exception ex)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      return response;
    }
  }
}
