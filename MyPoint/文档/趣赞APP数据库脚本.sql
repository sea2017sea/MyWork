
--指定需要操作的数据库
USE point
GO

--创建会员表
CREATE TABLE T_Member
(
SysNo INT IDENTITY(10000,1) PRIMARY KEY,                                      --会员ID，自增长，主键，唯一
Mobile VARCHAR(11) NOT NULL,                                                        --登录手机号码
Portrait NVARCHAR(max) NULL,                                                           --肖像，用于存放会员头像
MemPassWord NVARCHAR(50) NOT NULL,                                         --会员账号，密码，保存密文
NickName NVARCHAR(50) NULL,                                                        --会员昵称
Sex INT NULL,                                                                                     --会员性别，0 保密  1 男 2女
RegProvince INT NULL,                                                                        --注册省份ID   默认值（不填写）：0 
RegCity INT NULL,                                                                               --注册市ID  默认值（不填写）：0
RegArea INT NULL,                                                                              --注册区县ID  默认值（不填写）：0
Birthday DATETIME NOT NULL,                                                           --会员生日 默认值（不填写）：null
InforType INT NOT NULL,                                                                    --资讯类型  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女  100 没有填写生日的类型      2017-12-16调整为 0 没有选择性别  1 男  2 女
Account DECIMAL(18, 2) NOT NULL,                                                   --账户总的可用现金，单位：元     2017-12-09改版确认不要了    
AccountWithdrawn DECIMAL(18, 2) NOT NULL,                                          --账号累积提现总现金，单位：元   2017-12-09改版确认不要了    
Score DECIMAL(18, 2) NOT NULL,                                                       --账户总的可用抵用金金额，单位：元  未转化为RMBd的金额
ScoreWithdrawn DECIMAL(18,2) NOT NULL,                                               --账户累积提现低用金金额，单位：元  未转化为RMBd的金额
--JpushId NVARCHAR(100)  NULL,                                                       --推送标识  不要了
OpenidWxOpen NVARCHAR (256)  NULL,                                           --微信开发平台标识              
--OpenidWxMp NVARCHAR(100)  NULL,                                             --微信公众号标识    不要了
LastLoginTime DATETIME NULL,                                                          --最后一次登录时间
SourceTypeSysNo INT NOT NULL,                                                      --注册来源 1 安卓  2 IOS  0 没有来源渠道
DeviceCode  VARCHAR(256) NOT NULL,                                             --设备码  默认值：-1，IOS如果获取不到设备码，会给 0
MobileModel  VARCHAR(1024)  NULL,                                                  --手机型号  安卓给的是手机型号；IOS可能给的手机屏幕尺寸，也可能手机型号
ClientIp VARCHAR(512) NOT NULL,                                                    --注册IP  默认值：127.0.0.1
MinWithdrawals DECIMAL(18,2) NOT NULL DEFAULT 1,                                --最小提现额度  默认为：1.00 元，包含
RowCeateDate DATETIME NOT NULL,                                                 --创建时间
ModifyTime DATETIME NULL,                                                              --修改时间
timestamp TIMESTAMP NOT NULL,                                                     --时间戳
)
go

--发送短信
CREATE TABLE T_Sms
(
SysNo INT IDENTITY(1,1) PRIMARY KEY NOT NULL,        --主键，自增长，唯一
Mobile varchar(11) NOT NULL,                                        --手机号码
SmsType INT NOT NULL,                                                 --发送的短信类型，1 注册 2 登录 4密码找回    
SmsCode varchar(10) NOT NULL,                                     --验证码
SmsStatus INT NOT NULL,                                              --验证码状态 0 未验证  1已经验证  2验证失败
ExpireTime DATETIME NOT NULL,                                   --过期时间
VerifTime DATETIME NULL,                                             --验证时间
RowCeateDate DATETIME NOT NULL,                             --行创建时间
)
go

