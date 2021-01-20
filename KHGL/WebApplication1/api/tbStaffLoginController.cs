using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using Newtonsoft.Json.Linq;
using Codeplex.Data;
using System.Web.Security;

namespace WebApplication1.api
{
    public class tbStaffLoginController : ApiController
    {
        #region 用户表

        #region 声明变量
        Maticsoft.BLL.tbStaffLogin BLL = new Maticsoft.BLL.tbStaffLogin();
        Maticsoft.Model.tbStaffLogin Model = new Maticsoft.Model.tbStaffLogin();
        #endregion

        #region 验证用户名密码
        /// <summary>
        /// 获取列表
        /// </summary>
        ///<param name="FatherId">父ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Exists(string StaffName, string StaffPassword)
        {
            HttpResponseMessage result;
            dynamic o = new { success = true };

            try
            {
                if (StaffName != "" && StaffPassword != "")
                {
                    //验证用户名密码
                    if (!BLL.Exists(StaffName, StaffPassword))
                    {
                        throw new Exception("用户名密码错误！！！");
                    }
                }
                else
                {
                    throw new Exception("用户名密码不可为空！！！");
                }

                o = new { success = true };
            }
            catch (Exception ex)
            {
                o = new { errorMsg = ex.Message };
            }

            string json = JsonConvert.SerializeObject(o);
            result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }
        #endregion

        #region 获取列表所有
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetList()
        {
            HttpResponseMessage result;
            string json;

            try
            {
                DataSet ds = BLL.GetList(1000, "  1 = 1 ", "ID");
                dynamic o = new { success = true, rows = ds };
                json = JsonConvert.SerializeObject(o);
            }
            catch (Exception ex)
            {
                object o = new { errorMsg = ex.Message };
                json = JsonConvert.SerializeObject(o);
            }

            result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }
        #endregion

        #region 获取列表分页
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetListFenYe(int rows, int page)
        {
            HttpResponseMessage result;
            string json;

            try
            {

                int countMax = BLL.GetRecordCount("is_del=1");
                int rownumber = rows * (page - 1) + 1;

                if (countMax >= rows)
                {
                    if (countMax % rows == 0)
                    {
                        countMax = countMax / rows;
                    }
                    else
                    {
                        countMax = countMax / rows + 1;
                    }
                }
                else
                {
                    countMax = 1;
                }

                DataSet list = BLL.GetListByPage("is_del=1", "DateTime", rownumber, (rownumber + rows) - 1);

                dynamic o = new { success = true, rows = list, countMax = countMax };
                json = JsonConvert.SerializeObject(o);
            }
            catch (Exception ex)
            {
                object o = new { errorMsg = ex.Message };
                json = JsonConvert.SerializeObject(o);
            }

            result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }
        #endregion        

        #region 获取内容
        /// <summary>
        /// 查询(通过ID)
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDetails(int id)
        {
            string serviceUrl = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["http_host"]);
            HttpResponseMessage result;
            string json;

            try
            {
                Model = BLL.GetModel(id);
                dynamic o = new { success = true, rows = Model };
                json = JsonConvert.SerializeObject(o);
            }
            catch (Exception ex)
            {
                object o = new { errorMsg = ex.Message };
                json = JsonConvert.SerializeObject(o);
            }

            result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }
        #endregion

        #region 添加修改

        /// <summary>
        /// 添加/修改
        /// </summary>
        /// <param name="info">实体类</param>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Save(Maticsoft.Model.tbStaffLogin info)
        {
            HttpResponseMessage result;
            dynamic o = new { success = true };

            try
            {
                if (BLL.Exists(info.id))
                {
                    Maticsoft.Model.tbStaffLogin info1 = (Maticsoft.Model.tbStaffLogin)BLL.GetModel(info.id);

                    //给实体类赋值修改
                    info1 = Maticsoft.Common.OperationInfo.BindModelValue(info1, info);
                    BLL.Update(info1);
                }
                else
                {
                    //赋值默认值
                    info.DateTime = Convert.ToDateTime(DateTime.Now.ToString());
                    BLL.Add(info);
                }

                o = new { success = true };
            }
            catch (Exception ex)
            {
                o = new { errorMsg = ex.Message };
            }

            string json = JsonConvert.SerializeObject(o);
            result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage result;
            dynamic o = new { success = true };

            try
            {
                if (id > 0)
                {
                    BLL.Delete(id);
                }
                else
                {
                    throw new Exception("删除异常！！！");
                }

                o = new { success = true };
            }
            catch (Exception ex)
            {
                o = new { errorMsg = ex.Message };
            }

            string json = JsonConvert.SerializeObject(o);
            result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }

        #endregion

        #region 批量删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteList(string idlist)
        {
            HttpResponseMessage result;
            dynamic o = new { success = true };

            try
            {
                if (idlist.Length > 0)
                {
                    BLL.DeleteList(idlist);
                }
                else
                {
                    throw new Exception("删除异常！！！");
                }

                o = new { success = true };
            }
            catch (Exception ex)
            {
                o = new { errorMsg = ex.Message };
            }

            string json = JsonConvert.SerializeObject(o);
            result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }

