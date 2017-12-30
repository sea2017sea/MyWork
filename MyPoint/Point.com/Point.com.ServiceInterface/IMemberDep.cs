using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Common;
using Point.com.Model;
using Point.com.Model.Base;

namespace Point.com.ServiceInterface
{
    public interface IMemberDep
    {
        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_MemberLoginRes> MemberLogin(M_MemberLoginReq req);

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_MemberRegisterRes> MemberRegister(M_MemberRegisterReq req);

        /// <summary>
        /// 忘记密码，找回密码
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> ForgotPassWord(M_ForgotPassWordReq req);

        /// <summary>
        /// 更新微信openid
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="openidWxOpen"></param>
        /// <returns></returns>
        Ptcp<string> UpdateWxOpenid(int userid, string openidWxOpen);

        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryMemberInfoRes> QueryMemberInfo(M_QueryMemberInfoReq req);

        /// <summary>
        /// 根据手机号码查询会员信息，主要用于h5分享页面判断当前手机号码是否存在
        /// 如果存在则返回会员ID，不存在返回 false
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        Ptcp<string> QueryMemberInfoByMobile(string mobile);
        
        /// <summary>
        /// 检查会员是否存在
        /// </summary>
        /// <param name="selectCustomer"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Ptcp<string> CheckMemberIsExist(Enums.SelectCustomer selectCustomer, string value);
            
        /// <summary>
        /// 保存操作日志
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> AddOperationLog(M_AddOperationLogReq req);

        /// <summary>
        /// 查询所有的区域信息
        /// </summary>
        /// <returns></returns>
        Ptcp<M_QueryRegionInfoRes> QueryRegionInfo();

        /// <summary>
        /// 查询所有的区域信息，分好三级的
        /// </summary>
        /// <returns></returns>
        Ptcp<M_QueryRegionThreeRes> QueryRegionThree();

        /// <summary>
        /// 修改会员头像
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> UpdateMemberHead(M_UpdateMemberHeadReq req);

        /// <summary>
        /// 修改会员昵称
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> UpdateMembereNickName(M_UpdateMembereNickNameReq req);

        /// <summary>
        /// 修改会员性别
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        Ptcp<string> UpdateMemberSex(int userid, int sex);
    }
}
