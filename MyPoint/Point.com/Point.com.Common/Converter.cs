using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Common
{
    public class Converter
    {
        /// <summary>
        /// 获得int
        /// </summary>
        /// <param name="obj">转换前值</param>
        /// <param name="defValue">默认Int值</param>
        /// <returns>转换后值</returns>
        public static int ParseInt(object obj, int defValue)
        {
            int result = -1;
            try
            {
                if (obj != null)
                {
                    string res = obj.ToString();
                    if (!int.TryParse(res, out result))
                    {
                        result = defValue;
                    }
                }
                else
                {
                    result = defValue;
                }
            }
            catch
            {
                result = defValue;
            }
            return result;
        }

        /// <summary>
        /// obj转string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static string ParseString(object obj, string defValue)
        {
            string result = string.Empty;
            try
            {
                if (obj == null)
                    result = defValue;
                else
                    result = obj.ToString();
            }
            catch
            {
                result = defValue;
            }
            return result;
        }

        /// <summary>
        /// 将空类型转换不为空
        /// </summary>
        /// <param name="dec"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static decimal ParseDecimalNull(decimal? dec, decimal defValue)
        {
            decimal result = 0;

            try
            {
                if (dec != null)
                {
                    result = (decimal)dec;
                }
                else
                {
                    result = defValue;
                }
            }
            catch
            {
                result = defValue;
            }

            return result;
        }

        /// <summary>
        /// 获得Datetime
        /// </summary>
        /// <param name="obj">转换前值</param>
        /// <param name="defValue">默认时间</param>
        /// <returns>转换后值</returns>
        public static DateTime ParseDateTime(object obj, DateTime defValue)
        {
            DateTime result = DateTime.Now;
            try
            {
                if (!DateTime.TryParse(obj.ToString(), out result))
                {
                    result = defValue;
                }
            }
            catch
            {

            }
            return result;
        }


        /// <summary>
        /// 获得Decimal
        /// </summary>
        /// <param name="obj">转换前值</param>
        /// <param name="defValue">默认decimal值</param>
        /// <returns>转换后值</returns>
        public static decimal ParseDecimal(object obj, decimal defValue)
        {
            decimal result = new decimal(0);
            try
            {
                string res = obj.ToString();
                if (!decimal.TryParse(res, out result))
                {
                    result = defValue;
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary> 
        /// 产生指定长度随机码 自动排除0、o、1、i四个容易混淆的
        /// </summary>
        /// <param name="length">位数</param>
        /// <param name="isMix">是否字母数字混合 1 混合 0 纯数字</param>
        /// <returns>码</returns>
        public static string CreateRandom(int strLength, int isMix)
        {
            string result = "";

            System.Threading.Thread.Sleep(3);

            //排除0、o、1、i四个容易混淆的
            char[] pattern = null;
            if (isMix == 1)
                pattern = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            else
                pattern = new char[] { '0', '2', '3', '4', '5', '6', '7', '8', '9' };

            int n = pattern.Length;
            System.Random random = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < strLength; i++)
            {
                int rnd = random.Next(0, n);
                result += pattern[rnd];
            }

            return result;
        }
    }
}
