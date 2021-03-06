﻿// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Controllers.PurchaseController
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Managers;
using CustomERPApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomERPApi.Controllers
{
  public class PurchaseController : ApiController
  {
    [HttpPost]
    public HttpResponseMessage CreatePurchase(Purchase purchase_requests)
    {
      PurchaseManager purchaseManager = new PurchaseManager();
      cls_common_responses clsCommonResponses = new cls_common_responses();
      if (purchase_requests == null)
      {
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "";
        return this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, clsCommonResponses);
      }
      HttpResponseMessage response;
      try
      {
        purchase_requests.CreatedBy = new int?(1);
        purchase_requests.CreatedDate = new DateTime?(DateTime.Now);
        cls_common_responses purchase = purchaseManager.CreatePurchase("Proc_Purchase_Save", purchase_requests);
        int responseCode = purchase.ResponseCode;
        response = this.Request.CreateResponse<cls_common_responses>(HttpStatusCode.OK, purchase);
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
    public string GetLastPurchaseID()
    {
      int num = 0;
      string str1 = "";
      string str2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
          num = customErpEntities.Purchase.OrderByDescending<Purchase, int>((Expression<Func<Purchase, int>>) (p => p.IDNUMBER)).Select<Purchase, int>((Expression<Func<Purchase, int>>) (p => p.IDNUMBER)).FirstOrDefault<int>();
        if ((uint) num > 0U)
        {
          if (num.ToString().Length == 4)
            str1 = num.ToString();
          if (num.ToString().Length == 3)
            str1 = "0" + num.ToString();
          else if (num.ToString().Length == 2)
            str1 = "00" + num.ToString();
          else if (num.ToString().Length == 1)
            str1 = "000" + num.ToString();
        }
        str2 = str1;
      }
      catch (Exception ex)
      {
        str2 = str1;
      }
      return str2;
    }

    [HttpGet]
    public HttpResponseMessage GetPurchases()
    {
      PurchaseManager purchaseManager = new PurchaseManager();
      cls_user_responses clsUserResponses = new cls_user_responses();
      HttpResponseMessage response;
      try
      {
        response = this.Request.CreateResponse<List<Purchase>>(HttpStatusCode.OK, purchaseManager.GetPurchases());
      }
      catch (Exception ex)
      {
        response = this.Request.CreateResponse<cls_user_responses>(HttpStatusCode.OK, clsUserResponses);
      }
      return response;
    }
  }
}
