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
/// Summary description for SmsContent
/// </summary>
public class SMSContent
{
    public SMSContent()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    long _id = 0;

    public long Id
    {
        get { return _id; }
        set { _id = value; }
    }
    string _mobile = "";

    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }
    string _senderaddi = "";

    public string Senderaddi
    {
        get { return _senderaddi; }
        set { _senderaddi = value; }
    }
    string _recvaddi = "";

    public string Recvaddi
    {
        get { return _recvaddi; }
        set { _recvaddi = value; }
    }
    string _ct = "";

    public string Ct
    {
        get { return _ct; }
        set { _ct = value; }
    }
    string _sd = "";

    public string Sd
    {
        get { return _sd; }
        set { _sd = value; }
    }
    int _flag = 0;

    public int Flag
    {
        get { return _flag; }
        set { _flag = value; }
    }

}
