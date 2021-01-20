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
    public class tbCustomerClassController : ApiController
    {
        #region 用户表

        #region 声明变量
        Maticsoft.BLL.tbCustomerClass BLL = new Maticsoft.BLL.tbCustomerClass();
        Maticsoft.Model.tbCustomerClass Model = new Maticsoft.Model.tbCustomerClass();
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
                DataSet ds = BLL.GetList(1000, "  is_del = 1 ", "CTId");
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

                DataSet list = BLL.GetListByPage("is_del=1", "CTId", rownumber, (rownumber + rows) - 1);

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
        public HttpResponseMessage GetDetails(int CTId)
        {
            string serviceUrl = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["http_host"]);
            HttpResponseMessage result;
            string json;

            try
            {
                Model = BLL.GetModel(CTId);
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
        public HttpResponseMessage Save(Maticsoft.Model.tbCustomerClass info)
        {
            HttpResponseMessage result;
            dynamic o = new { success = true };

            try
            {
                if (BLL.Exists(info.CTId))
                {
                    Maticsoft.Model.tbCustomerClass info1 = (Maticsoft.Model.tbCustomerClass)BLL.GetModel(info.CTId);

                    //给实体类赋值修改
                    info1 = Maticsoft.Common.OperationInfo.BindModelValue(info1, info);
                    BLL.Update(info1);
                }
                else
                {
                    //赋值默认值
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
        public HttpResponseMessage Delete(int CTId)
        {
            HttpResponseMessage result;
            dynamic o = new { success = true };

            try
            {
                if (CTId > 0)
                {
                    BLL.Delete(CTId);
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

        #endregion
    }
}
