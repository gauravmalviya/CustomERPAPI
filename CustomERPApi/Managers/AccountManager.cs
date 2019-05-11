// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.AccountManager
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Models;
using System;
using System.Data.SqlClient;

namespace CustomERPApi.Managers
{
  public class AccountManager
  {
    public cls_login_responses LogIn(
      string sp_name,
      cls_login_requests login_requests)
    {
      login_requests.Password = Cryptography.Encrypt(login_requests.Password);
      cls_login_responses clsLoginResponses1 = new cls_login_responses();
      cls_login_responses clsLoginResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_login_responses clsLoginResponses3 in customErpEntities.Database.SqlQuery<cls_login_responses>(sp_name + " @email, @password", (object) new SqlParameter("@email", (object) login_requests.Email), (object) new SqlParameter("@password", (object) login_requests.Password)))
          {
            if (clsLoginResponses3.ResponseCode == 200)
            {
              clsLoginResponses1.ResponseCode = clsLoginResponses3.ResponseCode;
              clsLoginResponses1.ResponseMessage = clsLoginResponses3.ResponseMessage;
              clsLoginResponses1.UserID = clsLoginResponses3.UserID;
              clsLoginResponses1.UserIDNumber = clsLoginResponses3.UserIDNumber;
              clsLoginResponses1.UserName = clsLoginResponses3.UserName;
              clsLoginResponses1.UserType = clsLoginResponses3.UserType;
              clsLoginResponses1.CompanyID = clsLoginResponses3.CompanyID;
              clsLoginResponses1.IsSuperUser = clsLoginResponses3.IsSuperUser;
              clsLoginResponses1.CompanyName = clsLoginResponses3.CompanyName;
            }
            else if (clsLoginResponses3.ResponseCode != 400)
            {
              clsLoginResponses1.ResponseCode = 400;
              clsLoginResponses1.ResponseMessage = "Username or Password is incorrect";
              clsLoginResponses1.UserIDNumber = 0;
            }
            else
            {
              clsLoginResponses1.ResponseCode = clsLoginResponses3.ResponseCode;
              clsLoginResponses1.ResponseMessage = clsLoginResponses3.ResponseMessage;
              clsLoginResponses1.UserIDNumber = 0;
            }
          }
          clsLoginResponses2 = clsLoginResponses1;
        }
      }
      catch (Exception ex)
      {
        clsLoginResponses1.ResponseCode = 400;
        clsLoginResponses1.ResponseMessage = "Something went wrong, please try again later.";
        clsLoginResponses1.UserIDNumber = 0;
        clsLoginResponses2 = clsLoginResponses1;
      }
      return clsLoginResponses2;
    }
  }
}
