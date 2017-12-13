using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Model
{
    public class M_QueryArticleByIdReq
    {
        public int UserId { get; set; }               //会员ID，如是已登录状态，则必须传，否则给 0
        public int ArticleSysNo { get; set; }         //文章ID,必传
    }

    public class M_QueryArticleByIdRes
    {
        public M_ArticleEntity ArticleEntity { get; set; }     //文章信息
        public M_AuthorEntity AuthorEntity { get; set; }       //作者信息
    }
    
    public class M_QueryArticleReadByIdReq
    {
        public int ArticleSysNo { get; set; }         //文章ID,必传
    }

    public class M_QueryArticleReadByIdRes
    {
        public M_ArticleEntity ArticleEntity { get; set; }     //文章信息
        public M_AuthorEntity AuthorEntity { get; set; }       //作者信息
    }

    public class M_ArticleEntity
    {
        public bool IsRead { get; set; }               //是否可以阅读 true 可以、已付费, false 不可以、未付费
        public decimal ReadScore { get; set; }         //读取所需要的积分

        public int SysNo { get; set; }                 //文章ID
        public string HeadPic { get; set; }            //头图(左右、横排都是这个头图)
        public string Title { get; set; }              //文章标题
        public string Subtitle { get; set; }           //文章副标题
        public string Content { get; set; }            //文章内容

        public DateTime RowCeateDate { get; set; }     //文章创建时间
        public string StrRowCeateDate { get; set; }     //文章创建时间

        //public DateTime StartDateTime { get; set; }    //文件有效开始时间
        //public DateTime EndDateTime { get; set; }      //文章有效结束时间
        public int SortId { get; set; }                //排序，数值越大越靠前
    }

    public class M_AuthorEntity
    {
        public bool IsFollow { get; set; }             //是否已关注 true 关注, false 未关注
        public int HotArticleCount { get; set; }       //热门文章数量 

        public int NotReadCount { get; set; }                //未读文章数量   用于我的关注里面  >9 显示 9+
        public string StrNotReadCount { get; set; }          //未读文章数量   用于我的关注里面  >9 显示 9+
        public string Title { get; set; }                    //文章标题       用于我的关注里面

        public int AuthorSysNo { get; set; }           //作者ID
        public string AuthorName { get; set; }         //作者名称
        public string Portrait { get; set; }           //作者头像
        public string Describe { get; set; }           //作者描述信息，如：专注互联网行业资深编辑 
    }

    public class M_QueryAuthorArticleReq
    {
        public int UserId { get; set; }               //会员ID，如是已登录状态，则必须传，否则给 0
        public int AuthorSysNo { get; set; }           //作者ID

        public int PageIndex { get; set; }   //第几页
        public int PageSize { get; set; }    //每页大小
    }

    public class M_QueryAuthorArticleRes
    {
        public M_AuthorEntity AuthorEntity { get; set; }       //作者信息

        public List<M_ArticleEntity> ArticleEntities { get; set; }     //文章信息
        public int Total { get; set; }                                 //总的数据条数
    }

    public class M_SetFollowReq
    {
        public int UserId { get; set; }                //会员ID
        public int AuthorSysNo { get; set; }           //作者ID
        public bool IsFollow { get; set; }             //true 关注     false 取消关注
    }

    public class M_QueryMyFollowReq
    {
        public int UserId { get; set; }                //会员ID
    }

    public class M_QueryMyFollowRes
    {
        public List<M_AuthorEntity> AuthorEntities { get; set; }   //作者信息
    }

    public class M_PayReadReq
    {
        public int UserId { get; set; }                     //会员ID
        public int ArticleSysNo { get; set; }               //文章ID
    }

    public class M_QueryHomePageRedDotReq
    {
        public int UserId { get; set; }                     //会员ID
    }

    public class M_QueryHomePageRedDotRes
    {
        public int RedCount { get; set; }                  //红点数量，> 0 UI则需要展示 
    }
}
