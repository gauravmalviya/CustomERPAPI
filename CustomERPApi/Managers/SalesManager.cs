// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.SalesManager
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
  public class SalesManager
  {
    public cls_common_responses CreateSales(
      string sp_name,
      Sales sales_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmPONo, @prmSupplierID, @prmShippingName, @prmShippingAddress, @prmShippingCost, @prmPaymentType,@prmTotalQty, @prmSubTotal, @prmCurrency, @prmDeposite, @prmBBShippment, @prmIncoterms, @prmTotal, @prmCreatedBy", (object) new SqlParameter("@prmIDNUMBER", (object) sales_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) sales_requests.CompanyID), (object) new SqlParameter("@prmPONo", (object) sales_requests.SONO), (object) new SqlParameter("@prmSupplierID", (object) sales_requests.CustomerID), (object) new SqlParameter("@prmShippingName", (object) sales_requests.ShippingName), (object) new SqlParameter("@prmShippingAddress", (object) sales_requests.ShippingAddress), (object) new SqlParameter("@prmShippingCost", (object) sales_requests.ShippingCost), (object) new SqlParameter("@prmPaymentType", (object) sales_requests.PaymentType), (object) new SqlParameter("@prmTotalQty", (object) sales_requests.TotalQty), (object) new SqlParameter("@prmSubTotal", (object) sales_requests.SubTotal), (object) new SqlParameter("@prmCurrency", (object) sales_requests.Currency), (object) new SqlParameter("@prmDeposite", (object) sales_requests.Deposite), (object) new SqlParameter("@prmBBShippment", (object) sales_requests.BBShippment), (object) new SqlParameter("@prmIncoterms", (object) sales_requests.Incoterms), (object) new SqlParameter("@prmTotal", (object) sales_requests.Total), (object) new SqlParameter("@prmCreatedBy", (object) sales_requests.CreatedBy)))
          {
            if (clsCommonResponses3.ResponseCode == 200)
            {
              if (!SalesManager.saveStocks(sales_requests, clsCommonResponses3.ResponseGenID))
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

    public List<Sales> GetSales()
    {
      List<Sales> salesList1 = new List<Sales>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<Sales> salesList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Sales> list1 = customErpEntities.Sales.Select<Sales, Sales>((Expression<Func<Sales, Sales>>) (itm => itm)).ToList<Sales>();
          foreach (Sales sales in list1)
          {
            Sales customerName = sales;
            List<SalesDetails> list2 = customErpEntities.SalesDetails.Where<SalesDetails>((Expression<Func<SalesDetails, bool>>) (sl => sl.SalesID == customerName.IDNUMBER)).ToList<SalesDetails>();
            if (list2.Count > 0)
            {
              foreach (SalesDetails salesDetails in list2)
              {
                SalesDetails itemName = salesDetails;
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
              customerName.SalesDetails = list2;
            }
            Customer customer = customErpEntities.Customer.Where<Customer>((Expression<Func<Customer, bool>>) (cp => cp.IDNUMBER == customerName.CustomerID)).FirstOrDefault<Customer>();
            if (customer != null)
              customerName.CustomerName = customer.CustomerName;
          }
          salesList1 = list1;
          salesList2 = salesList1;
        }
      }
      catch (Exception ex)
      {
        salesList2 = salesList1;
      }
      return salesList2;
    }

    public static bool saveStocks(Sales sales_requests, int ResponseGenID)
    {
      Stockdbf stockdbf = new Stockdbf();
      StockDetails entity = new StockDetails();
      bool flag = false;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          if (sales_requests.SalesDetails != null)
          {
            if (sales_requests.SalesDetails.Count > 0)
            {
              foreach (SalesDetails salesDetail1 in sales_requests.SalesDetails)
              {
                SalesDetails salesDetail = salesDetail1;
                salesDetail.SalesID = ResponseGenID;
                SalesDetails salesDetails = customErpEntities.SalesDetails.Where<SalesDetails>((Expression<Func<SalesDetails, bool>>) (iv => iv.IDNUMBER == salesDetail.IDNUMBER && iv.SalesID == ResponseGenID)).SingleOrDefault<SalesDetails>();
                if (salesDetails == null)
                {
                  customErpEntities.SalesDetails.Add(salesDetail);
                  customErpEntities.SaveChanges();
                  if (customErpEntities.Stockdbf.FirstOrDefault<Stockdbf>((Expression<Func<Stockdbf, bool>>) (x => x.ItemID == salesDetail.ItemID && x.ItemVarientID == salesDetail.ItemVarientID)) != null)
                  {
                    stockdbf.StockQty -= salesDetail.Qty;
                    customErpEntities.SaveChanges();
                    entity.CompanyID = new int?(1);
                    entity.StockID = stockdbf.IDNUMBER;
                    entity.ItemID = salesDetail.ItemID;
                    entity.ItemVarientID = salesDetail.IDNUMBER;
                    entity.StockQty = salesDetail.Qty;
                    entity.StockRate = salesDetail.Price;
                    entity.TranCode = "D";
                    entity.TranBook = "SLS";
                    entity.TranNo = sales_requests.SONO;
                    entity.CreatedBy = new int?(1);
                    entity.CreatedDate = new DateTime?(DateTime.Now);
                    customErpEntities.StockDetails.Add(entity);
                    customErpEntities.SaveChanges();
                  }
                  flag = true;
                }
                else
                {
                  salesDetails.Price = salesDetail.Price;
                  salesDetails.Qty = salesDetail.Qty;
                  salesDetails.TotalAmount = salesDetail.TotalAmount;
                  salesDetails.CompanyID = salesDetail.CompanyID;
                  salesDetails.UnitID = salesDetail.UnitID;
                  customErpEntities.SaveChanges();
                  if (customErpEntities.Stockdbf.FirstOrDefault<Stockdbf>((Expression<Func<Stockdbf, bool>>) (x => x.ItemID == salesDetail.ItemID && x.ItemVarientID == salesDetail.ItemVarientID)) != null)
                  {
                    stockdbf.StockQty -= salesDetails.Qty;
                    customErpEntities.SaveChanges();
                    entity.CompanyID = new int?(1);
                    entity.StockID = stockdbf.IDNUMBER;
                    entity.ItemID = salesDetails.ItemID;
                    entity.ItemVarientID = salesDetails.IDNUMBER;
                    entity.StockQty = salesDetails.Qty;
                    entity.StockRate = salesDetails.Price;
                    entity.TranCode = "D";
                    entity.TranBook = "SLS";
                    entity.TranNo = sales_requests.SONO;
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