--创建账号交易流水表
CREATE TABLE T_AccountRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                    --主键，自增长，唯一
TranType INT NOT NULL,                                          --交易类型  1 回答问题（参与互动）    2 邀请好友（分享好友）  4 转出积分  8 转入积分 16 现金提现 32 兑换商品(兑换抵扣劵)   64 阅读文章付费
PlusReduce INT NOT NULL,                                       --交易获取或者使用 1增加 2 使用（减）
UserId INT NOT NULL,                                              --会员ID
TranNum DECIMAL(18, 2) NOT NULL,                      --交易数量
Company NVARCHAR(8) NOT NULL,                        --交易单位：积分、元
TranName NVARCHAR(64) NOT NULL,                     --交易说明
InRemarks NVARCHAR(512)  NULL,                         --内部备注，如：来源于哪里，关键ID等信息
IsPushIn int NOT NULL,                                            --站内是否推送，红点展示，0 未推送 1 推送  2推送失败
--IsPushOut int NOT NULL,                                      --站外是否推送，红点展示，0 未推送 1 推送  2推送失败    不要了
Remark NVARCHAR(200) NULL,                               --备注信息
RowCeateDate DATETIME NOT NULL,                      --创建时间
IsEnable BIT NOT NULL,                                           --是否启用 true 启用 0 禁用
)
GO


--新增操作日志表
CREATE TABLE T_OperationLog
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                    --主键，自增长，唯一
OperType INT NOT NULL,                                          --操作类型 1 登录成功  2资讯点击  4店铺点击 8兑换点击
UserId INT NULL,                                                       --会员ID
SourceTypeSysNo INT NOT NULL,                             --来源渠道 1 安卓  2 IOS
IdentityId VARCHAR(16)  NULL,                                 --标识ID，只有OperType 为2 4 8时才有ID，为1没有；为2 4 是 T_InforConfigure 表的 SysNo；为 8 时是 T_ShopGoods 表的 SysNo
ClientIp VARCHAR(128) NOT NULL,                                                    --注册IP
DeviceCode  VARCHAR(128) NOT NULL,                                             --设备码
RowCeateDate DATETIME NOT NULL,                                                 --创建时间
)
go

--创建区域信息表
CREATE TABLE Base_Region
(
RegionId INT NOT NULL,                                          --区域ID
ParentId INT NULL,                                                   --区域父级ID
RegionName NVARCHAR(100) NULL,                        --区域名称
RegionType INT NULL,                                               --区域类型
ZipCode NVARCHAR(50) NULL,                                 --邮编
QuHao NVARCHAR(50) NULL,                                   --区号
ShortSpell CHAR(10) NULL,                                        --简拼，可用作排序使用
SortId INT NULL,                                                       --排序，数值越大越靠前
IsEnable BIT NOT NULL                                             --是否启用 true 启用 0 禁用
) 
GO


--新增保存客户手机上安装了那些APP表
CREATE TABLE Base_SaveApp
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                             --主键，自增长，唯一
Mobile varchar(11)  NULL,                                                                  --手机号码
UserId int NULL,                                                                                  --会员ID
DeviceCode  VARCHAR(512) NOT NULL,                                             --设备码
AppName NVARCHAR(512) NULL,                                                       --APP名称
SourceTypeSysNo INT NOT NULL,                                                      --来源渠道 1 安卓  2 IOS
ClientIp VARCHAR(512) NOT NULL,                                                    --客户端IP
RowCeateDate DATETIME NOT NULL,                                                 --创建时间
ModifyTime DATETIME NULL,                                                              --修改时间
IsEnable BIT NOT NULL                                                                        --是否启用 true 启用 0 禁用
)
go

--创建分类表
CREATE TABLE T_Category
(
SysNo INT IDENTITY(1,1) ,                                                                 --主键，自增长，唯一
CateId INT PRIMARY KEY,                                                                  --分类ID
CateName NVARCHAR(64) NOT NULL,                                              --分类名称
CatePic VARCHAR(max) NULL,                                                            --分类图片
IntSort int NOT NULL,                                                                        --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                                --创建时间
ModifyTime DATETIME NULL,                                                             --修改时间
IsEnable BIT NOT NULL                                                                      --是否启用 true 启用 0 禁用
)
go

