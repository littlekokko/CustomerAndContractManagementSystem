using System;
using System.Collections.Generic;

using System.Text;

   public class Md5Helper
    {
       public static string md5(string str, int code)
       {
           if (code == 16) //16位加密
           {
               return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
           }
           else//32位加密 
           {
               return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
           }
       }
    }
