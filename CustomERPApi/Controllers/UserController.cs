// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.UserController
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
  public class UserController : ApiController
  {
    [HttpPost]
    public HttpResponseMessage CreateUser(Users user_requests)
    {
      UserManager userManager = new UserManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (user_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        cls_common_responses user = userManager.CreateUser("Proc_Users_Save", user_requests);
        int responseCode = user.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, user);
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
    public HttpResponseMessage DeleteUser(int UserID)
    {
      UserManager userManager = new UserManager();
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      HttpResponseMessage response;
      try
      {
        cls_common_responses clsCommonResponses2 = userManager.DeleteUser(UserID);
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
    public HttpResponseMessage GetUsers()
    {
      UserManager userManager = new UserManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<cls_user_responses>>(HttpStatusCode.OK, userManager.UserModule("Proc_Users_FillGrid"));
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
