// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.CustomerManager
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
  public class CustomerManager
  {
    public cls_common_responses CreateCustomer(
      string sp_name,
      Customer customer_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmCustomerName, @prmCustomerAddress, @prmPhoneNo1, @prmPhoneNo2, @prmEmailID,@prmCompanyName, @prmCompAddress, @prmWebsite, @prmCompEmail, @prmDesignation, @prmShippingAddress, @prmContFirstName1, @prmContSurname1, @prmContPosition1, @prmContEmail1, @prmContPhone1, @prmContFirstName2,@prmContSurname2, @prmContPosition2, @prmContEmail2, @prmContPhone2, @prmNote, @prmIsActive, @prmCreatedBy, @prmCreatedDate, @prmUpdatedBy, @prmUpdatedDate", (object) new SqlParameter("@prmIDNUMBER", (object) customer_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) customer_requests.CompanyID), (object) new SqlParameter("@prmCustomerName", (object) customer_requests.CustomerName), (object) new SqlParameter("@prmCustomerAddress", (object) customer_requests.CustomerAddress), (object) new SqlParameter("@prmPhoneNo1", (object) customer_requests.PhoneNo1), (object) new SqlParameter("@prmPhoneNo2", (object) customer_requests.PhoneNo2), (object) new SqlParameter("@prmEmailID", (object) customer_requests.EmailID), (object) new SqlParameter("@prmCompanyName", (object) customer_requests.CompanyName), (object) new SqlParameter("@prmCompAddress", (object) customer_requests.CompAddress), (object) new SqlParameter("@prmWebsite", (object) customer_requests.Website), (object) new SqlParameter("@prmCompEmail", (object) customer_requests.CompEmail), (object) new SqlParameter("@prmDesignation", (object) customer_requests.Designation), (object) new SqlParameter("@prmShippingAddress", (object) customer_requests.ShippingAddress), (object) new SqlParameter("@prmContFirstName1", (object) customer_requests.ContFirstName1), (object) new SqlParameter("@prmContSurname1", (object) customer_requests.ContSurname1), (object) new SqlParameter("@prmContPosition1", (object) customer_requests.ContPosition1), (object) new SqlParameter("@prmContEmail1", (object) customer_requests.ContEmail1), (object) new SqlParameter("@prmContPhone1", (object) customer_requests.ContPhone1), (object) new SqlParameter("@prmContFirstName2", (object) customer_requests.ContFirstName2), (object) new SqlParameter("@prmContSurname2", (object) customer_requests.ContSurname2), (object) new SqlParameter("@prmContPosition2", (object) customer_requests.ContPosition2), (object) new SqlParameter("@prmContEmail2", (object) customer_requests.ContEmail2), (object) new SqlParameter("@prmContPhone2", (object) customer_requests.ContPhone2), (object) new SqlParameter("@prmNote", (object) customer_requests.Note), (object) new SqlParameter("@prmIsActive", (object) customer_requests.IsActive), (object) new SqlParameter("@prmCreatedBy", (object) customer_requests.CreatedBy), (object) new SqlParameter("@prmCreatedDate", (object) customer_requests.CreatedDate), (object) new SqlParameter("@prmUpdatedBy", (object) customer_requests.UpdatedBy), (object) new SqlParameter("@prmUpdatedDate", (object) customer_requests.UpdatedDate)))
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

    public cls_common_responses DeleteCustomer(int CustomerID)
    {
      cls_common_responses clsCommonResponses = new cls_common_responses();
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          Customer entity = customErpEntities.Customer.Where<Customer>((Expression<Func<Customer, bool>>) (u => u.IDNUMBER == CustomerID)).FirstOrDefault<Customer>();
          if (entity == null)
          {
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 400;
            clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
          }
          else
          {
            customErpEntities.Customer.Remove(entity);
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

    public List<Customer> GetCustomers()
    {
      List<Customer> customerList1 = new List<Customer>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<Customer> customerList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Customer> list = customErpEntities.Customer.Select<Customer, Customer>((Expression<Func<Customer, Customer>>) (cus => cus)).ToList<Customer>();
          if (list.Count > 0)
            customerList1 = list;
          customerList2 = customerList1;
        }
      }
      catch (Exception ex)
      {
        customerList2 = customerList1;
      }
      return customerList2;
    }
  }
}
