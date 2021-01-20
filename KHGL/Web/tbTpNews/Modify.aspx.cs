﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.tbTpNews
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.tbTpNews bll=new Maticsoft.BLL.tbTpNews();
		Maticsoft.Model.tbTpNews model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtTPName.Text=model.TPName;
		this.txtTPEasyContent.Text=model.TPEasyContent;
		this.txtTPContent.Text=model.TPContent;
		this.txtTPImgUrl.Text=model.TPImgUrl;
		this.txtTPBianJi.Text=model.TPBianJi.ToString();
		this.txtTPFuShu1.Text=model.TPFuShu1;
		this.txtisDel.Text=model.isDel.ToString();
		this.txtFatherId.Text=model.FatherId.ToString();
		this.txtDateTime.Text=model.DateTime.ToString();
		this.txtOrderBy.Text=model.OrderBy.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTPName.Text.Trim().Length==0)
			{
				strErr+="TPName不能为空！\\n";	
			}
			if(this.txtTPEasyContent.Text.Trim().Length==0)
			{
				strErr+="TPEasyContent不能为空！\\n";	
			}
			if(this.txtTPContent.Text.Trim().Length==0)
			{
				strErr+="TPContent不能为空！\\n";	
			}
			if(this.txtTPImgUrl.Text.Trim().Length==0)
			{
				strErr+="TPImgUrl不能为空！\\n";	
			}
			if(this.txtTPFuShu1.Text.Trim().Length==0)
			{
				strErr+="TPFuShu1不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtisDel.Text))
			{
				strErr+="isDel格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtFatherId.Text))
			{
				strErr+="FatherId格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtDateTime.Text))
			{
				strErr+="DateTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtOrderBy.Text))
			{
				strErr+="OrderBy格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string TPName=this.txtTPName.Text;
			string TPEasyContent=this.txtTPEasyContent.Text;
			string TPContent=this.txtTPContent.Text;
			string TPImgUrl=this.txtTPImgUrl.Text;
			byte[] TPBianJi= new UnicodeEncoding().GetBytes(this.txtTPBianJi.Text);
			string TPFuShu1=this.txtTPFuShu1.Text;
			int isDel=int.Parse(this.txtisDel.Text);
			int FatherId=int.Parse(this.txtFatherId.Text);
			DateTime DateTime=DateTime.Parse(this.txtDateTime.Text);
			int OrderBy=int.Parse(this.txtOrderBy.Text);


			Maticsoft.Model.tbTpNews model=new Maticsoft.Model.tbTpNews();
			model.id=id;
			model.TPName=TPName;
			model.TPEasyContent=TPEasyContent;
			model.TPContent=TPContent;
			model.TPImgUrl=TPImgUrl;
			model.TPBianJi=TPBianJi;
			model.TPFuShu1=TPFuShu1;
			model.isDel=isDel;
			model.FatherId=FatherId;
			model.DateTime=DateTime;
			model.OrderBy=OrderBy;

			Maticsoft.BLL.tbTpNews bll=new Maticsoft.BLL.tbTpNews();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
