using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace System
{
    public class Configurator
    {
        private static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static string GetConnectiongString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// 数据库链接
        /// </summary>
        public static string DbConnectionString
        {
            get { return GetConnectiongString("DbConnectionString"); }
        }

        /// <summary>
        /// 数据库链接
        /// </summary>
        public static string DbHolycaConnectionString
        {
            get { return GetConnectiongString("DbHolycaConnectionString"); }
        }

        /// <summary>
        /// 数据库链接
        /// </summary>
        public static string DbbbHomeConnectionString
        {
            get { return GetConnectiongString("DbbbHomeConnectionString"); }
        }

        /// <summary>
        /// MLT 数据库链接
        /// </summary>
        public static string DbMLTConnectionString
        {
            get { return GetConnectiongString("DbPointConnectionString"); }
        }

        /// <summary>
        /// 图片服务器地址
        /// </summary>
        public static string ImageFileService
        {
            get { return GetAppSettings("ImageFileService"); }
        }

        /// <summary>
        /// 图片地址
        /// </summary>
        public static string ImageFileUrl
        {
            get { return GetAppSettings("ImageFileUrl"); }
        }

        /// <summary>
        /// 微信支付通知地址
        /// </summary>
        public static string NotifyUrl
        {
            get { return GetAppSettings("NotifyUrl"); }
        }
    }
}
