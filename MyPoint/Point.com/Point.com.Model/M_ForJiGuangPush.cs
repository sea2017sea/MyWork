using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Model
{
    public class M_SendPushReq
    {
        public int UserId { get; set; }                      //会员ID
        //public int SourceTypeSysNo { get; set; }             //来源渠道 1 安卓   2 IOS
        public string MsgTitle { get; set; }                 //推送的标题   通知栏展示的标题 不填则会显示应用的名称
        public string MsgAlert { get; set; }                 //推送的alert  通知栏展示的
        public string MsgContent { get; set; }               //推送的消息
    }
}