--创建分享注册记录表
CREATE TABLE T_ShareRegister
(
SysNo INT IDENTITY(1,1) ,                                                                 --主键，自增长，唯一
ShareSysNo int NOT NULL,                                                              --分享的内容标识
ShareUserId int NOT NULL,                                                               --分享人的会员ID
CoverMobile varchar(11) NOT  NULL,                                                --被分享人的手机号码
CoverUserId int  NULL,                                                                      --被分享人的会员ID
IsReceive bit NOT NULL,                                                                    --是否发放领取了奖励金额
RowCeateDate DATETIME NOT NULL,                                                --创建时间
ModifyTime DATETIME NULL,                                                             --修改时间
IsEnable BIT NOT NULL                                                                      --是否启用 true 启用 0 禁用
)
go


--创建数据信息表（用于首页数据展示）
CREATE TABLE T_InforConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --主键，自增长
DataType int NOT NULL,                                                   --数据类型  1 咨询、新闻   2 导购咨询(店铺)   4广告咨询（答题 ） 8 自媒体文章
StrInforType VARCHAR(512) NOT NULL,                                      --信息类型 0 所有  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女，格式：(1),(2),(3)
InforName NVARCHAR(1024) NOT NULL,                                       --信息标题
InforRemark NVARCHAR(1024)  NULL,                                        --信息的备注信息，自己填写，如：区域
InforDesc NVARCHAR(1024) NOT NULL,                                       --信息描述
LogoIcon VARCHAR(max) NULL,                                              --logo图标，店铺的logo
HeadPic VARCHAR(max) NOT NULL,                                           --头图(左右、横排都是这个头图)
CoverPic VARCHAR(max) NULL,                                              --封面图片
ShopPic VARCHAR(max) NULL,                                               --店铺列表图片地址
PushPic VARCHAR(max) NULL,                                               --推送页面图片地址
VideoUrl VARCHAR(Max)  NULL,                                             --视频地址
CateId int NULL,                                                         --店铺的分类ID，只有 InforType 为 2 时，必填
ShopSysNo int NULL,                                                      --店铺的ID，只有 InforType 为 4 时，必填，对应当前表 InforType = 2 时的店铺ID，用于答题完毕之后的推荐商品    InforType = 1 的时候，填写此值，表示当前广告跳自己的店铺 
ShowMode int NOT NULL,                                                   --展示方式  0 横排展示（店铺） 1 横排展示（广告，答题）  2 左右展示
InforSource NVARCHAR(1024) NOT NULL,                                     --来源，管理员手动填写，如：新浪、腾讯
LinkUrl VARCHAR(max) NULL,                                               --跳转链接地址
IntSort int NOT NULL,                                                    --排序，数值越大越靠前
IsShowIndex int NOT NULL,                                                --是否显示在首页，0 不显示   1 显示 注：对所有 DataType 类型有效
SourceDateTime DATETIME NOT NULL,                                        --来源时间
RowCeateDate DATETIME NOT NULL,                                          --创建时间
ModifyTime DATETIME NULL,                                                --修改时间
IsEnable BIT NOT NULL                                                    --是否启用 true 启用 0 禁用
)
go

--创建店铺商品信息表
CREATE TABLE T_ShopGoods
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
ShopSysNo int NOT NULL,                                                            --店铺ID，对应 T_InforConfigure 表sysno
GoodsName NVARCHAR(512) NOT NULL,                                    --商品名称
GoodsPic VARCHAR(max) NOT NULL,                                            --商品图片地址
GoodsOutLink VARCHAR(max) NULL,                                            --商品链接地址 如果有值则说明可以点击商品，到这个链接去
MarketPrice DECIMAL(18, 2) NOT NULL,                                      --市场价格，门店价格
GoodsLabelOne NVARCHAR(64) NOT NULL,                                 --商品标签   如：女、热销单品
GoodsLabelTwo NVARCHAR(64) NOT NULL,                                 --商品标签   如：男、当季新品
ExcCouponSysNo int NOT NULL,                                                  --兑换抵扣劵ID，获取到抵扣卷的金额，对应 T_CouponInfo 表的SysNo
CouponCount int NOT NULL,                                                       --抵扣劵数量
UseCouponCount int NOT NULL,                                                 --抵扣劵使用数量
OverCouponCount int NOT NULL,                                               --抵扣劵剩余数量
IntSort int NOT NULL,                                                                  --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                       --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建抵扣劵表
CREATE TABLE T_CouponInfo
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
ShopSysNo int NOT NULL,                                                            --店铺ID，对应 T_InforConfigure 表sysno
CouponName NVARCHAR(512) NOT NULL,                                  --抵扣劵名称
ExcAmount DECIMAL(18, 2) NOT NULL,                                       --抵扣金额
CouponType int NOT NULL,                                                          --抵扣劵的类型 1 链接  2 二维码、条形码  4 公码  8 私码
CouponCode NVARCHAR(512) NULL,                                           --抵扣劵的值，抵扣劵类型为8时，当前值为空，其他不可为空
UseRule NVARCHAR(128) NOT NULL,                                           --使用规则
RuleContent NVARCHAR(512) NOT NULL,                                    --规则内容
RowCeateDate DATETIME NOT NULL,                                          --创建时间
ModifyTime DATETIME NULL,                                                       --修改时间
IsEnable BIT NOT NULL                                                                --是否启用 true 启用 0 禁用
)
go

