
--taobao.tbk.dg.item.coupon.get (��ȯ�嵥API��������)

create table Taobao_tbk_dg_item_coupon_get
(
SysNo int identity primary key,             --����������
Shop_title nvarchar(256) null,              --��������
User_type int null,                         --�������ͣ�0��ʾ���У�1��ʾ�̳�
Zk_final_price nvarchar(32) null,           --�ۿۼ�
Title nvarchar(256) null,                   --��Ʒ����
Nick nvarchar(64) null,                     --�����ǳ�
Seller_id bigint null,                      --����id
Volume bigint null,                         --30������
Pict_url varchar(512) null,                 --��Ʒ��ͼ
Item_url varchar(512) null,                 --��Ʒ����ҳ���ӵ�ַ
Coupon_total_count bigint null,             --�Ż�ȯ����
Commission_rate varchar(32) null,           --Ӷ�����(%)
Coupon_info varchar(32) null,               --�Ż�ȯ���
Category int null,                          --��̨һ����Ŀ
Num_iid bigint null,                        --itemId
Coupon_remain_count bigint null,            --�Ż�ȯʣ����
Coupon_start_time varchar(128) null,        --�Ż�ȯ��ʼʱ��
Coupon_end_time varchar(128) null,          --�Ż�ȯ����ʱ��
Coupon_click_url varchar(512) null,         --��Ʒ�Ż�ȯ�ƹ�����
Item_description nvarchar(256) null,        --�����������Ƽ����ɣ�
Small_images nvarchar(max) null,            --��ƷСͼ�б�
RowCreateTime datetime not null,            --����ʱ��
IsHandle bit not null                       --�Ƿ��� true �Ѵ���  false δ����
)
go





select * from Taobao_tbk_dg_item_coupon_get order by sysno desc




