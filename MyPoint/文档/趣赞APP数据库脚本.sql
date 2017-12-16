
--ָ����Ҫ���������ݿ�
USE point
GO

--������Ա��
CREATE TABLE T_Member
(
SysNo INT IDENTITY(10000,1) PRIMARY KEY,                                      --��ԱID����������������Ψһ
Mobile VARCHAR(11) NOT NULL,                                                        --��¼�ֻ�����
Portrait NVARCHAR(max) NULL,                                                           --Ф�����ڴ�Ż�Աͷ��
MemPassWord NVARCHAR(50) NOT NULL,                                         --��Ա�˺ţ����룬��������
NickName NVARCHAR(50) NULL,                                                        --��Ա�ǳ�
Sex INT NULL,                                                                                     --��Ա�Ա�0 ����  1 �� 2Ů
RegProvince INT NULL,                                                                        --ע��ʡ��ID   Ĭ��ֵ������д����0 
RegCity INT NULL,                                                                               --ע����ID  Ĭ��ֵ������д����0
RegArea INT NULL,                                                                              --ע������ID  Ĭ��ֵ������д����0
Birthday DATETIME NOT NULL,                                                           --��Ա���� Ĭ��ֵ������д����null
InforType INT NOT NULL,                                                                    --��Ѷ����  1 30��������  2 30��������  4 30������Ů   8 30������Ů  100 û����д���յ�����      2017-12-16����Ϊ 0 û��ѡ���Ա�  1 ��  2 Ů
Account DECIMAL(18, 2) NOT NULL,                                                   --�˻��ܵĿ����ֽ𣬵�λ��Ԫ     2017-12-09�İ�ȷ�ϲ�Ҫ��    
AccountWithdrawn DECIMAL(18, 2) NOT NULL,                                          --�˺��ۻ��������ֽ𣬵�λ��Ԫ   2017-12-09�İ�ȷ�ϲ�Ҫ��    
Score DECIMAL(18, 2) NOT NULL,                                                       --�˻��ܵĿ��õ��ý����λ��Ԫ  δת��ΪRMBd�Ľ��
ScoreWithdrawn DECIMAL(18,2) NOT NULL,                                               --�˻��ۻ����ֵ��ý����λ��Ԫ  δת��ΪRMBd�Ľ��
--JpushId NVARCHAR(100)  NULL,                                                       --���ͱ�ʶ  ��Ҫ��
OpenidWxOpen NVARCHAR (256)  NULL,                                           --΢�ſ���ƽ̨��ʶ              
--OpenidWxMp NVARCHAR(100)  NULL,                                             --΢�Ź��ںű�ʶ    ��Ҫ��
LastLoginTime DATETIME NULL,                                                          --���һ�ε�¼ʱ��
SourceTypeSysNo INT NOT NULL,                                                      --ע����Դ 1 ��׿  2 IOS  0 û����Դ����
DeviceCode  VARCHAR(256) NOT NULL,                                             --�豸��  Ĭ��ֵ��-1��IOS�����ȡ�����豸�룬��� 0
MobileModel  VARCHAR(1024)  NULL,                                                  --�ֻ��ͺ�  ��׿�������ֻ��ͺţ�IOS���ܸ����ֻ���Ļ�ߴ磬Ҳ�����ֻ��ͺ�
ClientIp VARCHAR(512) NOT NULL,                                                    --ע��IP  Ĭ��ֵ��127.0.0.1
MinWithdrawals DECIMAL(18,2) NOT NULL DEFAULT 1,                                --��С���ֶ��  Ĭ��Ϊ��1.00 Ԫ������
RowCeateDate DATETIME NOT NULL,                                                 --����ʱ��
ModifyTime DATETIME NULL,                                                              --�޸�ʱ��
timestamp TIMESTAMP NOT NULL,                                                     --ʱ���
)
go

--���Ͷ���
CREATE TABLE T_Sms
(
SysNo INT IDENTITY(1,1) PRIMARY KEY NOT NULL,        --��������������Ψһ
Mobile varchar(11) NOT NULL,                                        --�ֻ�����
SmsType INT NOT NULL,                                                 --���͵Ķ������ͣ�1 ע�� 2 ��¼ 4�����һ�    
SmsCode varchar(10) NOT NULL,                                     --��֤��
SmsStatus INT NOT NULL,                                              --��֤��״̬ 0 δ��֤  1�Ѿ���֤  2��֤ʧ��
ExpireTime DATETIME NOT NULL,                                   --����ʱ��
VerifTime DATETIME NULL,                                             --��֤ʱ��
RowCeateDate DATETIME NOT NULL,                             --�д���ʱ��
)
go

