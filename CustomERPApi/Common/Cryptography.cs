// Decompiled with JetBrains decompiler
// Type: CustomERPApi.Common.Cryptography
// Assembly: CustomERPApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8B80D393-97B9-4885-A230-D87F18CB29C5
// Assembly location: C:\Users\Gaurav\Desktop\CustomERPApi.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CustomERPApi.Common
{
  public static class Cryptography
  {
    private static byte[] key = new byte[24]
    {
      (byte) 1,
      (byte) 2,
      (byte) 3,
      (byte) 4,
      (byte) 5,
      (byte) 6,
      (byte) 7,
      (byte) 8,
      (byte) 9,
      (byte) 10,
      (byte) 11,
      (byte) 12,
      (byte) 13,
      (byte) 14,
      (byte) 15,
      (byte) 16,
      (byte) 17,
      (byte) 18,
      (byte) 19,
      (byte) 20,
      (byte) 21,
      (byte) 22,
      (byte) 23,
      (byte) 24
    };
    private static byte[] iv8Bit = new byte[8]
    {
      (byte) 1,
      (byte) 2,
      (byte) 3,
      (byte) 4,
      (byte) 5,
      (byte) 6,
      (byte) 7,
      (byte) 8
    };
    private static string SecretKey = "_mysecretmacbook";
    private static string JWTSecretKey = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9";
    private static Dictionary<JwtHashAlgorithm, Func<byte[], byte[], byte[]>> HashAlgorithms = new Dictionary<JwtHashAlgorithm, Func<byte[], byte[], byte[]>>()
    {
      {
        JwtHashAlgorithm.RS256,
        (Func<byte[], byte[], byte[]>) ((key, value) =>
        {
          byte[] hash;
          using (HMACSHA256 hmacshA256 = new HMACSHA256(key))
            hash = hmacshA256.ComputeHash(value);
          return hash;
        })
      },
      {
        JwtHashAlgorithm.HS384,
        (Func<byte[], byte[], byte[]>) ((key, value) =>
        {
          byte[] hash;
          using (HMACSHA384 hmacshA384 = new HMACSHA384(key))
            hash = hmacshA384.ComputeHash(value);
          return hash;
        })
      },
      {
        JwtHashAlgorithm.HS512,
        (Func<byte[], byte[], byte[]>) ((key, value) =>
        {
          byte[] hash;
          using (HMACSHA512 hmacshA512 = new HMACSHA512(key))
            hash = hmacshA512.ComputeHash(value);
          return hash;
        })
      }
    };
    private const string private_key = "SmartCare360";

    private static byte[] Base64UrlDecode(string input)
    {
      string s = input.Replace('-', '+').Replace('_', '/');
      switch (s.Length % 4)
      {
        case 0:
          return Convert.FromBase64String(s);
        case 1:
          throw new Exception("Illegal base64url string!");
        case 2:
          return Convert.FromBase64String(s + "==");
        case 3:
          return Convert.FromBase64String(s + "=");
        default:
          throw new Exception("Illegal base64url string!");
      }
    }

    private static string Base64UrlEncode(byte[] input)
    {
      return Convert.ToBase64String(input).Split('=')[0].Replace('+', '-').Replace('/', '_');
    }

    //public static string Decode(string token, string key, bool verify)
    //{
    //  string[] strArray = token.Split('.');
    //  string input1 = strArray[0];
    //  string input2 = strArray[1];
    //  byte[] inArray1 = CustomERPApi.Common.Cryptography.Base64UrlDecode(strArray[2]);
    //  JObject jobject1 = JObject.Parse(Encoding.UTF8.GetString(CustomERPApi.Common.Cryptography.Base64UrlDecode(input1)));
    //  JObject jobject2 = JObject.Parse(Encoding.UTF8.GetString(CustomERPApi.Common.Cryptography.Base64UrlDecode(input2)));
    //  if (verify)
    //  {
    //    byte[] bytes1 = Encoding.UTF8.GetBytes(input1 + "." + input2);
    //    byte[] bytes2 = Encoding.UTF8.GetBytes(key);
    //    string algorithm =JToken.op_Explicit(jobject1.GetValue("alg"));
    //    byte[] inArray2 = CustomERPApi.Common.Cryptography.HashAlgorithms[CustomERPApi.Common.Cryptography.GetHashAlgorithm(algorithm)](bytes2, bytes1);
    //    string base64String1 = Convert.ToBase64String(inArray1);
    //    string base64String2 = Convert.ToBase64String(inArray2);
    //    if (base64String1 != base64String2)
    //      throw new ApplicationException(string.Format("Invalid signature. Expected {0} got {1}", (object) base64String1, (object) base64String2));
    //  }
    //  ((object) jobject2).ToString();
    //  return ((object) jobject2).ToString();
    //}

    public static string Decrypt(string CipherText)
    {
      CipherText = CipherText.Replace(' ', '+');
      string str;
      try
      {
        UTF8Encoding utF8Encoding = new UTF8Encoding();
        MD5CryptoServiceProvider cryptoServiceProvider1 = new MD5CryptoServiceProvider();
        byte[] hash = cryptoServiceProvider1.ComputeHash(utF8Encoding.GetBytes("SmartCare360"));
        TripleDESCryptoServiceProvider cryptoServiceProvider2 = new TripleDESCryptoServiceProvider();
        cryptoServiceProvider2.Key = hash;
        cryptoServiceProvider2.Mode = CipherMode.ECB;
        cryptoServiceProvider2.Padding = PaddingMode.PKCS7;
        TripleDESCryptoServiceProvider cryptoServiceProvider3 = cryptoServiceProvider2;
        byte[] inputBuffer = Convert.FromBase64String(CipherText);
        byte[] bytes;
        try
        {
          bytes = cryptoServiceProvider3.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
        }
        catch (Exception ex)
        {
          return "400";
        }
        finally
        {
          cryptoServiceProvider3.Clear();
          cryptoServiceProvider1.Clear();
        }
        str = utF8Encoding.GetString(bytes);
      }
      catch (Exception ex)
      {
        str = "400";
      }
      return str;
    }

    public static string DecryptAES(string toDecrypt)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(CustomERPApi.Common.Cryptography.SecretKey);
      byte[] inputBuffer = Convert.FromBase64String(toDecrypt);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Key = bytes;
      rijndaelManaged.Mode = CipherMode.ECB;
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      return Encoding.UTF8.GetString(rijndaelManaged.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
    }

    //public static string Encode(object payload, byte[] keyBytes, JwtHashAlgorithm algorithm)
    //{
    //  List<string> stringList = new List<string>();
    //  var data = new
    //  {
    //    alg = algorithm.ToString(),
    //    typ = "JWT"
    //  };
    //  byte[] bytes1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object) data, (Formatting) 0));
    //  byte[] bytes2 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload, (Formatting) 0));
    //  stringList.Add(CustomERPApi.Common.Cryptography.Base64UrlEncode(bytes1));
    //  stringList.Add(CustomERPApi.Common.Cryptography.Base64UrlEncode(bytes2));
    //  byte[] bytes3 = Encoding.UTF8.GetBytes(string.Join(".", stringList.ToArray()));
    //  byte[] input = CustomERPApi.Common.Cryptography.HashAlgorithms[algorithm](keyBytes, bytes3);
    //  stringList.Add(CustomERPApi.Common.Cryptography.Base64UrlEncode(input));
    //  return string.Join(".", stringList.ToArray());
    //}

    public static string Encrypt(string PlainText)
    {
      string str;
      try
      {
        using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
        {
          byte[] numArray = new byte[32];
          cryptoServiceProvider.GetBytes(numArray);
          Convert.ToBase64String(numArray);
        }
        UTF8Encoding utF8Encoding = new UTF8Encoding();
        MD5CryptoServiceProvider cryptoServiceProvider1 = new MD5CryptoServiceProvider();
        byte[] hash = cryptoServiceProvider1.ComputeHash(utF8Encoding.GetBytes("SmartCare360"));
        TripleDESCryptoServiceProvider cryptoServiceProvider2 = new TripleDESCryptoServiceProvider();
        cryptoServiceProvider2.Key = hash;
        cryptoServiceProvider2.Mode = CipherMode.ECB;
        cryptoServiceProvider2.Padding = PaddingMode.PKCS7;
        TripleDESCryptoServiceProvider cryptoServiceProvider3 = cryptoServiceProvider2;
        byte[] bytes = utF8Encoding.GetBytes(PlainText);
        byte[] inArray;
        try
        {
          inArray = cryptoServiceProvider3.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
        }
        catch (Exception ex)
        {
          return "400";
        }
        finally
        {
          cryptoServiceProvider3.Clear();
          cryptoServiceProvider1.Clear();
        }
        str = Convert.ToBase64String(inArray);
      }
      catch (Exception ex)
      {
        str = "400";
      }
      return str;
    }

    public static string EncryptAES(string toEncrypt)
    {
      byte[] bytes1 = Encoding.UTF8.GetBytes(CustomERPApi.Common.Cryptography.SecretKey);
      byte[] bytes2 = Encoding.UTF8.GetBytes(toEncrypt);
      Aes aes = Aes.Create("AES");
      aes.Mode = CipherMode.ECB;
      aes.Key = bytes1;
      byte[] inArray = aes.CreateEncryptor().TransformFinalBlock(bytes2, 0, bytes2.Length);
      return Convert.ToBase64String(inArray, 0, inArray.Length);
    }

    private static JwtHashAlgorithm GetHashAlgorithm(string algorithm)
    {
      if (algorithm == "RS256")
        return JwtHashAlgorithm.RS256;
      if (algorithm == "HS384")
        return JwtHashAlgorithm.HS384;
      if (algorithm != "HS512")
        throw new InvalidOperationException("Algorithm not supported.");
      return JwtHashAlgorithm.HS512;
    }

    public static bool IsUserValid(string plain_password, string encrypt_password)
    {
      bool flag;
      if ((plain_password != "" || plain_password != null) && (encrypt_password != "" || encrypt_password != null))
      {
        encrypt_password = CustomERPApi.Common.Cryptography.Decrypt(encrypt_password);
        flag = !(encrypt_password != plain_password);
      }
      else
        flag = false;
      return flag;
    }

    //public static string JWTDecode(string token)
    //{
    //  return CustomERPApi.Common.Cryptography.Decode(token, CustomERPApi.Common.Cryptography.JWTSecretKey, true);
    //}

    //public static string JWTEncode(object payload)
    //{
    //  return CustomERPApi.Common.Cryptography.Encode(payload, Encoding.UTF8.GetBytes(CustomERPApi.Common.Cryptography.JWTSecretKey), JwtHashAlgorithm.RS256);
    //}
  }
}
