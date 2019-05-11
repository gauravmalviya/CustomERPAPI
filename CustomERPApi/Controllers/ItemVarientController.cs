// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.ItemVarientController
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
  public class ItemVarientController : ApiController
  {
    [HttpGet]
    public HttpResponseMessage GetItemVarients()
    {
      ItemVarientManager itemVarientManager = new ItemVarientManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<ItemVarient>>(HttpStatusCode.OK, itemVarientManager.GetItemVarients());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
