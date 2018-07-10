

 



namespace Point.com.IRepository
{
    public partial interface IDbSession
    {
					 IHolycaDb HolycaDb {get;}
            				 IMLT MLT {get;}
            				 IBBHomeDb BBHomeDb {get;}
            	}
					 public partial interface IHolycaDb:IDbSingSession
				 {
				 
				 }
            				 public partial interface IMLT:IDbSingSession
				 {
				 
				 }
            				 public partial interface IBBHomeDb:IDbSingSession
				 {
				 
				 }
            
	                  public partial interface IHolycaDb
				  {	
					IBase_DeliverRepository Base_DeliverRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IBase_RegionRepository Base_RegionRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IBase_SaveAppRepository Base_SaveAppRepository{get;}
				  }  
                                  public partial interface IBBHomeDb
				  {	
					Ibase_t_memberRepository base_t_memberRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IB_AdvGoodsRepository B_AdvGoodsRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IB_AdvGoodsRecordRepository B_AdvGoodsRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IB_CategoryRepository B_CategoryRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IB_InforConfigureRepository B_InforConfigureRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IB_ReceiveConfigureRepository B_ReceiveConfigureRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IB_ReceiveCouponRecordRepository B_ReceiveCouponRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IB_RecommendConfigureRepository B_RecommendConfigureRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IB_ShareFriendsRepository B_ShareFriendsRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					ICrm_ClickExchangeRepository Crm_ClickExchangeRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					ICrm_DataAnalysisRepository Crm_DataAnalysisRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					ICrm_FinanceItemRepository Crm_FinanceItemRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					ICrm_InteractiveRepository Crm_InteractiveRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					ICrm_ProblemRepository Crm_ProblemRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					ICrm_PushRepository Crm_PushRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					ICrm_UserRepository Crm_UserRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_AccountRecommendRepository T_AccountRecommendRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_AccountRecordRepository T_AccountRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_AnswerRepository T_AnswerRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_AnswerRecommendRepository T_AnswerRecommendRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_AnswerRecordRepository T_AnswerRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_CategoryRepository T_CategoryRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_CouponExcRecordRepository T_CouponExcRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_CouponInfoRepository T_CouponInfoRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_CouponPrivateCodeRepository T_CouponPrivateCodeRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_FavoritesRepository T_FavoritesRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_InforConfigureRepository T_InforConfigureRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_JiGuangPushRepository T_JiGuangPushRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_JiGuangPushRecordRepository T_JiGuangPushRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_MemberRepository T_MemberRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_OperationLogRepository T_OperationLogRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_RechargeRepository T_RechargeRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_SelfMediaArticleRepository T_SelfMediaArticleRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_SelfMediaAuthorRepository T_SelfMediaAuthorRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_SelfMediaFollowRecordRepository T_SelfMediaFollowRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_SelfMediaPayRecordRepository T_SelfMediaPayRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_SelfMediaRedDotRecordRepository T_SelfMediaRedDotRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_SelfMediaSaveRecordRepository T_SelfMediaSaveRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_ShareAnswerRecordRepository T_ShareAnswerRecordRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_ShareRegisterRepository T_ShareRegisterRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_ShopGoodsRepository T_ShopGoodsRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_SmsRepository T_SmsRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_SubjectRepository T_SubjectRepository{get;}
				  }  
                                  public partial interface IMLT
				  {	
					IT_WithdrawalsRepository T_WithdrawalsRepository{get;}
				  }  
                }

