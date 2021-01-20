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
namespace Maticsoft.Web.tbBackstageAdmin
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
		Maticsoft.BLL.tbBackstageAdmin bll=new Maticsoft.BLL.tbBackstageAdmin();
		Maticsoft.Model.tbBackstageAdmin model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtUserName.Text=model.UserName.ToString();
		this.txtUserPass.Text=model.UserPass;
		this.txtOrderBy.Text=model.OrderBy.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserPass.Text.Trim().Length==0)
			{
				strErr+="UserPass不能为空！\\n";	
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
			byte[] UserName= new UnicodeEncoding().GetBytes(this.txtUserName.Text);
			string UserPass=this.txtUserPass.Text;
			int OrderBy=int.Parse(this.txtOrderBy.Text);


			Maticsoft.Model.tbBackstageAdmin model=new Maticsoft.Model.tbBackstageAdmin();
			model.id=id;
			model.UserName=UserName;
			model.UserPass=UserPass;
			model.OrderBy=OrderBy;

			Maticsoft.BLL.tbBackstageAdmin bll=new Maticsoft.BLL.tbBackstageAdmin();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
