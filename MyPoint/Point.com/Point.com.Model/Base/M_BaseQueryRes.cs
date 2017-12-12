using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Model.Base
{
    public class M_BaseQueryRes
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public long? Total { get; set; }
    }
}
