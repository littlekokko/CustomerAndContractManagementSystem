using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace WebApplication1.api
{
    public class PublicController : ApiController
    {
        #region 公共接口

        #region 上传图片
        [HttpPost]
        public HttpResponseMessage uploadP()
        {
            HttpResponseMessage result;
            dynamic o;
            string base64Str = "";

            //原密码
            if (HttpContext.Current.Request.Form["base64Str"] != null)
            {
                base64Str = HttpContext.Current.Request.Form["base64Str"].ToString();
            }

            string str = HttpUtility.HtmlDecode(base64Str);
            str = str.Replace("[", "").Replace("]", "");
            string savePath = "/uploadfiles/img/";
            string picture = "";
            string dirPath = "D:/客户管理系统/KHGL/WebApplication1" + savePath;
            string[] base64Strs = str.Split(',');

            try
            {
                for (int i = 0; i < base64Strs.Length; i++)
                {
                    if (i != 0)
                    {
                        picture = picture + ",";
                    }
                    byte[] myByte;
                    myByte = Convert.FromBase64String(base64Strs[i]);
                    Random ran = new Random(Guid.NewGuid().GetHashCode());
                    int ranNum = ran.Next(1000, 9999);
                    string newFileName = ranNum + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + ".jpg";
                    string path = dirPath + newFileName;
                    System.IO.File.WriteAllBytes(path, myByte);
                    picture = picture + savePath + newFileName;

                }
                o = new { success = true, picture = picture };
                string json = JsonConvert.SerializeObject(o);
                result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }
            catch (Exception ex)
            {
                o = new { success = false, errorMsg = ex.Message };
                string json = JsonConvert.SerializeObject(o);
                result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }

        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddNEWCocahClass()
        {
            //WriteLog("AddNEWCocahClass");
            HttpResponseMessage result;
            dynamic o = new { success = true };
            try
            {
                HttpPostedFile file = HttpContext.Current.Request.Files["file"];
                #region 保存图片
                string virtualPath = "/uploadfiles/img/";
                string path = HttpContext.Current.Server.MapPath(virtualPath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Bitmap bmp = new Bitmap(file.InputStream);
                Bitmap newbmp = new Bitmap(bmp);
                Random ran = new Random(Guid.NewGuid().GetHashCode());
                int ranNum = ran.Next(1000, 9999);
                string fileName = ranNum + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + ".jpg";
                newbmp.Save(path + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                #endregion
                o = new { success = true, picture = virtualPath + fileName };
                string json = JsonConvert.SerializeObject(o);
                result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }
            catch (Exception ex)
            {
                //WriteLog(ex.Message);
                string json = JsonConvert.SerializeObject(ex.Message);
                result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }
        }

        [HttpPost]
        public string upNews()
        {
            string end = "{\"code\": 1,\"msg\": \"服务器故障\",\"data\": {\"src\": \"\"}}"; //返回的json

            string base64Str = "";
            //数据流
            if (HttpContext.Current.Request.Form["base64Str"] != null)
            {
                base64Str = HttpContext.Current.Request.Form["base64Str"].ToString();
            }

            var file = HttpContext.Current.Request.Files[0]; //获取选中文件
            Stream stream = file.InputStream;    //将文件转为流

            Image img = Image.FromStream(stream);//将流中的图片转换为Image图片对象

            Random ran = new Random((int)DateTime.Now.Ticks);//利用时间种子解决伪随机数短时间重复问题

            //文件保存位置及命名，精确到毫秒并附带一组随机数，防止文件重名，数据库保存路径为此变量
            string serverPath = "/uploadfiles/img/" + DateTime.Now.ToString("yyyyMMddhhmmssms") + ran.Next(99999) + ".jpg";

            //路径映射为绝对路径
            string path = HttpContext.Current.Server.MapPath(serverPath);

            //赋值成网络绝对路径
            string serverPath1 = "http://localhost:2000" + serverPath;


            try
            {
                img.Save(path, ImageFormat.Jpeg);//图片保存，JPEG格式图片较小

                //保存成功后的json
                end = "{\"code\": 0,\"msg\": \"成功\",\"data\": {\"src\": \"" + serverPath + "\"}}";

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(end);//输出结果
                HttpContext.Current.Response.End();
            }

            return end;
        }


        [HttpPost]
        public string upNewsPic()
        {
            string end = "{\"code\": 1,\"msg\": \"服务器故障\",\"data\": {\"src\": \"\"}}"; //返回的json

            string base64Str = "";
            //数据流
            if (HttpContext.Current.Request.Form["base64Str"] != null)
            {
                base64Str = HttpContext.Current.Request.Form["base64Str"].ToString();
            }

            var file = HttpContext.Current.Request.Files[0]; //获取选中文件
            Stream stream = file.InputStream;    //将文件转为流

            Image img = Image.FromStream(stream);//将流中的图片转换为Image图片对象

            Random ran = new Random((int)DateTime.Now.Ticks);//利用时间种子解决伪随机数短时间重复问题

            //文件保存位置及命名，精确到毫秒并附带一组随机数，防止文件重名，数据库保存路径为此变量
            string serverPath = "/uploadfiles/img/" + DateTime.Now.ToString("yyyyMMddhhmmssms") + ran.Next(99999) + ".jpg";

            //路径映射为绝对路径
            string path = HttpContext.Current.Server.MapPath(serverPath);

            //赋值成网络绝对路径
            string serverPath1 = "http://localhost:2000" + serverPath;


            try
            {
                img.Save(path, ImageFormat.Jpeg);//图片保存，JPEG格式图片较小

                //保存成功后的json
                end = "{\"code\": 0,\"msg\": \"成功\",\"data\": {\"src\": \"" + serverPath1 + "\"}}";

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(end);//输出结果
                HttpContext.Current.Response.End();
            }

            return end;
        }
        #endregion


        #region 上传文件
        [HttpPost]
        public string upload_WjP()
        {
            string end = "{\"code\": 1,\"msg\": \"服务器故障\",\"data\": {\"src\": \"\"}}"; //返回的json


            var file = HttpContext.Current.Request.Files[0]; //获取选中文件

            string exName = System.IO.Path.GetExtension(file.FileName); //得到扩展名

            Random ran = new Random((int)DateTime.Now.Ticks);//利用时间种子解决伪随机数短时间重复问题

            //文件保存位置及命名，精确到毫秒并附带一组随机数，防止文件重名，数据库保存路径为此变量
            string serverPath = "/upload/" + DateTime.Now.ToString("yyyyMMddhhmmssms") + ran.Next(99999) + exName;

            //路径映射为绝对路径
            string path = HttpContext.Current.Server.MapPath(serverPath);

            //赋值成网络绝对路径
            serverPath = "http://localhost:2000" + serverPath;


            try
            {
                file.SaveAs(path);

                //保存成功后的json
                end = "{\"code\": 0,\"msg\": \"成功\",\"data\": {\"src\": \"" + serverPath + "\"}}";

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(end);//输出结果
                HttpContext.Current.Response.End();
            }


            return end;

        }

        #endregion

        #region 上传视频

        /// <summary>
        /// 上传视频
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Addshipin()
        {
            //WriteLog("AddNEWCocahClass");
            HttpResponseMessage result;
            dynamic o = new { success = true };
            try
            {
                HttpPostedFile aa = HttpContext.Current.Request.Files["file"];
                string sFileName = aa.FileName;
                string exName = System.IO.Path.GetExtension(sFileName); //得到扩展名
                #region 保存图片
                string virtualPath = "/uploadfiles/video/";
                string path = HttpContext.Current.Server.MapPath(virtualPath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //string[] array = sFileName.Split('.');
                //Bitmap bmp = new Bitmap(file.InputStream);
                //Bitmap newbmp = new Bitmap(bmp, 300, 300);
                Random ran = new Random(Guid.NewGuid().GetHashCode());
                int ranNum = ran.Next(1000, 9999);
                string fileName = ranNum + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + exName;
                aa.SaveAs(path + fileName);
                //newbmp.Save(path + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                #endregion
                o = new { success = true, picture = virtualPath + fileName };
                string json = JsonConvert.SerializeObject(o);
                result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }
            catch (Exception ex)
            {
                //WriteLog(ex.Message);
                string json = JsonConvert.SerializeObject(ex.Message);
                result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }
        }



        /// <summary>
        /// 上传视频
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Addshipin111(string file)
        {
            //WriteLog("AddNEWCocahClass");
            HttpResponseMessage result;
            dynamic o = new { success = true };
            try
            {
                var aa = HttpContext.Current.Request.Files[0];
                string sFileName = file;
                string exName = System.IO.Path.GetExtension(sFileName); //得到扩展名
                #region 保存图片
                string virtualPath = "/uploadfiles/video/";
                string path = HttpContext.Current.Server.MapPath(virtualPath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //string[] array = sFileName.Split('.');
                //Bitmap bmp = new Bitmap(file.InputStream);
                //Bitmap newbmp = new Bitmap(bmp, 300, 300);
                Random ran = new Random(Guid.NewGuid().GetHashCode());
                int ranNum = ran.Next(1000, 9999);
                string fileName = ranNum + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + exName;
                aa.SaveAs(path + fileName);
                //newbmp.Save(path + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                #endregion
                o = new { success = true, picture = virtualPath + fileName };
                string json = JsonConvert.SerializeObject(o);
                result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }
            catch (Exception ex)
            {
                //WriteLog(ex.Message);
                string json = JsonConvert.SerializeObject(ex.Message);
                result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }
        }
        #endregion
        #endregion

        #region 生成随机数
        /// <summary>
        /// 生成随机字母与数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <returns></returns>
        public string StrRandom(int Length, bool Sleep)
        {
            if (Sleep) System.Threading.Thread.Sleep(3);
            char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }
        #endregion
    }
}
