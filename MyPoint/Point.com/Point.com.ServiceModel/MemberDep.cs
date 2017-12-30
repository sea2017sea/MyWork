using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.ServiceModel.Base;
using ServiceStack.ServiceHost;

namespace Point.com.ServiceModel
{
    public class MemberLoginReq : BaseModel
    {
        //登录手机号码
        public string Mobile { get; set; }
        //登录密码
        public string MemPassWord { get; set; }
    }

    public class MemberLoginRes : BaseResponse
    {
        public MemberEntity MemberEntity { get; set; }
    }

    public class MemberRegisterReq : BaseModel
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

    public class MemberRegisterRes : BaseResponse
    {
        public int AuthorSysNo { get; set; }     //作者ID
        public int ArticleSysNo { get; set; }    //作者文章ID
    }

    public class MemberEntity
    {
        public int UserId { get; set; }                     //会员ID
        public string Mobile { get; set; }                  //会员手机号码
        public string Portrait { get; set; }                //会员头像地址
        public string MemPassWord { get; set; }             //会员密码
        public string NickName { get; set; }                //会员昵称
        public decimal MinWithdrawals { get; set; }         //最小提现金额起始值，默认为：1.00元

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


        public Nullable<decimal> Account { get; set; }                  //账户总的现金    2017-12-09改版确认不要了     
        public string StrAccount { get; set; }                          //账户总的现金    2017-12-09改版确认不要了    
        public Nullable<decimal> AccountWithdrawn { get; set; }         //账号提现总现金  2017-12-09改版确认不要了    
        public string StrAccountWithdrawn { get; set; }                 //账号提现总现金  2017-12-09改版确认不要了    
        public Nullable<decimal> ScoreWithdrawn { get; set; }           //账户累积提现低用金金额，单位：元  未转化为RMBd的金额
        public string StrScoreWithdrawn { get; set; }                   //账户累积提现低用金金额，单位：元  未转化为RMBd的金额


        public Nullable<decimal> Score { get; set; }                    //账户总的可用抵用金金额，单位：元  未转化为RMBd的金额
        public string StrScore { get; set; }                            //账户总的可用抵用金金额，单位：元  未转化为RMBd的金额


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

    public class AddOperationLogReq : BaseModel
    {
        public int OperType { get; set; }   //操作类型 1 登录成功  2资讯点击  4店铺点击 8兑换点击
        public string IdentityId { get; set; }  //标识ID，只有OperType 为2 4 8时才有ID，为1没有；为2 4 是 T_InforConfigure 表的 SysNo；为 8 时是 T_ShopGoods 表的 SysNo
    }

    public class AddOperationLogRes : BaseResponse
    {

    }

    public class QueryRegionInfoReq
    {
    }

    public class QueryRegionInfoRes : BaseResponse
    {
        //所有的区域信息
        public List<RegionEntity> Entities { get; set; }
    }

    public class QueryRegionThreeReq
    {
    }

    public class QueryRegionThreeRes : BaseResponse
    {
        //所有的区域信息 三级
        public List<RegionEntity> Entities { get; set; }
    }

    public class RegionEntity
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
        public List<RegionEntity> Entities { get; set; }
    }

    public class CheckMemberIsExistReq
    {
        public int SelectType { get; set; }           //查询类型  1 根据userid查询  2 根据手机号码查询
        public string SelectValue { get; set; }       //查询的值，根据 SelectType 确定是什么类型
    }

    public class CheckMemberIsExistRes : BaseResponse
    {

    }

    public class QueryMemberInfoReq : BaseModel
    {
    }

    public class QueryMemberInfoRes : BaseResponse
    {
        public MemberEntity MemberEntity { get; set; }
    }

    public class UpdateMemberHeadReq : BaseModel
    {
        public string Head { get; set; }    //头像
    }

    public class QueryMemberInfoByMobileReq
    {
        public string Mobile { get; set; }                  //会员手机号码
    }

    public class QueryMemberInfoByMobileRes : BaseResponse
    {
    }

    public class UpdateMemberHeadRes : BaseResponse
    {
    }

    public class UpdateMembereNickNameReq : BaseModel
    {
        public string NickName { get; set; }   //昵称
    }

    public class UpdateMembereNickNameRes : BaseResponse
    {
    }

    public class ForgotPassWordReq : BaseModel
    {
        public string Mobile { get; set; }                  //会员手机号码
        public string PassWord { get; set; }                //会员密码
        public string SmsCode { get; set; }                 //短信验证码
    }

    public class ForgotPassWordRes : BaseResponse
    {
    }

    public class UpdateWxOpenidReq
    {
        public int UserId { get; set; }              //会员ID
        public string OpenidWxOpen { get; set; }     //微信开发平台的标示ID
        //public string OpenidWxMp { get; set; }       //微信公众号的标示ID 不要了
    }

    public class UpdateWxOpenidRes : BaseResponse
    {

    }

    public class UpdateMemberSexReq
    {
        public int UserId { get; set; }              //会员ID
        public int Sex { get; set; }                        //性别 ，0 保密  1 男 2女
    }

        public class UpdateMemberSexRes : BaseResponse
    {
    }
}
