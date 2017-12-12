using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using Point.com.Common;
using Point.com.Logging;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;

namespace Point.com.ServiceImplement.ForWxPay
{
    public class ForWxPayImpl : BaseService, IForWxPay
    {
        private static string AppId = "wx285d430c2d379890";                          //账号ID
        private static string mch_id = "1400401502";                                 //商户号
        private static string NotifyUrl = Configurator.NotifyUrl;                    //支付完成回调页面
        private static string SecretKey = "pointcom201708150930000000000000";        //用户名，应用AppSecret

        /// <summary>
        /// 统一下单 预支付交易会话标识
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> GetWxPayRequestData(M_GetWxPayRequestDataReq req)
        {
            var ptcp = new Ptcp<string>();

            //货币类型
            //string feeType = CurrencyType;
            string notifyUrl = NotifyUrl;
            //string lastTime = DateTime.Now.AddHours(24).ToString();

            //微信支付金额为：分
            decimal amount = req.RechargeAmount*100;
            int total_fee = (int) amount;

            if (string.IsNullOrEmpty(AppId))
            {
                var errMsg = string.Format("订单号{0}]商户号不能为空！", req.OrderNo);
                Logger.Write(LoggerLevel.Error, "GetWxPayRequestData", "商户号不能为空", errMsg);

                ptcp.DoResult = "商户号不能为空";
                return ptcp;
            }

            #region  APP支付预处理 统一下单

            //APP支付预处理
            //统一下单
            WxPayData data = new WxPayData();

            if (!string.IsNullOrEmpty(req.GoodsName) && req.GoodsName.Length > 45)
            {
                req.GoodsName = req.GoodsName.Substring(0, 45) + "...";
            }

            data.SetValue("body", req.GoodsName);
            data.SetValue("attach", req.UserId);           //微信原样返回，存入会员ID
            data.SetValue("out_trade_no", req.OrderNo);
            data.SetValue("total_fee", total_fee);
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //data.SetValue("time_expire", lastTime);
            //data.SetValue("goods_tag", "test");//商品标签
            data.SetValue("trade_type", "APP");
            //data.SetValue("openid", info.OpenId);
            data.SetValue("notify_url", notifyUrl); //异步通知notifyUrl

            data.SetValue("appid", AppId); //公众账号ID
            data.SetValue("mch_id", mch_id); //商户号
            data.SetValue("spbill_create_ip", ServiceData.GetClientIP()); //终端ip	  	    
            data.SetValue("nonce_str", WxPayData.GenerateNonceStr()); //随机字符串

            WxPayData result = WxPayData.UnifiedOrder(data, SecretKey);
            if (!result.IsSet("appid") || !result.IsSet("prepay_id") ||
                result.GetValue("prepay_id").ToString() == "")
            {
                string err_code_des = "";
                if (result.GetValue("err_code_des") != null)
                {
                    err_code_des = result.GetValue("err_code_des").ToString();
                }
                else if (result.GetValue("return_msg") != null)
                {
                    err_code_des = result.GetValue("return_msg").ToString();
                }
                else
                {
                    err_code_des = result.ToJson();
                }

                var errMsg = string.Format("订单号{0}]统一下单获取预付单号失败！{1}", req.OrderNo, err_code_des);
                Logger.Write(LoggerLevel.Error, "GetWxPayRequestData", "获取预付单号失败1", errMsg);

                ptcp.DoResult = string.Format("获取预付单号失败，{0}", err_code_des);
                return ptcp;
            }

            WxPayData unifiedOrderResult = result;
            WxPayData jsApiParam = new WxPayData();
            jsApiParam.SetValue("appid", result.GetValue("appid"));
            jsApiParam.SetValue("noncestr", WxPayData.GenerateNonceStr());
            jsApiParam.SetValue("package", "Sign=WXPay");

            jsApiParam.SetValue("partnerid", mch_id);
            jsApiParam.SetValue("prepayid", result.GetValue("prepay_id"));

            jsApiParam.SetValue("timestamp", WxPayData.GenerateTimeStamp());
            jsApiParam.SetValue("sign", jsApiParam.MakeSign(SecretKey));

            var wxJsApiParam = jsApiParam.ToJson();
            if (string.IsNullOrEmpty(wxJsApiParam))
            {
                var errMsg = string.Format("订单号{0}]获取请求报文失败！", req.OrderNo);
                Logger.Write(LoggerLevel.Error, "GetWxPayRequestData", "获取预付单号失败2", errMsg);

                ptcp.DoResult = "获取支付请求报文失败";
                return ptcp;
            }

            ptcp.DoResult = wxJsApiParam;
            ptcp.DoFlag = PtcpState.Success;

            #endregion

            return ptcp;
        }

