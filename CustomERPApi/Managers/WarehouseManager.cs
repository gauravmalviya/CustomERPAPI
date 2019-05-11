// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.WarehouseManager
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
  public class WarehouseManager
  {
    public cls_common_responses Createwarehouse(
      string sp_name,
      Warehouse warehouse_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmWarehouseName, @prmAddress, @prmIsActive, @prmCreatedDate, @prmCreatedBy, @prmUpdateDate, @prmUpdatedBy", (object) new SqlParameter("@prmIDNUMBER", (object) warehouse_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) warehouse_requests.CompanyID), (object) new SqlParameter("@prmWarehouseName", (object) warehouse_requests.WarehouseName), (object) new SqlParameter("@prmAddress", (object) warehouse_requests.Address), (object) new SqlParameter("@prmIsActive", (object) warehouse_requests.IsActive), (object) new SqlParameter("@prmCreatedDate", (object) warehouse_requests.CreatedDate), (object) new SqlParameter("@prmCreatedBy", (object) warehouse_requests.CreatedBy), (object) new SqlParameter("@prmUpdateDate", (object) warehouse_requests.UpdatedDate), (object) new SqlParameter("@prmUpdatedBy", (object) warehouse_requests.UpdatedBy)))
          {
            if (clsCommonResponses3.ResponseCode == 200)
            {
              clsCommonResponses1.ResponseGenID = clsCommonResponses3.ResponseGenID;
              clsCommonResponses1.ResponseCode = clsCommonResponses3.ResponseCode;
              clsCommonResponses1.ResponseMessage = clsCommonResponses3.ResponseMessage;
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

    public cls_common_responses DeleteWarehouse(int WarehouseID)
    {
      cls_common_responses clsCommonResponses = new cls_common_responses();
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          Warehouse entity = customErpEntities.Warehouse.Where<Warehouse>((Expression<Func<Warehouse, bool>>) (u => u.IDNUMBER == WarehouseID)).FirstOrDefault<Warehouse>();
          if (entity == null)
          {
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 400;
            clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
          }
          else
          {
            customErpEntities.Warehouse.Remove(entity);
            customErpEntities.SaveChanges();
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 200;
            clsCommonResponses.ResponseMessage = "Record Delete SuccessFully!!";
          }
        }
      }
      catch (Exception ex)
      {
        clsCommonResponses.ResponseGenID = 0;
        clsCommonResponses.ResponseCode = 400;
        clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
      }
      return clsCommonResponses;
    }

    public List<Warehouse> GetWarehouses()
    {
      List<Warehouse> warehouseList1 = new List<Warehouse>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<Warehouse> warehouseList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Warehouse> list = customErpEntities.Warehouse.Select<Warehouse, Warehouse>((Expression<Func<Warehouse, Warehouse>>) (war => war)).ToList<Warehouse>();
          if (list.Count > 0)
            warehouseList1 = list;
          warehouseList2 = warehouseList1;
        }
      }
      catch (Exception ex)
      {
        warehouseList2 = warehouseList1;
      }
      return warehouseList2;
    }
  }
}
