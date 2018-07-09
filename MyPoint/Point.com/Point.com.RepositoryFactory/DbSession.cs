
 

using System;
using Point.com.IRepository;
using Point.com.Repository;
namespace Point.com.RepositoryFactory
{
    public partial class DbSession : IDbSession
    {
					private readonly string _dbConnectionStringHolycaDb= Configurator.DbConnectionString;

				public virtual string DbConnectionStringHolycaDb
				{
					get { return _dbConnectionStringHolycaDb; }
				}
				
				

				protected IHolycaDb _HolycaDb;
				public virtual IHolycaDb HolycaDb
				{
					get
					{
						if (null == _HolycaDb)
						{
							_HolycaDb = new HolycaDb(DbConnectionStringHolycaDb);
						}
						return _HolycaDb;
					}
				}
            				private readonly string _dbConnectionStringMLT= Configurator.DbConnectionString;

				public virtual string DbConnectionStringMLT
				{
					get { return _dbConnectionStringMLT; }
				}
				
				

				protected IMLT _MLT;
				public virtual IMLT MLT
				{
					get
					{
						if (null == _MLT)
						{
							_MLT = new MLT(DbConnectionStringMLT);
						}
						return _MLT;
					}
				}
            				private readonly string _dbConnectionStringBBHomeDb= Configurator.DbConnectionString;

				public virtual string DbConnectionStringBBHomeDb
				{
					get { return _dbConnectionStringBBHomeDb; }
				}
				
				

				protected IBBHomeDb _BBHomeDb;
				public virtual IBBHomeDb BBHomeDb
				{
					get
					{
						if (null == _BBHomeDb)
						{
							_BBHomeDb = new BBHomeDb(DbConnectionStringBBHomeDb);
						}
						return _BBHomeDb;
					}
				}
            	}

					public partial class HolycaDb :DbSingleSession{

					private readonly IUnitOfWork _unitOfWork;//= new UnitOfWork(_dbConnectionString);
					public HolycaDb(string dbConnectionString)
					{
						_unitOfWork = new UnitOfWork(dbConnectionString);
					}
					 public override IUnitOfWork UnitOfWork
					{
						get { return _unitOfWork; }
					}
				}
            				public partial class MLT :DbSingleSession{

					private readonly IUnitOfWork _unitOfWork;//= new UnitOfWork(_dbConnectionString);
					public MLT(string dbConnectionString)
					{
						_unitOfWork = new UnitOfWork(dbConnectionString);
					}
					 public override IUnitOfWork UnitOfWork
					{
						get { return _unitOfWork; }
					}
				}
            				public partial class BBHomeDb :DbSingleSession{

					private readonly IUnitOfWork _unitOfWork;//= new UnitOfWork(_dbConnectionString);
					public BBHomeDb(string dbConnectionString)
					{
						_unitOfWork = new UnitOfWork(dbConnectionString);
					}
					 public override IUnitOfWork UnitOfWork
					{
						get { return _unitOfWork; }
					}
				}
            