--�����˺Ž�����ˮ��
CREATE TABLE T_AccountRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                    --��������������Ψһ
TranType INT NOT NULL,                                          --��������  1 �ش����⣨���뻥����    2 ������ѣ�������ѣ�  4 ת������  8 ת����� 16 �ֽ����� 32 �һ���Ʒ(�һ��ֿۄ�)   64 �Ķ����¸���
PlusReduce INT NOT NULL,                                       --���׻�ȡ����ʹ�� 1���� 2 ʹ�ã�����
UserId INT NOT NULL,                                              --��ԱID
TranNum DECIMAL(18, 2) NOT NULL,                      --��������
Company NVARCHAR(8) NOT NULL,                        --���׵�λ�����֡�Ԫ
TranName NVARCHAR(64) NOT NULL,                     --����˵��
InRemarks NVARCHAR(512)  NULL,                         --�ڲ���ע���磺��Դ������ؼ�ID����Ϣ
IsPushIn int NOT NULL,                                            --վ���Ƿ����ͣ����չʾ��0 δ���� 1 ����  2����ʧ��
--IsPushOut int NOT NULL,                                      --վ���Ƿ����ͣ����չʾ��0 δ���� 1 ����  2����ʧ��    ��Ҫ��
Remark NVARCHAR(200) NULL,                               --��ע��Ϣ
RowCeateDate DATETIME NOT NULL,                      --����ʱ��
IsEnable BIT NOT NULL,                                           --�Ƿ����� true ���� 0 ����
)
GO


--����������־��
CREATE TABLE T_OperationLog
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                    --��������������Ψһ
OperType INT NOT NULL,                                          --�������� 1 ��¼�ɹ�  2��Ѷ���  4���̵�� 8�һ����
UserId INT NULL,                                                       --��ԱID
SourceTypeSysNo INT NOT NULL,                             --��Դ���� 1 ��׿  2 IOS
IdentityId VARCHAR(16)  NULL,                                 --��ʶID��ֻ��OperType Ϊ2 4 8ʱ����ID��Ϊ1û�У�Ϊ2 4 �� T_InforConfigure ��� SysNo��Ϊ 8 ʱ�� T_ShopGoods ��� SysNo
ClientIp VARCHAR(128) NOT NULL,                                                    --ע��IP
DeviceCode  VARCHAR(128) NOT NULL,                                             --�豸��
RowCeateDate DATETIME NOT NULL,                                                 --����ʱ��
)
go

--����������Ϣ��
CREATE TABLE Base_Region
(
RegionId INT NOT NULL,                                          --����ID
ParentId INT NULL,                                                   --���򸸼�ID
RegionName NVARCHAR(100) NULL,                        --��������
RegionType INT NULL,                                               --��������
ZipCode NVARCHAR(50) NULL,                                 --�ʱ�
QuHao NVARCHAR(50) NULL,                                   --����
ShortSpell CHAR(10) NULL,                                        --��ƴ������������ʹ��
SortId INT NULL,                                                       --������ֵԽ��Խ��ǰ
IsEnable BIT NOT NULL                                             --�Ƿ����� true ���� 0 ����
) 
GO


--��������ͻ��ֻ��ϰ�װ����ЩAPP��
CREATE TABLE Base_SaveApp
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                             --��������������Ψһ
Mobile varchar(11)  NULL,                                                                  --�ֻ�����
UserId int NULL,                                                                                  --��ԱID
DeviceCode  VARCHAR(512) NOT NULL,                                             --�豸��
AppName NVARCHAR(512) NULL,                                                       --APP����
SourceTypeSysNo INT NOT NULL,                                                      --��Դ���� 1 ��׿  2 IOS
ClientIp VARCHAR(512) NOT NULL,                                                    --�ͻ���IP
RowCeateDate DATETIME NOT NULL,                                                 --����ʱ��
ModifyTime DATETIME NULL,                                                              --�޸�ʱ��
IsEnable BIT NOT NULL                                                                        --�Ƿ����� true ���� 0 ����
)
go

