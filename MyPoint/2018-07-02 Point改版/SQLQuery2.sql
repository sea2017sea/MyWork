




--����������Ϣ��������ҳ����չʾ��
CREATE TABLE B_InforConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --������������
DataType int NOT NULL,                                                   --��������   1 ��棨���뻥������ȡ�����   2 �ƹ�(������ѣ������һ�)
ShowCrowd VARCHAR(64) NOT NULL,                                          --չʾ����Ⱥ 0 ����  1 30��������  2 30��������  4 30������Ů   8 30������Ů����ʽ��(1),(2),(3)
CoverPicUrl VARCHAR(max) NOT NULL,                                       --����ͼƬ
Title NVARCHAR(512) NULL,                                                --����
DescOne NVARCHAR(256) NULL,                                              --����1
DescTwo NVARCHAR(256) NULL,                                              --����2
MarketPrice DECIMAL(18,4) NULL,                                          --�г��۸�
PromotionPrice DECIMAL(18,4) NULL,                                       --�����۸�
IntSort int NOT NULL,                                                    --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                          --����ʱ��
ModifyTime DATETIME NULL,                                                --�޸�ʱ��
IsEnable BIT NOT NULL                                                    --�Ƿ����� true ���� 0 ����
)
go


--���������Ʒ��
CREATE TABLE T_AdvGoods
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --������������
AdvSysNo INT NOT NULL,                                                   --���ID ��Ӧ B_InforConfigure �������
GoodsName NVARCHAR(512) NOT NULL,                                        --��Ʒ����
GoodsPic VARCHAR(max) NOT NULL,                                          --��ƷͼƬ��ַ
GoodsDetailedLink VARCHAR(max) NULL,                                     --��Ʒ��ϸ���ӵ�ַ�������ƷͼƬ�ĵ�ַ �����ֵ��˵�����Ե����Ʒ�����������ȥ
GoodsExcLink VARCHAR(max) NULL,                                          --��Ʒ�һ����ӵ�ַ������һ���ť�ĵ�ַ �����ֵ��˵�����Ե����Ʒ�����������ȥ
MarketPrice DECIMAL(18, 4) NOT NULL,                                     --�г��۸�
PromotionPrice DECIMAL(18,4) NULL,                                       --�����۸�
DeductibleMoney DECIMAL(18,4) NULL,                                      --�ֿ۽��
IntSort int NOT NULL,                                                    --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                          --����ʱ��
ModifyTime DATETIME NULL,                                                --�޸�ʱ��
IsEnable BIT NOT NULL                                                    --�Ƿ����� true ���� 0 ����
)
go








