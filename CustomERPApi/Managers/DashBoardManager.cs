// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.DashBoardManager
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomERPApi.Managers
{
  public class DashBoardManager
  {
    public cls_DashBoard_Data GetDashBoardData()
    {
      cls_DashBoard_Data clsDashBoardData1 = new cls_DashBoard_Data();
      cls_DashBoard_Data clsDashBoardData2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          int num1 = customErpEntities.Users.Select<Users, Users>((Expression<Func<Users, Users>>) (us => us)).Count<Users>();
          int num2 = customErpEntities.Supplier.Select<Supplier, Supplier>((Expression<Func<Supplier, Supplier>>) (us => us)).Count<Supplier>();
          int num3 = customErpEntities.Customer.Select<Customer, Customer>((Expression<Func<Customer, Customer>>) (us => us)).Count<Customer>();
          int num4 = customErpEntities.Employee.Select<Employee, Employee>((Expression<Func<Employee, Employee>>) (us => us)).Count<Employee>();
          int num5 = customErpEntities.Item.Select<Item, Item>((Expression<Func<Item, Item>>) (us => us)).Count<Item>();
          int num6 = customErpEntities.Purchase.Select<Purchase, Purchase>((Expression<Func<Purchase, Purchase>>) (us => us)).Count<Purchase>();
          int num7 = customErpEntities.Sales.Select<Sales, Sales>((Expression<Func<Sales, Sales>>) (us => us)).Count<Sales>();
          clsDashBoardData1.UserCount = num1;
          clsDashBoardData1.SupplierCount = num2;
          clsDashBoardData1.CustomerCount = num3;
          clsDashBoardData1.EmployeeCount = num4;
          clsDashBoardData1.ProductCount = num5;
          clsDashBoardData1.PurchaseCount = num6;
          clsDashBoardData1.SalesCount = num7;
        }
        clsDashBoardData2 = clsDashBoardData1;
      }
      catch (Exception ex)
      {
        clsDashBoardData1.UserCount = 0;
        clsDashBoardData1.SupplierCount = 0;
        clsDashBoardData1.CustomerCount = 0;
        clsDashBoardData1.EmployeeCount = 0;
        clsDashBoardData1.ProductCount = 0;
        clsDashBoardData1.PurchaseCount = 0;
        clsDashBoardData1.SalesCount = 0;
        clsDashBoardData2 = clsDashBoardData1;
      }
      return clsDashBoardData2;
    }
  }
}
