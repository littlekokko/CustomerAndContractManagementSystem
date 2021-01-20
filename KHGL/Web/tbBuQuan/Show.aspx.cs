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
namespace Maticsoft.Web.tbBuQuan
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
		Maticsoft.BLL.tbBuQuan bll=new Maticsoft.BLL.tbBuQuan();
		Maticsoft.Model.tbBuQuan model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblBQName.Text=model.BQName;
		this.lblBQContent.Text=model.BQContent;
		this.lblBQImgUrl.Text=model.BQImgUrl;
		this.lblFatherId.Text=model.FatherId.ToString();
		this.lblDateTime.Text=model.DateTime.ToString();
		this.lblOrderBy.Text=model.OrderBy.ToString();

	}


    }
}
