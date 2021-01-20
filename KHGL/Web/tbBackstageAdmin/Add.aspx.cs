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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			byte[] UserName= new UnicodeEncoding().GetBytes(this.txtUserName.Text);
			string UserPass=this.txtUserPass.Text;
			int OrderBy=int.Parse(this.txtOrderBy.Text);

			Maticsoft.Model.tbBackstageAdmin model=new Maticsoft.Model.tbBackstageAdmin();
			model.UserName=UserName;
			model.UserPass=UserPass;
			model.OrderBy=OrderBy;

			Maticsoft.BLL.tbBackstageAdmin bll=new Maticsoft.BLL.tbBackstageAdmin();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
