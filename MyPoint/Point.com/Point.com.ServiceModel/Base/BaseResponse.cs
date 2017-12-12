using System;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Point.com.ServiceModel
{
    public class BaseResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public int DoFlag { get; set; }
        public string DoResult { get; set; }

        private string sysTime = DateTime.Now.ToString();
        public string SysTime
        {
            get { return sysTime; }
            set { sysTime = value; }
        }

        public BaseResponse()
        {
            DoFlag = -1;
            DoResult = null;

            ResponseStatus = new ResponseStatus()
            {

            };
        }
    }
}
