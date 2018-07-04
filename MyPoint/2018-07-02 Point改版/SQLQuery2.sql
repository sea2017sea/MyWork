
--2018-07-03 Point �������ݿ�ű�

USE point
go
  
  SELECT * FROM T_Member
  
--������Ա��(�������������ֶ�)
CREATE TABLE T_Member
(
SysNo INT IDENTITY(10000,1) PRIMARY KEY,                                      --��ԱID����������������Ψһ
Mobile VARCHAR(11) NOT NULL,                                                  --��¼�ֻ�����
Portrait NVARCHAR(max) NULL,                                                  --Ф�����ڴ�Ż�Աͷ��
MemPassWord NVARCHAR(50) NOT NULL,                                            --��Ա�˺ţ����룬��������
NickName NVARCHAR(50) NULL,                                                   --��Ա�ǳ�
Sex INT NULL,                                                                 --��Ա�Ա�0 ����  1 �� 2Ů
RegProvince INT NULL,                                                         --ע��ʡ��ID   Ĭ��ֵ������д����0 
RegCity INT NULL,                                                             --ע����ID     Ĭ��ֵ������д����0
RegArea INT NULL,                                                             --ע������ID   Ĭ��ֵ������д����0
Birthday DATETIME NOT NULL,                                                   --��Ա����     Ĭ��ֵ������д����null
InforType INT NOT NULL,                                                       --��Ѷ����  1 30��������  2 30��������  4 30������Ů   8 30������Ů  100 û����д���յ�����      2017-12-16����Ϊ 0 û��ѡ���Ա�  1 ��  2 Ů

Account DECIMAL(18, 2) NOT NULL,                                              --�˻��ܵĿ����ֽ𣬵�λ��Ԫ     2017-12-09�İ�ȷ�ϲ�Ҫ��    2018-07-04 �ܵĿ����ֽ���λ��Ԫ ��������֣�һ��������   
AccountWithdrawn DECIMAL(18, 2) NOT NULL,                                     --�˺��ۻ��������ֽ𣬵�λ��Ԫ   2017-12-09�İ�ȷ�ϲ�Ҫ��    
Score DECIMAL(18, 2) NOT NULL,                                                --�˻��ܵĿ��õ��ý����λ��Ԫ  δת��ΪRMBd�Ľ�2018-07-04 ȷ�ϲ�Ҫ�� 
ScoreWithdrawn DECIMAL(18,2) NOT NULL,                                        --�˻��ۻ����ֵ��ý����λ��Ԫ  δת��ΪRMBd�Ľ�2018-07-04 ȷ�ϲ�Ҫ��

--JpushId NVARCHAR(100)  NULL,                                                --���ͱ�ʶ          ��Ҫ��
OpenidWxOpen NVARCHAR (256)  NULL,                                            --΢�ſ���ƽ̨��ʶ              
--OpenidWxMp NVARCHAR(100)  NULL,                                             --΢�Ź��ںű�ʶ    ��Ҫ��
LastLoginTime DATETIME NULL,                                                  --���һ�ε�¼ʱ��
SourceTypeSysNo INT NOT NULL,                                                 --ע����Դ 1 ��׿  2 IOS  0 û����Դ����
DeviceCode  VARCHAR(256) NOT NULL,                                            --�豸��  Ĭ��ֵ��-1��IOS�����ȡ�����豸�룬��� 0
MobileModel  VARCHAR(1024)  NULL,                                             --�ֻ��ͺ�  ��׿�������ֻ��ͺţ�IOS���ܸ����ֻ���Ļ�ߴ磬Ҳ�����ֻ��ͺ�
ClientIp VARCHAR(512) NOT NULL,                                               --ע��IP  Ĭ��ֵ��127.0.0.1
MinWithdrawals DECIMAL(18,2) NOT NULL DEFAULT 1,                              --��С���ֶ��  Ĭ��Ϊ��1.00 Ԫ������
RowCeateDate DATETIME NOT NULL,                                               --����ʱ��
ModifyTime DATETIME NULL,                                                     --�޸�ʱ��
timestamp TIMESTAMP NOT NULL,                                                 --ʱ���
)
go


