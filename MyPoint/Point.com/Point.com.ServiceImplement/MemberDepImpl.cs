using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Point.com.Common;
using Point.com.Logging;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;

namespace Point.com.ServiceImplement
{
    public class MemberDepImpl : BaseService, IMemberDep
    {
        private static Pm pm = new Pm();
        private static SmsImpl sms = new SmsImpl();
        private static ForBaseImpl fb = new ForBaseImpl();

        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_MemberLoginRes> MemberLogin(M_MemberLoginReq req)
        {
            var ptcp = new Ptcp<M_MemberLoginRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请正确填写账号和密码";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "MemberLogin_in", "", jsonParam, "");

            if (string.IsNullOrEmpty(req.Mobile) || string.IsNullOrEmpty(req.MemPassWord))
            {
                ptcp.DoResult = "账号和密码不能为空";
                return ptcp;
            }

            if (req.Mobile.Length != 11)
            {
                ptcp.DoResult = "账号格式有误";
                return ptcp;
            } 
            
            if (req.MemPassWord.Length > 20 || req.MemPassWord.Length < 6)
            {
                ptcp.DoResult = "密码长度不能小于6位，大于20位";
                return ptcp;
            }

            if (req.SourceTypeSysNo <= 0)
            {
                ptcp.DoResult = "来源渠道不能为空";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.DeviceCode))
            {
                ptcp.DoResult = "设备码不能为空";
                return ptcp;
            }

