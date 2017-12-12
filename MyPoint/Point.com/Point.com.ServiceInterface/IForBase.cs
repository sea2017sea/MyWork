using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model;
using Point.com.Model.Base;

namespace Point.com.ServiceInterface
{
    public interface IForBase
    {
        /// <summary>
        /// 清空全部缓存
        /// </summary>
        /// <returns></returns>
        Ptcp<string> LocalCacheAll();

        /// <summary>
        /// 保存客户手机上面其他的APP信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> AddApp(M_AddAppReq req);

        /// <summary>
        /// 获取所有的分类信息
        /// </summary>
        /// <returns></returns>
        Ptcp<M_QueryCategoryRes> QueryCategory();

        /// <summary>
        /// 查询交易流水
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryAccountRecordRes> QueryAccountRecord(M_QueryAccountRecordReq req);

        /// <summary>
        /// 保存账号交易流水
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> AddAccountRecord(M_AddAccountRecordReq req);

        /// <summary>
        /// 保存充值记录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        //Ptcp<M_AddRechargeRes> AddRecharge(M_AddRechargeReq req);

        /// <summary>
        /// 发起支付，预下单，构建订单数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_CreatePaymentRes> CreatePayment(M_CreatePaymentReq req);

        /// <summary>
        /// 支付回调，更新订单状态
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> UpdatePayState(M_UpdatePayStateReq req);

        /// <summary>
        /// 查询订单支付状态
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        Ptcp<string> QueryPayState(int userid, int orderNo);

        /// <summary>
        /// 积分转让
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> ScoreTurn(M_ScoreTurnReq req);

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Ptcp<string> MemberWithdrawals(int userid);

        /// <summary>
        /// 保存极光推送的会员ID
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="jiGuangSysNo"></param>
        /// <param name="sourceTypeSysNo"></param>
        /// <returns></returns>
        Ptcp<string> AddJiGuangPush(int userid, string jiGuangSysNo, int sourceTypeSysNo);
    }
}
