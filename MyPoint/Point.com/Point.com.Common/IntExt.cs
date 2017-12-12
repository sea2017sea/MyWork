namespace System
{
    public static class IntExt
    {
        public static decimal ToYuan(this long fen)
        {
            return Convert.ToDecimal(fen) / 100;
        }

        public static decimal ToYuan(this long? fen)
        {
            decimal yuan = 0;
            if (null != fen)
            {
                yuan = ((long)fen).ToYuan();
            }
            return yuan;
        }

        public static decimal ToYuan(this int fen)
        {
            return ((long)fen).ToYuan();
        }

        public static decimal ToYuan(this int? fen)
        {
            return ((long?)fen).ToYuan();
        }


        public static int ToIntFen(this decimal yuan)
        {
            return Convert.ToInt32(yuan * 100);
        }
        public static long ToLongFen(this decimal yuan)
        {
            return Convert.ToInt64(yuan * 100);
        }


        public static int ToIntFen(this decimal? yuan)
        {
            int res = default(int);
            if (yuan != null)
            {

                res = ((decimal)yuan).ToIntFen();
            }
            return res;
        }

        public static long ToLongFen(this decimal? yuan)
        {
            long res = default(long);
            if (yuan != null)
            {

                res = ((decimal)yuan).ToLongFen();
            }
            return res;
        }
    }
}