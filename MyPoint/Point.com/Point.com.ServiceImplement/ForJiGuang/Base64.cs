using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.ServiceImplement.ForJiGuang
{
    class Base64
    {
        public static String getBase64Encode(String str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            //
            return Convert.ToBase64String(bytes);
        }
    }
}
