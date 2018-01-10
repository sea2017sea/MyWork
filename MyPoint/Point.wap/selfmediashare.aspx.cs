using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  Newtonsoft.Json;

public partial class selfmediashare : System.Web.UI.Page
{
    public string AuthorSysNo ;

    public QueryAuthorArticleRes res;
    public string author_name = "";
    public int author_id = 0;
    public int article_id = 0;
    public string res_str;
    public string subtitle = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["AuthorSysNo"] != null)
            {
                AuthorSysNo =  Request.QueryString["AuthorSysNo"];
            }
            
            int asNo = 0;
            if (int.TryParse(AuthorSysNo, out asNo))
            {
                SOAPointClient soa = new SOAPointClient();

                res = soa.QueryAuthorArticleReqs(asNo, 1, 30);
                if (res.ArticleEntities != null && res.ArticleEntities.Count > 0)
                {
                    foreach (var item in res.ArticleEntities)
                    {
                        item.Content = "";
                        item.Subtitle = item.Subtitle.Replace("\n", "\\n");
                        subtitle = item.Subtitle;
                    }
                }
                if (res.ArticleEntities != null && res.ArticleEntities.Count > 0)
                {
                    article_id = res.ArticleEntities[0].SortId;
                }
                res_str = JsonConvert.SerializeObject(res);
                res_str = res_str.Replace(":null", ":\"\"");
                author_id = res.AuthorEntity.AuthorSysNo;
                author_name = res.AuthorEntity.AuthorName;
            }

        }
    }
}