
--2018-07-03 Point 二版数据库脚本

USE point
go
  
  
--创建会员表(非新增，调整字段)
CREATE TABLE T_Member
(
SysNo INT IDENTITY(10000,1) PRIMARY KEY,                                      --会员ID，自增长，主键，唯一
Mobile VARCHAR(11) NOT NULL,                                                  --登录手机号码
Portrait NVARCHAR(max) NULL,                                                  --肖像，用于存放会员头像
MemPassWord NVARCHAR(50) NOT NULL,                                            --会员账号，密码，保存密文
NickName NVARCHAR(50) NULL,                                                   --会员昵称
Sex INT NULL,                                                                 --会员性别，0 保密  1 男 2女
RegProvince INT NULL,                                                         --注册省份ID   默认值（不填写）：0 
RegCity INT NULL,                                                             --注册市ID     默认值（不填写）：0
RegArea INT NULL,                                                             --注册区县ID   默认值（不填写）：0
Birthday DATETIME NOT NULL,                                                   --会员生日     默认值（不填写）：null
InforType INT NOT NULL,                                                       --资讯类型  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女  100 没有填写生日的类型      2017-12-16调整为 0 没有选择性别  1 男  2 女

Account DECIMAL(18, 2) NOT NULL,                                              --账户总的可用现金，单位：元     2017-12-09改版确认不要了    2018-07-04 总的可提现金额，单位：元 如操作提现，一次性提完   
AccountWithdrawn DECIMAL(18, 2) NOT NULL,                                     --账号累积提现总现金，单位：元   2017-12-09改版确认不要了    
Score DECIMAL(18, 2) NOT NULL,                                                --账户总的可用抵用金金额，单位：元  未转化为RMBd的金额；2018-07-04 确认不要了 
ScoreWithdrawn DECIMAL(18,2) NOT NULL,                                        --账户累积提现低用金金额，单位：元  未转化为RMBd的金额；2018-07-04 确认不要了

--JpushId NVARCHAR(100)  NULL,                                                --推送标识          不要了
OpenidWxOpen NVARCHAR (256)  NULL,                                            --微信开发平台标识              
--OpenidWxMp NVARCHAR(100)  NULL,                                             --微信公众号标识    不要了
LastLoginTime DATETIME NULL,                                                  --最后一次登录时间
SourceTypeSysNo INT NOT NULL,                                                 --注册来源 1 安卓  2 IOS  0 没有来源渠道
DeviceCode  VARCHAR(256) NOT NULL,                                            --设备码  默认值：-1，IOS如果获取不到设备码，会给 0
MobileModel  VARCHAR(1024)  NULL,                                             --手机型号  安卓给的是手机型号；IOS可能给的手机屏幕尺寸，也可能手机型号
ClientIp VARCHAR(512) NOT NULL,                                               --注册IP  默认值：127.0.0.1
MinWithdrawals DECIMAL(18,2) NOT NULL DEFAULT 1,                              --最小提现额度  默认为：1.00 元，包含
RowCeateDate DATETIME NOT NULL,                                               --创建时间
ModifyTime DATETIME NULL,                                                     --修改时间
timestamp TIMESTAMP NOT NULL,                                                 --时间戳
)
go


--创建提现记录表
CREATE TABLE T_Withdrawals
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                   --主键，自增长，唯一
UserId int NOT NULL,                                                   --会员ID，申请人
OpenidWxOpen NVARCHAR (256)  NULL,                                     --微信开发平台标识              
--OpenidWxMp NVARCHAR(256)  NULL,                                        --微信公众号标识
WithdrawalsMoney DECIMAL(18, 4) NOT NULL,                              --提现金额，单位：元
WithdrawalsState int NOT NULL,                                         --提现状态，0 待处理  1 处理中 2成功（已经发放包含给客户）
RowCeateDate DATETIME NOT NULL,                                        --创建时间(申请时间)
ModifyTime DATETIME NULL,                                              --修改时间(实际发送红包时间，也就是 WithdrawalsState = 2 时的时间)
IsEnable BIT NOT NULL                                                  --是否启用 true 启用 0 禁用
)
go


