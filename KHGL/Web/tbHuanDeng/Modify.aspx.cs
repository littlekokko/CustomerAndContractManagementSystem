using System;
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
namespace Maticsoft.Web.tbHuanDeng
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
		Maticsoft.BLL.tbHuanDeng bll=new Maticsoft.BLL.tbHuanDeng();
		Maticsoft.Model.tbHuanDeng model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtHDName.Text=model.HDName;
		this.txtHDEasyContent.Text=model.HDEasyContent;
		this.txtHDContent.Text=model.HDContent;
		this.txtHDImgUrl.Text=model.HDImgUrl;
		this.txtHDLinkUrl.Text=model.HDLinkUrl;
		this.txtFatherId.Text=model.FatherId.ToString();
		this.txtDateTime.Text=model.DateTime.ToString();
		this.txtOrderBy.Text=model.OrderBy.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtHDName.Text.Trim().Length==0)
			{
				strErr+="HDName不能为空！\\n";	
			}
			if(this.txtHDEasyContent.Text.Trim().Length==0)
			{
				strErr+="HDEasyContent不能为空！\\n";	
			}
			if(this.txtHDContent.Text.Trim().Length==0)
			{
				strErr+="HDContent不能为空！\\n";	
			}
			if(this.txtHDImgUrl.Text.Trim().Length==0)
			{
				strErr+="HDImgUrl不能为空！\\n";	
			}
			if(this.txtHDLinkUrl.Text.Trim().Length==0)
			{
				strErr+="HDLinkUrl不能为空！\\n";	
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
			string HDName=this.txtHDName.Text;
			string HDEasyContent=this.txtHDEasyContent.Text;
			string HDContent=this.txtHDContent.Text;
			string HDImgUrl=this.txtHDImgUrl.Text;
			string HDLinkUrl=this.txtHDLinkUrl.Text;
			int FatherId=int.Parse(this.txtFatherId.Text);
			DateTime DateTime=DateTime.Parse(this.txtDateTime.Text);
			int OrderBy=int.Parse(this.txtOrderBy.Text);


			Maticsoft.Model.tbHuanDeng model=new Maticsoft.Model.tbHuanDeng();
			model.id=id;
			model.HDName=HDName;
			model.HDEasyContent=HDEasyContent;
			model.HDContent=HDContent;
			model.HDImgUrl=HDImgUrl;
			model.HDLinkUrl=HDLinkUrl;
			model.FatherId=FatherId;
			model.DateTime=DateTime;
			model.OrderBy=OrderBy;

			Maticsoft.BLL.tbHuanDeng bll=new Maticsoft.BLL.tbHuanDeng();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