--���������
CREATE TABLE T_Category
(
SysNo INT IDENTITY(1,1) ,                                                                 --��������������Ψһ
CateId INT PRIMARY KEY,                                                                  --����ID
CateName NVARCHAR(64) NOT NULL,                                              --��������
CatePic VARCHAR(max) NULL,                                                            --����ͼƬ
IntSort int NOT NULL,                                                                        --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                                --����ʱ��
ModifyTime DATETIME NULL,                                                             --�޸�ʱ��
IsEnable BIT NOT NULL                                                                      --�Ƿ����� true ���� 0 ����
)
go

--��������ע���¼��
CREATE TABLE T_ShareRegister
(
SysNo INT IDENTITY(1,1) ,                                                                 --��������������Ψһ
ShareSysNo int NOT NULL,                                                              --��������ݱ�ʶ
ShareUserId int NOT NULL,                                                               --�����˵Ļ�ԱID
CoverMobile varchar(11) NOT  NULL,                                                --�������˵��ֻ�����
CoverUserId int  NULL,                                                                      --�������˵Ļ�ԱID
IsReceive bit NOT NULL,                                                                    --�Ƿ񷢷���ȡ�˽������
RowCeateDate DATETIME NOT NULL,                                                --����ʱ��
ModifyTime DATETIME NULL,                                                             --�޸�ʱ��
IsEnable BIT NOT NULL                                                                      --�Ƿ����� true ���� 0 ����
)
go


--����������Ϣ��������ҳ����չʾ��
CREATE TABLE T_InforConfigure
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                     --������������
DataType int NOT NULL,                                                   --��������  1 ��ѯ������   2 ������ѯ(����)   4�����ѯ������ �� 8 ��ý������
StrInforType VARCHAR(512) NOT NULL,                                      --��Ϣ���� 0 ����  1 30��������  2 30��������  4 30������Ů   8 30������Ů����ʽ��(1),(2),(3)
InforName NVARCHAR(1024) NOT NULL,                                       --��Ϣ����
InforRemark NVARCHAR(1024)  NULL,                                        --��Ϣ�ı�ע��Ϣ���Լ���д���磺����
InforDesc NVARCHAR(1024) NOT NULL,                                       --��Ϣ����
LogoIcon VARCHAR(max) NULL,                                              --logoͼ�꣬���̵�logo
HeadPic VARCHAR(max) NOT NULL,                                           --ͷͼ(���ҡ����Ŷ������ͷͼ)
CoverPic VARCHAR(max) NULL,                                              --����ͼƬ
ShopPic VARCHAR(max) NULL,                                               --�����б�ͼƬ��ַ
PushPic VARCHAR(max) NULL,                                               --����ҳ��ͼƬ��ַ
VideoUrl VARCHAR(Max)  NULL,                                             --��Ƶ��ַ
CateId int NULL,                                                         --���̵ķ���ID��ֻ�� InforType Ϊ 2 ʱ������
ShopSysNo int NULL,                                                      --���̵�ID��ֻ�� InforType Ϊ 4 ʱ�������Ӧ��ǰ�� InforType = 2 ʱ�ĵ���ID�����ڴ������֮����Ƽ���Ʒ    InforType = 1 ��ʱ����д��ֵ����ʾ��ǰ������Լ��ĵ��� 
ShowMode int NOT NULL,                                                   --չʾ��ʽ  0 ����չʾ�����̣� 1 ����չʾ����棬���⣩  2 ����չʾ
InforSource NVARCHAR(1024) NOT NULL,                                     --��Դ������Ա�ֶ���д���磺���ˡ���Ѷ
LinkUrl VARCHAR(max) NULL,                                               --��ת���ӵ�ַ
IntSort int NOT NULL,                                                    --������ֵԽ��Խ��ǰ
IsShowIndex int NOT NULL,                                                --�Ƿ���ʾ����ҳ��0 ����ʾ   1 ��ʾ ע�������� DataType ������Ч
SourceDateTime DATETIME NOT NULL,                                        --��Դʱ��
RowCeateDate DATETIME NOT NULL,                                          --����ʱ��
ModifyTime DATETIME NULL,                                                --�޸�ʱ��
IsEnable BIT NOT NULL                                                    --�Ƿ����� true ���� 0 ����
)
go