	                  public partial class HolycaDb:IHolycaDb
				  {					
					private IBase_DeliverRepository _Base_DeliverRepository;
					public virtual string Base_DeliverTableName{
						get{
							return "Base_Deliver";
						}
					}
					public IBase_DeliverRepository Base_DeliverRepository
					{
						get
						{
							if (null == _Base_DeliverRepository)
							{
								_Base_DeliverRepository = new Base_DeliverRepository(this._unitOfWork,Base_DeliverTableName);
							}
							return _Base_DeliverRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IBase_RegionRepository _Base_RegionRepository;
					public virtual string Base_RegionTableName{
						get{
							return "Base_Region";
						}
					}
					public IBase_RegionRepository Base_RegionRepository
					{
						get
						{
							if (null == _Base_RegionRepository)
							{
								_Base_RegionRepository = new Base_RegionRepository(this._unitOfWork,Base_RegionTableName);
							}
							return _Base_RegionRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IBase_SaveAppRepository _Base_SaveAppRepository;
					public virtual string Base_SaveAppTableName{
						get{
							return "Base_SaveApp";
						}
					}
					public IBase_SaveAppRepository Base_SaveAppRepository
					{
						get
						{
							if (null == _Base_SaveAppRepository)
							{
								_Base_SaveAppRepository = new Base_SaveAppRepository(this._unitOfWork,Base_SaveAppTableName);
							}
							return _Base_SaveAppRepository;
						}
					}
				  }  
                                  public partial class BBHomeDb:IBBHomeDb
				  {					
					private Ibase_t_memberRepository _base_t_memberRepository;
					public virtual string base_t_memberTableName{
						get{
							return "base_t_member";
						}
					}
					public Ibase_t_memberRepository base_t_memberRepository
					{
						get
						{
							if (null == _base_t_memberRepository)
							{
								_base_t_memberRepository = new base_t_memberRepository(this._unitOfWork,base_t_memberTableName);
							}
							return _base_t_memberRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IB_AdvGoodsRepository _B_AdvGoodsRepository;
					public virtual string B_AdvGoodsTableName{
						get{
							return "B_AdvGoods";
						}
					}
					public IB_AdvGoodsRepository B_AdvGoodsRepository
					{
						get
						{
							if (null == _B_AdvGoodsRepository)
							{
								_B_AdvGoodsRepository = new B_AdvGoodsRepository(this._unitOfWork,B_AdvGoodsTableName);
							}
							return _B_AdvGoodsRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IB_AdvGoodsRecordRepository _B_AdvGoodsRecordRepository;
					public virtual string B_AdvGoodsRecordTableName{
						get{
							return "B_AdvGoodsRecord";
						}
					}
					public IB_AdvGoodsRecordRepository B_AdvGoodsRecordRepository
					{
						get
						{
							if (null == _B_AdvGoodsRecordRepository)
							{
								_B_AdvGoodsRecordRepository = new B_AdvGoodsRecordRepository(this._unitOfWork,B_AdvGoodsRecordTableName);
							}
							return _B_AdvGoodsRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IB_CategoryRepository _B_CategoryRepository;
					public virtual string B_CategoryTableName{
						get{
							return "B_Category";
						}
					}
					public IB_CategoryRepository B_CategoryRepository
					{
						get
						{
							if (null == _B_CategoryRepository)
							{
								_B_CategoryRepository = new B_CategoryRepository(this._unitOfWork,B_CategoryTableName);
							}
							return _B_CategoryRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IB_InforConfigureRepository _B_InforConfigureRepository;
					public virtual string B_InforConfigureTableName{
						get{
							return "B_InforConfigure";
						}
					}
					public IB_InforConfigureRepository B_InforConfigureRepository
					{
						get
						{
							if (null == _B_InforConfigureRepository)
							{
								_B_InforConfigureRepository = new B_InforConfigureRepository(this._unitOfWork,B_InforConfigureTableName);
							}
							return _B_InforConfigureRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IB_ReceiveConfigureRepository _B_ReceiveConfigureRepository;
					public virtual string B_ReceiveConfigureTableName{
						get{
							return "B_ReceiveConfigure";
						}
					}
					public IB_ReceiveConfigureRepository B_ReceiveConfigureRepository
					{
						get
						{
							if (null == _B_ReceiveConfigureRepository)
							{
								_B_ReceiveConfigureRepository = new B_ReceiveConfigureRepository(this._unitOfWork,B_ReceiveConfigureTableName);
							}
							return _B_ReceiveConfigureRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IB_RecommendConfigureRepository _B_RecommendConfigureRepository;
					public virtual string B_RecommendConfigureTableName{
						get{
							return "B_RecommendConfigure";
						}
					}
					public IB_RecommendConfigureRepository B_RecommendConfigureRepository
					{
						get
						{
							if (null == _B_RecommendConfigureRepository)
							{
								_B_RecommendConfigureRepository = new B_RecommendConfigureRepository(this._unitOfWork,B_RecommendConfigureTableName);
							}
							return _B_RecommendConfigureRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IB_ShareFriendsRepository _B_ShareFriendsRepository;
					public virtual string B_ShareFriendsTableName{
						get{
							return "B_ShareFriends";
						}
					}
					public IB_ShareFriendsRepository B_ShareFriendsRepository
					{
						get
						{
							if (null == _B_ShareFriendsRepository)
							{
								_B_ShareFriendsRepository = new B_ShareFriendsRepository(this._unitOfWork,B_ShareFriendsTableName);
							}
							return _B_ShareFriendsRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private ICrm_ClickExchangeRepository _Crm_ClickExchangeRepository;
					public virtual string Crm_ClickExchangeTableName{
						get{
							return "Crm_ClickExchange";
						}
					}
					public ICrm_ClickExchangeRepository Crm_ClickExchangeRepository
					{
						get
						{
							if (null == _Crm_ClickExchangeRepository)
							{
								_Crm_ClickExchangeRepository = new Crm_ClickExchangeRepository(this._unitOfWork,Crm_ClickExchangeTableName);
							}
							return _Crm_ClickExchangeRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private ICrm_DataAnalysisRepository _Crm_DataAnalysisRepository;
					public virtual string Crm_DataAnalysisTableName{
						get{
							return "Crm_DataAnalysis";
						}
					}
					public ICrm_DataAnalysisRepository Crm_DataAnalysisRepository
					{
						get
						{
							if (null == _Crm_DataAnalysisRepository)
							{
								_Crm_DataAnalysisRepository = new Crm_DataAnalysisRepository(this._unitOfWork,Crm_DataAnalysisTableName);
							}
							return _Crm_DataAnalysisRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private ICrm_FinanceItemRepository _Crm_FinanceItemRepository;
					public virtual string Crm_FinanceItemTableName{
						get{
							return "Crm_FinanceItem";
						}
					}
					public ICrm_FinanceItemRepository Crm_FinanceItemRepository
					{
						get
						{
							if (null == _Crm_FinanceItemRepository)
							{
								_Crm_FinanceItemRepository = new Crm_FinanceItemRepository(this._unitOfWork,Crm_FinanceItemTableName);
							}
							return _Crm_FinanceItemRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private ICrm_InteractiveRepository _Crm_InteractiveRepository;
					public virtual string Crm_InteractiveTableName{
						get{
							return "Crm_Interactive";
						}
					}
					public ICrm_InteractiveRepository Crm_InteractiveRepository
					{
						get
						{
							if (null == _Crm_InteractiveRepository)
							{
								_Crm_InteractiveRepository = new Crm_InteractiveRepository(this._unitOfWork,Crm_InteractiveTableName);
							}
							return _Crm_InteractiveRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private ICrm_ProblemRepository _Crm_ProblemRepository;
					public virtual string Crm_ProblemTableName{
						get{
							return "Crm_Problem";
						}
					}
					public ICrm_ProblemRepository Crm_ProblemRepository
					{
						get
						{
							if (null == _Crm_ProblemRepository)
							{
								_Crm_ProblemRepository = new Crm_ProblemRepository(this._unitOfWork,Crm_ProblemTableName);
							}
							return _Crm_ProblemRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private ICrm_PushRepository _Crm_PushRepository;
					public virtual string Crm_PushTableName{
						get{
							return "Crm_Push";
						}
					}
					public ICrm_PushRepository Crm_PushRepository
					{
						get
						{
							if (null == _Crm_PushRepository)
							{
								_Crm_PushRepository = new Crm_PushRepository(this._unitOfWork,Crm_PushTableName);
							}
							return _Crm_PushRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private ICrm_UserRepository _Crm_UserRepository;
					public virtual string Crm_UserTableName{
						get{
							return "Crm_User";
						}
					}
					public ICrm_UserRepository Crm_UserRepository
					{
						get
						{
							if (null == _Crm_UserRepository)
							{
								_Crm_UserRepository = new Crm_UserRepository(this._unitOfWork,Crm_UserTableName);
							}
							return _Crm_UserRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_AccountRecommendRepository _T_AccountRecommendRepository;
					public virtual string T_AccountRecommendTableName{
						get{
							return "T_AccountRecommend";
						}
					}
					public IT_AccountRecommendRepository T_AccountRecommendRepository
					{
						get
						{
							if (null == _T_AccountRecommendRepository)
							{
								_T_AccountRecommendRepository = new T_AccountRecommendRepository(this._unitOfWork,T_AccountRecommendTableName);
							}
							return _T_AccountRecommendRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_AccountRecordRepository _T_AccountRecordRepository;
					public virtual string T_AccountRecordTableName{
						get{
							return "T_AccountRecord";
						}
					}
					public IT_AccountRecordRepository T_AccountRecordRepository
					{
						get
						{
							if (null == _T_AccountRecordRepository)
							{
								_T_AccountRecordRepository = new T_AccountRecordRepository(this._unitOfWork,T_AccountRecordTableName);
							}
							return _T_AccountRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_AnswerRepository _T_AnswerRepository;
					public virtual string T_AnswerTableName{
						get{
							return "T_Answer";
						}
					}
					public IT_AnswerRepository T_AnswerRepository
					{
						get
						{
							if (null == _T_AnswerRepository)
							{
								_T_AnswerRepository = new T_AnswerRepository(this._unitOfWork,T_AnswerTableName);
							}
							return _T_AnswerRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_AnswerRecommendRepository _T_AnswerRecommendRepository;
					public virtual string T_AnswerRecommendTableName{
						get{
							return "T_AnswerRecommend";
						}
					}
					public IT_AnswerRecommendRepository T_AnswerRecommendRepository
					{
						get
						{
							if (null == _T_AnswerRecommendRepository)
							{
								_T_AnswerRecommendRepository = new T_AnswerRecommendRepository(this._unitOfWork,T_AnswerRecommendTableName);
							}
							return _T_AnswerRecommendRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_AnswerRecordRepository _T_AnswerRecordRepository;
					public virtual string T_AnswerRecordTableName{
						get{
							return "T_AnswerRecord";
						}
					}
					public IT_AnswerRecordRepository T_AnswerRecordRepository
					{
						get
						{
							if (null == _T_AnswerRecordRepository)
							{
								_T_AnswerRecordRepository = new T_AnswerRecordRepository(this._unitOfWork,T_AnswerRecordTableName);
							}
							return _T_AnswerRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_CategoryRepository _T_CategoryRepository;
					public virtual string T_CategoryTableName{
						get{
							return "T_Category";
						}
					}
					public IT_CategoryRepository T_CategoryRepository
					{
						get
						{
							if (null == _T_CategoryRepository)
							{
								_T_CategoryRepository = new T_CategoryRepository(this._unitOfWork,T_CategoryTableName);
							}
							return _T_CategoryRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_CouponExcRecordRepository _T_CouponExcRecordRepository;
					public virtual string T_CouponExcRecordTableName{
						get{
							return "T_CouponExcRecord";
						}
					}
					public IT_CouponExcRecordRepository T_CouponExcRecordRepository
					{
						get
						{
							if (null == _T_CouponExcRecordRepository)
							{
								_T_CouponExcRecordRepository = new T_CouponExcRecordRepository(this._unitOfWork,T_CouponExcRecordTableName);
							}
							return _T_CouponExcRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_CouponInfoRepository _T_CouponInfoRepository;
					public virtual string T_CouponInfoTableName{
						get{
							return "T_CouponInfo";
						}
					}
					public IT_CouponInfoRepository T_CouponInfoRepository
					{
						get
						{
							if (null == _T_CouponInfoRepository)
							{
								_T_CouponInfoRepository = new T_CouponInfoRepository(this._unitOfWork,T_CouponInfoTableName);
							}
							return _T_CouponInfoRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_CouponPrivateCodeRepository _T_CouponPrivateCodeRepository;
					public virtual string T_CouponPrivateCodeTableName{
						get{
							return "T_CouponPrivateCode";
						}
					}
					public IT_CouponPrivateCodeRepository T_CouponPrivateCodeRepository
					{
						get
						{
							if (null == _T_CouponPrivateCodeRepository)
							{
								_T_CouponPrivateCodeRepository = new T_CouponPrivateCodeRepository(this._unitOfWork,T_CouponPrivateCodeTableName);
							}
							return _T_CouponPrivateCodeRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_FavoritesRepository _T_FavoritesRepository;
					public virtual string T_FavoritesTableName{
						get{
							return "T_Favorites";
						}
					}
					public IT_FavoritesRepository T_FavoritesRepository
					{
						get
						{
							if (null == _T_FavoritesRepository)
							{
								_T_FavoritesRepository = new T_FavoritesRepository(this._unitOfWork,T_FavoritesTableName);
							}
							return _T_FavoritesRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_InforConfigureRepository _T_InforConfigureRepository;
					public virtual string T_InforConfigureTableName{
						get{
							return "T_InforConfigure";
						}
					}
					public IT_InforConfigureRepository T_InforConfigureRepository
					{
						get
						{
							if (null == _T_InforConfigureRepository)
							{
								_T_InforConfigureRepository = new T_InforConfigureRepository(this._unitOfWork,T_InforConfigureTableName);
							}
							return _T_InforConfigureRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_JiGuangPushRepository _T_JiGuangPushRepository;
					public virtual string T_JiGuangPushTableName{
						get{
							return "T_JiGuangPush";
						}
					}
					public IT_JiGuangPushRepository T_JiGuangPushRepository
					{
						get
						{
							if (null == _T_JiGuangPushRepository)
							{
								_T_JiGuangPushRepository = new T_JiGuangPushRepository(this._unitOfWork,T_JiGuangPushTableName);
							}
							return _T_JiGuangPushRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_JiGuangPushRecordRepository _T_JiGuangPushRecordRepository;
					public virtual string T_JiGuangPushRecordTableName{
						get{
							return "T_JiGuangPushRecord";
						}
					}
					public IT_JiGuangPushRecordRepository T_JiGuangPushRecordRepository
					{
						get
						{
							if (null == _T_JiGuangPushRecordRepository)
							{
								_T_JiGuangPushRecordRepository = new T_JiGuangPushRecordRepository(this._unitOfWork,T_JiGuangPushRecordTableName);
							}
							return _T_JiGuangPushRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_MemberRepository _T_MemberRepository;
					public virtual string T_MemberTableName{
						get{
							return "T_Member";
						}
					}
					public IT_MemberRepository T_MemberRepository
					{
						get
						{
							if (null == _T_MemberRepository)
							{
								_T_MemberRepository = new T_MemberRepository(this._unitOfWork,T_MemberTableName);
							}
							return _T_MemberRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_OperationLogRepository _T_OperationLogRepository;
					public virtual string T_OperationLogTableName{
						get{
							return "T_OperationLog";
						}
					}
					public IT_OperationLogRepository T_OperationLogRepository
					{
						get
						{
							if (null == _T_OperationLogRepository)
							{
								_T_OperationLogRepository = new T_OperationLogRepository(this._unitOfWork,T_OperationLogTableName);
							}
							return _T_OperationLogRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_RechargeRepository _T_RechargeRepository;
					public virtual string T_RechargeTableName{
						get{
							return "T_Recharge";
						}
					}
					public IT_RechargeRepository T_RechargeRepository
					{
						get
						{
							if (null == _T_RechargeRepository)
							{
								_T_RechargeRepository = new T_RechargeRepository(this._unitOfWork,T_RechargeTableName);
							}
							return _T_RechargeRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_SelfMediaArticleRepository _T_SelfMediaArticleRepository;
					public virtual string T_SelfMediaArticleTableName{
						get{
							return "T_SelfMediaArticle";
						}
					}
					public IT_SelfMediaArticleRepository T_SelfMediaArticleRepository
					{
						get
						{
							if (null == _T_SelfMediaArticleRepository)
							{
								_T_SelfMediaArticleRepository = new T_SelfMediaArticleRepository(this._unitOfWork,T_SelfMediaArticleTableName);
							}
							return _T_SelfMediaArticleRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_SelfMediaAuthorRepository _T_SelfMediaAuthorRepository;
					public virtual string T_SelfMediaAuthorTableName{
						get{
							return "T_SelfMediaAuthor";
						}
					}
					public IT_SelfMediaAuthorRepository T_SelfMediaAuthorRepository
					{
						get
						{
							if (null == _T_SelfMediaAuthorRepository)
							{
								_T_SelfMediaAuthorRepository = new T_SelfMediaAuthorRepository(this._unitOfWork,T_SelfMediaAuthorTableName);
							}
							return _T_SelfMediaAuthorRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_SelfMediaFollowRecordRepository _T_SelfMediaFollowRecordRepository;
					public virtual string T_SelfMediaFollowRecordTableName{
						get{
							return "T_SelfMediaFollowRecord";
						}
					}
					public IT_SelfMediaFollowRecordRepository T_SelfMediaFollowRecordRepository
					{
						get
						{
							if (null == _T_SelfMediaFollowRecordRepository)
							{
								_T_SelfMediaFollowRecordRepository = new T_SelfMediaFollowRecordRepository(this._unitOfWork,T_SelfMediaFollowRecordTableName);
							}
							return _T_SelfMediaFollowRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_SelfMediaPayRecordRepository _T_SelfMediaPayRecordRepository;
					public virtual string T_SelfMediaPayRecordTableName{
						get{
							return "T_SelfMediaPayRecord";
						}
					}
					public IT_SelfMediaPayRecordRepository T_SelfMediaPayRecordRepository
					{
						get
						{
							if (null == _T_SelfMediaPayRecordRepository)
							{
								_T_SelfMediaPayRecordRepository = new T_SelfMediaPayRecordRepository(this._unitOfWork,T_SelfMediaPayRecordTableName);
							}
							return _T_SelfMediaPayRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_SelfMediaRedDotRecordRepository _T_SelfMediaRedDotRecordRepository;
					public virtual string T_SelfMediaRedDotRecordTableName{
						get{
							return "T_SelfMediaRedDotRecord";
						}
					}
					public IT_SelfMediaRedDotRecordRepository T_SelfMediaRedDotRecordRepository
					{
						get
						{
							if (null == _T_SelfMediaRedDotRecordRepository)
							{
								_T_SelfMediaRedDotRecordRepository = new T_SelfMediaRedDotRecordRepository(this._unitOfWork,T_SelfMediaRedDotRecordTableName);
							}
							return _T_SelfMediaRedDotRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_SelfMediaSaveRecordRepository _T_SelfMediaSaveRecordRepository;
					public virtual string T_SelfMediaSaveRecordTableName{
						get{
							return "T_SelfMediaSaveRecord";
						}
					}
					public IT_SelfMediaSaveRecordRepository T_SelfMediaSaveRecordRepository
					{
						get
						{
							if (null == _T_SelfMediaSaveRecordRepository)
							{
								_T_SelfMediaSaveRecordRepository = new T_SelfMediaSaveRecordRepository(this._unitOfWork,T_SelfMediaSaveRecordTableName);
							}
							return _T_SelfMediaSaveRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_ShareAnswerRecordRepository _T_ShareAnswerRecordRepository;
					public virtual string T_ShareAnswerRecordTableName{
						get{
							return "T_ShareAnswerRecord";
						}
					}
					public IT_ShareAnswerRecordRepository T_ShareAnswerRecordRepository
					{
						get
						{
							if (null == _T_ShareAnswerRecordRepository)
							{
								_T_ShareAnswerRecordRepository = new T_ShareAnswerRecordRepository(this._unitOfWork,T_ShareAnswerRecordTableName);
							}
							return _T_ShareAnswerRecordRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_ShareRegisterRepository _T_ShareRegisterRepository;
					public virtual string T_ShareRegisterTableName{
						get{
							return "T_ShareRegister";
						}
					}
					public IT_ShareRegisterRepository T_ShareRegisterRepository
					{
						get
						{
							if (null == _T_ShareRegisterRepository)
							{
								_T_ShareRegisterRepository = new T_ShareRegisterRepository(this._unitOfWork,T_ShareRegisterTableName);
							}
							return _T_ShareRegisterRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_ShopGoodsRepository _T_ShopGoodsRepository;
					public virtual string T_ShopGoodsTableName{
						get{
							return "T_ShopGoods";
						}
					}
					public IT_ShopGoodsRepository T_ShopGoodsRepository
					{
						get
						{
							if (null == _T_ShopGoodsRepository)
							{
								_T_ShopGoodsRepository = new T_ShopGoodsRepository(this._unitOfWork,T_ShopGoodsTableName);
							}
							return _T_ShopGoodsRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_SmsRepository _T_SmsRepository;
					public virtual string T_SmsTableName{
						get{
							return "T_Sms";
						}
					}
					public IT_SmsRepository T_SmsRepository
					{
						get
						{
							if (null == _T_SmsRepository)
							{
								_T_SmsRepository = new T_SmsRepository(this._unitOfWork,T_SmsTableName);
							}
							return _T_SmsRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_SubjectRepository _T_SubjectRepository;
					public virtual string T_SubjectTableName{
						get{
							return "T_Subject";
						}
					}
					public IT_SubjectRepository T_SubjectRepository
					{
						get
						{
							if (null == _T_SubjectRepository)
							{
								_T_SubjectRepository = new T_SubjectRepository(this._unitOfWork,T_SubjectTableName);
							}
							return _T_SubjectRepository;
						}
					}
				  }  
                                  public partial class MLT:IMLT
				  {					
					private IT_WithdrawalsRepository _T_WithdrawalsRepository;
					public virtual string T_WithdrawalsTableName{
						get{
							return "T_Withdrawals";
						}
					}
					public IT_WithdrawalsRepository T_WithdrawalsRepository
					{
						get
						{
							if (null == _T_WithdrawalsRepository)
							{
								_T_WithdrawalsRepository = new T_WithdrawalsRepository(this._unitOfWork,T_WithdrawalsTableName);
							}
							return _T_WithdrawalsRepository;
						}
					}
				  }  
                }


