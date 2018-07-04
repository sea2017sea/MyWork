
--2018-07-03 Point 二版数据库脚本

USE point
go
  
  SELECT * FROM T_Member
  
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


--创建数据信息表（用于首页数据展示）
CREATE TABLE B_InforConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --主键，自增长
DataType int NOT NULL,                                                   --数据类型   1 广告（参与互动，领取红包）   2 推广(邀请好友，立享钜惠)
ShowCrowd VARCHAR(64) NOT NULL,                                          --展示的人群 0 所有  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女，格式：(1),(2),(3)
CoverPicUrl VARCHAR(max) NOT NULL,                                       --封面图片
ShopName nvarchar(128) NULL,                                             --店铺名称      当 DataType = 2 时，有店铺名称
LogoPicUrl VARCHAR(max) NULL,                                            --店铺logo图片  当 DataType = 2 时，有店铺logo
Title NVARCHAR(512) NULL,                                                --标题
DescOne NVARCHAR(256) NULL,                                              --描述1
DescTwo NVARCHAR(256) NULL,                                              --描述2
MarketPrice DECIMAL(18,4) NULL,                                          --市场价格
PromotionPrice DECIMAL(18,4) NULL,                                       --促销价格
IntSort int NOT NULL,                                                    --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                          --创建时间
ModifyTime DATETIME NULL,                                                --修改时间
IsEnable BIT NOT NULL                                                    --是否启用 true 启用 0 禁用
)
go


--创建广告商品表
CREATE TABLE B_AdvGoods
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --主键，自增长
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
--SetInvitationNum INT NULL,                                               --需要邀请的人数
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
AdvSysNo INT NOT NULL,                                                   --广告ID 对应 B_InforConfigure 表的主键
AdvGoodsSysNo INT NOT NULL,                                              --广告商品ID 对应 T_AdvGoods 表的主键
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

--创建 邀请/分享 好友记录表
CREATE TABLE B_ShareFriends
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                          --主键，自增长，唯一
ShareSysNo int NOT NULL,                                                      --分享的内容标识  对应 B_InforConfigure 表的主键
ShareUserId int NOT NULL,                                                     --分享人的会员ID
CoverMobile varchar(11) NOT NULL,                                             --被分享人的手机号码
CoverUserId int NULL,                                                         --被分享人的会员ID
IsReceive bit NOT NULL,                                                       --是否发放领取了奖励金额
RowCeateDate DATETIME NOT NULL,                                               --创建时间
ModifyTime DATETIME NULL,                                                     --修改时间
IsEnable BIT NOT NULL                                                         --是否启用 true 启用 0 禁用
)
go