--创建账号交易流水表
CREATE TABLE T_AccountRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                    --主键，自增长，唯一
TranType INT NOT NULL,                                  --交易类型  1 回答问题（参与互动）    2 邀请好友（分享好友）  4 转出积分  8 转入积分 16 现金提现 32 兑换商品(兑换抵扣劵)   64 阅读文章付费
PlusReduce INT NOT NULL,                                --交易获取或者使用 1增加 2 使用（减）
UserId INT NOT NULL,                                    --会员ID
TranNum DECIMAL(18, 2) NOT NULL,                        --交易数量
Company NVARCHAR(8) NOT NULL,                           --交易单位：积分、元
TranName NVARCHAR(64) NOT NULL,                         --交易说明
InRemarks NVARCHAR(512)  NULL,                          --内部备注，如：来源于哪里，关键ID等信息
IsPushIn int NOT NULL,                                  --站内是否推送，红点展示，0 未推送 1 推送  2推送失败
--IsPushOut int NOT NULL,                               --站外是否推送，红点展示，0 未推送 1 推送  2推送失败    不要了
Remark NVARCHAR(200) NULL,                              --备注信息
RowCeateDate DATETIME NOT NULL,                         --创建时间
IsEnable BIT NOT NULL,                                  --是否启用 true 启用 0 禁用
)
GO


----------------------------------------------------------------------------------------------------------------
--以下是新增的表

--创建数据信息表（用于首页数据展示）
CREATE TABLE B_InforConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,  --主键，自增长
DataType int NOT NULL,                --数据类型   1 广告（参与互动，领取红包）   2 推广(邀请好友，立享钜惠)
ShowCrowd VARCHAR(64) NOT NULL,       --展示的人群 0 所有  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女，格式：(1),(2),(3)
CoverPicUrl VARCHAR(max) NOT NULL,    --封面图片

ShopName nvarchar(128) NULL,          --店铺名称              当 DataType = 2 时，有店铺名称
LogoPicUrl VARCHAR(max) NULL,         --店铺logo图片          当 DataType = 2 时，有店铺logo
SetInvitationNum INT NULL,            --需要邀请的人数        当 DataType = 2 时，需要有邀请的人数
ReceiveType int not null,             --领取类型（当 DataType = 2 时有效）  1 站内补贴现金红包（CouponMoney 此时必须有值）   2 站外链接地址,此时会去 T_ReceiveConfigure 表找对应的记录
CouponMoney DECIMAL(18,4) NULL,       --优惠券金额            当 DataType = 2 时，需要优惠券金额

Title NVARCHAR(512) NULL,             --标题
DescOne NVARCHAR(256) NULL,           --描述1
DescTwo NVARCHAR(256) NULL,           --描述2
MarketPrice DECIMAL(18,4) NULL,       --市场价格
PromotionPrice DECIMAL(18,4) NULL,    --促销价格
RowCeateDate DATETIME NOT NULL,       --创建时间
ModifyTime DATETIME NULL,             --修改时间
IsEnable BIT NOT NULL                 --是否启用 true 启用 0 禁用
)
go

--创建 邀请/分享 好友记录表  
--H5页面收集收集号码 APP注册的根据注册的手机号码回写 CoverUserId 字段，形成闭环
CREATE TABLE B_ShareFriends
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                          --主键，自增长，唯一
ShareSysNo int NOT NULL,                                                      --分享的内容标识  对应 B_InforConfigure 表的主键
ShareUserId int NOT NULL,                                                     --分享人(发起人)的会员ID
CoverMobile varchar(11) NOT NULL,                                             --被分享人的手机号码
CoverUserId int NULL,                                                         --被分享人的会员ID
RowCeateDate DATETIME NOT NULL,                                               --创建时间
ModifyTime DATETIME NULL,                                                     --修改时间
IsEnable BIT NOT NULL                                                         --是否启用 true 启用 0 禁用
)

--创建邀请好友外部链接配置表
create table B_ReceiveConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                          --主键，自增长，唯一
RecSysNo INT not null,                                                        --对应 B_InforConfigure 表的 sysno 字段
ReceiveUrl varchar(max) not null,                                             --领取的地址
UserId int null,                                                              --关联的会员ID，有会员ID，则说明当前地址已经被当前会员绑定
RowCeateDate DATETIME NOT NULL,                                               --创建时间
ModifyTime DATETIME NULL,                                                     --修改时间
IsEnable BIT NOT NULL                                                         --是否启用 true 启用 0 禁用
)
go


--创建推荐数据配置表
--用于APP 手机桌面红点 以及 首页拉取的逻辑
--注册的时候直接在本表插入最近的三条信息ID，用于默认展示
--如果是邀请好友过来的，还需要把邀请的那条信息同时插入到这张表，否则首页不能显示这条数据
CREATE TABLE B_RecommendConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --主键，自增长，唯一D
DataType int not null,                                                      --数据类型 1 人工插入  2 系统插入（系统插入的不需要红点展示）
UserId int NOT NULL,                                                        --会员ID
InforSysNo int NOT NULL,                                                    --信息ID，对应 T_InforConfigure 表sysno
PushState int NOT NULL,                                                     --推送，红点展示，0 未推送(未读取) 1 推送
IntSort int NOT NULL,                                                       --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                             --创建时间
ModifyTime DATETIME NULL,                                                   --修改时间
IsEnable BIT NOT NULL                                                       --是否启用 true 启用 0 禁用
)
go