--����������Ʒ��Ϣ��
CREATE TABLE T_ShopGoods
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
ShopSysNo int NOT NULL,                                                            --����ID����Ӧ T_InforConfigure ��sysno
GoodsName NVARCHAR(512) NOT NULL,                                    --��Ʒ����
GoodsPic VARCHAR(max) NOT NULL,                                            --��ƷͼƬ��ַ
GoodsOutLink VARCHAR(max) NULL,                                            --��Ʒ���ӵ�ַ �����ֵ��˵�����Ե����Ʒ�����������ȥ
MarketPrice DECIMAL(18, 2) NOT NULL,                                      --�г��۸��ŵ�۸�
GoodsLabelOne NVARCHAR(64) NOT NULL,                                 --��Ʒ��ǩ   �磺Ů��������Ʒ
GoodsLabelTwo NVARCHAR(64) NOT NULL,                                 --��Ʒ��ǩ   �磺�С�������Ʒ
ExcCouponSysNo int NOT NULL,                                                  --�һ��ֿۄ�ID����ȡ���ֿ۾�Ľ���Ӧ T_CouponInfo ���SysNo
CouponCount int NOT NULL,                                                       --�ֿۄ�����
UseCouponCount int NOT NULL,                                                 --�ֿۄ�ʹ������
OverCouponCount int NOT NULL,                                               --�ֿۄ�ʣ������
IntSort int NOT NULL,                                                                  --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                       --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go

--�����ֿۄ���
CREATE TABLE T_CouponInfo
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
ShopSysNo int NOT NULL,                                                            --����ID����Ӧ T_InforConfigure ��sysno
CouponName NVARCHAR(512) NOT NULL,                                  --�ֿۄ�����
ExcAmount DECIMAL(18, 2) NOT NULL,                                       --�ֿ۽��
CouponType int NOT NULL,                                                          --�ֿۄ������� 1 ����  2 ��ά�롢������  4 ����  8 ˽��
CouponCode NVARCHAR(512) NULL,                                           --�ֿۄ���ֵ���ֿۄ�����Ϊ8ʱ����ǰֵΪ�գ���������Ϊ��
UseRule NVARCHAR(128) NOT NULL,                                           --ʹ�ù���
RuleContent NVARCHAR(512) NOT NULL,                                    --��������
RowCeateDate DATETIME NOT NULL,                                          --����ʱ��
ModifyTime DATETIME NULL,                                                       --�޸�ʱ��
IsEnable BIT NOT NULL                                                                --�Ƿ����� true ���� 0 ����
)
go

--����˽���
CREATE TABLE T_CouponPrivateCode
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
CouponSysNo int NOT NULL,                                                        --��Ӧ T_CouponInfo �ĵֿۄ�ID
PrivateCode VARCHAR(20) NOT NULL,                                           --��
UserId int NULL,                                                                             --��ԱID����ֵ���Ҵ���0����ʾ��ʹ��
ExcDateTime DATETIME NULL,                                                        --�һ�ʱ�� 
RowCeateDate DATETIME NOT NULL,                                             --����ʱ��
ModifyTime DATETIME NULL,                                                          --�޸�ʱ��
IsEnable BIT NOT NULL                                                                    --�Ƿ����� true ���� 0 ����
)
go



--�����ֿۄ��һ���¼��
CREATE TABLE T_CouponExcRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
UserId int NOT NULL,                                                                    --��ԱID
ShopSysNo int NOT NULL,                                                            --����ID����Ӧ T_InforConfigure �� sysno
GoodsSysNo int NOT NULL,                                                           --������ƷID ��Ӧ T_ShopGoods ��� sysno
CouponSysNo int NOT NULL,                                                       --�ֿ۾�ID����Ӧ T_CouponInfo ��� sysno
PrivateCode VARCHAR(20) NULL,                                                  --��
ExcAmount DECIMAL(18, 2) NOT NULL,                                       --�ֿ۽��
UseScore DECIMAL(18, 2) NOT NULL,                                          --ʹ�õĵ��ý���
RechargeAmount DECIMAL(18, 2) NOT NULL,                              --��ֵ����Ӷ����ʱ��ֵ�Ľ��
RowCeateDate DATETIME NOT NULL,                                          --����ʱ��
ModifyTime DATETIME NULL,                                                       --�޸�ʱ��
CouponState int NOT NULL,                                                         --�ֿۄ�״̬  0 ��Ч  1 ��Ч  2 ��ʹ�� �������ֶ��������ݿ�״̬��һ�����ڿͻ�ʹ����֮�󣬹���������Ϊ��Ч��ǰ�������ʾ��ǰ�ֿۄ�Ϊ��Ч״̬����ǰ���Ѿ��ÿ��Բ鿴��ǰ����
IsEnable BIT NOT NULL                                                                --�Ƿ����� true ���� 0 ����
)
go

