// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.ExpenseManager
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
  public class ExpenseManager
  {
    public cls_common_responses CreateExpenses(
      string sp_name,
      Expenses expenses_requests)
    {
      cls_common_responses clsCommonResponses1 = new cls_common_responses();
      cls_common_responses clsCommonResponses2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          foreach (cls_common_responses clsCommonResponses3 in customErpEntities.Database.SqlQuery<cls_common_responses>(sp_name + " @prmIDNUMBER, @prmCompanyID, @prmExpenseName, @prmPaidBy, @prmWallet, @prmItem, @prmItemID, @prmItemVarientID, @prmCurrency, @prmCost, @prmUSDCost, @prmNote, @prmIsActive, @prmCreatedBy", (object) new SqlParameter("prmIDNUMBER", (object) expenses_requests.IDNUMBER), (object) new SqlParameter("prmCompanyID", (object) expenses_requests.CompanyID), (object) new SqlParameter("@prmExpenseName", (object) expenses_requests.ExpenseName), (object) new SqlParameter("@prmPaidBy", (object) expenses_requests.PaidBy), (object) new SqlParameter("@prmWallet", (object) expenses_requests.Wallet), (object) new SqlParameter("@prmItem", (object) expenses_requests.Item), (object) new SqlParameter("@prmItemID", (object) expenses_requests.ItemID), (object) new SqlParameter("@prmItemVarientID", (object) expenses_requests.ItemVarientID), (object) new SqlParameter("@prmCurrency", (object) expenses_requests.Currency), (object) new SqlParameter("@prmCost", (object) expenses_requests.Cost), (object) new SqlParameter("@prmUSDCost", (object) expenses_requests.USDCost), (object) new SqlParameter("@prmNote", (object) expenses_requests.Note), (object) new SqlParameter("@prmIsActive", (object) expenses_requests.IsActive), (object) new SqlParameter("@prmCreatedBy", (object) expenses_requests.CreatedBy)))
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

    public cls_common_responses DeleteExpense(int ExpenseID)
    {
      cls_common_responses clsCommonResponses = new cls_common_responses();
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          Expenses entity = customErpEntities.Expenses.Where<Expenses>((Expression<Func<Expenses, bool>>) (u => u.IDNUMBER == ExpenseID)).FirstOrDefault<Expenses>();
          if (entity == null)
          {
            clsCommonResponses.ResponseGenID = 0;
            clsCommonResponses.ResponseCode = 400;
            clsCommonResponses.ResponseMessage = "Something went wrong, please try again later.";
          }
          else
          {
            customErpEntities.Expenses.Remove(entity);
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

    public List<Expenses> GetExpenses()
    {
      List<Expenses> expensesList1 = new List<Expenses>();
      List<Expenses> expensesList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<Expenses> list = customErpEntities.Expenses.Select<Expenses, Expenses>((Expression<Func<Expenses, Expenses>>) (ex => ex)).ToList<Expenses>();
          if (list.Count > 0)
            expensesList1 = list;
          expensesList2 = expensesList1;
        }
      }
      catch (Exception ex)
      {
        expensesList2 = expensesList1;
      }
      return expensesList2;
    }
  }
}
