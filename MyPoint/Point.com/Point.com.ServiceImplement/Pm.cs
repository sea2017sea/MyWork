using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Common;
using Point.com.Model;
using Point.com.Model.Base;

namespace Point.com.ServiceImplement
{
    public class Pm
    {
        /// <summary>
        /// 转换性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public string TableSex(int sex)
        {
            string str = "";
            switch (sex)
            {
                case (int)Enums.Sex.secrecy:
                    str = "保密";
                    break;
                case (int)Enums.Sex.men:
                    str = "男";
                    break;
                case (int)Enums.Sex.women:
                    str = "女";
                    break;
                default:
                    str = "保密";
                    break;
            }

            return str;
        }

        /// <summary>
        /// 抵用劵状态  0 有效  1 无效  2 已使用
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public static string TableCouponState(int parm)
        {
            string str = "";
            switch (parm)
            {
                case (int)Enums.CouponState.Ok:
                    str = "有效";
                    break;
                case (int)Enums.CouponState.No:
                    str = "无效";
                    break;
                case (int)Enums.CouponState.Use:
                    str = "已使用";
                    break;
                default:
                    str = "无效";
                    break;
            }

            return str;
        }

        /// <summary>
        /// 转换来源渠道
        /// </summary>
        /// <param name="sourceTypeSysNo"></param>
        /// <returns></returns>
        public string TableSourceTypeSysNo(int sourceTypeSysNo)
        {
            string str = "";
            switch (sourceTypeSysNo)
            {
                case (int)Enums.SourceTypeSysNo.AndroIdApp:
                    str = "安卓";
                    break;
                case (int)Enums.SourceTypeSysNo.IosApp:
                    str = "IOS";
                    break;
                default:
                    str = "未知";
                    break;
            }

            return str;
        }

        /// <summary>
        /// 转换资讯类型
        /// </summary>
        /// <param name="inforType"></param>
        /// <returns></returns>
        public string TableInforType(int inforType)
        {
            string str = "";
            switch (inforType)
            {
                case (int) Enums.InforType.Man30Up:
                    str = "30岁以上(男)";
                    break;
                case (int) Enums.InforType.Man30Lower:
                    str = "30岁以下(男)";
                    break;
                case (int) Enums.InforType.Woman30Up:
                    str = "30岁以上(女)";
                    break;
                case (int) Enums.InforType.Woman30Lower:
                    str = "30岁以下(女)";
                    break;
                default:
                    str = "30岁以上(男)";
                    break;
            }

            return str;
        }

        /// <summary>
        /// 解析账号中心流水图片地址
        /// </summary>
        /// <param name="tranType"></param>
        /// <returns></returns>
        public static string TableAccountRecordPicUrl(int tranType)
        {
            string str = "http://img.point-server.com/default/default0.png";

            // 1 回答问题（参与互动）    2 邀请好友（分享好友）  4 转出积分  8 转入积分 16 现金提现 32 兑换商品(兑换抵用劵)
            switch (tranType)
            {
                case 1:
                    str = "http://img.point-server.com/default/arpicurl1.png";
                    break;
                case 2:
                    str = "http://img.point-server.com/default/arpicurl2.png";
                    break;
                case 4:
                    str = "http://img.point-server.com/default/arpicurl4.png";
                    break;
                case 8:
                    str = "http://img.point-server.com/default/arpicurl8.png";
                    break;
                case 16:
                    str = "http://img.point-server.com/default/arpicurl16.png";
                    break;
                case 32:
                    str = "http://img.point-server.com/default/arpicurl32.png";
                    break;
                default:
                    str = "http://img.point-server.com/default/default0.png";
                    break;
            }

            return str;
        }
    }
}
