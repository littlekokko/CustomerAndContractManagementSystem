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
namespace Maticsoft.Web.tbJianJie
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
		Maticsoft.BLL.tbJianJie bll=new Maticsoft.BLL.tbJianJie();
		Maticsoft.Model.tbJianJie model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtJJName.Text=model.JJName;
		this.txtJJEasyContent.Text=model.JJEasyContent;
		this.txtJJContent.Text=model.JJContent;
		this.txtJJImgUrl.Text=model.JJImgUrl.ToString();
		this.txtFatherId.Text=model.FatherId.ToString();
		this.txtDateTime.Text=model.DateTime.ToString();
		this.txtOrderBy.Text=model.OrderBy.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtJJName.Text.Trim().Length==0)
			{
				strErr+="JJName不能为空！\\n";	
			}
			if(this.txtJJEasyContent.Text.Trim().Length==0)
			{
				strErr+="JJEasyContent不能为空！\\n";	
			}
			if(this.txtJJContent.Text.Trim().Length==0)
			{
				strErr+="JJContent不能为空！\\n";	
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
			string JJName=this.txtJJName.Text;
			string JJEasyContent=this.txtJJEasyContent.Text;
			string JJContent=this.txtJJContent.Text;
			byte[] JJImgUrl= new UnicodeEncoding().GetBytes(this.txtJJImgUrl.Text);
			int FatherId=int.Parse(this.txtFatherId.Text);
			DateTime DateTime=DateTime.Parse(this.txtDateTime.Text);
			int OrderBy=int.Parse(this.txtOrderBy.Text);


			Maticsoft.Model.tbJianJie model=new Maticsoft.Model.tbJianJie();
			model.id=id;
			model.JJName=JJName;
			model.JJEasyContent=JJEasyContent;
			model.JJContent=JJContent;
			model.JJImgUrl=JJImgUrl;
			model.FatherId=FatherId;
			model.DateTime=DateTime;
			model.OrderBy=OrderBy;

			Maticsoft.BLL.tbJianJie bll=new Maticsoft.BLL.tbJianJie();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
