// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.CategoryManager
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
  public class CategoryManager
  {
    public cls_common_responses CreateCategory(
      string sp_name,
      Category category_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmCategoryName, @prmIsActive, @prmCreatedDate, @prmCreatedBy, @prmUpdateDate, @prmUpdatedBy", (object) new SqlParameter("@prmIDNUMBER", (object) category_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) category_requests.CompanyID), (object) new SqlParameter("@prmCategoryName", (object) category_requests.CategoryName), (object) new SqlParameter("@prmIsActive", (object) category_requests.IsActive), (object) new SqlParameter("@prmCreatedDate", (object) category_requests.CreatedDate), (object) new SqlParameter("@prmCreatedBy", (object) category_requests.CreatedBy), (object) new SqlParameter("@prmUpdateDate", (object) category_requests.UpdateDate), (object) new SqlParameter("@prmUpdatedBy", (object) category_requests.UpdatedBy)))
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

    public cls_common_responses DeleteCategory(int CategoryID)
    {
      cls_common_responses clsCommonResponses = new cls_common_responses();
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          Category entity = customErpEntities.Category.Where<Category>((Expression<Func<Category, bool>>) (u => u.IDNUMBER == CategoryID)).FirstOrDefault<Category>();
          if (entity == null)
          {
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 400;
            clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
          }
          else
          {
            customErpEntities.Category.Remove(entity);
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

    public List<Category> GetCategories()
    {
      List<Category> categoryList1 = new List<Category>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<Category> categoryList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Category> list = customErpEntities.Category.Select<Category, Category>((Expression<Func<Category, Category>>) (cat => cat)).ToList<Category>();
          if (list.Count > 0)
            categoryList1 = list;
          categoryList2 = categoryList1;
        }
      }
      catch (Exception ex)
      {
        categoryList2 = categoryList1;
      }
      return categoryList2;
    }
  }
}
