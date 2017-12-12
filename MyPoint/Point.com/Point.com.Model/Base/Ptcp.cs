
namespace Point.com.Model.Base
{
    public enum PtcpState
    {
        Success = 1,
        Failed = -1
    }

    public class Ptcp<T>
    {
        public PtcpState DoFlag { get; set; }
        public string DoResult { get; set; }
        public T ReturnValue { get; set; }

        public Ptcp()
        {
            DoFlag = PtcpState.Failed;
            DoResult = null;
        }

        public Ptcp(PtcpState statusFlag, string message)
        {
            this.DoFlag = statusFlag;
            this.DoResult = message;
        }

        public Ptcp(PtcpState statusFlag, T t)
        {
            this.DoFlag = statusFlag;
            this.ReturnValue = t;
        }

        public Ptcp(PtcpState statusFlag, string message, T t)
        {
            this.DoFlag = statusFlag;
            this.DoResult = message;
            this.ReturnValue = t;
        }
    }
}