        #endregion

        #region 获取微信分享授权地址

        /// <summary>
        /// 获取微信分享授权地址
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getWx(string url)
        {
            long timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

            string noncestr = CreatenNonce_str();

            string jsapi_ticket = GetAccessToken();
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
                          .Append("noncestr=").Append(noncestr).Append("&")
                          .Append("timestamp=").Append(timestamp).Append("&")
                          .Append("url=").Append(url.IndexOf("#") >= 0 ? url.Substring(0, url.IndexOf("#")) : url);
            string string1 = string1Builder.ToString();

            string signature = FormsAuthentication.HashPasswordForStoringInConfigFile(string1, "SHA1");

            string json;
            //object o = new { appId = "wx5fc908f9f0980f3b", timestamp = timestamp, nonceStr = noncestr, signature = signature };
            object o = new { appId = "wx4c0ca98bcd3fee4a", timestamp = timestamp, nonceStr = noncestr, signature = signature };
            json = JsonConvert.SerializeObject(o);

            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetAccessToken()
        {
            string ticket = "";

            //这里是把数据库存的GetAccessToken取出来
            //IMemberBLL bll = new MemberBLL();
            //DM_WX model = bll.GetWx(1);

            //TimeSpan ts = DateTime.Now - model.WX_DATE;

            //double se = ts.TotalSeconds;

            ////如果存储时间超过6400秒则从服务器取新的
            //if (se > Convert.ToDouble(6400))
            //{
            string grant_type = "client_credential";
            string appid = "wx4c0ca98bcd3fee4a";
            string secret = "e08898fff991c79da8725ad1f8d5d428";
            string tokenUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}", grant_type, appid, secret);
            var wc = new WebClient();
            var strReturn = wc.DownloadString(tokenUrl);
            var jObject = JObject.Parse(strReturn);
            ticket = GetWeiXinJsapi_Ticket(jObject["access_token"].ToString());

            ////取出来的GetAccessToken存储到服务器
            //DM_WX info = new DM_WX();

            //info.WX_ID = 1;
            //info.WX_DATE = DateTime.Now;
            //info.WX_CLOB = ticket;

            //bll.UpdateWx(info);
            //}
            //else
            //{
            //    //如果存储时间没有超过6400秒则用服务器得
            //    ticket = model.WX_CLOB;
            //}

            return ticket;
        }

        /// <summary>
        /// 获取Jsapi_Ticket
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetWeiXinJsapi_Ticket(string accessToken)
        {
            string type = "jsapi";
            string tokenUrl = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type={1}", accessToken, type);
            var wc = new WebClient();
            var strReturn = wc.DownloadString(tokenUrl); //取得微信返回的json数据
            var jObject = JObject.Parse(strReturn);

            return jObject["ticket"].ToString();
        }

        // <summary>
        /// 获取jsapi_ticket
        /// jsapi_ticket是公众号用于调用微信JS接口的临时票据。
        /// 正常情况下，jsapi_ticket的有效期为7200秒，通过access_token来获取。
        /// 由于获取jsapi_ticket的api调用次数非常有限，频繁刷新jsapi_ticket会导致api调用受限，影响自身业务，开发者必须在自己的服务全局缓存jsapi_ticket 。        ///本代码来自开源微信SDK项目：https://github.com/night-king/weixinSDK
        /// </summary>
        /// <param name="access_token">BasicAPI获取的access_token,也可以通过TokenHelper获取</param>
        /// <returns></returns>
        public static dynamic GetTickect(string access_token)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", access_token);
            var client = new HttpClient();
            var result = client.GetAsync(url).Result;
            if (!result.IsSuccessStatusCode) return string.Empty;
            var jsTicket = DynamicJson.Parse(result.Content.ReadAsStringAsync().Result);
            return jsTicket;
        }

        /// <summary>
        /// 创建随机字符串        
        /// </summary>
        /// <returns></returns>
        public string CreatenNonce_str()
        {
            string[] strs = new string[]
                                 {
                                  "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                                  "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
                                 };

            Random r = new Random();
            var sb = new StringBuilder();
            var length = strs.Length;
            for (int i = 0; i < 15; i++)
            {
                sb.Append(strs[r.Next(length - 1)]);
            }
            return sb.ToString();
        }

        #endregion

        #region 获取StaffName
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetStaffName(string StaffName)
        {
            HttpResponseMessage result;
            string json;

            try
            {
                string str = " is_del=1 and StaffName='" + StaffName+"' ";
                DataSet ds = BLL.GetList(1, str, "ID");
                dynamic o = new { success = true, rows = ds };
                json = JsonConvert.SerializeObject(o);
            }
            catch (Exception ex)
            {
                object o = new { errorMsg = ex.Message };
                json = JsonConvert.SerializeObject(o);
            }

            result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }
        #endregion

        #endregion
    }
}
