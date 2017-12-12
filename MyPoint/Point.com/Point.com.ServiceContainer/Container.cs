using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.ServiceImplement;
using Point.com.ServiceImplement.ForJiGuang;
using Point.com.ServiceImplement.ForWxPay;
using Point.com.ServiceInterface;

namespace Point.com.ServiceContainer
{
    internal class Container
    {
        internal static void Configer(IContainer container)
        {
            //会员相关
            container.Register<MemberDepImpl, IMemberDep>(new MemberDepImpl());
            
            //短信相关
            container.Register<SmsImpl, ISms>(new SmsImpl());

            //基础服务
            container.Register<ForBaseImpl, IForBase>(new ForBaseImpl());

            //数据配置
            container.Register<ForInforImpl, IForInfor>(new ForInforImpl());

            //极光推送
            container.Register<ForJiGuangPushImpl, IForJiGuangPush>(new ForJiGuangPushImpl());

            //微信支付
            container.Register<ForWxPayImpl, IForWxPay>(new ForWxPayImpl());
        }
    }
}
