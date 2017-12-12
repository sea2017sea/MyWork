using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Funq;
using Point.com.Facade;
using Point.com.Logging;
using Point.com.Logging.External;
using ServiceStack.WebHost.Endpoints;

namespace Point.com.Host
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("Point.com Web Service", typeof(INoticeService).Assembly)
        {
            
        }

        public override void Configure(Container container)
        {
            //Permit modern browsers (e.g. Firefox) to allow sending of any REST HTTP Method
            base.SetConfig(new EndpointHostConfig
            {
                GlobalResponseHeaders =
                    {
                        { "Access-Control-Allow-Origin", "*" },
                        { "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
                    },
            });

            //请求过滤器
            this.RequestFilters.Add((req, res, reqDto) =>
            {
                //验证权限 

                //记录来源ip，时间，原始内容
                //string reqKey = req.Headers.Get("RequestIdentity");
                string reqIp = req.UserHostAddress;
                string reqMethod = req.OperationName;
                string reqcontent =SerializerCollection.JsonSerializer.Serialize(reqDto);
                //记录信息
                LoggerIoc.GetLogger().Write(LoggerLevel.Info, "00000000", reqMethod, reqcontent, reqIp);

            });

            //响应过滤器
            this.ResponseFilters.Add((req, res, resDto) =>
            {
                //记录响应时间 和 响应 内容
                string resContent = SerializerCollection.FrameJsonSerializer.Serialize(resDto);
                LoggerIoc.GetLogger().Write(LoggerLevel.Info, "11111111", string.Empty, resContent);
            });
        }
    }
}