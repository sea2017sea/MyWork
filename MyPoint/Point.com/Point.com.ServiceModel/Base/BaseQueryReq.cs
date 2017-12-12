
using ServiceStack.ServiceHost;

namespace Point.com.ServiceModel
{
    public class BaseQueryReq
    {
        [ApiMember(Description = "第几页")]
        public int? PageIndex { get; set; }

        [ApiMember(Description = "每页显示条数")]
        public int? PageSize { get; set; }
    }
}
