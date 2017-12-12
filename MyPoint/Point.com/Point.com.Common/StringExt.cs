using System;
using System.Collections.Generic;
using System.Linq;

namespace Point.com.Common
{
    public static class StringExt
    {
        public static List<int?> ToIntNullList(this string str)
        {
            List<int?> intList = new List<int?>();
            if (str.IsNotNull())
            {
                if (str.IndexOf(",") != -1)
                {
                    string[] strs = str.Split(',');
                    if (strs.IsHasRow())
                    {
                        foreach (var s in strs)
                        {
                            intList.Add(Converter.ParseInt(s,0));
                        }
                    }
                }
                else
                {
                    intList.Add(Converter.ParseInt(str,0));
                }
            }
            return intList;
        }

        public static List<string> ToStringNullList(this string str)
        {
            List<string> intList = new List<string>();
            if (str.IsNotNull())
            {
                if (str.IndexOf(",") != -1)
                {
                    string[] strs = str.Split(',');
                    if (strs.IsHasRow())
                    {
                        foreach (var s in strs)
                        {
                            string strParse = Converter.ParseString(s, "");
                            if (!string.IsNullOrEmpty(strParse))
                                intList.Add(strParse);
                        }
                    }
                }
                else
                {
                    string strParse = Converter.ParseString(str, "");
                    if (!string.IsNullOrEmpty(strParse))
                        intList.Add(strParse);
                }
            }
            return intList;
        }

        public static string ToStringNullList(this List<int?> intlst)
        {
            string str = "0";
            if (intlst.IsHasRow())
            {
                return string.Join(",",intlst.OrderBy(c => c));
            }
            return str;
        }

        public static string ToSpecialChar(this string charname)
        {
            if (charname.IsNotNull())
            {
                if (charname.IndexOf("'") != -1)
                {
                    return charname.Replace("'", "'+ char(39) + '");
                }
                else
                {
                    return charname;
                }
            }
            else
            {
                return "";
            }
        }
    }
}
