using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.ServiceModel
{
    public class SendPushReq
    {
        public int UserId { get; set; }                      //会员ID 
        public string MsgTitle { get; set; }                 //推送的标题   通知栏展示的标题 不填则会显示应用的名称
        public string MsgAlert { get; set; }                 //推送的alert  通知栏展示的
        public string MsgContent { get; set; }               //推送的消息
    }

    public class SendPushRes : BaseResponse
    {

    }
}
