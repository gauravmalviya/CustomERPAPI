// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.CategoryController
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
  public class CategoryController : ApiController
  {
    [HttpGet]
    public HttpResponseMessage GetCategories()
    {
      CategoryManager categoryManager = new CategoryManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<Category>>(HttpStatusCode.OK, categoryManager.GetCategories());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }

    [HttpPost]
    public HttpResponseMessage CreateCategory(Category category_requests)
    {
      CategoryManager categoryManager = new CategoryManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (category_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        category_requests.CreatedBy = new int?(1);
        category_requests.CreatedDate = new DateTime?(DateTime.Now);
        category_requests.UpdatedBy = new int?(1);
        category_requests.UpdateDate = new DateTime?(DateTime.Now);
        cls_common_responses category = categoryManager.CreateCategory("Proc_Category_Save", category_requests);
        int responseCode = category.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, category);
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
    public HttpResponseMessage DeleteCategory(int CategoryID)
    {
      CategoryManager categoryManager = new CategoryManager();
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      HttpResponseMessage response;
      try
      {
        cls_common_responses clsCommonResponses2 = categoryManager.DeleteCategory(CategoryID);
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
  }
}
