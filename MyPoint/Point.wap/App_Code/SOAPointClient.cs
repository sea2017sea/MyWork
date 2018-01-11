using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Point.com.ServiceModel;
using ServiceStack.ServiceClient.Web;

/// <summary>
/// SOAPointClient 的摘要说明
/// </summary>
public class SOAPointClient
{
    #region

    //服务地址
    public string PointcomUrl = ConfigurationSettings.AppSettings["PointcomUrl"];

    private JsonServiceClient _pointJsonServiceClient;
    public JsonServiceClient PointJsonServiceClient
    {
        get
        {
            if (null == _pointJsonServiceClient)
            {
                _pointJsonServiceClient = new JsonServiceClient(PointcomUrl);
            }
            return _pointJsonServiceClient;
        }
    }

    #endregion

    public string QueryMemberInfoByMobileReq(string mobile)
    {
        var res = PointJsonServiceClient.Send<QueryMemberInfoByMobileRes>(new QueryMemberInfoByMobileReq()
        {
            Mobile = mobile
        });

        return JsonConvert.SerializeObject(res);
    }

    public QuerySubjectRes QuerySubjectReq(int userid, int inforSysNo)
    {
        var res = PointJsonServiceClient.Send<QuerySubjectRes>(new QuerySubjectReq()
        {
            UserId = userid,
            InforSysNo = inforSysNo
        });

        return res;
    }

    public QueryShareSubjectRes QueryShareSubjectReq(string moblie, int inforSysNo)
    {
        var res = PointJsonServiceClient.Send<QueryShareSubjectRes>(new QueryShareSubjectReq()
        {
            Moblie = moblie,
            InforSysNo = inforSysNo
        });
        return res;
    }

    public string AddAnswerRecordReq(int userid, string parameter)
    {
        var res = PointJsonServiceClient.Send<AddAnswerRecordRes>(new AddAnswerRecordReq()
        {
            UserId = userid,
            Parameter = parameter
        });

        return JsonConvert.SerializeObject(res);
    }

    public string AddShareAnswerRecordReq(int shareUserId,string mobile, string parameter)
    {
        var res = PointJsonServiceClient.Send<AddShareAnswerRecordRes>(new AddShareAnswerRecordReq()
        {
            ShareUserId = shareUserId,
            Mobile = mobile,
            Parameter = parameter
        });

        return JsonConvert.SerializeObject(res);
    }

    public string QueryShareTitleReq(int sysno)
    {
        var res = PointJsonServiceClient.Send<QueryShareTitleRes>(new QueryShareTitleReq()
        {
            SysNo = sysno
        });

        if (res.DoFlag == 1 && !string.IsNullOrEmpty(res.DoResult))
        {
            return res.DoResult;
        }

        return "";
    }


    public QueryAuthorArticleRes QueryAuthorArticleReqs(int _AuthorSysNo, int _PageIndex, int _PageSize)
    {
        var res = PointJsonServiceClient.Send<QueryAuthorArticleRes>(new QueryAuthorArticleReq()
        {
            AuthorSysNo = _AuthorSysNo,
            PageIndex = _PageIndex,
            PageSize = _PageSize,
            UserId = 0
        });
        return res;
    }

    public string AddSelfMediaSaveRecordReq(int authorID,int aiticleID, string mobile)
    {
        var res = PointJsonServiceClient.Send<AddAnswerRecordRes>(new AddSelfMediaSaveRecordReq()
        {
            Mobile = mobile,
            ArticleSysNo = aiticleID,
            AuthorSysNo = authorID
        });

        return JsonConvert.SerializeObject(res);
    }

    //public string QueryShareSubjectReq(int InforSysNo)
    //{
    //    var res = PointJsonServiceClient.Send<QueryShareSubjectRes>(new QueryShareSubjectReq()
    //    {
    //        Mobile = "",
    //        InforSysNo = InforSysNo
    //    });

    //    return JsonConvert.SerializeObject(res);
    //}
}




public class QueryAuthorArticleRes : Point.com.ServiceModel.BaseResponse
{
    public AuthorEntity AuthorEntity { get; set; }       //作者信息
    public int Total { get; set; }                                 //总的数据条数
    public List<ArticleEntity> ArticleEntities { get; set; }     //文章信息
}

public class AuthorEntity
{
    public bool IsFollow { get; set; }        //是否已关注 true 关注, false 未关注
    public int HotArticleCount { get; set; }       //热门文章数量 
    public int NotReadCount { get; set; }  //未读文章数量 用于我的关注里面 >9 显示 9+
    public string StrNotReadCount { get; set; } //未读文章数量 用于我的关注里面  >9 显示 9+
    public string Title { get; set; }              //文章标题       用于我的关注里面
    public int AuthorSysNo { get; set; }           //作者ID
    public string AuthorName { get; set; }         //作者名称
    public string Portrait { get; set; }           //作者头像
    public string Describe { get; set; }  //作者描述信息，如：专注互联网行业资深编辑 
}


public class ArticleEntity
{
    public bool IsRead { get; set; }          //是否可以阅读 true 可以、已付费, false 不可以、未付费
    public decimal ReadScore { get; set; }         //读取所需要的积分
    public int SysNo { get; set; }                 //文章ID
    public string HeadPic { get; set; }            //头图(左右、横排都是这个头图)
    public string Title { get; set; }              //文章标题
    public string Subtitle { get; set; }           //文章副标题
    public string Content { get; set; }            //文章内容
    public DateTime RowCeateDate { get; set; }     //文章创建时间
    public string StrRowCeateDate { get; set; }     //文章创建时间
    public int SortId { get; set; }                //排序，数值越大越靠前
}



public class QueryAuthorArticleReq
{
    public QueryAuthorArticleReq()
    {
    }

    public int AuthorSysNo { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int UserId { get; set; }
}


public class AddSelfMediaSaveRecordReq
{
    public AddSelfMediaSaveRecordReq()
    {
    }
    public string Mobile { get; set; }              //手机号码    必填
    public int AuthorSysNo { get; set; }            //作者ID      必填
    public int ArticleSysNo { get; set; }           //作者文章ID  必填
}





//public class QueryShareSubjectRes : BaseResponse
//{
//    public int IsAnswer { get; set; }      //是否已经回答过了，0 未回答  1 已回答
//    public List<SubjectEntity> SubjectEntities { get; set; }       //题目
//}

//public class SubjectEntity
//{
//    public int SysNo { get; set; }                          //题目ID
//    public int InforSysNo { get; set; }                     //信息ID，当 InforSysNo > 0 时说明是广告的一级题目；InforSysNo = 0时，说明是由题目答案引发的题目
//    public string ProblemNameUrl { get; set; }              //题目，一个图片地址
//    public decimal AnswerMoney { get; set; }                //答题金额
//    public string StrAnswerMoney { get; set; }              //答题金额
//    public List<AnswerEntity> AnswerEntities { get; set; }    //答案
//}






public class AnswerEntity
{
    public int SysNo { get; set; }                      //答案ID
    public int SubSysNo { get; set; }                   //题目ID
    public int ChildrenSubSysNo { get; set; }           //当前答案关联的题目ID
    public string AnswerNameUrl { get; set; }           //答案，一个图片地址
}

/// <summary>
/// H5 自定义分享签名结构体
/// </summary>
public class ShareConfigContract
{
    public string appid { get; set; }

    public string timestamp { get; set; }

    public string nonceStr { get; set; }

    public string signture { get; set; }
}