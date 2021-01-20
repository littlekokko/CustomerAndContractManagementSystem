using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WebApplication1.api;
using WxPayAPI;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlipayAction("1");
        }

        /// <summary>
        /// 微信支付回调处理
        /// </summary>
        /// <param name="ly"></param>
        private void AlipayAction(string ly)
        {
            //接收从微信后台POST过来的数据
            //System.IO.Stream s = HttpContext.Request.InputStream;
            System.IO.Stream s = System.Web.HttpContext.Current.Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            XmlDocument xd = new XmlDocument();
            string no = "";

            DataSet ds = new DataSet();
            StringReader stram = new StringReader(builder.ToString());
            WriteLog(builder.ToString());
            //StringReader stram = new StringReader("<xml><appid><![CDATA[wx23a3fb72006d54cb]]></appid><attach><![CDATA[代拿服务]]></attach><bank_type><![CDATA[OTHERS]]></bank_type><cash_fee><![CDATA[1]]></cash_fee><fee_type><![CDATA[CNY]]></fee_type><is_subscribe><![CDATA[N]]></is_subscribe><mch_id><![CDATA[1563001541]]></mch_id><nonce_str><![CDATA[d21925482d0b46debd6fde94c91d8b49]]></nonce_str><openid><![CDATA[o-vAg5eabWjq7zTY98nTLY8f9eB8]]></openid><out_trade_no><![CDATA[20200503145241557733]]></out_trade_no><result_code><![CDATA[SUCCESS]]></result_code><return_code><![CDATA[SUCCESS]]></return_code><sign><![CDATA[9C5A8D25A1264DBA39435DFE8FFF75DF]]></sign><time_end><![CDATA[20200503145302]]></time_end><total_fee>1</total_fee><trade_type><![CDATA[JSAPI]]></trade_type><transaction_id><![CDATA[4200000562202005038283179768]]></transaction_id></xml>");
            XmlTextReader reader = new XmlTextReader(stram);
            ds.ReadXml(reader);
            no = ds.Tables[0].Rows[0]["out_trade_no"].ToString();

            #region 添加服务

            //修改订单状态
            //cxkj.BLL.tb_order bll_o = new cxkj.BLL.tb_order();
            //cxkj.Model.tb_order info_o = new cxkj.Model.tb_order();
            //info_o = bll_o.GetModel(no);

            //判断订单状态是否是未支付
            //if (info_o.o_State == 1)
            //{
            //    //获取获取服务项目表
            //    //服务项目表
            //    //cxkj.BLL.tb_serviceProducts bll_sp = new cxkj.BLL.tb_serviceProducts();

            //    //通过订单表获取产品ID
            //    cxkj.Model.tb_serviceProducts info_sp = bll_sp.GetModel(Convert.ToInt32(info_o.p_ID));

            //    //服务项目ID赋值
            //    string[] arr_pid = info_sp.p_Service.Split(',');

            //    //服务内容
            //    cxkj.BLL.tb_service bll_s = new cxkj.BLL.tb_service();
            //    cxkj.Model.tb_service info_s = new cxkj.Model.tb_service();

            //    //我的服务
            //    cxkj.BLL.tb_wdfw bll_wdfw = new cxkj.BLL.tb_wdfw();
            //    cxkj.Model.tb_wdfw info_wdfw = new cxkj.Model.tb_wdfw();
            //    for (int i = 0; i < arr_pid.Length; i++)
            //    {
            //        //获取服务内容
            //        info_s = bll_s.GetModel(Convert.ToInt32(arr_pid[i]));

            //        //插入我的服务
            //        info_wdfw.s_ID = info_s.ID;
            //        info_wdfw.openID = info_o.o_openID;
            //        info_wdfw.s_Name = info_s.service_Name;
            //        wdfwController wdfw = new wdfwController();
            //        wdfw.Save(info_wdfw);
            //        //更改订单状态
            //        info_o.o_State = 2;
            //        bll_o.Update(info_o);
            //    }

                #endregion

            //}

            WxPayData resultInfo = new WxPayData();
            resultInfo.SetValue("return_code", "SUCCESS");
            resultInfo.SetValue("return_msg", "OK");
            Response.Write(resultInfo.ToXml());
            Response.End();
        }

        /// <summary>
        /// 简单的写Log方法
        /// </summary>
        /// <param name="strLogInfo"></param>
        public void WriteLog(string strLogInfo)
        {
            string fileName = @"C:\Log\logtest.txt";
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(strLogInfo);
                sw.WriteLine("--------------------------");
                sw.Flush();
                sw.Close();
            }
        }
    }
}