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
namespace Maticsoft.Web.tbBuQuan
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
		Maticsoft.BLL.tbBuQuan bll=new Maticsoft.BLL.tbBuQuan();
		Maticsoft.Model.tbBuQuan model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtBQName.Text=model.BQName;
		this.txtBQContent.Text=model.BQContent;
		this.txtBQImgUrl.Text=model.BQImgUrl;
		this.txtFatherId.Text=model.FatherId.ToString();
		this.txtDateTime.Text=model.DateTime.ToString();
		this.txtOrderBy.Text=model.OrderBy.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBQName.Text.Trim().Length==0)
			{
				strErr+="BQName不能为空！\\n";	
			}
			if(this.txtBQContent.Text.Trim().Length==0)
			{
				strErr+="BQContent不能为空！\\n";	
			}
			if(this.txtBQImgUrl.Text.Trim().Length==0)
			{
				strErr+="BQImgUrl不能为空！\\n";	
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
			string BQName=this.txtBQName.Text;
			string BQContent=this.txtBQContent.Text;
			string BQImgUrl=this.txtBQImgUrl.Text;
			int FatherId=int.Parse(this.txtFatherId.Text);
			DateTime DateTime=DateTime.Parse(this.txtDateTime.Text);
			int OrderBy=int.Parse(this.txtOrderBy.Text);


			Maticsoft.Model.tbBuQuan model=new Maticsoft.Model.tbBuQuan();
			model.id=id;
			model.BQName=BQName;
			model.BQContent=BQContent;
			model.BQImgUrl=BQImgUrl;
			model.FatherId=FatherId;
			model.DateTime=DateTime;
			model.OrderBy=OrderBy;

			Maticsoft.BLL.tbBuQuan bll=new Maticsoft.BLL.tbBuQuan();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