--����������Ϣ��������ҳ����չʾ��
CREATE TABLE B_InforConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --������������
DataType int NOT NULL,                                                   --��������   1 ��棨���뻥������ȡ�����   2 �ƹ�(������ѣ������һ�)
ShowCrowd VARCHAR(64) NOT NULL,                                          --չʾ����Ⱥ 0 ����  1 30��������  2 30��������  4 30������Ů   8 30������Ů����ʽ��(1),(2),(3)
CoverPicUrl VARCHAR(max) NOT NULL,                                       --����ͼƬ
ShopName nvarchar(128) NULL,                                             --��������      �� DataType = 2 ʱ���е�������
LogoPicUrl VARCHAR(max) NULL,                                            --����logoͼƬ  �� DataType = 2 ʱ���е���logo
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
CREATE TABLE B_AdvGoods
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --������������
AdvSysNo INT NOT NULL,                                                   --���ID ��Ӧ B_InforConfigure �������
CateId INT NOT NULL,                                                     --��Ʒ��������
GoodsName NVARCHAR(512) NOT NULL,                                        --��Ʒ����
GoodsPic VARCHAR(max) NOT NULL,                                          --��ƷͼƬ��ַ
GoodsDetailedLink VARCHAR(max) NULL,                                     --��Ʒ��ϸ���ӵ�ַ�������ƷͼƬ�ĵ�ַ �����ֵ��˵�����Ե����Ʒ�����������ȥ
GoodsExcLink VARCHAR(max) NULL,                                          --��Ʒ�һ����ӵ�ַ������һ���ť�ĵ�ַ �����ֵ��˵�����Ե����Ʒ�����������ȥ
MarketPrice DECIMAL(18, 4) NOT NULL,                                     --�г��۸�
PromotionPrice DECIMAL(18,4) NULL,                                       --�����۸�
DeductibleMoney DECIMAL(18,4) NULL,                                      --�ֿ۽��
CashBonus DECIMAL(18,4) NULL,                                            --�ֽ��� �ͻ�����֮�󷢸��ͻ��ĺ����� 0 �������
CashBonusNum int NULL,                                                   --�ֽ�����������
--SetInvitationNum INT NULL,                                               --��Ҫ���������
IntSort int NOT NULL,                                                    --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                          --����ʱ��
ModifyTime DATETIME NULL,                                                --�޸�ʱ��
IsEnable BIT NOT NULL                                                    --�Ƿ����� true ���� 0 ����
)
go

--���������Ʒ������¼(�����ȡ��¼��)
CREATE TABLE B_AdvGoodsRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --������������
UserId INT NOT NULL,                                                     --��ԱID
AdvSysNo INT NOT NULL,                                                   --���ID ��Ӧ B_InforConfigure �������
AdvGoodsSysNo INT NOT NULL,                                              --�����ƷID ��Ӧ T_AdvGoods �������
CashBonus DECIMAL(18,4) NULL,                                            --��ȡ���ֽ��� �ͻ�����֮�󷢸��ͻ��ĺ�����
RowCeateDate DATETIME NOT NULL,                                          --����ʱ��
ModifyTime DATETIME NULL,                                                --�޸�ʱ��
IsEnable BIT NOT NULL                                                    --�Ƿ����� true ���� 0 ����
)
go


--���������
CREATE TABLE B_Category
(
SysNo INT IDENTITY(1,1) ,                                                    --��������������Ψһ
CateId INT PRIMARY KEY,                                                      --����ID
CateName NVARCHAR(64) NOT NULL,                                              --��������
CateDescOne NVARCHAR(64) NOT NULL,                                           --����������Ϣ1
CateDescTwo NVARCHAR(64) NOT NULL,                                           --����������Ϣ2
CatePic VARCHAR(max) NULL,                                                   --����ͼƬ
IntSort int NOT NULL,                                                        --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                              --����ʱ��
ModifyTime DATETIME NULL,                                                    --�޸�ʱ��
IsEnable BIT NOT NULL                                                        --�Ƿ����� true ���� 0 ����
)
go

--���� ����/���� ���Ѽ�¼��
CREATE TABLE B_ShareFriends
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                          --��������������Ψһ
ShareSysNo int NOT NULL,                                                      --��������ݱ�ʶ  ��Ӧ B_InforConfigure �������
ShareUserId int NOT NULL,                                                     --�����˵Ļ�ԱID
CoverMobile varchar(11) NOT NULL,                                             --�������˵��ֻ�����
CoverUserId int NULL,                                                         --�������˵Ļ�ԱID
IsReceive bit NOT NULL,                                                       --�Ƿ񷢷���ȡ�˽������
RowCeateDate DATETIME NOT NULL,                                               --����ʱ��
ModifyTime DATETIME NULL,                                                     --�޸�ʱ��
IsEnable BIT NOT NULL                                                         --�Ƿ����� true ���� 0 ����
)
go



