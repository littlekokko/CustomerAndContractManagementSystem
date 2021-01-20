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
namespace Maticsoft.Web.tbHuanDeng
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.tbHuanDeng bll=new Maticsoft.BLL.tbHuanDeng();
		Maticsoft.Model.tbHuanDeng model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblHDName.Text=model.HDName;
		this.lblHDEasyContent.Text=model.HDEasyContent;
		this.lblHDContent.Text=model.HDContent;
		this.lblHDImgUrl.Text=model.HDImgUrl;
		this.lblHDLinkUrl.Text=model.HDLinkUrl;
		this.lblFatherId.Text=model.FatherId.ToString();
		this.lblDateTime.Text=model.DateTime.ToString();
		this.lblOrderBy.Text=model.OrderBy.ToString();

	}


    }
}