--创建私码表
CREATE TABLE T_CouponPrivateCode
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
CouponSysNo int NOT NULL,                                                        --对应 T_CouponInfo 的抵扣劵ID
PrivateCode VARCHAR(20) NOT NULL,                                           --码
UserId int NULL,                                                                             --会员ID，有值并且大于0，标示被使用
ExcDateTime DATETIME NULL,                                                        --兑换时间 
RowCeateDate DATETIME NOT NULL,                                             --创建时间
ModifyTime DATETIME NULL,                                                          --修改时间
IsEnable BIT NOT NULL                                                                    --是否启用 true 启用 0 禁用
)
go


--创建抵扣劵兑换记录表
CREATE TABLE T_CouponExcRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
UserId int NOT NULL,                                                                    --会员ID
ShopSysNo int NOT NULL,                                                            --店铺ID，对应 T_InforConfigure 表 sysno
GoodsSysNo int NOT NULL,                                                           --店铺商品ID 对应 T_ShopGoods 表的 sysno
CouponSysNo int NOT NULL,                                                       --抵扣卷ID，对应 T_CouponInfo 表的 sysno
PrivateCode VARCHAR(20) NULL,                                                  --码
ExcAmount DECIMAL(18, 2) NOT NULL,                                       --抵扣金额
UseScore DECIMAL(18, 2) NOT NULL,                                          --使用的抵用金金额
RechargeAmount DECIMAL(18, 2) NOT NULL,                              --充值金额，低佣金不足时充值的金额
RowCeateDate DATETIME NOT NULL,                                          --创建时间
ModifyTime DATETIME NULL,                                                       --修改时间
CouponState int NOT NULL,                                                         --抵扣劵状态  0 有效  1 无效  2 已使用 （管理手动更改数据库状态，一般用于客户使用了之后，管理来更新为无效，前端则会显示当前抵扣劵为无效状态），前端已经让可以查看当前数据
IsEnable BIT NOT NULL                                                                --是否启用 true 启用 0 禁用
)
go

--创建充值记录表
CREATE TABLE T_Recharge
(
SysNo INT IDENTITY(1000,1) PRIMARY KEY,                                   --主键，自增长，唯一 内部的订单号
UserId int NOT NULL,                                                                      --会员ID
ShopSysNo int NOT NULL,                                                              --店铺ID，对应 T_InforConfigure 表 sysno
GoodsSysNo int NOT NULL,                                                           --店铺商品ID 对应 T_ShopGoods 表的 sysno
GoodsName NVARCHAR(512) NOT NULL,                                      --商品名称
RechargeAmount DECIMAL(18, 2) NOT NULL,                                --充值金额，低佣金不足时充值的金额
PaymentNumber VARCHAR(128)  NULL,                                           --外部的支付流水
PayTime DATETIME NULL,                                                               --支付时间
PayState int NOT NULL,                                                                  --支付状态，0 未支付 1 支付中 2 支付成功
IsUse int NOT NULL,                                                                       --是否已经被使用 0 未支付成功  1 未被使用 2已经使用
RowCeateDate DATETIME NOT NULL,                                             --创建时间
ModifyTime DATETIME NULL,                                                          --修改时间
IsEnable BIT NOT NULL                                                                   --是否启用 true 启用 0 禁用
)
go

