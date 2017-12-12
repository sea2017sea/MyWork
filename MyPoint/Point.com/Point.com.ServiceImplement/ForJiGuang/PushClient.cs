using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using cn.jpush.api.common;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;

namespace Point.com.ServiceImplement.ForJiGuang
{
    internal class PushClient : BaseHttpClient
    {
        private const String HOST_NAME_SSL = "https://api.jpush.cn";
        private const String PUSH_PATH = "/v3/push";

        private String appKey = "b733236e851e9a1187ba94b0";
        private String masterSecret = "da995fb388c7609dfa79b46a";

        public PushClient()
        {
            Preconditions.checkArgument(!String.IsNullOrEmpty(appKey), "appKey should be set");
            Preconditions.checkArgument(!String.IsNullOrEmpty(masterSecret), "masterSecret should be set");
        }
        public MessageResult sendPush(PushPayload payload)
        {
            String payloadString = payload.ToJson();

            Preconditions.checkArgument(!string.IsNullOrEmpty(payloadString), "payloadString should not be empty");

            String url = HOST_NAME_SSL;
            url += PUSH_PATH;
            ResponseWrapper result = sendPost(url, Authorization(), payloadString);
            MessageResult messResult = new MessageResult();
            messResult.ResponseResult = result;

            JpushSuccess jpushSuccess = JsonConvert.DeserializeObject<JpushSuccess>(result.responseContent);
            messResult.sendno = long.Parse(jpushSuccess.sendno);
            messResult.msg_id = long.Parse(jpushSuccess.msg_id);

            return messResult;
        }

        private String Authorization()
        {

            Debug.Assert(!string.IsNullOrEmpty(this.appKey));
            Debug.Assert(!string.IsNullOrEmpty(this.masterSecret));

            String origin = this.appKey + ":" + this.masterSecret;
            return Base64.getBase64Encode(origin);
        }

        public PushPayload PushObject_All_All_Alert()
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.android();
            pushPayload.audience = Audience.s_registrationId("1507bfd3f7f0af7925b");

            //Message sms_message = new Message();
            //sms_message.title = "标题";
            //sms_message.msg_content = "内容";

            pushPayload.message = Message.content("标2222题");


            pushPayload.notification = new Notification().setAlert("了开始了减肥收到了快捷方式的浪2222222费");
            
            return pushPayload;
        }
    }
    enum MsgTypeEnum
    {
        NOTIFICATIFY = 1,
        COUSTOM_MESSAGE = 2
    }
}
