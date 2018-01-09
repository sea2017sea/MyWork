using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Common
{
    public class RegexExt
    {
        public static string emailRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public static string mobileRegex = @"^13[0-9]{9}|17[0-9]{9}|15[012356789][0-9]{8}|18[0123456789][0-9]{8}|144[0-9]{8}|145[0-9]{8}|147[0-9]{8}|177[0-9]{8}|182[0-9]{8}$";
    }
}
