using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for SMSReport
/// </summary>
public class SMSReport
{
    public SMSReport()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string seq = "0";
    public string mobile = "";
    public string errorCode = "";
    public string serviceCodeAdd = "";
    public string reportType = "";
    public int flag = 0;
}
