using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class question : System.Web.UI.Page
{
    public string shareSysNo = "";
    public string shareUserId = "0";
    public string userid = "0";
    public string moblie = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ShareSysNo"] != null)
            {
                shareSysNo = Request.QueryString["ShareSysNo"];
            }

            if (Request.QueryString["ShareUserId"] != null)
            {
                shareUserId = Request.QueryString["ShareUserId"];
            }

            if (Request.QueryString["userid"] != null)
            {
                userid = Request.QueryString["userid"];
            }

            if (Request.QueryString["moblie"] != null)
            {
                moblie = Request.QueryString["moblie"];
            }

            if (Convert.ToInt32(shareUserId) <= 0 || Convert.ToInt32(shareSysNo) <= 0)
            {
                string url = string.Format("index.aspx?ShareSysNo={0}&ShareUserId={1}",shareSysNo,shareUserId);
                Response.Redirect(url);   
            }
        }
    }
}