
--2018-07-03 Point 二版数据库脚本

USE point
go
  
select * from dbo.T_Category

--创建数据信息表（用于首页数据展示）
CREATE TABLE B_InforConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --主键，自增长
DataType int NOT NULL,                                                   --数据类型   1 广告（参与互动，领取红包）   2 推广(邀请好友，立享钜惠)
ShowCrowd VARCHAR(64) NOT NULL,                                          --展示的人群 0 所有  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女，格式：(1),(2),(3)
CoverPicUrl VARCHAR(max) NOT NULL,                                       --封面图片
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
CREATE TABLE T_AdvGoods
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --主键，自增长
AdvSysNo INT NOT NULL,                                                   --广告ID 对应 B_InforConfigure 表的主键
GoodsName NVARCHAR(512) NOT NULL,                                        --商品名称
GoodsPic VARCHAR(max) NOT NULL,                                          --商品图片地址
GoodsDetailedLink VARCHAR(max) NULL,                                     --商品明细连接地址，点击商品图片的地址 如果有值则说明可以点击商品，到这个链接去
GoodsExcLink VARCHAR(max) NULL,                                          --商品兑换链接地址，点击兑换按钮的地址 如果有值则说明可以点击商品，到这个链接去
MarketPrice DECIMAL(18, 4) NOT NULL,                                     --市场价格
PromotionPrice DECIMAL(18,4) NULL,                                       --促销价格
DeductibleMoney DECIMAL(18,4) NULL,                                      --抵扣金额
IntSort int NOT NULL,                                                    --排序，数值越大越靠前
RowCeateDate DATETIME NOT NULL,                                          --创建时间
ModifyTime DATETIME NULL,                                                --修改时间
IsEnable BIT NOT NULL                                                    --是否启用 true 启用 0 禁用
)
go