        /// <summary>
        /// 支付回调，通知
        /// </summary>
        /// <param name="sendData"></param>
        /// <returns></returns>
        public Ptcp<string> WxAsyncNotify(string sendData)
        {
            var ptcp = new Ptcp<string>();

            try
            {
                if (!string.IsNullOrEmpty(sendData))
                {
                    try
                    {
                        //跟踪日志后期去掉
                        Logger.Write(LoggerLevel.Error, "WxAsyncNotify_in", "支付回调进入", sendData);

                        //转换数据格式并验证签名
                        WxPayData data = new WxPayData();
                        data.FromXml(sendData, SecretKey);

                        //检查支付结果中transaction_id是否存在
                        if (!data.IsSet("transaction_id"))
                        {
                            //若transaction_id不存在，则立即返回结果给微信支付后台
                            var res = new WxPayData();
                            res.SetValue("return_code", "FAIL");
                            res.SetValue("return_msg", "支付结果中微信订单号不存在");
                            Logger.Write(LoggerLevel.Error, "WxAsyncNotify", "支付失败", "支付结果中微信订单号不存在！SendData：" + sendData);
                            ptcp.DoResult = "支付结果中微信订单号不存在";
                            return ptcp;
                        }

                        string transaction_id = data.GetValue("transaction_id").ToString();  //微信支付订单号
                        string result_code = data.GetValue("result_code").ToString();        //表示交易SUCCESS/FAIL
                        string return_code = data.GetValue("return_code").ToString();        //此字段是通信标识，非交易标识，交易是否成功需要查看result_code(SUCCESS/FAIL )
                        string return_msg = string.Empty;
                        string attach = data.GetValue("attach").ToString();  //微信支付订单号

                        int userid = Converter.ParseInt(attach, 0);

                        if (data.GetValue("return_msg") != null && data.GetValue("return_msg").ToString() != "")
                        {
                            return_msg = data.GetValue("return_msg").ToString(); //返回信息，如非空，为错误原因 
                        }

                        string time_end = string.Empty;
                        DateTime? dtTime_end = null;
                        if (data.GetValue("time_end") != null && data.GetValue("time_end").ToString() != "")
                        {
                            time_end = data.GetValue("time_end").ToString();//支付完成时间
                            var s = DateTime.ParseExact(time_end, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                            time_end = string.Format("{0:yyyy-MM-dd HH:mm:ss}", s);

                            dtTime_end = Convert.ToDateTime(time_end);
                        }

                        string out_trade_no = data.GetValue("out_trade_no").ToString();//商户系统的订单号，与请求一致
                        string err_code = string.Empty;
                        if (data.GetValue("err_code") != null && data.GetValue("err_code").ToString() != "")
                        {
                            err_code = data.GetValue("err_code").ToString(); //错误返回的信息描述
                        }

                        string err_code_des = string.Empty;
                        if (data.GetValue("err_code_des") != null && data.GetValue("err_code_des").ToString() != "")
                        {
                            err_code_des = data.GetValue("err_code_des").ToString(); //错误返回的信息描述
                        }

                        string total_fee = data.GetValue("total_fee").ToString();    //订单总金额，单位为分
                        decimal total_feeIn = Convert.ToDecimal(total_fee) / 100;    //订单总金额，单位为元

                        if (result_code == "SUCCESS" && return_code == "SUCCESS")
                        {
                            var fbRes = new ForBaseImpl().UpdatePayState(new M_UpdatePayStateReq()
                                {
                                    UserId = userid,
                                    OrderNo = Converter.ParseInt(out_trade_no,0),
                                    RechargeAmount = total_feeIn,
                                    PaymentNumber = transaction_id,
                                    PayTime = dtTime_end,
                                    PayState = 2
                                });
                            if (fbRes.DoFlag == PtcpState.Success)
                            {
                                ptcp.DoResult = "支付成功";
                                return ptcp;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(fbRes.DoResult))
                                {
                                    ptcp.DoResult = fbRes.DoResult;
                                    return ptcp;
                                }

                                ptcp.DoResult = "修改支付状态失败";
                                return ptcp;
                            }
                        }
                        else
                        {
                            string msg = string.Format("app支付接口异步通知失败！合并订单：{0},callBack.SendData：{1}", out_trade_no, sendData);
                            var res = new WxPayData();
                            res.SetValue("return_code", "FAIL");
                            res.SetValue("return_msg", "app支付接口异步通知失败");
                            Logger.Write(LoggerLevel.Error, "WxAsyncNotify", "app支付接口异步通知失败", msg);

                            ptcp.DoResult = "app支付接口异步通知失败";
                            return ptcp;
                        }
                    }
                    catch (Exception ex)
                    {
                        //若签名错误，则立即返回结果给微信支付后台
                        var res = new WxPayData();
                        res.SetValue("return_code", "FAIL");
                        res.SetValue("return_msg", ex.Message);
                        string msg = string.Format("app支付接口异步通知解析数据异常！sendData:【{0}】", ex.Message);
                        Logger.Write(LoggerLevel.Error, "WxAsyncNotify", "app支付接口异步通知解析数据异常", msg);

                        ptcp.DoResult = "app支付接口异步通知解析数据异常";
                        return ptcp;
                    }
                }

                ptcp.DoResult = "app支付接口异步通知参数为空";
                return ptcp;
            }
            catch (Exception ex)
            {
                string msg = string.Format("app支付接口异步通知发生异常！callBack.SendData：{0}，ex：{1}",sendData, ex.ToString());
                Logger.Write(LoggerLevel.Error, "WxAsyncNotify", "异常", msg);

                ptcp.DoResult = "app支付接口异步通知发生异常";
                return ptcp;
            }

            return ptcp;
        }
    }
}
