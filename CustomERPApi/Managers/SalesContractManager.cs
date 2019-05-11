// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.SalesContractManager
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
  public class SalesContractManager
  {
    public cls_common_responses CreateSalesContract(
      string sp_name,
      SalesContract salescontract_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmSCNo, @prmSCDate, @prmSupplierID, @prmShippingName, @prmShippingAddress, @prmShippingCost, @prmPaymentType,@prmTotalQty, @prmSubTotal, @prmCurrency, @prmDeposite, @prmBBShippment, @prmIncoterms, @prmTotal, @prmCreatedBy", (object) new SqlParameter("@prmIDNUMBER", (object) salescontract_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) salescontract_requests.CompanyID), (object) new SqlParameter("@prmPONo", (object) salescontract_requests.SCNO), (object) new SqlParameter("@prmSCDate", (object) salescontract_requests.SCDate), (object) new SqlParameter("@prmSupplierID", (object) salescontract_requests.CustomerID), (object) new SqlParameter("@prmShippingName", (object) salescontract_requests.ShippingName), (object) new SqlParameter("@prmShippingAddress", (object) salescontract_requests.ShippingAddress), (object) new SqlParameter("@prmShippingCost", (object) salescontract_requests.ShippingCost), (object) new SqlParameter("@prmPaymentType", (object) salescontract_requests.PaymentType), (object) new SqlParameter("@prmTotalQty", (object) salescontract_requests.TotalQty), (object) new SqlParameter("@prmSubTotal", (object) salescontract_requests.SubTotal), (object) new SqlParameter("@prmCurrency", (object) salescontract_requests.Currency), (object) new SqlParameter("@prmDeposite", (object) salescontract_requests.Deposite), (object) new SqlParameter("@prmBBShippment", (object) salescontract_requests.BBShippment), (object) new SqlParameter("@prmIncoterms", (object) salescontract_requests.Incoterms), (object) new SqlParameter("@prmTotal", (object) salescontract_requests.Total), (object) new SqlParameter("@prmCreatedBy", (object) salescontract_requests.CreatedBy)))
          {
            if (clsCommonResponses3.ResponseCode == 200)
            {
              if (!SalesContractManager.saveSalesContractDetail(salescontract_requests, clsCommonResponses3.ResponseGenID))
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

    public List<SalesContract> GetSales()
    {
      List<SalesContract> salesContractList1 = new List<SalesContract>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<SalesContract> salesContractList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<SalesContract> list1 = customErpEntities.SalesContract.Select<SalesContract, SalesContract>((Expression<Func<SalesContract, SalesContract>>) (itm => itm)).ToList<SalesContract>();
          foreach (SalesContract salesContract in list1)
          {
            SalesContract customerName = salesContract;
            List<SalesContractDetails> list2 = customErpEntities.SalesContractDetails.Where<SalesContractDetails>((Expression<Func<SalesContractDetails, bool>>) (sl => sl.SalesID == customerName.IDNUMBER)).ToList<SalesContractDetails>();
            if (list2.Count > 0)
            {
              foreach (SalesContractDetails salesContractDetails in list2)
              {
                SalesContractDetails itemName = salesContractDetails;
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
              customerName.SalescontractDetails = list2;
            }
            Customer customer = customErpEntities.Customer.Where<Customer>((Expression<Func<Customer, bool>>) (cp => cp.IDNUMBER == customerName.CustomerID)).FirstOrDefault<Customer>();
            if (customer != null)
              customerName.CustomerName = customer.CustomerName;
          }
          salesContractList1 = list1;
          salesContractList2 = salesContractList1;
        }
      }
      catch (Exception ex)
      {
        salesContractList2 = salesContractList1;
      }
      return salesContractList2;
    }

    public static bool saveSalesContractDetail(
      SalesContract salescontract_requests,
      int ResponseGenID)
    {
      Stockdbf stockdbf = new Stockdbf();
      StockDetails stockDetails = new StockDetails();
      bool flag = false;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          if (salescontract_requests.SalescontractDetails != null)
          {
            if (salescontract_requests.SalescontractDetails.Count > 0)
            {
              foreach (SalesContractDetails salescontractDetail1 in salescontract_requests.SalescontractDetails)
              {
                SalesContractDetails salescontractDetail = salescontractDetail1;
                salescontractDetail.SalesID = ResponseGenID;
                SalesContractDetails salesContractDetails = customErpEntities.SalesContractDetails.Where<SalesContractDetails>((Expression<Func<SalesContractDetails, bool>>) (iv => iv.IDNUMBER == salescontractDetail.IDNUMBER && iv.SalesID == ResponseGenID)).SingleOrDefault<SalesContractDetails>();
                if (salesContractDetails == null)
                {
                  customErpEntities.SalesContractDetails.Add(salescontractDetail);
                  customErpEntities.SaveChanges();
                }
                else
                {
                  salesContractDetails.Price = salescontractDetail.Price;
                  salesContractDetails.Qty = salescontractDetail.Qty;
                  salesContractDetails.TotalAmount = salescontractDetail.TotalAmount;
                  salesContractDetails.CompanyID = salescontractDetail.CompanyID;
                  salesContractDetails.UnitID = salescontractDetail.UnitID;
                  customErpEntities.SaveChanges();
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
