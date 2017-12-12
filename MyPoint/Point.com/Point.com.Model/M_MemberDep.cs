using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model.Base;

namespace Point.com.Model
{
    public class M_MemberLoginReq : M_BaseModel
    {
        public string Mobile { get; set; }
        public string MemPassWord { get; set; }
    }

    public class M_MemberLoginRes
    {
        public M_MemberEntity MemberEntity { get; set; }
    }

    public class M_MemberRegisterReq : M_BaseModel
    {
        public string Mobile { get; set; }                  //会员手机号码
        public string Portrait { get; set; }                //会员头像地址
        public string MemPassWord { get; set; }             //会员密码
        public string NickName { get; set; }                //会员昵称
        public int Sex { get; set; }                        //性别 ，0 保密  1 男 2女
        public Nullable<System.DateTime> Birthday { get; set; }    //会员生日
        public int RegProvince { get; set; }      //注册省份ID
        public int RegCity { get; set; }          //注册市ID
        public int RegArea { get; set; }          //注册区县ID
        public string SmsCode { get; set; }       //短信验证码
        public string MobileModel { get; set; }   //手机型号  安卓给的是手机型号；IOS可能给的手机屏幕尺寸，也可能手机型号

        //public string ShareKey { get; set; }      //分享的key，以英文的,分割；格式：分享人的会员ID,分享的内容ID，如：10023,780   不要了
    }

    public class M_QueryMemberInfoReq : M_BaseModel
    {
    }

    public class M_QueryMemberInfoRes
    {
        public M_MemberEntity MemberEntity { get; set; }
    }

    public class M_QueryRegionInfoRes
    {
        //所有的区域信息
        public List<M_RegionEntity> Entities { get; set; }
    }

    public class M_QueryRegionThreeRes
    {
        //所有的区域信息 三级
        public List<M_RegionEntity> Entities { get; set; }
    }

    public class M_RegionEntity
    {
        public Nullable<int> RegionId { get; set; }       //区域ID
        public Nullable<int> ParentId { get; set; }       //区域父级ID
        public string RegionName { get; set; }            //区域名称
        public Nullable<int> RegionType { get; set; }     //区域类型 1 省份  2 市  3 区县
        public string ZipCode { get; set; }               //邮编
        public string QuHao { get; set; }                 //区号
        public string ShortSpell { get; set; }            //简拼
        public Nullable<int> SortId { get; set; }         //排序，数值越大越靠前

        //下级分类
        public List<M_RegionEntity> Entities { get; set; }
    }

    public class M_MemberEntity
    {
        public int UserId { get; set; }                     //会员ID
        public string Mobile { get; set; }                  //会员手机号码
        public string Portrait { get; set; }                //会员头像地址
        public string MemPassWord { get; set; }             //会员密码
        public string NickName { get; set; }                //会员昵称

        public int Sex { get; set; }                        //性别 ，0 保密  1 男 2女
        public string StrSex { get; set; }                  // string 类型性别 ，0 保密  1 男 2女

        public Nullable<int> RegProvince { get; set; }      //注册省份ID
        public string StrRegProvince { get; set; }          //注册省份ID

        public Nullable<int> RegCity { get; set; }          //注册市ID
        public string StrRegCity { get; set; }              //注册市ID

        public Nullable<int> RegArea { get; set; }          //注册区县ID
        public string StrRegArea { get; set; }              //注册区县ID

        public Nullable<System.DateTime> Birthday { get; set; }    //会员生日
        public string StrBirthday { get; set; }                    //会员生日

        public Nullable<int> InforType { get; set; }               //资讯类型  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女
        public string StrInfoType { get; set; }                    //资讯类型  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女

        public string MobileModel { get; set; }                   //手机型号  安卓给的是手机型号；IOS可能给的手机屏幕尺寸，也可能手机型号

        public Nullable<decimal> Account { get; set; }                  //账户总的现金   
        public string StrAccount { get; set; }                          //账户总的现金   
        public Nullable<decimal> AccountWithdrawn { get; set; }         //账号提现总现金
        public string StrAccountWithdrawn { get; set; }                 //账号提现总现金
        public Nullable<decimal> Score { get; set; }                    //账户总的抵用金金额
        public string StrScore { get; set; }                            //账户总的抵用金金额
        public Nullable<decimal> ScoreWithdrawn { get; set; }           //账户申请提现抵用金金额
        public string StrScoreWithdrawn { get; set; }                   //账户申请提现抵用金金额

        //public string JpushId { get; set; }                           //推送数据标识  不要了
        public string OpenidWxOpen { get; set; }                        //微信开放平台标识
        //public string OpenidWxMp { get; set; }                          //微信公众号平台标识 不要了

        public Nullable<System.DateTime> LastLoginTime { get; set; }   //最后一次登录时间
        public string StrLastLoginTime { get; set; }                   //最后一次登录时间

        public string ClientIp { get; set; }                           //注册时的IP
        public string DeviceCode { get; set; }                         //设备码
        public Nullable<System.DateTime> RowCeateDate { get; set; }    //注册时间
        public string StrRowCeateDate { get; set; }    //注册时间

        public Nullable<int> SourceTypeSysNo { get; set; }             //注册来源 1 安卓  2 IOS
        public string StrSourceTypeSysNo { get; set; }                 //注册来源 1 安卓  2 IOS
    }

    public class M_AddOperationLogReq : M_BaseModel
    {
        public int OperType { get; set; }   //操作类型 1 登录成功  2资讯点击  4店铺点击 8兑换点击
        public string IdentityId { get; set; }  //标识ID，只有OperType 为2 4 8时才有ID，为1没有；为2 4 是 T_InforConfigure 表的 SysNo；为 8 时是 T_ShopGoods 表的 SysNo
    }

    public class M_UpdateMemberHeadReq : M_BaseModel
    {
        public string Head { get; set; }    //头像
    }

    public class M_UpdateMembereNickNameReq : M_BaseModel
    {
        public string NickName { get; set; }   //昵称
    }

    public class M_ForgotPassWordReq : M_BaseModel
    {
        public string Mobile { get; set; }                  //会员手机号码
        public string PassWord { get; set; }                //会员密码
        public string SmsCode { get; set; }                 //短信验证码
    }
}
