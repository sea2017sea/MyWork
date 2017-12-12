using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Model.Base
{
    public class M_BaseQueryReq
    {
        private int? _pageIndex;
        public int? PageIndex
        {
            get
            {
                if (_pageIndex == null || _pageIndex <= 0)
                {
                    _pageIndex = 1;
                }
                if (_pageIndex > 1000)
                {
                    _pageIndex = 20;
                }

                return _pageIndex;
            }
            set { _pageIndex = value; }
        }

        private int? _pageSize;
        public int? PageSize
        {
            get
            {
                if (_pageSize == null || _pageSize <= 0)
                {
                    _pageSize = 10;
                }
                if (_pageSize > 100)
                {
                    _pageSize = 30;
                }

                return _pageSize;
            }
            set { _pageSize = value; }
        }
    }
}