--������ֵ��¼��
CREATE TABLE T_Recharge
(
SysNo INT IDENTITY(1000,1) PRIMARY KEY,                                   --��������������Ψһ �ڲ��Ķ�����
UserId int NOT NULL,                                                                      --��ԱID
ShopSysNo int NOT NULL,                                                              --����ID����Ӧ T_InforConfigure �� sysno
GoodsSysNo int NOT NULL,                                                           --������ƷID ��Ӧ T_ShopGoods ��� sysno
GoodsName NVARCHAR(512) NOT NULL,                                      --��Ʒ����
RechargeAmount DECIMAL(18, 2) NOT NULL,                                --��ֵ����Ӷ����ʱ��ֵ�Ľ��
PaymentNumber VARCHAR(128)  NULL,                                           --�ⲿ��֧����ˮ
PayTime DATETIME NULL,                                                               --֧��ʱ��
PayState int NOT NULL,                                                                  --֧��״̬��0 δ֧�� 1 ֧���� 2 ֧���ɹ�
IsUse int NOT NULL,                                                                       --�Ƿ��Ѿ���ʹ�� 0 δ֧���ɹ�  1 δ��ʹ�� 2�Ѿ�ʹ��
RowCeateDate DATETIME NOT NULL,                                             --����ʱ��
ModifyTime DATETIME NULL,                                                          --�޸�ʱ��
IsEnable BIT NOT NULL                                                                   --�Ƿ����� true ���� 0 ����
)
go

--������Ŀ��
CREATE TABLE T_Subject
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
InforSysNo  int NOT NULL,                                                           --���⣬��Ӧ T_InforConfigure ��sysno��Ϊ0�򣬱�ʾ���ɴ���������Ŀ
ProblemNameUrl VARCHAR(max) NOT NULL,                                --��Ŀ�����ƣ���һ��ͼƬ�ĵ�ַ
AnswerMoney DECIMAL(18, 2) NOT NULL,                                   --������
IntSort int NOT NULL,                                                                   --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go

--������Ŀ�𰸱�
CREATE TABLE T_Answer
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
SubSysNo int NOT NULL,                                                              --��ĿID����Ӧ T_Subject �� sysno
ChildrenSubSysNo int NOT NULL,                                                 --�¼���ĿID����Ӧ T_Subject �� sysno
AnswerNameUrl VARCHAR(max) NOT NULL,                                 --��Ŀ�𰸣���һ��ͼƬ�ĵ�ַ
IntSort int NOT NULL,                                                                   --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go



--���������¼��
CREATE TABLE T_AnswerRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
UserId int NOT NULL,                                                                   --��Ա��
SubSysNo int NOT NULL,                                                              --��ĿID����Ӧ T_Subject �� sysno
AnsSysNo int NOT NULL,                                                              --��Ŀ��ID����Ӧ T_Answer �� sysno
AnswerMoney DECIMAL(18, 2) NOT NULL,                                   --������
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go

--����h5����δע���Ա�����¼��
CREATE TABLE T_ShareAnswerRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
Mobile varchar(11) NOT  NULL,                                                     --��������˵��ֻ�����
SubSysNo int NOT NULL,                                                              --��ĿID����Ӧ T_Subject �� sysno
AnsSysNo int NOT NULL,                                                              --��Ŀ��ID����Ӧ T_Answer �� sysno
AnswerMoney DECIMAL(18, 2) NOT NULL,                                   --������
IsTransfer int NOT NULL,                                                              --�Ƿ��Ѿ�Ǩ�Ƶ������¼��  0 δǨ��  1 ��Ǩ��
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go


--�����˻������Ƽ��������ñ�
CREATE TABLE T_AccountRecommend
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
UserId int NOT NULL,                                                                    --��ԱID
InforSysNo  int NOT NULL,                                                           --��ϢID����Ӧ T_InforConfigure ��sysno
IsPushIn int NOT NULL,                                                                --վ���Ƿ����ͣ����չʾ��0 δ���� 1 ����  2����ʧ��
--IsPushOut int NOT NULL,                                                           --վ���Ƿ����ͣ����չʾ��0 δ���� 1 ����  2����ʧ��   ������
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go

