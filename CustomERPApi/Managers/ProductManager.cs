// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.ProductManager
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CustomERPApi.Managers
{
  public class ProductManager
  {
    public cls_common_responses CreateProduct(
      string sp_name,
      Item product_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        if (product_requests.IsImage == 1)
        {
          string str = ProductManager.SaveBranchFile(product_requests.ItemImage, "Item", product_requests.ItemName);
          product_requests.ItemImage = !(str != "error") ? "../dist/img/user-image.png" : str;
        }
        else if (product_requests.IDNUMBER == 0)
          product_requests.ItemImage = "../dist/img/user-image.png";
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmItemName, @prmItemImage, @prmCategoryID, @prmDescription, @prmcmLength, @prmcmHeight,@prmcmWidth, @prminchLength, @prminchHeight, @prminchWidth, @prmkgWeight, @prmlbsWeight, @prmNote, @prmIsActive, @prmCreatedBy, @prmUpdateBy", (object) new SqlParameter("@prmIDNUMBER", (object) product_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) product_requests.CompanyID), (object) new SqlParameter("@prmItemName", (object) product_requests.ItemName), (object) new SqlParameter("@prmItemImage", (object) product_requests.ItemImage), (object) new SqlParameter("@prmCategoryID", (object) product_requests.CategoryID), (object) new SqlParameter("@prmDescription", (object) product_requests.Description), (object) new SqlParameter("@prmcmLength", (object) product_requests.cmLength), (object) new SqlParameter("@prmcmHeight", (object) product_requests.cmHeight), (object) new SqlParameter("@prmcmWidth", (object) product_requests.cmWidth), (object) new SqlParameter("@prminchLength", (object) product_requests.inchLength), (object) new SqlParameter("@prminchHeight", (object) product_requests.inchHeight), (object) new SqlParameter("@prminchWidth", (object) product_requests.inchWidth), (object) new SqlParameter("@prmkgWeight", (object) product_requests.kgWeight), (object) new SqlParameter("@prmlbsWeight", (object) product_requests.lbsWeight), (object) new SqlParameter("@prmNote", (object) product_requests.Note), (object) new SqlParameter("@prmIsActive", (object) product_requests.IsActive), (object) new SqlParameter("@prmCreatedBy", (object) product_requests.CreatedBy), (object) new SqlParameter("@prmUpdateBy", (object) product_requests.UpdateBy)))
          {
            if (clsCommonResponses3.ResponseCode == 200)
            {
              if (!ProductManager.saveStocks(product_requests, clsCommonResponses3.ResponseGenID))
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

    public List<Item> GetProducts()
    {
      List<Item> objList1 = new List<Item>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<Item> objList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Item> list1 = customErpEntities.Item.Select<Item, Item>((Expression<Func<Item, Item>>) (itm => itm)).ToList<Item>();
          if (list1.Count > 0)
          {
            foreach (Item obj in list1)
            {
              Item categoryName = obj;
              Decimal num = new Decimal();
              int? nullable1 = new int?(0);
              List<ItemVarient> list2 = customErpEntities.ItemVarient.Where<ItemVarient>((Expression<Func<ItemVarient, bool>>) (itmvar => itmvar.ItemID == categoryName.IDNUMBER)).ToList<ItemVarient>();
              if (list2.Count > 0)
                categoryName.ItemVarients = list2;
              Category category = customErpEntities.Category.Where<Category>((Expression<Func<Category, bool>>) (ct => (int?) ct.IDNUMBER == categoryName.CategoryID)).FirstOrDefault<Category>();
              if (category != null)
                categoryName.CategoryName = category.CategoryName;
              List<ItemVarient> list3 = customErpEntities.ItemVarient.Where<ItemVarient>((Expression<Func<ItemVarient, bool>>) (ct => ct.ItemID == categoryName.IDNUMBER)).ToList<ItemVarient>();
              if (list3 != null)
              {
                foreach (ItemVarient itemVarient in list3)
                {
                  num += itemVarient.Inventory;
                  int? nullable2 = nullable1;
                  int? warehouseId = itemVarient.WarehouseID;
                  nullable1 = !(nullable2.HasValue & warehouseId.HasValue) ? new int?() : new int?(nullable2.GetValueOrDefault() + warehouseId.GetValueOrDefault());
                }
                categoryName.Total = num;
                categoryName.ShanghaiTotal = nullable1;
              }
            }
            objList1 = list1;
          }
          objList2 = objList1;
        }
      }
      catch (Exception ex)
      {
        objList2 = objList1;
      }
      return objList2;
    }

    private static string SaveBranchFile(
      string fileName,
      string filePrefix,
      string branchShortName)
    {
      string str1;
      try
      {
        string sourceFileName = string.Format("{0}\\{1}", (object) HttpContext.Current.Server.MapPath("~/TempFiles"), (object) fileName);
        FileInfo fileInfo = new FileInfo(fileName);
        DateTime now = DateTime.Now;
        string str2 = string.Format("{0}_{1}{2}", (object) filePrefix, (object) now.ToString("ddMMyyHHmmss"), (object) fileInfo.Extension);
        if (!Directory.Exists(string.Format("{0}\\{1}", (object) HttpContext.Current.Server.MapPath("~/Images"), (object) branchShortName)))
          Directory.CreateDirectory(string.Format("{0}\\{1}", (object) HttpContext.Current.Server.MapPath("~/Images"), (object) branchShortName));
        Array.ForEach<string>(Directory.GetFiles(string.Format("{0}\\{1}", (object) HttpContext.Current.Server.MapPath("~/Images"), (object) branchShortName)), (Action<string>) (path => File.Delete(path)));
        string destFileName = string.Format("{0}\\{1}\\{2}", (object) HttpContext.Current.Server.MapPath("~/Images"), (object) branchShortName, (object) str2);
        File.Move(sourceFileName, destFileName);
        str1 = string.Format("/Images/{0}/{1}", (object) branchShortName, (object) str2);
      }
      catch (Exception ex)
      {
        str1 = "error";
      }
      return str1;
    }

    public static bool saveStocks(Item product_requests, int ResponseGenID)
    {
      Stockdbf entity1 = new Stockdbf();
      StockDetails entity2 = new StockDetails();
      ItemVarient itemVarient1 = new ItemVarient();
      bool flag = false;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          if (product_requests.ItemVarients != null)
          {
            if (product_requests.ItemVarients.Count > 0)
            {
              foreach (ItemVarient itemVarient2 in product_requests.ItemVarients)
              {
                ItemVarient responseGenID = itemVarient2;
                responseGenID.ItemID = ResponseGenID;
                responseGenID.CreatedBy = new int?(1);
                responseGenID.CreatedDate = new DateTime?(DateTime.Now);
                responseGenID.UpdateBy = new int?(1);
                responseGenID.UpdatedDate = new DateTime?(DateTime.Now);
                ItemVarient warehouseID = customErpEntities.ItemVarient.Where<ItemVarient>((Expression<Func<ItemVarient, bool>>) (iv => iv.IDNUMBER == responseGenID.IDNUMBER && iv.ItemID == ResponseGenID)).SingleOrDefault<ItemVarient>();
                if (warehouseID == null)
                {
                  warehouseID = responseGenID;
                  entity1.StockQty = responseGenID.Inventory;
                  warehouseID.WarehouseID = responseGenID.WarehouseID;
                  customErpEntities.ItemVarient.Add(warehouseID);
                  customErpEntities.SaveChanges();
                  if (customErpEntities.Stockdbf.Where<Stockdbf>((Expression<Func<Stockdbf, bool>>) (st => st.ItemID == responseGenID.ItemID && st.ItemVarientID == responseGenID.IDNUMBER)).FirstOrDefault<Stockdbf>() != null)
                  {
                    entity1.StockQty = responseGenID.Inventory;
                    customErpEntities.SaveChanges();
                    entity2.StockQty = responseGenID.Inventory;
                    entity2.StockRate = warehouseID.Cost;
                    entity2.TranNo = product_requests.ItemName;
                    customErpEntities.SaveChanges();
                  }
                  else
                  {
                    entity1.CompanyID = new int?(1);
                    entity1.ItemID = responseGenID.ItemID;
                    entity1.ItemVarientID = responseGenID.IDNUMBER;
                    entity1.StockQty = warehouseID.Inventory;
                    customErpEntities.Stockdbf.Add(entity1);
                    customErpEntities.SaveChanges();
                    entity2.CompanyID = new int?(1);
                    entity2.StockID = entity1.IDNUMBER;
                    entity2.ItemID = responseGenID.ItemID;
                    entity2.ItemVarientID = responseGenID.IDNUMBER;
                    entity2.StockQty = responseGenID.Inventory;
                    entity2.StockRate = responseGenID.Cost;
                    entity2.TranCode = "C";
                    entity2.TranBook = "OP";
                    entity2.TranNo = product_requests.ItemName;
                    entity2.CreatedBy = new int?(1);
                    entity2.CreatedDate = new DateTime?(DateTime.Now);
                    customErpEntities.StockDetails.Add(entity2);
                    customErpEntities.SaveChanges();
                  }
                  flag = true;
                }
                else
                {
                  warehouseID.Color = responseGenID.Color;
                  warehouseID.Size = responseGenID.Size;
                  warehouseID.Inventory = responseGenID.Inventory;
                  warehouseID.WarehouseID = responseGenID.WarehouseID;
                  warehouseID.Cost = responseGenID.Cost;
                  warehouseID.SKU = responseGenID.SKU;
                  warehouseID.UPC = responseGenID.UPC;
                  customErpEntities.SaveChanges();
                  if (customErpEntities.Stockdbf.FirstOrDefault<Stockdbf>((Expression<Func<Stockdbf, bool>>) (x => x.ItemID == warehouseID.ItemID && x.ItemVarientID == warehouseID.IDNUMBER)) != null)
                  {
                    entity1.StockQty = warehouseID.Inventory;
                    customErpEntities.SaveChanges();
                    entity2.StockQty = responseGenID.Inventory;
                    entity2.StockRate = warehouseID.Cost;
                    entity2.TranNo = product_requests.ItemName;
                    customErpEntities.SaveChanges();
                  }
                  else
                  {
                    entity1.CompanyID = new int?(1);
                    entity1.ItemID = warehouseID.ItemID;
                    entity1.ItemVarientID = warehouseID.IDNUMBER;
                    entity1.StockQty = warehouseID.Inventory;
                    customErpEntities.Stockdbf.Add(entity1);
                    customErpEntities.SaveChanges();
                    entity2.CompanyID = new int?(1);
                    entity2.StockID = entity1.IDNUMBER;
                    entity2.ItemID = warehouseID.ItemID;
                    entity2.ItemVarientID = warehouseID.IDNUMBER;
                    entity2.StockQty = warehouseID.Inventory;
                    entity2.StockRate = warehouseID.Cost;
                    entity2.TranCode = "C";
                    entity2.TranBook = "OP";
                    entity2.TranNo = product_requests.ItemName;
                    entity2.CreatedBy = new int?(1);
                    entity2.CreatedDate = new DateTime?(DateTime.Now);
                    customErpEntities.StockDetails.Add(entity2);
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