--创建题目表
CREATE TABLE T_Subject
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
InforSysNo  int NOT NULL,                                                           --问题，对应 T_InforConfigure 表sysno，为0则，表示是由答案引发的题目
ProblemNameUrl VARCHAR(max) NOT NULL,                                --题目的名称，是一个图片的地址
AnswerMoney DECIMAL(18, 2) NOT NULL,                                   --答题金额
IntSort int NOT NULL,                                                                   --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建题目答案表
CREATE TABLE T_Answer
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
SubSysNo int NOT NULL,                                                              --题目ID，对应 T_Subject 表 sysno
ChildrenSubSysNo int NOT NULL,                                                 --下级题目ID，对应 T_Subject 表 sysno
AnswerNameUrl VARCHAR(max) NOT NULL,                                 --题目答案，是一个图片的地址
IntSort int NOT NULL,                                                                   --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建答题记录表
CREATE TABLE T_AnswerRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
UserId int NOT NULL,                                                                   --会员表
SubSysNo int NOT NULL,                                                              --题目ID，对应 T_Subject 表 sysno
AnsSysNo int NOT NULL,                                                              --题目答案ID，对应 T_Answer 表 sysno
AnswerMoney DECIMAL(18, 2) NOT NULL,                                   --答题金额
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建h5分享未注册会员答题记录表
CREATE TABLE T_ShareAnswerRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
Mobile varchar(11) NOT  NULL,                                                     --分享答题人的手机号码
SubSysNo int NOT NULL,                                                              --题目ID，对应 T_Subject 表 sysno
AnsSysNo int NOT NULL,                                                              --题目答案ID，对应 T_Answer 表 sysno
AnswerMoney DECIMAL(18, 2) NOT NULL,                                                --答题金额
IsTransfer int NOT NULL,                                                              --是否已经迁移到答题记录表  0 未迁移  1 已迁移
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go


--创建账户中心推荐数据配置表
CREATE TABLE T_AccountRecommend
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
UserId int NOT NULL,                                                                    --会员ID
InforSysNo  int NOT NULL,                                                           --信息ID，对应 T_InforConfigure 表sysno
IsPushIn int NOT NULL,                                                                --站内是否推送，红点展示，0 未推送 1 推送  2推送失败
--IsPushOut int NOT NULL,                                                           --站外是否推送，红点展示，0 未推送 1 推送  2推送失败   不用了
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建答题完毕之后推荐商品表
--说明：如果根据答案ID在当前表查询不到数据记录(未配置)，则会去 T_InforConfigure 表找当前广告问题绑定的店铺ID，然后拉取这个店铺下面的所有商品
--如果找不到店铺表，则不会展示推荐数据
CREATE TABLE T_AnswerRecommend
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
AnsSysNo int NOT NULL,                                                              --题目答案ID，对应 T_Answer 表 sysno
GoodsSysNo int NOT NULL,                                                          --商品ID，对应 T_ShopGoods 表 sysno
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建收藏咨询表
CREATE TABLE T_Favorites
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
UserId int NOT NULL,                                                                    --会员ID
InforSysNo  int NOT NULL,                                                           --信息ID，对应 T_InforConfigure 表sysno
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建积分转让记录表  不要当前表了，直接更改 T_Member 会员表的记录
--CREATE TABLE T_ScoreTurnRecord
--(
--SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
--UserId int NOT NULL,                                                                    --会员ID，申请人
--FatherId int NOT NULL,                                                                --父级ID，对于当前表的 sysno，为 0 则说明是客户首次发起转让，否则就是后台管理分批次在处理
--TurnScore DECIMAL(18, 2) NOT NULL,                                         --转让的积分
--TurnState int NOT NULL,                                                              --处理状态 0 待处理， 1 处理中  2 处理完成
--RowCeateDate DATETIME NOT NULL,                                           --创建时间
--ModifyTime DATETIME NULL,                                                        --修改时间
--IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
--)
--go