--�����������֮���Ƽ���Ʒ��
--˵����������ݴ�ID�ڵ�ǰ���ѯ�������ݼ�¼(δ����)�����ȥ T_InforConfigure ���ҵ�ǰ�������󶨵ĵ���ID��Ȼ����ȡ������������������Ʒ
--����Ҳ������̱��򲻻�չʾ�Ƽ�����
CREATE TABLE T_AnswerRecommend
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
AnsSysNo int NOT NULL,                                                              --��Ŀ��ID����Ӧ T_Answer �� sysno
GoodsSysNo int NOT NULL,                                                          --��ƷID����Ӧ T_ShopGoods �� sysno
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go

--�����ղ���ѯ��
CREATE TABLE T_Favorites
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
UserId int NOT NULL,                                                                    --��ԱID
InforSysNo  int NOT NULL,                                                           --��ϢID����Ӧ T_InforConfigure ��sysno
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go

--��������ת�ü�¼��  ��Ҫ��ǰ���ˣ�ֱ�Ӹ��� T_Member ��Ա��ļ�¼
--CREATE TABLE T_ScoreTurnRecord
--(
--SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
--UserId int NOT NULL,                                                                    --��ԱID��������
--FatherId int NOT NULL,                                                                --����ID�����ڵ�ǰ��� sysno��Ϊ 0 ��˵���ǿͻ��״η���ת�ã�������Ǻ�̨����������ڴ���
--TurnScore DECIMAL(18, 2) NOT NULL,                                         --ת�õĻ���
--TurnState int NOT NULL,                                                              --����״̬ 0 ������ 1 ������  2 �������
--RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
--ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
--IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
--)
--go



--�������ּ�¼��
CREATE TABLE T_Withdrawals
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
UserId int NOT NULL,                                                                    --��ԱID��������
OpenidWxOpen NVARCHAR (256)  NULL,                                     --΢�ſ���ƽ̨��ʶ              
OpenidWxMp NVARCHAR(256)  NULL,                                         --΢�Ź��ںű�ʶ
WithdrawalsMoney DECIMAL(18, 2) NOT NULL,                            --���ֽ���λ��Ԫ
WithdrawalsState int NOT NULL,                                                   --����״̬��0 ������  1 ������ 2�ɹ����Ѿ����Ű������ͻ���
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go

--�������������û�ID��
CREATE TABLE T_JiGuangPush
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
UserId int NOT NULL,                                                                    --��ԱID��������
JiGuangSysNo VARCHAR(256)  NOT NULL,                                   --�����Ψһ�û���ʾ
SourceTypeSysNo INT NOT NULL,                                                 --��Դ 1 ��׿  2 IOS
RowCeateDate DATETIME NOT NULL,                                           --����ʱ��
ModifyTime DATETIME NULL,                                                        --�޸�ʱ��
IsEnable BIT NOT NULL                                                                 --�Ƿ����� true ���� 0 ����
)
go

--�����������ͼ�¼��
CREATE TABLE T_JiGuangPushRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                                        --��������������Ψһ
UserId int  NULL,                                                                           --��ԱID��������
JiGuangSysNo VARCHAR(256)  NOT NULL,                                   --�����Ψһ�û���ʾ
MsgTitle NVARCHAR(256)   NULL,                                                 --��Ϣ����
MsgAlert NVARCHAR(256) NOT   NULL,                                        --��Ϣaler
MsgContent NVARCHAR(512)   NULL,                                           --��Ϣ����
PushMsgId VARCHAR(256)   NULL,                                                --���ͽ����ID
PushResult  VARCHAR(256)   NULL,                                                --���ͽ��״̬
SourceTypeSysNo INT  NULL,                                                         --���͵�ƽ̨ 1 ��׿  2 IOS
RowCeateDate DATETIME NOT NULL,                                             --����ʱ��
ModifyTime DATETIME NULL,                                                          --�޸�ʱ��
IsEnable BIT NOT NULL                                                                   --�Ƿ����� true ���� 0 ����
)
go


