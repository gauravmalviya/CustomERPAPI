// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.ProductController
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
  public class ProductController : ApiController
  {
    [HttpPost]
    public HttpResponseMessage CreateProduct(Item product_requests)
    {
      ProductManager productManager = new ProductManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (product_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        product_requests.CreatedBy = new int?(1);
        product_requests.CreatedDate = new DateTime?(DateTime.Now);
        product_requests.UpdateBy = new int?(1);
        product_requests.UpdatedDate = new DateTime?(DateTime.Now);
        cls_common_responses product = productManager.CreateProduct("Proc_Item_Save", product_requests);
        int responseCode = product.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, product);
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
    public HttpResponseMessage GetProducts()
    {
      ProductManager productManager = new ProductManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<Item>>(HttpStatusCode.OK, productManager.GetProducts());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
