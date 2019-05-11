// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.WarehouseController
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
  public class WarehouseController : ApiController
  {
    [HttpPost]
    public HttpResponseMessage Createwarehouse(Warehouse warehouse_requests)
    {
      WarehouseManager warehouseManager = new WarehouseManager();
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      if (warehouse_requests == null)
      {
        clsCommonResponses1.ResponseCode = 400;
        clsCommonResponses1.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses1);
      }
      HttpResponseMessage response;
      try
      {
        warehouse_requests.CreatedBy = new int?(1);
        warehouse_requests.CreatedDate = new DateTime?(DateTime.Now);
        warehouse_requests.UpdatedBy = new int?(1);
        warehouse_requests.UpdatedDate = new DateTime?(DateTime.Now);
        cls_common_responses clsCommonResponses2 = warehouseManager.Createwarehouse("Proc_Warehouse_Save", warehouse_requests);
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
    public HttpResponseMessage DeleteWarehouse(int WarehouseID)
    {
      WarehouseManager warehouseManager = new WarehouseManager();
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      HttpResponseMessage response;
      try
      {
        cls_common_responses clsCommonResponses2 = warehouseManager.DeleteWarehouse(WarehouseID);
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
    public HttpResponseMessage GetWarehouses()
    {
      WarehouseManager warehouseManager = new WarehouseManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<Warehouse>>(HttpStatusCode.OK, warehouseManager.GetWarehouses());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
