// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.PurchaseManager
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace CustomERPApi.Managers
{
  public class PurchaseManager
  {
    public cls_common_responses CreatePurchase(
      string sp_name,
      Purchase purchase_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmPONo, @prmSupplierID, @prmShippingName, @prmShippingAddress, @prmShippingCost, @prmPaymentType,@prmTotalQty, @prmSubTotal, @prmCurrency, @prmDeposite, @prmBBShippment, @prmIncoterms, @prmTotal, @prmCreatedBy", (object) new SqlParameter("@prmIDNUMBER", (object) purchase_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) purchase_requests.CompanyID), (object) new SqlParameter("@prmPONo", (object) purchase_requests.PONo), (object) new SqlParameter("@prmSupplierID", (object) purchase_requests.SupplierID), (object) new SqlParameter("@prmShippingName", (object) purchase_requests.ShippingName), (object) new SqlParameter("@prmShippingAddress", (object) purchase_requests.ShippingAddress), (object) new SqlParameter("@prmShippingCost", (object) purchase_requests.ShippingCost), (object) new SqlParameter("@prmPaymentType", (object) purchase_requests.PaymentType), (object) new SqlParameter("@prmTotalQty", (object) purchase_requests.TotalQty), (object) new SqlParameter("@prmSubTotal", (object) purchase_requests.SubTotal), (object) new SqlParameter("@prmCurrency", (object) purchase_requests.Currency), (object) new SqlParameter("@prmDeposite", (object) purchase_requests.Deposite), (object) new SqlParameter("@prmBBShippment", (object) purchase_requests.BBShippment), (object) new SqlParameter("@prmIncoterms", (object) purchase_requests.Incoterms), (object) new SqlParameter("@prmTotal", (object) purchase_requests.Total), (object) new SqlParameter("@prmCreatedBy", (object) purchase_requests.CreatedBy)))
          {
            if (clsCommonResponses3.ResponseCode == 200)
            {
              if (!PurchaseManager.saveStocks(purchase_requests, clsCommonResponses3.ResponseGenID))
              {
                clsCommonResponses1.ResponseGenID = 0;
                clsCommonResponses1.ResponseCode = 400;
                clsCommonResponses1.ResponseMessage = "Something went wrong in Stock Insertion!!";
              }
              else
              {
                clsCommonResponses1.ResponseGenID = clsCommonResponses3.ResponseGenID;
                clsCommonResponses1.ResponseCode = clsCommonResponses3.ResponseCode;
                clsCommonResponses1.ResponseMessage = clsCommonResponses3.ResponseMessage;
              }
            }
            else if (clsCommonResponses3.ResponseCode != 400)
            {
              clsCommonResponses1.ResponseGenID = clsCommonResponses3.ResponseGenID;
              clsCommonResponses1.ResponseCode = 400;
              clsCommonResponses1.ResponseMessage = clsCommonResponses3.ResponseMessage;
            }
            else
            {
              clsCommonResponses1.ResponseGenID = clsCommonResponses3.ResponseGenID;
              clsCommonResponses1.ResponseCode = clsCommonResponses3.ResponseCode;
              clsCommonResponses1.ResponseMessage = clsCommonResponses3.ResponseMessage;
            }
          }
          clsCommonResponses2 = clsCommonResponses1;
        }
      }
      catch (Exception ex)
      {
        clsCommonResponses1.ResponseGenID = 0;
        clsCommonResponses1.ResponseCode = 400;
        clsCommonResponses1.ResponseMessage = "Something went wrong, please try again later.";
        clsCommonResponses2 = clsCommonResponses1;
      }
      return clsCommonResponses2;
    }

    public List<Purchase> GetPurchases()
    {
      List<Purchase> purchaseList1 = new List<Purchase>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<Purchase> purchaseList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Purchase> list1 = customErpEntities.Purchase.Select<Purchase, Purchase>((Expression<Func<Purchase, Purchase>>) (itm => itm)).ToList<Purchase>();
          foreach (Purchase purchase in list1)
          {
            Purchase supplierName = purchase;
            List<PurchaseDetails> list2 = customErpEntities.PurchaseDetails.Where<PurchaseDetails>((Expression<Func<PurchaseDetails, bool>>) (pd => pd.PurchaseID == supplierName.IDNUMBER)).ToList<PurchaseDetails>();
            if (list2.Count > 0)
            {
              foreach (PurchaseDetails purchaseDetails in list2)
              {
                PurchaseDetails itemName = purchaseDetails;
                Item obj = customErpEntities.Item.Where<Item>((Expression<Func<Item, bool>>) (it => it.IDNUMBER == itemName.ItemID)).FirstOrDefault<Item>();
                if (obj != null)
                {
                  itemName.ItemName = obj.ItemName;
                  itemName.ProductImage = obj.ItemImage;
                  ItemVarient itemVarient = customErpEntities.ItemVarient.Where<ItemVarient>((Expression<Func<ItemVarient, bool>>) (itv => itv.IDNUMBER == itemName.ItemVarientID)).FirstOrDefault<ItemVarient>();
                  if (itemVarient != null)
                  {
                    itemName.Color = itemVarient.Color;
                    itemName.SKU = itemVarient.SKU;
                    itemName.UPC = itemVarient.UPC;
                  }
                }
              }
              supplierName.PurchaseDetails = list2;
            }
            Supplier supplier = customErpEntities.Supplier.Where<Supplier>((Expression<Func<Supplier, bool>>) (sp => sp.IDNUMBER == supplierName.SupplierID)).FirstOrDefault<Supplier>();
            if (supplier != null)
              supplierName.SupplierName = supplier.SupplierName;
          }
          purchaseList1 = list1;
          purchaseList2 = purchaseList1;
        }
      }
      catch (Exception ex)
      {
        purchaseList2 = purchaseList1;
      }
      return purchaseList2;
    }

    public static bool saveStocks(Purchase purchase_requests, int ResponseGenID)
    {
      Stockdbf stockdbf = new Stockdbf();
      StockDetails entity = new StockDetails();
      bool flag = false;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          if (purchase_requests.PurchaseDetails != null)
          {
            if (purchase_requests.PurchaseDetails.Count > 0)
            {
              foreach (PurchaseDetails purchaseDetail1 in purchase_requests.PurchaseDetails)
              {
                PurchaseDetails purchaseDetail = purchaseDetail1;
                purchaseDetail.PurchaseID = ResponseGenID;
                PurchaseDetails purchaseDetails = customErpEntities.PurchaseDetails.Where<PurchaseDetails>((Expression<Func<PurchaseDetails, bool>>) (iv => iv.IDNUMBER == purchaseDetail.IDNUMBER && iv.PurchaseID == ResponseGenID)).SingleOrDefault<PurchaseDetails>();
                if (purchaseDetails == null)
                {
                  customErpEntities.PurchaseDetails.Add(purchaseDetail);
                  customErpEntities.SaveChanges();
                  if (customErpEntities.Stockdbf.FirstOrDefault<Stockdbf>((Expression<Func<Stockdbf, bool>>) (x => x.ItemID == purchaseDetail.ItemID && x.ItemVarientID == purchaseDetail.ItemVarientID)) != null)
                  {
                    stockdbf.StockQty += purchaseDetail.Qty;
                    customErpEntities.SaveChanges();
                    entity.CompanyID = new int?(1);
                    entity.StockID = stockdbf.IDNUMBER;
                    entity.ItemID = purchaseDetail.ItemID;
                    entity.ItemVarientID = purchaseDetail.IDNUMBER;
                    entity.StockQty = purchaseDetail.Qty;
                    entity.StockRate = purchaseDetail.Price;
                    entity.TranCode = "C";
                    entity.TranBook = "PUR";
                    entity.TranNo = purchase_requests.PONo;
                    entity.CreatedBy = new int?(1);
                    entity.CreatedDate = new DateTime?(DateTime.Now);
                    customErpEntities.StockDetails.Add(entity);
                    customErpEntities.SaveChanges();
                  }
                  flag = true;
                }
                else
                {
                  purchaseDetails.Price = purchaseDetail.Price;
                  purchaseDetails.Qty = purchaseDetail.Qty;
                  purchaseDetails.TotalAmount = purchaseDetail.TotalAmount;
                  purchaseDetails.CompanyID = purchaseDetail.CompanyID;
                  purchaseDetails.UnitID = purchaseDetail.UnitID;
                  customErpEntities.SaveChanges();
                  if (customErpEntities.Stockdbf.FirstOrDefault<Stockdbf>((Expression<Func<Stockdbf, bool>>) (x => x.ItemID == purchaseDetail.ItemID && x.ItemVarientID == purchaseDetail.ItemVarientID)) != null)
                  {
                    stockdbf.StockQty += purchaseDetails.Qty;
                    customErpEntities.SaveChanges();
                    entity.CompanyID = new int?(1);
                    entity.StockID = stockdbf.IDNUMBER;
                    entity.ItemID = purchaseDetails.ItemID;
                    entity.ItemVarientID = purchaseDetails.IDNUMBER;
                    entity.StockQty = purchaseDetails.Qty;
                    entity.StockRate = purchaseDetails.Price;
                    entity.TranCode = "C";
                    entity.TranBook = "PUR";
                    entity.TranNo = purchase_requests.PONo;
                    entity.CreatedBy = new int?(1);
                    entity.CreatedDate = new DateTime?(DateTime.Now);
                    customErpEntities.StockDetails.Add(entity);
                    customErpEntities.SaveChanges();
                  }
                  flag = true;
                }
              }
            }
            flag = true;
          }
          flag = true;
        }
      }
      catch (Exception ex)
      {
        flag = false;
      }
      return flag;
    }
  }
}
