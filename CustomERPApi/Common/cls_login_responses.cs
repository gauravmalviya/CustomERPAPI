// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Common.cls_login_responses
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

namespace CustomERPApi.Common
{
  public class cls_login_responses
  {
    public int CompanyID { get; set; }

    public string CompanyName { get; set; }

    public int IsSuperUser { get; set; }

    public int ResponseCode { get; set; }

    public string ResponseMessage { get; set; }

    public string UserID { get; set; }

    public int UserIDNumber { get; set; }

    public string UserName { get; set; }

    public int UserType { get; set; }
  }
}
