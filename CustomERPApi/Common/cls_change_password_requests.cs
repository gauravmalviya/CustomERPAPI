// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Common.cls_change_password_requests
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System;

namespace CustomERPApi.Common
{
  public class cls_change_password_requests
  {
    private DateTime currentDate = DateTime.Now;

    public string CurrentPassword { get; set; }

    public string NewPassword { get; set; }

    public int UserID { get; set; }
  }
}
