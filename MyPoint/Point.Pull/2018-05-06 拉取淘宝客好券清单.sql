
--taobao.tbk.dg.item.coupon.get (好券清单API【导购】)

create table Taobao_tbk_dg_item_coupon_get
(
SysNo int identity primary key,             --主机，自增
Shop_title nvarchar(256) null,              --店铺名称
User_type int null,                         --卖家类型，0表示集市，1表示商城
Zk_final_price nvarchar(32) null,           --折扣价
Title nvarchar(256) null,                   --商品标题
Nick nvarchar(64) null,                     --卖家昵称
Seller_id bigint null,                      --卖家id
Volume bigint null,                         --30天销量
Pict_url varchar(512) null,                 --商品主图
Item_url varchar(512) null,                 --商品详情页链接地址
Coupon_total_count bigint null,             --优惠券总量
Commission_rate varchar(32) null,           --佣金比率(%)
Coupon_info varchar(32) null,               --优惠券面额
Category int null,                          --后台一级类目
Num_iid bigint null,                        --itemId
Coupon_remain_count bigint null,            --优惠券剩余量
Coupon_start_time varchar(128) null,        --优惠券开始时间
Coupon_end_time varchar(128) null,          --优惠券结束时间
Coupon_click_url varchar(512) null,         --商品优惠券推广链接
Item_description nvarchar(256) null,        --宝贝描述（推荐理由）
Small_images nvarchar(max) null,            --商品小图列表
RowCreateTime datetime not null,            --创建时间
IsHandle bit not null                       --是否处理 true 已处理  false 未处理
)
go





select * from Taobao_tbk_dg_item_coupon_get order by sysno desc




