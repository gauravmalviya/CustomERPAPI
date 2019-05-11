// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.SupplierManager
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
  public class SupplierManager
  {
    public cls_common_responses CreateSuplier(
      string sp_name,
      Supplier supplier_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmSupplierName, @prmSupplierAddress, @prmPhoneNo1, @prmPhoneNo2, @prmEmailID,@prmCompanyName, @prmCompAddress, @prmWebsite, @prmCompEmail, @prmDesignation, @prmShippingAddress, @prmContFirstName1, @prmContSurname1, @prmContPosition1, @prmContEmail1, @prmContPhone1, @prmContFirstName2,@prmContSurname2, @prmContPosition2, @prmContEmail2, @prmContPhone2, @prmBankName, @prmBankAddress, @prmIBAN, @prmSWIFT, @prmAccountNumber, @prmNote, @prmIsActive, @prmCreatedBy, @prmCreatedDate, @prmUpdatedBy, @prmUpdatedDate", (object) new SqlParameter("@prmIDNUMBER", (object) supplier_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) supplier_requests.CompanyID), (object) new SqlParameter("@prmSupplierName", (object) supplier_requests.SupplierName), (object) new SqlParameter("@prmSupplierAddress", (object) supplier_requests.SupplierAddress), (object) new SqlParameter("@prmPhoneNo1", (object) supplier_requests.PhoneNo1), (object) new SqlParameter("@prmPhoneNo2", (object) supplier_requests.PhoneNo2), (object) new SqlParameter("@prmEmailID", (object) supplier_requests.EmailID), (object) new SqlParameter("@prmCompanyName", (object) supplier_requests.CompanyName), (object) new SqlParameter("@prmCompAddress", (object) supplier_requests.CompAddress), (object) new SqlParameter("@prmWebsite", (object) supplier_requests.Website), (object) new SqlParameter("@prmCompEmail", (object) supplier_requests.CompEmail), (object) new SqlParameter("@prmDesignation", (object) supplier_requests.Designation), (object) new SqlParameter("@prmShippingAddress", (object) supplier_requests.ShippingAddress), (object) new SqlParameter("@prmContFirstName1", (object) supplier_requests.ContFirstName1), (object) new SqlParameter("@prmContSurname1", (object) supplier_requests.ContSurname1), (object) new SqlParameter("@prmContPosition1", (object) supplier_requests.ContPosition1), (object) new SqlParameter("@prmContEmail1", (object) supplier_requests.ContEmail1), (object) new SqlParameter("@prmContPhone1", (object) supplier_requests.ContPhone1), (object) new SqlParameter("@prmContFirstName2", (object) supplier_requests.ContFirstName2), (object) new SqlParameter("@prmContSurname2", (object) supplier_requests.ContSurname2), (object) new SqlParameter("@prmContPosition2", (object) supplier_requests.ContPosition2), (object) new SqlParameter("@prmContEmail2", (object) supplier_requests.ContEmail2), (object) new SqlParameter("@prmContPhone2", (object) supplier_requests.ContPhone2), (object) new SqlParameter("@prmBankName", (object) supplier_requests.BankName), (object) new SqlParameter("@prmBankAddress", (object) supplier_requests.BankAddress), (object) new SqlParameter("@prmIBAN", (object) supplier_requests.IBAN), (object) new SqlParameter("@prmSWIFT", (object) supplier_requests.SWIFT), (object) new SqlParameter("@prmAccountNumber", (object) supplier_requests.AccountNumber), (object) new SqlParameter("@prmNote", (object) supplier_requests.Note), (object) new SqlParameter("@prmIsActive", (object) supplier_requests.IsActive), (object) new SqlParameter("@prmCreatedBy", (object) supplier_requests.CreatedBy), (object) new SqlParameter("@prmCreatedDate", (object) supplier_requests.CreatedDate), (object) new SqlParameter("@prmUpdatedBy", (object) supplier_requests.UpdatedBy), (object) new SqlParameter("@prmUpdatedDate", (object) supplier_requests.UpdatedDate)))
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

    public cls_common_responses DeleteSupplier(int SupplierID)
    {
      cls_common_responses clsCommonResponses = new cls_common_responses();
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          Supplier entity = customErpEntities.Supplier.Where<Supplier>((Expression<Func<Supplier, bool>>) (u => u.IDNUMBER == SupplierID)).FirstOrDefault<Supplier>();
          if (entity == null)
          {
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 400;
            clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
          }
          else
          {
            customErpEntities.Supplier.Remove(entity);
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

    public List<Supplier> GetSupplier()
    {
      List<Supplier> supplierList1 = new List<Supplier>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<Supplier> supplierList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Supplier> list = customErpEntities.Supplier.Select<Supplier, Supplier>((Expression<Func<Supplier, Supplier>>) (sup => sup)).ToList<Supplier>();
          if (list.Count > 0)
            supplierList1 = list;
          supplierList2 = supplierList1;
        }
      }
      catch (Exception ex)
      {
        supplierList2 = supplierList1;
      }
      return supplierList2;
    }
  }
}
