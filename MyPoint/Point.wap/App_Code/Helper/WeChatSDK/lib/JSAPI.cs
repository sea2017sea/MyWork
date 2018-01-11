using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using LitJson;
using WxPayAPI;
using System.Security.Cryptography;
using System.Net;


namespace WxPayAPI
{
    /// <summary>
    /// http://mp.weixin.qq.com/wiki/7/aaa137b55fb2e0456bf8dd9148dd613f.html
    /// 微信JS-SDK使用权限签名算法
    /// </summary>
    public class JSAPI
    {

        public static string getToken()
        {
            var token = "";
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", WxPayConfig.APPID, WxPayConfig.APPSECRET);


            string response = HttpService.Get(url);

            Log.Debug("JSAPI", "Get access_token  url: " + url);
            Log.Debug("JSAPI", "Get access_token : " + response);
            if (response != null)
            {
                try
                {
                    JsonData jd = JsonMapper.ToObject(response);
                    token = (string)jd["access_token"];
                }
                catch { }
            }
            return token;

        }
        public static string GetTickect(string access_token)
        {

            var ticket = "";
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", access_token);


            string response = HttpService.Get(url);

            Log.Debug("JSAPI", "Get jsapi_ticket  url: " + url);
            Log.Debug("JSAPI", "Get jsapi_ticket : " + response);
            if (response != null)
            {
                try
                {
                    JsonData jd = JsonMapper.ToObject(response);
                    ticket = (string)jd["ticket"];
                }
                catch
                {

                }
            }
            return ticket;

        }


        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="noncestr">随机字符串(必须与wx.config中的nonceStr相同)</param>
        /// <param name="timestamp">时间戳(必须与wx.config中的timestamp相同)</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分(必须是调用JS接口页面的完整URL)</param>
        /// <returns></returns>
        public static string GetSignature(string jsapi_ticket, string noncestr, string timestamp, string url, out string string1)
        {
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
                          .Append("noncestr=").Append(noncestr).Append("&")
                          .Append("timestamp=").Append(timestamp).Append("&")
                          .Append("url=").Append(url.IndexOf("#") >= 0 ? url.Substring(0, url.IndexOf("#")) : url);
            string1 = string1Builder.ToString();
            return Sha1(string1);
        }
        public static string Sha1(string orgStr, string encode = "UTF-8")
        {
            var sha1 = new SHA1Managed();
            var sha1bytes = System.Text.Encoding.GetEncoding(encode).GetBytes(orgStr);
            byte[] resultHash = sha1.ComputeHash(sha1bytes);
            string sha1String = BitConverter.ToString(resultHash).ToLower();
            sha1String = sha1String.Replace("-", "");
            return sha1String;
        }

    }
}