            var memInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    Mobile = req.Mobile
                }, " ORDER BY SysNo ASC").FirstOrDefault();
            if (memInfo.IsNull() || memInfo.SysNo <= 0)
            {
                ptcp.DoResult = "账号或密码错误";
                return ptcp;
            }

            #region 校验

            //校验密码
            if (memInfo.MemPassWord == EncryptionExt.MD5Encrypt(req.MemPassWord.Trim(), 16))
            {
                //登录成功
                M_MemberEntity entity = TableT_MemberToM_MemberEntity(memInfo);

                //保存操作日志
                AddOperationLog(new M_AddOperationLogReq()
                {
                    OperType = (int)Enums.OperationLog.Login,
                    UserId = memInfo.SysNo.GetValueOrDefault(),
                    ClientIp = req.ClientIp,
                    DeviceCode = req.DeviceCode,
                    SourceTypeSysNo = req.SourceTypeSysNo
                });

                //更新最后一次登录的时间
                DbSession.MLT.T_MemberRepository.Update(new T_Member()
                    {
                        LastLoginTime = DateTime.Now
                    },new T_Member(){SysNo = memInfo.SysNo});
                DbSession.MLT.SaveChange();

                ptcp.ReturnValue = new M_MemberLoginRes();
                ptcp.ReturnValue.MemberEntity = entity;
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "登录成功";
            }
            else
            {
                ptcp.DoResult = "账号或密码错误";
                return ptcp;
            }

            #endregion

            return ptcp;
        }

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_MemberRegisterRes> MemberRegister(M_MemberRegisterReq req)
        {
            var ptcp = new Ptcp<M_MemberRegisterRes>();

            #region 基础数据验证

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "MemberRegister_in", "", jsonParam, "");

            if (string.IsNullOrEmpty(req.ClientIp))
            {
                //ptcp.DoResult = "IP不能为空";
                //return ptcp;
                req.ClientIp = "127.0.0.1";
            }

            if (string.IsNullOrEmpty(req.DeviceCode))
            {
            //    ptcp.DoResult = "设备码不能为空";
            //    return ptcp;
                req.DeviceCode = "-1";
            }

            if (req.SourceTypeSysNo != (int)Enums.SourceTypeSysNo.AndroIdApp && req.SourceTypeSysNo != (int)Enums.SourceTypeSysNo.IosApp)
            {
                //ptcp.DoResult = "来源渠道不能为空";
                //return ptcp;

                req.SourceTypeSysNo = (int) Enums.SourceTypeSysNo.Default;
            }

            if (string.IsNullOrEmpty(req.Mobile))
            {
                ptcp.DoResult = "手机号码不能为空";
                return ptcp;
            }

            if (req.Mobile.Length != 11)
            {
                ptcp.DoResult = "手机号码格式不正确";
                return ptcp;
            }

            Regex regex = new Regex(RegexExt.mobileRegex);
            if (!regex.IsMatch(req.Mobile))
            {
                ptcp.DoResult = "手机号码格式不正确";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.MemPassWord))
            {
                ptcp.DoResult = "密码不能为空";
                return ptcp;
            }
            
            if (req.MemPassWord.Length > 20 || req.MemPassWord.Length < 6)
            {
                ptcp.DoResult = "密码长度不能小于6位，大于20位";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.Portrait))
            {
                ptcp.DoResult = "头像不能为空";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.NickName))
            {
                ptcp.DoResult = "昵称不能为空";
                return ptcp;
            }

            if (req.NickName.Length > 10)
            {
                ptcp.DoResult = "昵称不能超过10个字符";
                return ptcp;
            }

            if (req.Sex != (int)Enums.Sex.men && req.Sex != (int)Enums.Sex.women)
            {
                //IOS审核性别、生日、区域不可强制，如果客户没有选择默认给 0  保密
                req.Sex = 0;
            }

            //IOS审核性别、生日、区域不可强制，如果客户没有选择默认给 null
            if (req.Birthday != null)
            {
                if (Convert.ToDateTime(req.Birthday) > DateTime.Now)
                {
                    ptcp.DoResult = "请正确的选择生日";
                    return ptcp;
                }
            }

            if (req.RegProvince <= 0 )
            {
                //IOS审核性别、生日、区域不可强制
                req.RegProvince = 0;
                req.RegCity = 0;
                req.RegArea = 0;
            }

            if (req.RegCity <= 0)
            {
                //IOS审核性别、生日、区域不可强制
                req.RegProvince = 0;
                req.RegCity = 0;
                req.RegArea = 0;
            }

            if (req.RegArea <= 0)
            {
                //IOS审核性别、生日、区域不可强制
                req.RegProvince = 0;
                req.RegCity = 0;
                req.RegArea = 0;
            }

            if (string.IsNullOrEmpty(req.SmsCode))
            {
                ptcp.DoResult = "短信验证码不能为空";
                return ptcp;
            }

            #endregion

            //检查会员是否已经存在
            var isExtRes = CheckMemberIsExist(Enums.SelectCustomer.Mobile, req.Mobile);
            if (isExtRes.IsNotNull() && isExtRes.DoFlag == PtcpState.Success)
            {
                ptcp.DoResult = "手机号码已经存在，请直接登录";
                return ptcp;
            }

            //不存在，更新验证码，并插入会员
            var sendRes = sms.CheckSmsCode((int)Enums.SmsType.Reg,req.Mobile, req.SmsCode);
            if (sendRes.IsNull() || sendRes.DoFlag == PtcpState.Failed)
            {
                if (!string.IsNullOrEmpty(sendRes.DoResult))
                {
                    ptcp.DoResult = sendRes.DoResult;
                    return ptcp;
                }
                else
                {
                    ptcp.DoResult = "注册失败，请稍后再试";
                    return ptcp;
                }
            }
            
            DateTime dtNow = DateTime.Now;

            //计算资讯类型
            //2017-12-16调整为根据性别计算  0 没有选择性别  1 男  2 女
            int inforType = req.Sex;

            #region 老的计算逻辑  不要了

            //if (req.Birthday != null)
            //{
            //    #region

            //    DateTime birthdy = Convert.ToDateTime(req.Birthday);
            //    int year = birthdy.Year;
            //    int yearNow = dtNow.Year;

            //    int ageMem = yearNow - year;
            //    if (ageMem > 30)
            //    {
            //        if (req.Sex == (int) Enums.Sex.men)
            //        {
            //            //30岁以上男
            //            inforType = (int) Enums.InforType.Man30Up;
            //        }
            //        else
            //        {
            //            //30岁以下男
            //            inforType = (int)Enums.InforType.Man30Lower;
            //        }
            //    }
            //    else
            //    {
            //        if (req.Sex == (int)Enums.Sex.women)
            //        {
            //            //30岁以上女
            //            inforType = (int)Enums.InforType.Woman30Up;
            //        }
            //        else
            //        {
            //            //30岁以下女
            //            inforType = (int)Enums.InforType.Woman30Lower;
            //        }
            //    }

            //    #endregion
            //}

            #endregion

            string sql = "";

            if (req.Birthday != null)
            {
                sql = string.Format(
                        @"INSERT INTO T_Member (Mobile,Portrait,MemPassWord,NickName,Sex,RegProvince,RegCity,RegArea,Birthday,InforType,Account,AccountWithdrawn,Score,ScoreWithdrawn,OpenidWxOpen,LastLoginTime,SourceTypeSysNo,DeviceCode,MobileModel,ClientIp,MinWithdrawals,RowCeateDate,ModifyTime,timestamp) OUTPUT INSERTED.SysNo VALUES ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},'{8}',{9},0,0,0,0,NULL,'{10}',{11},'{12}','{13}','{14}',1,'{15}',NULL,DEFAULT)",
                        req.Mobile, req.Portrait, EncryptionExt.MD5Encrypt(req.MemPassWord.Trim(), 16), req.NickName,
                        req.Sex, req.RegProvince, req.RegCity, req.RegArea, req.Birthday, inforType, dtNow,
                        req.SourceTypeSysNo, req.DeviceCode, req.MobileModel, req.ClientIp, dtNow);
            }
            else
            {
                sql = string.Format(
                        @"INSERT INTO T_Member (Mobile,Portrait,MemPassWord,NickName,Sex,RegProvince,RegCity,RegArea,Birthday,InforType,Account,AccountWithdrawn,Score,ScoreWithdrawn,OpenidWxOpen,LastLoginTime,SourceTypeSysNo,DeviceCode,MobileModel,ClientIp,MinWithdrawals,RowCeateDate,ModifyTime,timestamp) OUTPUT INSERTED.SysNo VALUES ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},NULL,{8},0,0,0,0,NULL,'{9}',{10},'{11}','{12}','{13}',1,'{14}',NULL,DEFAULT)",
                        req.Mobile, req.Portrait, EncryptionExt.MD5Encrypt(req.MemPassWord.Trim(), 16), req.NickName,
                        req.Sex, req.RegProvince, req.RegCity, req.RegArea, inforType, dtNow,
                        req.SourceTypeSysNo, req.DeviceCode, req.MobileModel, req.ClientIp, dtNow);
            }
            
            int sysNo = DbSession.MLT.ExecuteSql<int>(sql).FirstOrDefault();

            #region 处理个人账户中心默认欢迎页面 约定 T_InforConfigure 表的 SysNo = 1 为欢迎页面的消息

            DbSession.MLT.T_AccountRecommendRepository.Add(new T_AccountRecommend()
            {
                UserId = sysNo,
                InforSysNo = 1,
                IsPushIn = 0,
                RowCeateDate = dtNow,
                ModifyTime = dtNow,
                IsEnable = true
            });

            #endregion

            #region 处理会员邀请

            //检查当前会员手机号码是否存在要求记录里面
            var share = DbSession.MLT.T_ShareRegisterRepository.QueryBy(new T_ShareRegister()
                {
                    CoverMobile = req.Mobile,
                    IsEnable = true
                }," ORDER BY SysNo DESC").FirstOrDefault();

            //获取答题记录
            var answers = DbSession.MLT.T_ShareAnswerRecordRepository.QueryBy(new T_ShareAnswerRecord()
                {
                    Mobile = req.Mobile,
                    IsTransfer = 0,
                    IsEnable = true
                }).ToList();

            if (share.IsNotNull() && share.SysNo > 0 && answers.IsHasRow())
            {
                //未发送奖励金
                if (share.IsReceive == false)
                {
                    #region

                    //获取最新的一道题的奖励金
                    var answersneow = answers.Where(c => c.AnswerMoney > 0).OrderByDescending(c => c.SysNo).FirstOrDefault();
                    if (answersneow.IsNotNull() && answersneow.SysNo > 0)
                    { 
                        //给分享人发送奖励金 新增流水
                        fb.AddAccountRecord(new M_AddAccountRecordReq()
                        {
                            UserId = share.ShareUserId.GetValueOrDefault(),
                            TranNum = answersneow.AnswerMoney.GetValueOrDefault(),
                            TranType = (int)Enums.TranType.Share
                        });

                        //给被分享人(当前注册的会员)发送奖励金 新增流水
                        fb.AddAccountRecord(new M_AddAccountRecordReq()
                        {
                            UserId = sysNo,
                            TranNum = answersneow.AnswerMoney.GetValueOrDefault(),
                            TranType = (int)Enums.TranType.Partic
                        });

                        //更新发送状态
                        DbSession.MLT.T_ShareRegisterRepository.Update(new T_ShareRegister()
                        {
                            CoverUserId = sysNo,
                            ModifyTime = dtNow,
                            IsReceive = true
                        },new T_ShareRegister()
                        {
                            SysNo = share.SysNo
                        });

                        //更新分享答题记录
                        //将分享答题记录迁移到答题记录表
                        foreach (var a in answers)
                        {
                            DbSession.MLT.T_AnswerRecordRepository.Add(new T_AnswerRecord()
                            {
                                UserId = sysNo,
                                AnsSysNo = a.AnsSysNo,
                                SubSysNo = a.SubSysNo,
                                AnswerMoney = a.AnswerMoney,
                                RowCeateDate = a.RowCeateDate,
                                ModifyTime = dtNow,
                                IsEnable = true
                            });

                            DbSession.MLT.T_ShareAnswerRecordRepository.Update(new T_ShareAnswerRecord()
                            {
                                ModifyTime = dtNow,
                                IsTransfer = 1
                            }, new T_ShareAnswerRecord() { SysNo = a.SysNo });
                        }
                    }

                    #endregion

                    //DbSession.MLT.SaveChange();
                }
            }

            #endregion

            #region 处理自媒体分享注册

            var selfMediaList = DbSession.MLT.T_SelfMediaSaveRecordRepository.QueryBy(new T_SelfMediaSaveRecord()
                {
                    Mobile = req.Mobile,
                    IsTransfer = 0,
                    IsEnable = true
                }, " order by SysNo desc").ToList();
            if (selfMediaList.IsNotNull() && selfMediaList.IsHasRow())
            {
                ForSelfMediaImpl forSelf = new ForSelfMediaImpl();
                foreach (var selfMedia in selfMediaList)
                {
                    //更新记录
                    DbSession.MLT.T_SelfMediaSaveRecordRepository.Update(new T_SelfMediaSaveRecord()
                    {
                        TranNum = 15,
                        IsTransfer = 1,
                        ModifyTime = dtNow
                    }, new T_SelfMediaSaveRecord()
                    {
                        SysNo = selfMedia.SysNo,
                        Mobile = req.Mobile
                    });

                    //自动关注作者
                    forSelf.SetFollow(new M_SetFollowReq()
                    {
                        UserId = sysNo,
                        AuthorSysNo = selfMedia.AuthorSysNo.GetValueOrDefault(),
                        IsFollow = true
                    });
                }

                //给当前会员发送低佣金  不给作者奖励金
                fb.AddAccountRecord(new M_AddAccountRecordReq()
                {
                    UserId = sysNo,
                    TranNum = 15,
                    TranType = (int)Enums.TranType.SaveSelfMedia
                });

                ptcp.ReturnValue = new M_MemberRegisterRes();
                ptcp.ReturnValue.AuthorSysNo = selfMediaList[0].AuthorSysNo.GetValueOrDefault();
                ptcp.ReturnValue.ArticleSysNo = selfMediaList[0].ArticleSysNo.GetValueOrDefault();
            }

            #endregion

            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "注册成功";
            return ptcp;
        }

        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryMemberInfoRes> QueryMemberInfo(M_QueryMemberInfoReq req)
        {
            var ptcp = new Ptcp<M_QueryMemberInfoRes>();

            if (req.IsNull() || req.UserId <= 0)
            {
                ptcp.DoResult = "查询会员标识错误";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryMemberInfo_in", "", jsonParam, "");

            var member = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    SysNo = req.UserId
                }).FirstOrDefault();
            if (member.IsNull() || member.SysNo <= 0)
            {
                ptcp.DoResult = "没有此会员信息";
                return ptcp;
            }

            ptcp.ReturnValue = new M_QueryMemberInfoRes();
            ptcp.ReturnValue.MemberEntity = TableT_MemberToM_MemberEntity(member);
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";
            return ptcp;
        }

        /// <summary>
        /// 根据手机号码查询会员信息，主要用于h5分享页面判断当前手机号码是否存在
        /// 如果存在则返回会员ID，不存在返回 false
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public Ptcp<string> QueryMemberInfoByMobile(string mobile)
        {
            var ptcp = new Ptcp<string>();

            if (string.IsNullOrEmpty(mobile))
            {
                ptcp.DoResult = "手机号码不能为空";
                return ptcp;
            }

            Logger.Write(LoggerLevel.Error, "QueryMemberInfoByMobile_in", "", mobile, "");

            var member = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
            {
                Mobile = mobile
            }).FirstOrDefault();

            if (member.IsNull() || member.SysNo <= 0)
            {
                ptcp.DoResult = "没有此会员信息";
                return ptcp;
            }
            else
            {
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = member.SysNo.ToString();

                return ptcp;
            }
        }

        /// <summary>
        /// 更新微信openid
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="openidWxOpen"></param>
        /// <returns></returns>
        public Ptcp<string> UpdateWxOpenid(int userid, string openidWxOpen)
        {
            var ptcp = new Ptcp<string>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (string.IsNullOrEmpty(openidWxOpen))
            {
                ptcp.DoResult = "微信开放平台标示不能为空";
                return ptcp;
            }

            var memberInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    SysNo = userid
                }).FirstOrDefault();

            if (memberInfo.IsNull() || memberInfo.SysNo <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (!string.IsNullOrEmpty(openidWxOpen))
            {
                if (!string.IsNullOrEmpty(memberInfo.OpenidWxOpen))
                {
                    ptcp.DoResult = "微信开放平台标示已存在";
                    return ptcp;
                }

                DbSession.MLT.T_MemberRepository.Update(new T_Member(){OpenidWxOpen = openidWxOpen,ModifyTime = DateTime.Now},
                    new T_Member(){SysNo = userid});
                DbSession.MLT.SaveChange();
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "更新成功";
            }

            //if (!string.IsNullOrEmpty(openidWxMp))
            //{
            //    if (!string.IsNullOrEmpty(memberInfo.OpenidWxMp))
            //    {
            //        ptcp.DoResult = "微信公众号标示已存在";
            //        return ptcp;
            //    }
            //    DbSession.MLT.T_MemberRepository.Update(new T_Member() { OpenidWxMp = openidWxMp, ModifyTime = DateTime.Now },
            //        new T_Member() { SysNo = userid });
            //    DbSession.MLT.SaveChange();
            //    ptcp.DoFlag = PtcpState.Success;
            //    ptcp.DoResult = "更新成功";
            //}

            return ptcp;
        }

        /// <summary>
        /// 忘记密码，找回密码
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> ForgotPassWord(M_ForgotPassWordReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "ForgotPassWord_in", "", jsonParam, "");

            if (string.IsNullOrEmpty(req.Mobile))
            {
                ptcp.DoResult = "手机号码不能为空";
                return ptcp;
            }

            if (req.Mobile.Length != 11)
            {
                ptcp.DoResult = "手机号码格式有误";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.PassWord))
            {
                ptcp.DoResult = "密码不能为空";
                return ptcp;
            }

            if (req.PassWord.Length > 20 || req.PassWord.Length < 6)
            {
                ptcp.DoResult = "密码长度不能小于6位，大于20位";
                return ptcp;
            }
            if (string.IsNullOrEmpty(req.SmsCode))
            {
                ptcp.DoResult = "短信验证码不能为空";
                return ptcp;
            }

            //判断当前手机号码是否存在
            var resMem = CheckMemberIsExist(Enums.SelectCustomer.Mobile, req.Mobile);
            if (resMem.IsNotNull() && resMem.DoFlag == PtcpState.Failed)
            {
                ptcp.DoResult = "输入的手机号码有误，请核实";
                return ptcp;
            }

            //校验短信验证码
            var smsRes = sms.CheckSmsCode((int)Enums.SmsType.PwdBack,req.Mobile, req.SmsCode);
            if (smsRes.DoFlag == PtcpState.Failed)
            {
                if (!string.IsNullOrEmpty(smsRes.DoResult))
                {
                    ptcp.DoResult = smsRes.DoResult;
                    return ptcp;
                }
                else
                {
                    ptcp.DoResult = "系统异常，请稍后再试";
                    return ptcp;
                }
            }

            //更新密码
            DbSession.MLT.T_MemberRepository.Update(new T_Member()
                {
                    MemPassWord = EncryptionExt.MD5Encrypt(req.PassWord.Trim(), 16),
                    ModifyTime = DateTime.Now
                },new T_Member(){Mobile = req.Mobile});
            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "更新密码成功";
            return ptcp;
        }

        /// <summary>
        /// 检查会员是否存在
        /// </summary>
        /// <param name="selectCustomer"></param>
        /// <param name="value"></param>
        /// <returns>DoFlag = True 存在，DoFlag = False 不存在</returns>
        public Ptcp<string> CheckMemberIsExist(Enums.SelectCustomer selectCustomer,string value)
        {
            var ptcp = new Ptcp<string>();

            if (string.IsNullOrEmpty(value))
            {
                ptcp.DoResult = "查询标识错误";
                return ptcp;
            }

            T_Member tMember = null;
            switch (selectCustomer)
            {
                case Enums.SelectCustomer.UserId:

                    int userid = Converter.ParseInt(value, 0);
                    if (userid > 0)
                    {
                        //根据会员ID查询
                        tMember = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                            {
                                SysNo = userid
                            }).FirstOrDefault();
                    }
                    break;
                case Enums.SelectCustomer.Mobile:
                    //根据手机号码查询
                    tMember = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                    {
                        Mobile = value
                    }, " ORDER BY SysNo ASC").FirstOrDefault();
                    break;
            }

            if (tMember.IsNotNull() && tMember.SysNo > 0)
            {
                //当前会员存在
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "当前会员已存在";
            }
            else
            {
                //当前会员不存在
                ptcp.DoFlag = PtcpState.Failed;
                ptcp.DoResult = "当前会员不存在";
            }

            return ptcp;
        }

        /// <summary>
        /// 修改会员头像
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> UpdateMemberHead(M_UpdateMemberHeadReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "UpdateMemberHead_in", "", jsonParam, "");

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员标识有误";
                return ptcp;
            }
            if (string.IsNullOrEmpty(req.Head))
            {
                ptcp.DoResult = "会员头像不能为空";
                return ptcp;
            }

            DbSession.MLT.T_MemberRepository.Update(new T_Member()
                {
                    Portrait = req.Head,
                    ModifyTime = DateTime.Now
                },new T_Member(){SysNo = req.UserId});
            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "修改头像成功";
            return ptcp;
        }

        /// <summary>
        /// 修改会员昵称
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> UpdateMembereNickName(M_UpdateMembereNickNameReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "UpdateMembereNickName_in", "", jsonParam, "");

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员标识有误";
                return ptcp;
            }
            if (string.IsNullOrEmpty(req.NickName))
            {
                ptcp.DoResult = "会员昵称不能为空";
                return ptcp;
            }

            DbSession.MLT.T_MemberRepository.Update(new T_Member()
            {
                NickName = req.NickName,
                ModifyTime = DateTime.Now
            }, new T_Member() { SysNo = req.UserId });
            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "修改昵称成功";
            return ptcp;
        }

        /// <summary>
        /// 修改会员性别
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public Ptcp<string> UpdateMemberSex(int userid, int sex)
        {
            var ptcp = new Ptcp<string>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (sex != (int)Enums.Sex.men && sex != (int)Enums.Sex.women)
            {
                ptcp.DoResult = "请选择性别";
                return ptcp;
            }

            DbSession.MLT.T_MemberRepository.Update(new T_Member() {
                Sex = sex,
                InforType = sex,
                ModifyTime = DateTime.Now
            },new T_Member() {
                SysNo = userid
            });
            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "修改成功";
            return ptcp;
        }

        /// <summary>
        /// 查询所有的区域信息
        /// </summary>
        /// <returns></returns>
        public Ptcp<M_QueryRegionInfoRes> QueryRegionInfo()
        {
            var ptcp = new Ptcp<M_QueryRegionInfoRes>();

            string cacheKey = string.Format("{0}.QueryRegionInfo", GetType().Name);
            var allReg = CacheClientSession.LocalCacheClient.Get(cacheKey, () =>
                {
                    var regions = DbSession.MLT.Base_RegionRepository.QueryBy(new Base_Region()
                        {
                            IsEnable = true
                        }).ToList();

                    if (regions.IsNotNull() && regions.IsHasRow())
                    {
                        return Mapper.MapperGeneric<Base_Region, M_RegionEntity>(regions).ToList();
                    }

                    return null;
                }, new TimeSpan(1, 0, 0, 0));

            ptcp.ReturnValue = new M_QueryRegionInfoRes();
            ptcp.ReturnValue.Entities = allReg;

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";
            return ptcp;
        }

        /// <summary>
        /// 查询所有的区域信息，分好三级的
        /// </summary>
        /// <returns></returns>
        public Ptcp<M_QueryRegionThreeRes> QueryRegionThree()
        {
            var ptcp = new Ptcp<M_QueryRegionThreeRes>();

            string cacheKey = string.Format("{0}.QueryRegionThree", GetType().Name);

            var treeReg = CacheClientSession.LocalCacheClient.Get(cacheKey, () =>
                {
                    var allReg = QueryRegionInfo();
                    if (allReg.DoFlag == PtcpState.Success && allReg.ReturnValue.IsNotNull() &&
                        allReg.ReturnValue.Entities.IsHasRow())
                    {
                        var oneRegs = allReg.ReturnValue.Entities.Where(c => c.RegionType == 1).ToList();
                        if (oneRegs.IsNotNull() && oneRegs.IsHasRow())
                        {
                            List<M_RegionEntity> mRegion = new List<M_RegionEntity>();
                            mRegion.AddRange(oneRegs);

                            foreach (var mr in mRegion)
                            {
                                var twoReg = allReg.ReturnValue.Entities.Where(c => c.ParentId == mr.RegionId).ToList();
                                if (twoReg.IsNotNull() && twoReg.IsHasRow())
                                {
                                    mr.Entities = new List<M_RegionEntity>();
                                    mr.Entities.AddRange(twoReg);

                                    foreach (var ent in mr.Entities)
                                    {
                                        if (mr.RegionName == ent.RegionName)
                                        {
                                            mr.RegionName = mr.RegionName.Substring(0, mr.RegionName.Length - 1);
                                        }

                                        var threeReg = allReg.ReturnValue.Entities.Where(c => c.ParentId == ent.RegionId).ToList();
                                        if (threeReg.IsNotNull() && threeReg.IsHasRow())
                                        {
                                            ent.Entities = new List<M_RegionEntity>();
                                            ent.Entities.AddRange(threeReg);
                                        }
                                    }
                                }
                            }

                            return mRegion;
                        }
                    }

                    return null;
                }, new TimeSpan(1, 0, 0, 0));

            ptcp.ReturnValue = new M_QueryRegionThreeRes();
            ptcp.ReturnValue.Entities = treeReg;

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";

            return ptcp;
        }

        /// <summary>
        /// 保存操作日志
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> AddOperationLog(M_AddOperationLogReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "AddOperationLog_in", "", jsonParam, "");

            if (req.OperType <= 0)
            {
                ptcp.DoResult = "操作类型错误";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.ClientIp))
            {
                ptcp.DoResult = "IP为空";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.DeviceCode))
            {
                ptcp.DoResult = "设备码为空";
                return ptcp;
            }

            DbSession.MLT.T_OperationLogRepository.Add(new T_OperationLog()
                {
                    UserId = req.UserId,
                    OperType = req.OperType,
                    IdentityId = req.IdentityId,
                    ClientIp = req.ClientIp,
                    DeviceCode = req.DeviceCode,
                    SourceTypeSysNo = req.SourceTypeSysNo,
                    RowCeateDate = DateTime.Now
                });
            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "保存成功";
            return ptcp;
        }

        #region 方法 

        /// <summary>
        /// 会员数据转换
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public M_MemberEntity TableT_MemberToM_MemberEntity(T_Member member)
        {
            M_MemberEntity memberEntity = new M_MemberEntity();
            memberEntity.UserId = member.SysNo.GetValueOrDefault();
            memberEntity.Mobile = member.Mobile;
            memberEntity.Portrait = member.Portrait;
            //memberEntity.MemPassWord = member.MemPassWord;
            memberEntity.NickName = member.NickName;

            memberEntity.Sex = member.Sex.GetValueOrDefault();
            memberEntity.StrSex = pm.TableSex(memberEntity.Sex);

            memberEntity.MinWithdrawals = member.MinWithdrawals.GetValueOrDefault();
            if (memberEntity.MinWithdrawals <= 0)
            {
                memberEntity.MinWithdrawals = 1;
            }

            memberEntity.Birthday = member.Birthday;
            if (memberEntity.Birthday != null)
            {
                memberEntity.StrBirthday = member.Birthday.ToString();
            }

            memberEntity.RegProvince = member.RegProvince;
            memberEntity.RegArea = member.RegArea;
            memberEntity.RegCity = member.RegCity;

            //获取区域信息
            var allReg = QueryRegionInfo();
            if (allReg.DoFlag == PtcpState.Success && allReg.ReturnValue.IsNotNull() &&
                allReg.ReturnValue.Entities.IsHasRow())
            {
                var proInfo = allReg.ReturnValue.Entities.Where(c => c.RegionId == memberEntity.RegProvince).FirstOrDefault();
                if (proInfo.IsNotNull())
                {
                    memberEntity.StrRegProvince = proInfo.RegionName;
                }
                var areaInfo = allReg.ReturnValue.Entities.Where(c => c.RegionId == memberEntity.RegArea).FirstOrDefault();
                if (areaInfo.IsNotNull())
                {
                    memberEntity.StrRegArea = areaInfo.RegionName;
                }
                var cityInfo = allReg.ReturnValue.Entities.Where(c => c.RegionId == memberEntity.RegCity).FirstOrDefault();
                if (cityInfo.IsNotNull())
                {
                    memberEntity.StrRegCity = cityInfo.RegionName;
                }
            }

            memberEntity.InforType = member.InforType;
            memberEntity.StrInfoType = pm.TableInforType(memberEntity.InforType.GetValueOrDefault());

            memberEntity.MobileModel = member.MobileModel;

            memberEntity.Account = member.Account;
            memberEntity.StrAccount = string.Format("{0:F}", memberEntity.Account);

            memberEntity.AccountWithdrawn = member.AccountWithdrawn;
            memberEntity.StrAccountWithdrawn = string.Format("{0:F}", memberEntity.AccountWithdrawn);

            memberEntity.Score = member.Score;
            memberEntity.StrScore = string.Format("{0:F}", memberEntity.Score);

            memberEntity.ScoreWithdrawn = member.ScoreWithdrawn;
            memberEntity.StrScoreWithdrawn = string.Format("{0:F}", memberEntity.ScoreWithdrawn);

            //memberEntity.JpushId = member.JpushId;
            memberEntity.OpenidWxOpen = member.OpenidWxOpen;
            //memberEntity.OpenidWxMp = member.OpenidWxMp;

            memberEntity.LastLoginTime = member.LastLoginTime;
            if (memberEntity.LastLoginTime != null)
            {
                memberEntity.StrLastLoginTime = memberEntity.LastLoginTime.ToString();
            }

            memberEntity.SourceTypeSysNo = member.SourceTypeSysNo;
            memberEntity.StrSourceTypeSysNo = pm.TableSourceTypeSysNo(memberEntity.SourceTypeSysNo.GetValueOrDefault());

            memberEntity.ClientIp = member.ClientIp;
            memberEntity.DeviceCode = member.DeviceCode;
            memberEntity.RowCeateDate = member.RowCeateDate;
            if (memberEntity.RowCeateDate != null)
            {
                memberEntity.StrRowCeateDate = memberEntity.RowCeateDate.ToString();
            }

            return memberEntity;
        }

        #endregion
    }
}
