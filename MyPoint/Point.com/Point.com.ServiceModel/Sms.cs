using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.ServiceModel.Base;

namespace Point.com.ServiceModel
{
    public class SendSmsReq:BaseModel
    {
        public string Mobile { get; set; }    //手机号码
        public int SmsType { get; set; }      //发送的短信类型，1 注册 2 登录 4密码找回   
    }

    public class SendSmsRes:BaseResponse
    {
    }
}
