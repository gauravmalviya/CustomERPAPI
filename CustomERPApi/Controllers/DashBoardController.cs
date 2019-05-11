// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.DashBoardController
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
  public class DashBoardController : ApiController
  {
    [HttpGet]
    public HttpResponseMessage GetDashBoardData()
    {
      DashBoardManager dashBoardManager = new DashBoardManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<cls_DashBoard_Data>(HttpStatusCode.OK, dashBoardManager.GetDashBoardData());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