--创建广告商品表
CREATE TABLE B_AdvGoods
(
SysNo INT IDENTITY(1000,1) PRIMARY KEY,                                  --主键，自增长，商品ID
AdvSysNo INT NOT NULL,                                                   --广告ID 对应 B_InforConfigure 表的主键
CateId INT NOT NULL,                                                     --商品所属分类
GoodsName NVARCHAR(512) NOT NULL,                                        --商品名称
GoodsPic VARCHAR(max) NOT NULL,                                          --商品图片地址
GoodsDetailedLink VARCHAR(max) NULL,                                     --商品明细连接地址，点击商品图片的地址 如果有值则说明可以点击商品，到这个链接去
GoodsExcLink VARCHAR(max) NULL,                                          --商品兑换链接地址，点击兑换按钮的地址 如果有值则说明可以点击商品，到这个链接去
MarketPrice DECIMAL(18, 4) NOT NULL,                                     --市场价格
PromotionPrice DECIMAL(18,4) NULL,                                       --促销价格
DeductibleMoney DECIMAL(18,4) NULL,                                      --抵扣金额
CashBonus DECIMAL(18,4) NULL,                                            --现金红包 客户参与之后发给客户的红包金额 0 不给红包
CashBonusNum int NULL,                                                   --现金红包的总数量
IntSort int NOT NULL,                                                    --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                          --创建时间
ModifyTime DATETIME NULL,                                                --修改时间
IsEnable BIT NOT NULL                                                    --是否启用 true 启用 0 禁用
)
go 

--新增广告商品互动记录(红包领取记录表)
CREATE TABLE B_AdvGoodsRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --主键，自增长
UserId INT NOT NULL,                                                     --会员ID
AdvSysNo INT NOT NULL,                                                   --广告ID 对应 B_InforConfigure 表的 SysNo 主键
AdvGoodsSysNo INT NOT NULL,                                              --广告商品ID 对应 T_AdvGoods 表的 SysNo 主键
CashBonus DECIMAL(18,4) NULL,                                            --获取的现金红包 客户参与之后发给客户的红包金额
RowCeateDate DATETIME NOT NULL,                                          --创建时间
ModifyTime DATETIME NULL,                                                --修改时间
IsEnable BIT NOT NULL                                                    --是否启用 true 启用 0 禁用
)
go


--创建分类表
CREATE TABLE B_Category
(
SysNo INT IDENTITY(1,1) ,                                                    --主键，自增长，唯一
CateId INT PRIMARY KEY,                                                      --分类ID
CateName NVARCHAR(64) NOT NULL,                                              --分类名称
CateDescOne NVARCHAR(64) NOT NULL,                                           --分类描述信息1
CateDescTwo NVARCHAR(64) NOT NULL,                                           --分类描述信息2
CatePic VARCHAR(max) NULL,                                                   --分类图片
IntSort int NOT NULL,                                                        --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                              --创建时间
ModifyTime DATETIME NULL,                                                    --修改时间
IsEnable BIT NOT NULL                                                        --是否启用 true 启用 0 禁用
)
go


select * from dbo.B_RecommendConfigure

select * from dbo.B_InforConfigure

select * from dbo.B_AdvGoodsRecord
select * from dbo.B_AdvGoods
--insert into B_InforConfigure values (1,'0','封面图片','店铺名称','店铺logo图片',1,1,0,'标题','描述1','描述2',123,23,'2018-07-05 14:17:42.000','2018-07-05 14:17:42.000',1)
--insert into B_RecommendConfigure values (1,123,1,1,1,'2018-05-10 14:00:11.000','2018-05-10 14:00:11.000',1)

--insert into B_AdvGoods values(1,1,'商品名称','商品图片地址','商品明细连接地址','商品兑换链接地址',123,343,23,23,232,1,'2018-07-05 14:17:42.000','2018-07-05 14:17:42.000',1)
--insert into B_AdvGoodsRecord values(123,1,1,23,'2018-05-11 09:46:27.000','2018-05-11 09:46:27.000',1)

select * from dbo.T_MemB_AdvGoodsRecordber



