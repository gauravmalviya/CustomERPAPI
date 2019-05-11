// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Managers.ItemVarientManager
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using CustomERPApi.Common;
using CustomERPApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CustomERPApi.Managers
{
  public class ItemVarientManager
  {
    public List<ItemVarient> GetItemVarients()
    {
      List<ItemVarient> itemVarientList1 = new List<ItemVarient>();
      cls_user_responses clsUserResponses = new cls_user_responses();
      List<ItemVarient> itemVarientList2;
      try
      {
        using (CustomERPEntities customErpEntities = new CustomERPEntities())
        {
          List<ItemVarient> list = customErpEntities.ItemVarient.Select<ItemVarient, ItemVarient>((Expression<Func<ItemVarient, ItemVarient>>) (itm => itm)).ToList<ItemVarient>();
          if (list.Count > 0)
          {
            foreach (ItemVarient itemVarient in list)
            {
              ItemVarient itemName = itemVarient;
              Item obj = customErpEntities.Item.Where<Item>((Expression<Func<Item, bool>>) (itm => itm.IDNUMBER == itemName.ItemID)).FirstOrDefault<Item>();
              if (obj != null)
              {
                itemName.ItemName = obj.ItemName;
                itemName.ProductImage = obj.ItemImage;
                itemName.ItemVarientName = obj.ItemName + " - " + itemName.Color + " - " + itemName.Size;
              }
            }
            itemVarientList1 = list;
          }
          itemVarientList2 = itemVarientList1;
        }
      }
      catch (Exception ex)
      {
        itemVarientList2 = itemVarientList1;
      }
      return itemVarientList2;
    }
  }
}
