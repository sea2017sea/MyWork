using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index_bak : System.Web.UI.Page
{
    public string shareSysNo = "0";
    public string shareUserId = "0";
    public string shareTitle = "参与互动获抵用金";

    private static SOAPointClient soa = new SOAPointClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ShareSysNo"] != null)
            {
                shareSysNo = Request.QueryString["ShareSysNo"];

                shareTitle = soa.QueryShareTitleReq(Convert.ToInt32(shareSysNo));
            }

            if (Request.QueryString["ShareUserId"] != null)
            {
                shareUserId = Request.QueryString["ShareUserId"];
            }
        }
    }
}