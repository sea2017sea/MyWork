using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Point.com.ServiceModel;
using ServiceStack.ServiceClient.Web;

public partial class Ajax_index : System.Web.UI.Page
{
    private static SOAPointClient soa = new SOAPointClient();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    /// <summary>
    /// 检查会员是否存在 存在返回 会员ID
    /// </summary>
    /// <param name="mobile"></param>
    /// <returns></returns>
    [WebMethod]
    public static string QueryMemberInfoByMobileAjax(string mobile)
    {
        return soa.QueryMemberInfoByMobileReq(mobile);
    }

    /// <summary>
    /// 根据广告(答题)咨询ID获取所有的题目信息
    /// </summary>
    /// <param name="userid">如果存在会员，则必传</param>
    /// <param name="moblie">会员不存在时，的手机号码，必传</param>
    /// <param name="inforSysNo"></param>
    /// <returns></returns>
    [WebMethod]
    public static string QuerySubjectAjax(int userid,string moblie, int inforSysNo)
    {
        if (userid > 0)
        {
            //存在会员时  根据广告(答题)咨询ID获取所有的题目信息
            var res = soa.QuerySubjectReq(userid, inforSysNo);
            if (res.DoFlag == 1 && res.SubjectEntities != null && res.SubjectEntities.Count > 0)
            {
                var sonRes = res.SubjectEntities.Where(c => c.InforSysNo == inforSysNo).ToList();
                QuerySubjectRes qs = new QuerySubjectRes();
                qs.DoFlag = 1;
                qs.DoResult = res.DoResult;
                qs.SubjectEntities = sonRes;
                qs.IsAnswer = res.IsAnswer;
                return JsonConvert.SerializeObject(qs);
            }
        }
        else
        {
            //不存在会员ID时 根据广告(答题)咨询ID获取所有的题目信息
            var res = soa.QueryShareSubjectReq(moblie, inforSysNo);
            if (res.DoFlag == 1 && res.SubjectEntities != null && res.SubjectEntities.Count > 0)
            {
                var sonRes = res.SubjectEntities.Where(c => c.InforSysNo == inforSysNo).ToList();

                QuerySubjectRes qs = new QuerySubjectRes();
                qs.DoFlag = 1;
                qs.DoResult = res.DoResult;
                qs.SubjectEntities = sonRes;
                qs.IsAnswer = res.IsAnswer;
                return JsonConvert.SerializeObject(qs);
            }
        }

        return "";
    }




    /// <summary>
    /// 根据广告(答题)咨询ID获取所有的题目信息
    /// </summary>
    /// <param name="userid">如果存在会员，则必传</param>
    /// <param name="moblie">会员不存在时，的手机号码，必传</param>
    /// <param name="inforSysNo"></param>
    /// <param name="subSonSysNo"></param>
    /// <returns></returns>
    [WebMethod]
    public static string QuerySubjectSonAjax(int userid, string moblie, int inforSysNo,int subSonSysNo)
    {
        if (userid > 0)
        {
            //存在会员时  根据广告(答题)咨询ID获取所有的题目信息
            var res = soa.QuerySubjectReq(userid, inforSysNo);
            if (res.DoFlag == 1 && res.SubjectEntities != null && res.SubjectEntities.Count > 0)
            {
                var sonRes = res.SubjectEntities.Where(c => c.SysNo == subSonSysNo).ToList();

                QuerySubjectRes qs = new QuerySubjectRes();
                qs.DoFlag = 1;
                qs.DoResult = res.DoResult;
                qs.SubjectEntities = sonRes;
                qs.IsAnswer = res.IsAnswer;
                return JsonConvert.SerializeObject(qs);
            }
        }
        else
        {
            //不存在会员ID时 根据广告(答题)咨询ID获取所有的题目信息
            var res = soa.QueryShareSubjectReq(moblie, inforSysNo);

            if (res.DoFlag == 1 && res.SubjectEntities != null && res.SubjectEntities.Count > 0)
            {
                var sonRes = res.SubjectEntities.Where(c => c.SysNo == subSonSysNo).ToList();

                QuerySubjectRes qs = new QuerySubjectRes();
                qs.DoFlag = 1;
                qs.DoResult = res.DoResult;
                qs.SubjectEntities = sonRes;
                qs.IsAnswer = res.IsAnswer;
                return JsonConvert.SerializeObject(qs);
            }
        }

        return "";
    }

    /// <summary>
    /// 保存答题记录
    /// </summary>
    /// <param name="shareUserId">分享人的会员ID 必须</param>
    /// <param name="moblie">手机号码，必传</param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    [WebMethod]
    public static string AddAnswerRecordAjax(int shareUserId, string moblie, string parameter)
    {
        //会员不存在时，保存答题记录
        return soa.AddShareAnswerRecordReq(shareUserId,moblie, parameter);

        //if (userid > 0)
        //{
        //    //存在会员时，保存答题记录
        //    return soa.AddAnswerRecordReq(userid, parameter);
        //}
        //else
        //{
        //    //会员不存在时，保存答题记录
        //    return soa.AddShareAnswerRecordReq(moblie, parameter);
        //}
    }

    /// <summary>
    /// 保存自媒体分享手机号
    /// </summary>
    /// <param name="mobile"></param>
    /// <param name="authID"></param>
    /// <param name="articleID"></param>
    /// <returns></returns>
    [WebMethod]
    public static string SaveSelfMediaShare(string mobile,int authID,int articleID)
    {
        return soa.AddSelfMediaSaveRecordReq(authID, articleID, mobile);
    }

    /// <summary>
    /// 获取问题分享的题目列表
    /// </summary>
    /// <param name="inforSysNo"></param>
    /// <returns></returns>
    [WebMethod]
    public static string QueryShareSubjectReq(int inforSysNo)
    {

        var res = soa.QueryShareSubjectReq("", inforSysNo);
        if (res.DoFlag == 1)
        {
            res.SubjectEntities.RemoveAll(p => p.InforSysNo != inforSysNo);

            return JsonConvert.SerializeObject(res);
        }
        return "";
    }
}