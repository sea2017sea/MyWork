using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Common;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;
using Point.com.ServiceModel;

namespace Point.com.Facade
{
    public class MemberDepService : BaseService<IMemberDep>
    {
        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MemberLoginRes Any(MemberLoginReq req)
        {
            var res = new MemberLoginRes();

            try
            {
                var m_req = Mapper.Map<MemberLoginReq, M_MemberLoginReq>(req);
                var ptcp = ServiceImpl.MemberLogin(m_req);

                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int) PtcpState.Success;
                }

                res.DoResult = ptcp.DoResult;
                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.MemberEntity.IsNotNull())
                {
                    res.MemberEntity = Mapper.Map<M_MemberEntity, MemberEntity>(ptcp.ReturnValue.MemberEntity);
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MemberRegisterRes Any(MemberRegisterReq req)
        {
            var res = new MemberRegisterRes();

            try
            {
                var m_req = Mapper.Map<MemberRegisterReq, M_MemberRegisterReq>(req);
                var ptcp = ServiceImpl.MemberRegister(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }
            return res;
        }

        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public QueryMemberInfoRes Any(QueryMemberInfoReq req)
        {
            var res = new QueryMemberInfoRes();

            try
            {
                var m_req = Mapper.Map<QueryMemberInfoReq, M_QueryMemberInfoReq>(req);
                var ptcp = ServiceImpl.QueryMemberInfo(m_req); 
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.MemberEntity.IsNotNull())
                {
                    res.MemberEntity = Mapper.Map<M_MemberEntity, MemberEntity>(ptcp.ReturnValue.MemberEntity);
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据手机号码查询会员信息，主要用于h5分享页面判断当前手机号码是否存在
        /// 如果存在则返回会员ID，不存在返回 false
        /// </summary>
        /// <param name="req"></param>
        /// <returns>DoFlag = 1 则返回 会员ID </returns>
        public QueryMemberInfoByMobileRes Any(QueryMemberInfoByMobileReq req)
        {
            var res = new QueryMemberInfoByMobileRes();

            try
            {
                var ptcp = ServiceImpl.QueryMemberInfoByMobile(req.Mobile);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 更新微信openid
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public UpdateWxOpenidRes Any(UpdateWxOpenidReq req)
        {
            var res = new UpdateWxOpenidRes();

            try
            {
                var ptcp = ServiceImpl.UpdateWxOpenid(req.UserId,req.OpenidWxOpen);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 忘记密码，找回密码
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ForgotPassWordRes Any(ForgotPassWordReq req)
        {
            var res = new ForgotPassWordRes();

            try
            {
                var m_req = Mapper.Map<ForgotPassWordReq, M_ForgotPassWordReq>(req);
                var ptcp = ServiceImpl.ForgotPassWord(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 保存操作日志
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AddOperationLogRes Any(AddOperationLogReq req)
        {
            var res = new AddOperationLogRes();

            try
            {
                var m_req = Mapper.Map<AddOperationLogReq, M_AddOperationLogReq>(req);
                var ptcp = ServiceImpl.AddOperationLog(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 检查会员是否存在
        /// </summary>
        /// <param name="req"></param>
        /// <returns> DoFlag = true 存在，DoFlag = false 不存在 </returns>
        public CheckMemberIsExistRes Any(CheckMemberIsExistReq req)
        {
            var res = new CheckMemberIsExistRes();

            try
            {
                Ptcp<string> ptcp;
                if (req.SelectType == (int) Enums.SelectCustomer.UserId)
                {
                    ptcp = ServiceImpl.CheckMemberIsExist(Enums.SelectCustomer.UserId, req.SelectValue);
                }
                else if (req.SelectType == (int) Enums.SelectCustomer.Mobile)
                {
                    ptcp = ServiceImpl.CheckMemberIsExist(Enums.SelectCustomer.Mobile, req.SelectValue);
                }
                else
                {
                    res.DoResult = "查询类型错误";
                    return res;
                }

                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 查询所有的区域信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryRegionInfoRes Any(QueryRegionInfoReq req)
        {
            var res = new QueryRegionInfoRes();

            try
            {
                var ptcp = ServiceImpl.QueryRegionInfo();
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.Entities.IsHasRow())
                {
                    res.Entities = Mapper.MapperGeneric<M_RegionEntity, RegionEntity>(ptcp.ReturnValue.Entities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 查询所有的区域信息，分好三级的
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryRegionThreeRes Any(QueryRegionThreeReq req)
        {
            var res = new QueryRegionThreeRes();

            try
            {
                var ptcp = ServiceImpl.QueryRegionThree();
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.Entities.IsHasRow())
                {
                    res.Entities = Mapper.MapperGeneric<M_RegionEntity, RegionEntity>(ptcp.ReturnValue.Entities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 修改会员头像
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public UpdateMemberHeadRes Any(UpdateMemberHeadReq req)
        {
            var res = new UpdateMemberHeadRes();

            try
            {
                var m_req = Mapper.Map<UpdateMemberHeadReq, M_UpdateMemberHeadReq>(req);
                var ptcp = ServiceImpl.UpdateMemberHead(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 修改会员昵称
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public UpdateMembereNickNameRes Any(UpdateMembereNickNameReq req)
        {
            var res = new UpdateMembereNickNameRes();

            try
            {
                var m_req = Mapper.Map<UpdateMembereNickNameReq, M_UpdateMembereNickNameReq>(req);
                var ptcp = ServiceImpl.UpdateMembereNickName(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 修改会员性别
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public UpdateMemberSexRes Any(UpdateMemberSexReq req)
        {
            var res = new UpdateMemberSexRes();

            try
            {
                var ptcp = ServiceImpl.UpdateMemberSex(req.UserId,req.Sex);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }
    }
}