--2017-12-05������ý�����
--�½���ý��������Ϣ��
CREATE TABLE T_SelfMediaAuthor
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --������ϢID����������������Ψһ
AuthorName NVARCHAR(10) NOT NULL,                              --��������
Portrait NVARCHAR(max) NULL,                                   --����ͷ��
Describe NVARCHAR(256) NULL,                                   --����������Ϣ���磺רע��������ҵ����༭
Score DECIMAL(18, 2) NOT NULL,                                 --��ǰ���ߵĻ���
RowCeateDate DATETIME NOT NULL,                                --����ʱ��
ModifyTime DATETIME NULL,                                      --�޸�ʱ��
IsEnable BIT NOT NULL                                          --�Ƿ����� true ���� 0 ����
)
go


--��������������Ϣ
CREATE TABLE T_SelfMediaArticle
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --����ID����������������Ψһ
StrInforType VARCHAR(512) NOT NULL,                            --��Ϣ���� 0 ����  1 30��������  2 30��������  4 30������Ů   8 30������Ů����ʽ��(1),(2),(3)
AuthorSysNo int NOT NULL,                                      --����ID����Ӧ T_SelfMediaAuthor �� sysno
HeadPic VARCHAR(max) NOT NULL,                                 --ͷͼ(���ҡ����Ŷ������ͷͼ)
Title NVARCHAR(256) NOT NULL,                                  --���±���
Subtitle NVARCHAR(512) NOT NULL,                               --�ļ�������
Content NVARCHAR(max) NULL,                                    --�������ģ�������� html ��ʽ
ReadScore DECIMAL(18, 2) NOT NULL,                             --�Ķ���Ҫ�Ļ���
IsHot bit NOT NULL,                                            --�Ƿ���������
ShowMode int NOT NULL,                                         --չʾ��ʽ  0 ����չʾ�����̣� 1 ����չʾ����棬���⣩  2 ����չʾ
IsShowIndex int NOT NULL,                                      --�Ƿ���ʾ����ҳ��0 ����ʾ   1 ��ʾ
SortId INT NULL,                                               --������ֵԽ��Խ��ǰ
RowCeateDate DATETIME NOT NULL,                                --����ʱ��
ModifyTime DATETIME NULL,                                      --�޸�ʱ��
IsEnable BIT NOT NULL                                          --�Ƿ����� true ���� 0 ����
)
go

--��ҳ����¼��
CREATE TABLE T_SelfMediaRedDotRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --��ע��¼ID����������������Ψһ
UserId int NOT NULL,                                           --��ԱID
AuthorSysNo int NOT NULL,                                      --����ID����Ӧ T_SelfMediaAuthor �� sysno
ArticleSysNo int NOT NULL,                                     --����ID����Ӧ T_SelfMediaArticle �� sysno
RowCeateDate DATETIME NOT NULL,                                --����ʱ��
ModifyTime DATETIME NULL,                                      --�޸�ʱ��
IsEnable BIT NOT NULL                                          --�Ƿ����� true ���� 0 ����
)
go


--������ע��¼��
CREATE TABLE T_SelfMediaFollowRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --��ע��¼ID����������������Ψһ
UserId int NOT NULL,                                           --��ԱID
AuthorSysNo int NOT NULL,                                      --����ID����Ӧ T_SelfMediaAuthor �� sysno
IsFollow bit NOT NULL,                                         --�Ƿ��ע ȡ����ע�ٴι�ע����������ԭ��¼������ true ��ע  false ȡ����ע,
RowCeateDate DATETIME NOT NULL,                                --����ʱ��
ModifyTime DATETIME NULL,                                      --�޸�ʱ��
IsEnable BIT NOT NULL                                          --�Ƿ����� true ���� 0 ����
)
go

--�������Ѽ�¼��
CREATE TABLE T_SelfMediaPayRecord
(
SysNo INT IDENTITY(1,1) PRIMARY KEY,                           --��ע��¼ID����������������Ψһ
UserId int NOT NULL,                                           --��ԱID
AuthorSysNo int NOT NULL,                                      --����ID����Ӧ T_SelfMediaAuthor �� sysno
ArticleSysNo int NOT NULL,                                     --����ID����Ӧ T_SelfMediaArticle �� sysno
PayScore DECIMAL(18, 2) NOT NULL,                              --֧���Ļ���
RowCeateDate DATETIME NOT NULL,                                --����ʱ��
ModifyTime DATETIME NULL,                                      --�޸�ʱ��
IsEnable BIT NOT NULL                                          --�Ƿ����� true ���� 0 ����
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