--创建提现记录表
CREATE TABLE T_Withdrawals
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
UserId int NOT NULL,                                                                    --会员ID，申请人
OpenidWxOpen NVARCHAR (256)  NULL,                                     --微信开发平台标识              
OpenidWxMp NVARCHAR(256)  NULL,                                         --微信公众号标识
WithdrawalsMoney DECIMAL(18, 2) NOT NULL,                            --提现金额，单位：元
WithdrawalsState int NOT NULL,                                                   --提现状态，0 待处理  1 处理中 2成功（已经发放包含给客户）
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建极光推送用户ID表
CREATE TABLE T_JiGuangPush
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
UserId int NOT NULL,                                                                    --会员ID，申请人
JiGuangSysNo VARCHAR(256)  NOT NULL,                                   --极光的唯一用户表示
SourceTypeSysNo INT NOT NULL,                                                 --来源 1 安卓  2 IOS
RowCeateDate DATETIME NOT NULL,                                           --创建时间
ModifyTime DATETIME NULL,                                                        --修改时间
IsEnable BIT NOT NULL                                                                 --是否启用 true 启用 0 禁用
)
go

--创建极光推送记录表
CREATE TABLE T_JiGuangPushRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
UserId int  NULL,                                                                           --会员ID，申请人
JiGuangSysNo VARCHAR(256)  NOT NULL,                                   --极光的唯一用户表示
MsgTitle NVARCHAR(256)   NULL,                                                 --消息标题
MsgAlert NVARCHAR(256) NOT   NULL,                                        --消息aler
MsgContent NVARCHAR(512)   NULL,                                           --消息内容
PushMsgId VARCHAR(256)   NULL,                                                --推送结果的ID
PushResult  VARCHAR(256)   NULL,                                                --推送结果状态
SourceTypeSysNo INT  NULL,                                                         --推送的平台 1 安卓  2 IOS
RowCeateDate DATETIME NOT NULL,                                             --创建时间
ModifyTime DATETIME NULL,                                                          --修改时间
IsEnable BIT NOT NULL                                                                   --是否启用 true 启用 0 禁用
)
go


--2017-12-05新增自媒体类别
--新建自媒体作者信息表
CREATE TABLE T_SelfMediaAuthor
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --作者信息ID，自增长，主键，唯一
AuthorName NVARCHAR(10) NOT NULL,                              --作者名称
Portrait NVARCHAR(max) NULL,                                   --作者头像
Describe NVARCHAR(256) NULL,                                   --作者描述信息，如：专注互联网行业资深编辑
Score DECIMAL(18, 2) NOT NULL,                                 --当前作者的积分
RowCeateDate DATETIME NOT NULL,                                --创建时间
ModifyTime DATETIME NULL,                                      --修改时间
IsEnable BIT NOT NULL                                          --是否启用 true 启用 0 禁用
)
go


--创建作者文章信息
CREATE TABLE T_SelfMediaArticle
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --文章ID，自增长，主键，唯一
StrInforType VARCHAR(512) NOT NULL,                            --信息类型 0 所有  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女，格式：(1),(2),(3)
AuthorSysNo int NOT NULL,                                      --作者ID，对应 T_SelfMediaAuthor 的 sysno
HeadPic VARCHAR(max) NOT NULL,                                 --头图(左右、横排都是这个头图)
Title NVARCHAR(256) NOT NULL,                                  --文章标题
Subtitle NVARCHAR(512) NOT NULL,                               --文件副标题
Content NVARCHAR(max) NULL,                                    --文章内文，保存的是 html 格式
ReadScore DECIMAL(18, 2) NOT NULL,                             --阅读需要的积分
IsHot bit NOT NULL,                                            --是否热门文章
ShowMode int NOT NULL,                                         --展示方式  0 横排展示（店铺） 1 横排展示（广告，答题）  2 左右展示
IsShowIndex int NOT NULL,                                      --是否显示在首页，0 不显示   1 显示
SortId INT NULL,                                               --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                --创建时间
ModifyTime DATETIME NULL,                                      --修改时间
IsEnable BIT NOT NULL                                          --是否启用 true 启用 0 禁用
)
go

