// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.UserManager
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Configurations;
using CustomERPApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace CustomERPApi.Managers
{
  public class UserManager
  {
    public cls_common_responses CreateUser(string sp_name, Users user_requests)
    {
      user_requests.CompanyID = new int?(1);
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      user_requests.pswd = Cryptography.Encrypt(user_requests.pswd);
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmUserType, @prmUserID, @prmUserName, @prmpswd, @prmEmailID, @prmMobileNo, @prmBOD, @prmIsActive, @prmIsSuperUser", (object) new SqlParameter("@prmIDNUMBER", (object) user_requests.IDNUMBER), (object) new SqlParameter("@prmCompanyID", (object) user_requests.CompanyID), (object) new SqlParameter("@prmUserType", (object) user_requests.UserType), (object) new SqlParameter("@prmUserID", (object) user_requests.UserID), (object) new SqlParameter("@prmUserName", (object) user_requests.UserName), (object) new SqlParameter("@prmpswd", (object) user_requests.pswd), (object) new SqlParameter("@prmEmailID", (object) user_requests.EmailID), (object) new SqlParameter("@prmMobileNo", (object) user_requests.MobileNo), (object) new SqlParameter("@prmBOD", (object) user_requests.BOD), (object) new SqlParameter("@prmIsActive", (object) user_requests.IsActive), (object) new SqlParameter("@prmIsSuperUser", (object) user_requests.IsSuperUser)))
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

    public cls_common_responses DeleteUser(int UserID)
    {
      cls_common_responses clsCommonResponses = new cls_common_responses();
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          Users entity = customErpEntities.Users.Where<Users>((Expression<Func<Users, bool>>) (u => u.IDNUMBER == UserID)).FirstOrDefault<Users>();
          if (entity == null)
          {
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 400;
            clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
          }
          else
          {
            customErpEntities.Users.Remove(entity);
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

    public List<cls_user_responses> UserModule(string sp_name)
    {
      string baseUrl = Credentials.BaseUrl;
      DateTime.Now.ToString("yyyyMMddHHmmssfff");
      List<cls_user_responses> clsUserResponsesList1 = new List<cls_user_responses>();
      cls_user_responses clsUserResponses1 = new cls_user_responses();
      List<cls_user_responses> clsUserResponsesList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<cls_user_responses> list = customErpEntities.Database.SqlQuery<cls_user_responses>(sp_name).ToList<cls_user_responses>();
          if (list.Count <= 0)
          {
            clsUserResponses1.UserID = "";
            clsUserResponses1.IDNUMBER = 0;
            clsUserResponses1.UserName = "";
            clsUserResponses1.EmailID = "";
            clsUserResponses1.MobileNo = "";
            clsUserResponses1.UserTypeName = "";
            clsUserResponses1.BOD = "";
            clsUserResponses1.Active = "";
            clsUserResponsesList1.Add(clsUserResponses1);
          }
          else
          {
            foreach (cls_user_responses clsUserResponses2 in list)
            {
              clsUserResponses1.UserID = clsUserResponses2.UserID;
              clsUserResponses1.UserName = !string.IsNullOrEmpty(clsUserResponses2.UserName) ? clsUserResponses2.UserName : "";
              clsUserResponses1.EmailID = !string.IsNullOrEmpty(clsUserResponses2.EmailID) ? clsUserResponses2.EmailID : "";
              clsUserResponses1.MobileNo = !string.IsNullOrEmpty(clsUserResponses2.MobileNo) ? clsUserResponses2.MobileNo : "";
              clsUserResponses1.UserTypeName = !string.IsNullOrEmpty(clsUserResponses1.UserTypeName) ? clsUserResponses2.UserTypeName : "";
              clsUserResponses1.Active = !string.IsNullOrEmpty(clsUserResponses1.Active) ? clsUserResponses2.Active : "";
              clsUserResponsesList1.Add(clsUserResponses1);
            }
          }
          clsUserResponsesList2 = list;
        }
      }
      catch (Exception ex)
      {
        clsUserResponses1.UserID = "";
        clsUserResponses1.IDNUMBER = 0;
        clsUserResponses1.UserName = "";
        clsUserResponses1.EmailID = "";
        clsUserResponses1.MobileNo = "";
        clsUserResponses1.UserTypeName = "";
        clsUserResponses1.BOD = "";
        clsUserResponses1.Active = "";
        clsUserResponsesList1.Add(clsUserResponses1);
        clsUserResponsesList2 = clsUserResponsesList1;
      }
      return clsUserResponsesList2;
    }
  }
}
