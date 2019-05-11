// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.SupplierController
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
  public class SupplierController : ApiController
  {
    [HttpGet]
    public HttpResponseMessage DeleteSupplier(int SupplierID)
    {
      SupplierManager supplierManager = new SupplierManager();
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      HttpResponseMessage response;
      try
      {
        cls_common_responses clsCommonResponses2 = supplierManager.DeleteSupplier(SupplierID);
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
    public HttpResponseMessage GetSuppliers()
    {
      SupplierManager supplierManager = new SupplierManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<Supplier>>(HttpStatusCode.OK, supplierManager.GetSupplier());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }

    [HttpPost]
    public HttpResponseMessage CreateSupplier(Supplier supplier_requests)
    {
      SupplierManager supplierManager = new SupplierManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (supplier_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        supplier_requests.CreatedBy = new int?(1);
        supplier_requests.CreatedDate = new DateTime?(DateTime.Now);
        supplier_requests.UpdatedBy = new int?(1);
        supplier_requests.UpdatedDate = new DateTime?(DateTime.Now);
        cls_common_responses suplier = supplierManager.CreateSuplier("Proc_Supplier_Save", supplier_requests);
        int responseCode = suplier.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, suplier);
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