--首页红点记录表
CREATE TABLE T_SelfMediaRedDotRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --关注记录ID，自增长，主键，唯一
UserId int NOT NULL,                                           --会员ID
AuthorSysNo int NOT NULL,                                      --作者ID，对应 T_SelfMediaAuthor 的 sysno
ArticleSysNo int NOT NULL,                                     --文章ID，对应 T_SelfMediaArticle 的 sysno
RowCeateDate DATETIME NOT NULL,                                --创建时间
ModifyTime DATETIME NULL,                                      --修改时间
IsEnable BIT NOT NULL                                          --是否启用 true 启用 0 禁用
)
go


--创建关注记录表
CREATE TABLE T_SelfMediaFollowRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --关注记录ID，自增长，主键，唯一
UserId int NOT NULL,                                           --会员ID
AuthorSysNo int NOT NULL,                                      --作者ID，对应 T_SelfMediaAuthor 的 sysno
IsFollow bit NOT NULL,                                         --是否关注 取消关注再次关注，会做作废原记录在新增 true 关注  false 取消关注,
RowCeateDate DATETIME NOT NULL,                                --创建时间
ModifyTime DATETIME NULL,                                      --修改时间
IsEnable BIT NOT NULL                                          --是否启用 true 启用 0 禁用
)
go

--创建付费记录表
CREATE TABLE T_SelfMediaPayRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --关注记录ID，自增长，主键，唯一
UserId int NOT NULL,                                           --会员ID
AuthorSysNo int NOT NULL,                                      --作者ID，对应 T_SelfMediaAuthor 的 sysno
ArticleSysNo int NOT NULL,                                     --文章ID，对应 T_SelfMediaArticle 的 sysno
PayScore DECIMAL(18, 2) NOT NULL,                              --支付的积分
RowCeateDate DATETIME NOT NULL,                                --创建时间
ModifyTime DATETIME NULL,                                      --修改时间
IsEnable BIT NOT NULL                                          --是否启用 true 启用 0 禁用
)
go
 
--创建自媒体分享未注册会员记录表
CREATE TABLE T_SelfMediaSaveRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一
Mobile varchar(11) NOT NULL,                                                --填写的手机号码
AuthorSysNo int NOT NULL,                                                   --作者ID，对应 T_SelfMediaAuthor 的 sysno
ArticleSysNo int NOT NULL,                                                  --文章ID，对应 T_SelfMediaArticle 的 sysno
TranNum DECIMAL(18, 2) NULL,                                                --获取的低佣金
IsTransfer int NOT NULL,                                                    --是否已经注册并自动关注了作者  0 未迁移  1 已迁移
RowCeateDate DATETIME NOT NULL,                                             --创建时间
ModifyTime DATETIME NULL,                                                   --修改时间
IsEnable BIT NOT NULL                                                       --是否启用 true 启用 0 禁用
)
go


SELECT TOP 100 * FROM T_SelfMediaAuthor
SELECT TOP 100 * FROM T_SelfMediaArticle
SELECT TOP 100 * FROM T_SelfMediaFollowRecord
SELECT TOP 100 * FROM T_SelfMediaPayRecord

SELECT TOP 100 * FROM dbo.T_Member ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_Sms ORDER BY SysNo DESC
SELECT TOP 100 * FROM dbo.T_AccountRecord ORDER BY RowCeateDate DESC
SELECT TOP 100 * FROM dbo.T_OperationLog
SELECT TOP 100 * FROM dbo.T_Category ORDER BY IntSort DESC
SELECT TOP 100 * FROM dbo.T_ShareRegister ORDER BY SysNo DESC
SELECT TOP 100 * FROM dbo.Base_SaveApp
SELECT TOP 100 * FROM dbo.Base_Region WHERE regiontype = 3
SELECT TOP 100 * FROM  dbo.dbo.GlobalRecord
SELECT TOP 100 * FROM dbo.T_InforConfigure ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_ShopGoods ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_CouponInfo ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_CouponExcRecord ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_Subject ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_Answer ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_AnswerRecord ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_AccountRecommend ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_AnswerRecommend ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_Favorites ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_CouponPrivateCode ORDER BY SysNo ASC
SELECT TOP 100 * FROM dbo.T_InforConfigure
SELECT TOP 100 * FROM dbo.T_SelfMediaSaveRecord order by SysNo desc






