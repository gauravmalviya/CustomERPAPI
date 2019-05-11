// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Configurations.Credentials
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using System.Configuration;
using System.Web.Configuration;

namespace CustomERPApi.Configurations
{
  public class Credentials
  {
    public static string ApiBaseUrl
    {
      get
      {
        return WebConfigurationManager.AppSettings["api_base_url"];
      }
    }

    public static string AppBaseUrl
    {
      get
      {
        return WebConfigurationManager.AppSettings["app_base_url"];
      }
    }

    public static string BaseUrl
    {
      get
      {
        return WebConfigurationManager.AppSettings["base_url"];
      }
    }

    public static string EmailDisplayName
    {
      get
      {
        return WebConfigurationManager.AppSettings["email_display_name"];
      }
    }

    public static string PhysicalPath
    {
      get
      {
        return WebConfigurationManager.AppSettings["physical_path"];
      }
    }

    public static string SenderEmail
    {
      get
      {
        return WebConfigurationManager.AppSettings["sender_email"];
      }
    }

    public static string SenderPassword
    {
      get
      {
        return WebConfigurationManager.AppSettings["sender_password"];
      }
    }

    public static string ValidateConnectionString
    {
      get
      {
        return ConfigurationManager.ConnectionStrings["SmartCare360EntitiesSmartValidate"].ConnectionString;
      }
    }
  }
}
