
using System.Collections.Generic;
using Point.com.IRepository;
using Point.com.Model;
using System;

namespace Point.com.Repository
{
   
	
public partial class B_AdvGoodsRepository : BaseRepository<B_AdvGoods>, IB_AdvGoodsRepository
{
		public B_AdvGoodsRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="B_AdvGoods";
		} 
		public B_AdvGoodsRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(B_AdvGoods model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.AdvSysNo!=null) 
		{
			list.Add(addFunc("AdvSysNo",model.AdvSysNo.ToString()));
		}

						if(model.CateId!=null) 
		{
			list.Add(addFunc("CateId",model.CateId.ToString()));
		}

						if(model.GoodsName!=null) 
		{
			list.Add(addFunc("GoodsName",model.GoodsName.ToString()));
		}

						if(model.GoodsPic!=null) 
		{
			list.Add(addFunc("GoodsPic",model.GoodsPic.ToString()));
		}

						if(model.GoodsDetailedLink!=null) 
		{
			list.Add(addFunc("GoodsDetailedLink",model.GoodsDetailedLink.ToString()));
		}

						if(model.GoodsExcLink!=null) 
		{
			list.Add(addFunc("GoodsExcLink",model.GoodsExcLink.ToString()));
		}

						if(model.MarketPrice!=null) 
		{
			list.Add(addFunc("MarketPrice",model.MarketPrice.ToString()));
		}

						if(model.PromotionPrice!=null) 
		{
			list.Add(addFunc("PromotionPrice",model.PromotionPrice.ToString()));
		}

						if(model.DeductibleMoney!=null) 
		{
			list.Add(addFunc("DeductibleMoney",model.DeductibleMoney.ToString()));
		}

						if(model.CashBonus!=null) 
		{
			list.Add(addFunc("CashBonus",model.CashBonus.ToString()));
		}

						if(model.CashBonusNum!=null) 
		{
			list.Add(addFunc("CashBonusNum",model.CashBonusNum.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(B_AdvGoods model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.AdvSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AdvSysNo.ToString(),addFunc("[AdvSysNo]")));
		}
					

						if(model.CateId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CateId.ToString(),addFunc("[CateId]")));
		}
					

						if(model.GoodsName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsName.ToString(),addFunc("[GoodsName]")));
		}
					

						if(model.GoodsPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsPic.ToString(),addFunc("[GoodsPic]")));
		}
					

						if(model.GoodsDetailedLink!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsDetailedLink.ToString(),addFunc("[GoodsDetailedLink]")));
		}
					

						if(model.GoodsExcLink!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsExcLink.ToString(),addFunc("[GoodsExcLink]")));
		}
					

						if(model.MarketPrice!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MarketPrice.ToString(),addFunc("[MarketPrice]")));
		}
					

						if(model.PromotionPrice!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PromotionPrice.ToString(),addFunc("[PromotionPrice]")));
		}
					

						if(model.DeductibleMoney!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DeductibleMoney.ToString(),addFunc("[DeductibleMoney]")));
		}
					

						if(model.CashBonus!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CashBonus.ToString(),addFunc("[CashBonus]")));
		}
					

						if(model.CashBonusNum!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CashBonusNum.ToString(),addFunc("[CashBonusNum]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(B_AdvGoods)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(B_AdvGoods)item[0];		
	var where=	(B_AdvGoods)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(B_AdvGoods where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, B_AdvGoods where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(B_AdvGoods where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, B_AdvGoods where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, B_AdvGoods where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class B_AdvGoodsRecordRepository : BaseRepository<B_AdvGoodsRecord>, IB_AdvGoodsRecordRepository
{
		public B_AdvGoodsRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="B_AdvGoodsRecord";
		} 
		public B_AdvGoodsRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(B_AdvGoodsRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.AdvSysNo!=null) 
		{
			list.Add(addFunc("AdvSysNo",model.AdvSysNo.ToString()));
		}

						if(model.AdvGoodsSysNo!=null) 
		{
			list.Add(addFunc("AdvGoodsSysNo",model.AdvGoodsSysNo.ToString()));
		}

						if(model.CashBonus!=null) 
		{
			list.Add(addFunc("CashBonus",model.CashBonus.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(B_AdvGoodsRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.AdvSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AdvSysNo.ToString(),addFunc("[AdvSysNo]")));
		}
					

						if(model.AdvGoodsSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AdvGoodsSysNo.ToString(),addFunc("[AdvGoodsSysNo]")));
		}
					

						if(model.CashBonus!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CashBonus.ToString(),addFunc("[CashBonus]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(B_AdvGoodsRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(B_AdvGoodsRecord)item[0];		
	var where=	(B_AdvGoodsRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(B_AdvGoodsRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, B_AdvGoodsRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(B_AdvGoodsRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, B_AdvGoodsRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, B_AdvGoodsRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class B_CategoryRepository : BaseRepository<B_Category>, IB_CategoryRepository
{
		public B_CategoryRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="B_Category";
		} 
		public B_CategoryRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(B_Category model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.CateId!=null) 
		{
			list.Add(addFunc("CateId",model.CateId.ToString()));
		}

						if(model.CateName!=null) 
		{
			list.Add(addFunc("CateName",model.CateName.ToString()));
		}

						if(model.CateDescOne!=null) 
		{
			list.Add(addFunc("CateDescOne",model.CateDescOne.ToString()));
		}

						if(model.CateDescTwo!=null) 
		{
			list.Add(addFunc("CateDescTwo",model.CateDescTwo.ToString()));
		}

						if(model.CatePic!=null) 
		{
			list.Add(addFunc("CatePic",model.CatePic.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(B_Category model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.CateId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CateId.ToString(),addFunc("[CateId]")));
		}
					

						if(model.CateName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CateName.ToString(),addFunc("[CateName]")));
		}
					

						if(model.CateDescOne!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CateDescOne.ToString(),addFunc("[CateDescOne]")));
		}
					

						if(model.CateDescTwo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CateDescTwo.ToString(),addFunc("[CateDescTwo]")));
		}
					

						if(model.CatePic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CatePic.ToString(),addFunc("[CatePic]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(B_Category)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(B_Category)item[0];		
	var where=	(B_Category)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(B_Category where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, B_Category where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(B_Category where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, B_Category where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, B_Category where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class B_InforConfigureRepository : BaseRepository<B_InforConfigure>, IB_InforConfigureRepository
{
		public B_InforConfigureRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="B_InforConfigure";
		} 
		public B_InforConfigureRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(B_InforConfigure model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.DataType!=null) 
		{
			list.Add(addFunc("DataType",model.DataType.ToString()));
		}

						if(model.ShowCrowd!=null) 
		{
			list.Add(addFunc("ShowCrowd",model.ShowCrowd.ToString()));
		}

						if(model.CoverPicUrl!=null) 
		{
			list.Add(addFunc("CoverPicUrl",model.CoverPicUrl.ToString()));
		}

						if(model.ShopName!=null) 
		{
			list.Add(addFunc("ShopName",model.ShopName.ToString()));
		}

						if(model.LogoPicUrl!=null) 
		{
			list.Add(addFunc("LogoPicUrl",model.LogoPicUrl.ToString()));
		}

						if(model.SetInvitationNum!=null) 
		{
			list.Add(addFunc("SetInvitationNum",model.SetInvitationNum.ToString()));
		}

						if(model.ReceiveType!=null) 
		{
			list.Add(addFunc("ReceiveType",model.ReceiveType.ToString()));
		}

						if(model.CouponMoney!=null) 
		{
			list.Add(addFunc("CouponMoney",model.CouponMoney.ToString()));
		}

						if(model.Title!=null) 
		{
			list.Add(addFunc("Title",model.Title.ToString()));
		}

						if(model.DescOne!=null) 
		{
			list.Add(addFunc("DescOne",model.DescOne.ToString()));
		}

						if(model.DescTwo!=null) 
		{
			list.Add(addFunc("DescTwo",model.DescTwo.ToString()));
		}

						if(model.MarketPrice!=null) 
		{
			list.Add(addFunc("MarketPrice",model.MarketPrice.ToString()));
		}

						if(model.PromotionPrice!=null) 
		{
			list.Add(addFunc("PromotionPrice",model.PromotionPrice.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(B_InforConfigure model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.DataType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DataType.ToString(),addFunc("[DataType]")));
		}
					

						if(model.ShowCrowd!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShowCrowd.ToString(),addFunc("[ShowCrowd]")));
		}
					

						if(model.CoverPicUrl!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CoverPicUrl.ToString(),addFunc("[CoverPicUrl]")));
		}
					

						if(model.ShopName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShopName.ToString(),addFunc("[ShopName]")));
		}
					

						if(model.LogoPicUrl!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.LogoPicUrl.ToString(),addFunc("[LogoPicUrl]")));
		}
					

						if(model.SetInvitationNum!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SetInvitationNum.ToString(),addFunc("[SetInvitationNum]")));
		}
					

						if(model.ReceiveType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ReceiveType.ToString(),addFunc("[ReceiveType]")));
		}
					

						if(model.CouponMoney!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CouponMoney.ToString(),addFunc("[CouponMoney]")));
		}
					

						if(model.Title!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Title.ToString(),addFunc("[Title]")));
		}
					

						if(model.DescOne!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DescOne.ToString(),addFunc("[DescOne]")));
		}
					

						if(model.DescTwo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DescTwo.ToString(),addFunc("[DescTwo]")));
		}
					

						if(model.MarketPrice!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MarketPrice.ToString(),addFunc("[MarketPrice]")));
		}
					

						if(model.PromotionPrice!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PromotionPrice.ToString(),addFunc("[PromotionPrice]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(B_InforConfigure)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(B_InforConfigure)item[0];		
	var where=	(B_InforConfigure)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(B_InforConfigure where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, B_InforConfigure where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(B_InforConfigure where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, B_InforConfigure where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, B_InforConfigure where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class B_ReceiveConfigureRepository : BaseRepository<B_ReceiveConfigure>, IB_ReceiveConfigureRepository
{
		public B_ReceiveConfigureRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="B_ReceiveConfigure";
		} 
		public B_ReceiveConfigureRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(B_ReceiveConfigure model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.RecSysNo!=null) 
		{
			list.Add(addFunc("RecSysNo",model.RecSysNo.ToString()));
		}

						if(model.ReceiveUrl!=null) 
		{
			list.Add(addFunc("ReceiveUrl",model.ReceiveUrl.ToString()));
		}

						if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(B_ReceiveConfigure model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.RecSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RecSysNo.ToString(),addFunc("[RecSysNo]")));
		}
					

						if(model.ReceiveUrl!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ReceiveUrl.ToString(),addFunc("[ReceiveUrl]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(B_ReceiveConfigure)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(B_ReceiveConfigure)item[0];		
	var where=	(B_ReceiveConfigure)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(B_ReceiveConfigure where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, B_ReceiveConfigure where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(B_ReceiveConfigure where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, B_ReceiveConfigure where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, B_ReceiveConfigure where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class B_RecommendConfigureRepository : BaseRepository<B_RecommendConfigure>, IB_RecommendConfigureRepository
{
		public B_RecommendConfigureRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="B_RecommendConfigure";
		} 
		public B_RecommendConfigureRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(B_RecommendConfigure model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.DataType!=null) 
		{
			list.Add(addFunc("DataType",model.DataType.ToString()));
		}

						if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.InforSysNo!=null) 
		{
			list.Add(addFunc("InforSysNo",model.InforSysNo.ToString()));
		}

						if(model.PushState!=null) 
		{
			list.Add(addFunc("PushState",model.PushState.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(B_RecommendConfigure model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.DataType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DataType.ToString(),addFunc("[DataType]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.InforSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforSysNo.ToString(),addFunc("[InforSysNo]")));
		}
					

						if(model.PushState!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PushState.ToString(),addFunc("[PushState]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(B_RecommendConfigure)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(B_RecommendConfigure)item[0];		
	var where=	(B_RecommendConfigure)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(B_RecommendConfigure where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, B_RecommendConfigure where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(B_RecommendConfigure where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, B_RecommendConfigure where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, B_RecommendConfigure where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class B_ShareFriendsRepository : BaseRepository<B_ShareFriends>, IB_ShareFriendsRepository
{
		public B_ShareFriendsRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="B_ShareFriends";
		} 
		public B_ShareFriendsRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(B_ShareFriends model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.ShareSysNo!=null) 
		{
			list.Add(addFunc("ShareSysNo",model.ShareSysNo.ToString()));
		}

						if(model.ShareUserId!=null) 
		{
			list.Add(addFunc("ShareUserId",model.ShareUserId.ToString()));
		}

						if(model.CoverMobile!=null) 
		{
			list.Add(addFunc("CoverMobile",model.CoverMobile.ToString()));
		}

						if(model.CoverUserId!=null) 
		{
			list.Add(addFunc("CoverUserId",model.CoverUserId.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(B_ShareFriends model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.ShareSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShareSysNo.ToString(),addFunc("[ShareSysNo]")));
		}
					

						if(model.ShareUserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShareUserId.ToString(),addFunc("[ShareUserId]")));
		}
					

						if(model.CoverMobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CoverMobile.ToString(),addFunc("[CoverMobile]")));
		}
					

						if(model.CoverUserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CoverUserId.ToString(),addFunc("[CoverUserId]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(B_ShareFriends)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(B_ShareFriends)item[0];		
	var where=	(B_ShareFriends)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(B_ShareFriends where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, B_ShareFriends where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(B_ShareFriends where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, B_ShareFriends where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, B_ShareFriends where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Base_DeliverRepository : BaseRepository<Base_Deliver>, IBase_DeliverRepository
{
		public Base_DeliverRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Base_Deliver";
		} 
		public Base_DeliverRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Base_Deliver model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.IntDeliverID!=null) 
		{
			list.Add(addFunc("IntDeliverID",model.IntDeliverID.ToString()));
		}

						if(model.VchDeliverName!=null) 
		{
			list.Add(addFunc("VchDeliverName",model.VchDeliverName.ToString()));
		}

						if(model.VchDeliverDesc!=null) 
		{
			list.Add(addFunc("VchDeliverDesc",model.VchDeliverDesc.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.IntIsCarriage!=null) 
		{
			list.Add(addFunc("IntIsCarriage",model.IntIsCarriage.ToString()));
		}

						if(model.IntIsEnable!=null) 
		{
			list.Add(addFunc("IntIsEnable",model.IntIsEnable.ToString()));
		}

						if(model.IntAddUserID!=null) 
		{
			list.Add(addFunc("IntAddUserID",model.IntAddUserID.ToString()));
		}

						if(model.DtAddDate!=null) 
		{
			list.Add(addFunc("DtAddDate",model.DtAddDate.ToString()));
		}

						if(model.IntModUserID!=null) 
		{
			list.Add(addFunc("IntModUserID",model.IntModUserID.ToString()));
		}

						if(model.DtModDate!=null) 
		{
			list.Add(addFunc("DtModDate",model.DtModDate.ToString()));
		}

						if(model.Tb_code!=null) 
		{
			list.Add(addFunc("Tb_code",model.Tb_code.ToString()));
		}

						if(model.Tb_id!=null) 
		{
			list.Add(addFunc("Tb_id",model.Tb_id.ToString()));
		}

						if(model.Tb_name!=null) 
		{
			list.Add(addFunc("Tb_name",model.Tb_name.ToString()));
		}

						if(model.Tb_reg_mail_no!=null) 
		{
			list.Add(addFunc("Tb_reg_mail_no",model.Tb_reg_mail_no.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Base_Deliver model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.IntDeliverID!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntDeliverID.ToString(),addFunc("[IntDeliverID]")));
		}
					

						if(model.VchDeliverName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.VchDeliverName.ToString(),addFunc("[VchDeliverName]")));
		}
					

						if(model.VchDeliverDesc!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.VchDeliverDesc.ToString(),addFunc("[VchDeliverDesc]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.IntIsCarriage!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntIsCarriage.ToString(),addFunc("[IntIsCarriage]")));
		}
					

						if(model.IntIsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntIsEnable.ToString(),addFunc("[IntIsEnable]")));
		}
					

						if(model.IntAddUserID!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntAddUserID.ToString(),addFunc("[IntAddUserID]")));
		}
					

						if(model.DtAddDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DtAddDate.ToString(),addFunc("[DtAddDate]")));
		}
					

						if(model.IntModUserID!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntModUserID.ToString(),addFunc("[IntModUserID]")));
		}
					

						if(model.DtModDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DtModDate.ToString(),addFunc("[DtModDate]")));
		}
					

						if(model.Tb_code!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Tb_code.ToString(),addFunc("[Tb_code]")));
		}
					

						if(model.Tb_id!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Tb_id.ToString(),addFunc("[Tb_id]")));
		}
					

						if(model.Tb_name!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Tb_name.ToString(),addFunc("[Tb_name]")));
		}
					

						if(model.Tb_reg_mail_no!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Tb_reg_mail_no.ToString(),addFunc("[Tb_reg_mail_no]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Base_Deliver)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Base_Deliver)item[0];		
	var where=	(Base_Deliver)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Base_Deliver where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Base_Deliver where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Base_Deliver where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Base_Deliver where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Base_Deliver where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Base_RegionRepository : BaseRepository<Base_Region>, IBase_RegionRepository
{
		public Base_RegionRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Base_Region";
		} 
		public Base_RegionRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Base_Region model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.RegionId!=null) 
		{
			list.Add(addFunc("RegionId",model.RegionId.ToString()));
		}

						if(model.ParentId!=null) 
		{
			list.Add(addFunc("ParentId",model.ParentId.ToString()));
		}

						if(model.RegionName!=null) 
		{
			list.Add(addFunc("RegionName",model.RegionName.ToString()));
		}

						if(model.RegionType!=null) 
		{
			list.Add(addFunc("RegionType",model.RegionType.ToString()));
		}

						if(model.ZipCode!=null) 
		{
			list.Add(addFunc("ZipCode",model.ZipCode.ToString()));
		}

						if(model.QuHao!=null) 
		{
			list.Add(addFunc("QuHao",model.QuHao.ToString()));
		}

						if(model.ShortSpell!=null) 
		{
			list.Add(addFunc("ShortSpell",model.ShortSpell.ToString()));
		}

						if(model.SortId!=null) 
		{
			list.Add(addFunc("SortId",model.SortId.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Base_Region model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.RegionId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegionId.ToString(),addFunc("[RegionId]")));
		}
					

						if(model.ParentId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ParentId.ToString(),addFunc("[ParentId]")));
		}
					

						if(model.RegionName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegionName.ToString(),addFunc("[RegionName]")));
		}
					

						if(model.RegionType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegionType.ToString(),addFunc("[RegionType]")));
		}
					

						if(model.ZipCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ZipCode.ToString(),addFunc("[ZipCode]")));
		}
					

						if(model.QuHao!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.QuHao.ToString(),addFunc("[QuHao]")));
		}
					

						if(model.ShortSpell!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShortSpell.ToString(),addFunc("[ShortSpell]")));
		}
					

						if(model.SortId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SortId.ToString(),addFunc("[SortId]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Base_Region)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Base_Region)item[0];		
	var where=	(Base_Region)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Base_Region where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Base_Region where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Base_Region where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Base_Region where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Base_Region where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Base_SaveAppRepository : BaseRepository<Base_SaveApp>, IBase_SaveAppRepository
{
		public Base_SaveAppRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Base_SaveApp";
		} 
		public Base_SaveAppRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Base_SaveApp model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.Mobile!=null) 
		{
			list.Add(addFunc("Mobile",model.Mobile.ToString()));
		}

						if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.DeviceCode!=null) 
		{
			list.Add(addFunc("DeviceCode",model.DeviceCode.ToString()));
		}

						if(model.AppName!=null) 
		{
			list.Add(addFunc("AppName",model.AppName.ToString()));
		}

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(addFunc("SourceTypeSysNo",model.SourceTypeSysNo.ToString()));
		}

						if(model.ClientIp!=null) 
		{
			list.Add(addFunc("ClientIp",model.ClientIp.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Base_SaveApp model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.Mobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Mobile.ToString(),addFunc("[Mobile]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.DeviceCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DeviceCode.ToString(),addFunc("[DeviceCode]")));
		}
					

						if(model.AppName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AppName.ToString(),addFunc("[AppName]")));
		}
					

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SourceTypeSysNo.ToString(),addFunc("[SourceTypeSysNo]")));
		}
					

						if(model.ClientIp!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ClientIp.ToString(),addFunc("[ClientIp]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Base_SaveApp)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Base_SaveApp)item[0];		
	var where=	(Base_SaveApp)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Base_SaveApp where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Base_SaveApp where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Base_SaveApp where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Base_SaveApp where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Base_SaveApp where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class base_t_memberRepository : BaseRepository<base_t_member>, Ibase_t_memberRepository
{
		public base_t_memberRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="base_t_member";
		} 
		public base_t_memberRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(base_t_member model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.MembNo!=null) 
		{
			list.Add(addFunc("MembNo",model.MembNo.ToString()));
		}

						if(model.UserCode!=null) 
		{
			list.Add(addFunc("UserCode",model.UserCode.ToString()));
		}

						if(model.UserName!=null) 
		{
			list.Add(addFunc("UserName",model.UserName.ToString()));
		}

						if(model.RegTime!=null) 
		{
			list.Add(addFunc("RegTime",model.RegTime.ToString()));
		}

						if(model.CreateBy!=null) 
		{
			list.Add(addFunc("CreateBy",model.CreateBy.ToString()));
		}

						if(model.UpdateTime!=null) 
		{
			list.Add(addFunc("UpdateTime",model.UpdateTime.ToString()));
		}

						if(model.UpdateBy!=null) 
		{
			list.Add(addFunc("UpdateBy",model.UpdateBy.ToString()));
		}

						if(model.CardNO!=null) 
		{
			list.Add(addFunc("CardNO",model.CardNO.ToString()));
		}

						if(model.NoteFlag!=null) 
		{
			list.Add(addFunc("NoteFlag",model.NoteFlag.ToString()));
		}

						if(model.UserGroupId!=null) 
		{
			list.Add(addFunc("UserGroupId",model.UserGroupId.ToString()));
		}

						if(model.Policymaker!=null) 
		{
			list.Add(addFunc("Policymaker",model.Policymaker.ToString()));
		}

						if(model.ReferrerMembNo!=null) 
		{
			list.Add(addFunc("ReferrerMembNo",model.ReferrerMembNo.ToString()));
		}

						if(model.Province!=null) 
		{
			list.Add(addFunc("Province",model.Province.ToString()));
		}

						if(model.City!=null) 
		{
			list.Add(addFunc("City",model.City.ToString()));
		}

						if(model.District!=null) 
		{
			list.Add(addFunc("District",model.District.ToString()));
		}

						if(model.Scores!=null) 
		{
			list.Add(addFunc("Scores",model.Scores.ToString()));
		}

						if(model.Valid!=null) 
		{
			list.Add(addFunc("Valid",model.Valid.ToString()));
		}

						if(model.MobileTel!=null) 
		{
			list.Add(addFunc("MobileTel",model.MobileTel.ToString()));
		}

						if(model.Tel!=null) 
		{
			list.Add(addFunc("Tel",model.Tel.ToString()));
		}

						if(model.Email!=null) 
		{
			list.Add(addFunc("Email",model.Email.ToString()));
		}

						if(model.UserLevel!=null) 
		{
			list.Add(addFunc("UserLevel",model.UserLevel.ToString()));
		}

						if(model.AreaNo!=null) 
		{
			list.Add(addFunc("AreaNo",model.AreaNo.ToString()));
		}

						if(model.RegType!=null) 
		{
			list.Add(addFunc("RegType",model.RegType.ToString()));
		}

						if(model.ClusterId!=null) 
		{
			list.Add(addFunc("ClusterId",model.ClusterId.ToString()));
		}

						if(model.RegFrom!=null) 
		{
			list.Add(addFunc("RegFrom",model.RegFrom.ToString()));
		}

						if(model.Passward!=null) 
		{
			list.Add(addFunc("Passward",model.Passward.ToString()));
		}

						if(model.NickName!=null) 
		{
			list.Add(addFunc("NickName",model.NickName.ToString()));
		}

						if(model.Sex!=null) 
		{
			list.Add(addFunc("Sex",model.Sex.ToString()));
		}

						if(model.Question!=null) 
		{
			list.Add(addFunc("Question",model.Question.ToString()));
		}

						if(model.Answer!=null) 
		{
			list.Add(addFunc("Answer",model.Answer.ToString()));
		}

						if(model.Qq!=null) 
		{
			list.Add(addFunc("Qq",model.Qq.ToString()));
		}

						if(model.Msn!=null) 
		{
			list.Add(addFunc("Msn",model.Msn.ToString()));
		}

						if(model.BeValidate!=null) 
		{
			list.Add(addFunc("BeValidate",model.BeValidate.ToString()));
		}

						if(model.OrderTimes!=null) 
		{
			list.Add(addFunc("OrderTimes",model.OrderTimes.ToString()));
		}

						if(model.IntUserType!=null) 
		{
			list.Add(addFunc("IntUserType",model.IntUserType.ToString()));
		}

						if(model.Timestamp!=null) 
		{
			list.Add(addFunc("Timestamp",model.Timestamp.ToString()));
		}

						if(model.IsVfMobile!=null) 
		{
			list.Add(addFunc("IsVfMobile",model.IsVfMobile.ToString()));
		}

						if(model.LoginMobile!=null) 
		{
			list.Add(addFunc("LoginMobile",model.LoginMobile.ToString()));
		}

						if(model.VchRegMobEmail!=null) 
		{
			list.Add(addFunc("VchRegMobEmail",model.VchRegMobEmail.ToString()));
		}

						if(model.VchHeadImg!=null) 
		{
			list.Add(addFunc("VchHeadImg",model.VchHeadImg.ToString()));
		}

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(addFunc("SourceTypeSysNo",model.SourceTypeSysNo.ToString()));
		}

						if(model.ClientIp!=null) 
		{
			list.Add(addFunc("ClientIp",model.ClientIp.ToString()));
		}

						if(model.UserGuid!=null) 
		{
			list.Add(addFunc("UserGuid",model.UserGuid.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(base_t_member model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.MembNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MembNo.ToString(),addFunc("[MembNo]")));
		}
					

						if(model.UserCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserCode.ToString(),addFunc("[UserCode]")));
		}
					

						if(model.UserName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserName.ToString(),addFunc("[UserName]")));
		}
					

						if(model.RegTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegTime.ToString(),addFunc("[RegTime]")));
		}
					

						if(model.CreateBy!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CreateBy.ToString(),addFunc("[CreateBy]")));
		}
					

						if(model.UpdateTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UpdateTime.ToString(),addFunc("[UpdateTime]")));
		}
					

						if(model.UpdateBy!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UpdateBy.ToString(),addFunc("[UpdateBy]")));
		}
					

						if(model.CardNO!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CardNO.ToString(),addFunc("[CardNO]")));
		}
					

						if(model.NoteFlag!=null) 
		{
			list.Add(string.Format("{1}!={0}",model.NoteFlag.ToString(),addFunc("[eFlag]")));			
		}	
					

						if(model.UserGroupId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserGroupId.ToString(),addFunc("[UserGroupId]")));
		}
					

						if(model.Policymaker!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Policymaker.ToString(),addFunc("[Policymaker]")));
		}
					

						if(model.ReferrerMembNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ReferrerMembNo.ToString(),addFunc("[ReferrerMembNo]")));
		}
					

						if(model.Province!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Province.ToString(),addFunc("[Province]")));
		}
					

						if(model.City!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.City.ToString(),addFunc("[City]")));
		}
					

						if(model.District!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.District.ToString(),addFunc("[District]")));
		}
					

						if(model.Scores!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Scores.ToString(),addFunc("[Scores]")));
		}
					

						if(model.Valid!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Valid.ToString(),addFunc("[Valid]")));
		}
					

						if(model.MobileTel!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MobileTel.ToString(),addFunc("[MobileTel]")));
		}
					

						if(model.Tel!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Tel.ToString(),addFunc("[Tel]")));
		}
					

						if(model.Email!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Email.ToString(),addFunc("[Email]")));
		}
					

						if(model.UserLevel!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserLevel.ToString(),addFunc("[UserLevel]")));
		}
					

						if(model.AreaNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AreaNo.ToString(),addFunc("[AreaNo]")));
		}
					

						if(model.RegType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegType.ToString(),addFunc("[RegType]")));
		}
					

						if(model.ClusterId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ClusterId.ToString(),addFunc("[ClusterId]")));
		}
					

						if(model.RegFrom!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegFrom.ToString(),addFunc("[RegFrom]")));
		}
					

						if(model.Passward!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Passward.ToString(),addFunc("[Passward]")));
		}
					

						if(model.NickName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.NickName.ToString(),addFunc("[NickName]")));
		}
					

						if(model.Sex!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Sex.ToString(),addFunc("[Sex]")));
		}
					

						if(model.Question!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Question.ToString(),addFunc("[Question]")));
		}
					

						if(model.Answer!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Answer.ToString(),addFunc("[Answer]")));
		}
					

						if(model.Qq!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Qq.ToString(),addFunc("[Qq]")));
		}
					

						if(model.Msn!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Msn.ToString(),addFunc("[Msn]")));
		}
					

						if(model.BeValidate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.BeValidate.ToString(),addFunc("[BeValidate]")));
		}
					

						if(model.OrderTimes!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.OrderTimes.ToString(),addFunc("[OrderTimes]")));
		}
					

						if(model.IntUserType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntUserType.ToString(),addFunc("[IntUserType]")));
		}
					

						if(model.Timestamp!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Timestamp.ToString(),addFunc("[Timestamp]")));
		}
					

						if(model.IsVfMobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsVfMobile.ToString(),addFunc("[IsVfMobile]")));
		}
					

						if(model.LoginMobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.LoginMobile.ToString(),addFunc("[LoginMobile]")));
		}
					

						if(model.VchRegMobEmail!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.VchRegMobEmail.ToString(),addFunc("[VchRegMobEmail]")));
		}
					

						if(model.VchHeadImg!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.VchHeadImg.ToString(),addFunc("[VchHeadImg]")));
		}
					

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SourceTypeSysNo.ToString(),addFunc("[SourceTypeSysNo]")));
		}
					

						if(model.ClientIp!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ClientIp.ToString(),addFunc("[ClientIp]")));
		}
					

						if(model.UserGuid!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserGuid.ToString(),addFunc("[UserGuid]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(base_t_member)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(base_t_member)item[0];		
	var where=	(base_t_member)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(base_t_member where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, base_t_member where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(base_t_member where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, base_t_member where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, base_t_member where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Crm_ClickExchangeRepository : BaseRepository<Crm_ClickExchange>, ICrm_ClickExchangeRepository
{
		public Crm_ClickExchangeRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Crm_ClickExchange";
		} 
		public Crm_ClickExchangeRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Crm_ClickExchange model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.GoodsPic!=null) 
		{
			list.Add(addFunc("GoodsPic",model.GoodsPic.ToString()));
		}

						if(model.GoodsName!=null) 
		{
			list.Add(addFunc("GoodsName",model.GoodsName.ToString()));
		}

						if(model.ClickCount!=null) 
		{
			list.Add(addFunc("ClickCount",model.ClickCount.ToString()));
		}

						if(model.ExchangeCount!=null) 
		{
			list.Add(addFunc("ExchangeCount",model.ExchangeCount.ToString()));
		}

						if(model.Remark!=null) 
		{
			list.Add(addFunc("Remark",model.Remark.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

						if(model.GoodsType!=null) 
		{
			list.Add(addFunc("GoodsType",model.GoodsType.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Crm_ClickExchange model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.GoodsPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsPic.ToString(),addFunc("[GoodsPic]")));
		}
					

						if(model.GoodsName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsName.ToString(),addFunc("[GoodsName]")));
		}
					

						if(model.ClickCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ClickCount.ToString(),addFunc("[ClickCount]")));
		}
					

						if(model.ExchangeCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ExchangeCount.ToString(),addFunc("[ExchangeCount]")));
		}
					

						if(model.Remark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Remark.ToString(),addFunc("[Remark]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

						if(model.GoodsType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsType.ToString(),addFunc("[GoodsType]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Crm_ClickExchange)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Crm_ClickExchange)item[0];		
	var where=	(Crm_ClickExchange)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Crm_ClickExchange where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Crm_ClickExchange where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Crm_ClickExchange where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Crm_ClickExchange where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Crm_ClickExchange where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Crm_DataAnalysisRepository : BaseRepository<Crm_DataAnalysis>, ICrm_DataAnalysisRepository
{
		public Crm_DataAnalysisRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Crm_DataAnalysis";
		} 
		public Crm_DataAnalysisRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Crm_DataAnalysis model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.DataType!=null) 
		{
			list.Add(addFunc("DataType",model.DataType.ToString()));
		}

						if(model.DataCata!=null) 
		{
			list.Add(addFunc("DataCata",model.DataCata.ToString()));
		}

						if(model.DataName!=null) 
		{
			list.Add(addFunc("DataName",model.DataName.ToString()));
		}

						if(model.DataValue!=null) 
		{
			list.Add(addFunc("DataValue",model.DataValue.ToString()));
		}

						if(model.Proportion!=null) 
		{
			list.Add(addFunc("Proportion",model.Proportion.ToString()));
		}

						if(model.Remark!=null) 
		{
			list.Add(addFunc("Remark",model.Remark.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Crm_DataAnalysis model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.DataType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DataType.ToString(),addFunc("[DataType]")));
		}
					

						if(model.DataCata!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DataCata.ToString(),addFunc("[DataCata]")));
		}
					

						if(model.DataName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DataName.ToString(),addFunc("[DataName]")));
		}
					

						if(model.DataValue!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DataValue.ToString(),addFunc("[DataValue]")));
		}
					

						if(model.Proportion!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Proportion.ToString(),addFunc("[Proportion]")));
		}
					

						if(model.Remark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Remark.ToString(),addFunc("[Remark]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Crm_DataAnalysis)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Crm_DataAnalysis)item[0];		
	var where=	(Crm_DataAnalysis)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Crm_DataAnalysis where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Crm_DataAnalysis where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Crm_DataAnalysis where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Crm_DataAnalysis where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Crm_DataAnalysis where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Crm_FinanceItemRepository : BaseRepository<Crm_FinanceItem>, ICrm_FinanceItemRepository
{
		public Crm_FinanceItemRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Crm_FinanceItem";
		} 
		public Crm_FinanceItemRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Crm_FinanceItem model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.DeliveryCount!=null) 
		{
			list.Add(addFunc("DeliveryCount",model.DeliveryCount.ToString()));
		}

						if(model.InteractionCount!=null) 
		{
			list.Add(addFunc("InteractionCount",model.InteractionCount.ToString()));
		}

						if(model.UnitPrice!=null) 
		{
			list.Add(addFunc("UnitPrice",model.UnitPrice.ToString()));
		}

						if(model.AmountMoney!=null) 
		{
			list.Add(addFunc("AmountMoney",model.AmountMoney.ToString()));
		}

						if(model.Remark!=null) 
		{
			list.Add(addFunc("Remark",model.Remark.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Crm_FinanceItem model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.DeliveryCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DeliveryCount.ToString(),addFunc("[DeliveryCount]")));
		}
					

						if(model.InteractionCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InteractionCount.ToString(),addFunc("[InteractionCount]")));
		}
					

						if(model.UnitPrice!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UnitPrice.ToString(),addFunc("[UnitPrice]")));
		}
					

						if(model.AmountMoney!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AmountMoney.ToString(),addFunc("[AmountMoney]")));
		}
					

						if(model.Remark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Remark.ToString(),addFunc("[Remark]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Crm_FinanceItem)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Crm_FinanceItem)item[0];		
	var where=	(Crm_FinanceItem)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Crm_FinanceItem where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Crm_FinanceItem where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Crm_FinanceItem where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Crm_FinanceItem where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Crm_FinanceItem where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Crm_InteractiveRepository : BaseRepository<Crm_Interactive>, ICrm_InteractiveRepository
{
		public Crm_InteractiveRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Crm_Interactive";
		} 
		public Crm_InteractiveRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Crm_Interactive model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.ProblemSysNo!=null) 
		{
			list.Add(addFunc("ProblemSysNo",model.ProblemSysNo.ToString()));
		}

						if(model.InteractiveName!=null) 
		{
			list.Add(addFunc("InteractiveName",model.InteractiveName.ToString()));
		}

						if(model.Number!=null) 
		{
			list.Add(addFunc("Number",model.Number.ToString()));
		}

						if(model.Proportion!=null) 
		{
			list.Add(addFunc("Proportion",model.Proportion.ToString()));
		}

						if(model.Remark!=null) 
		{
			list.Add(addFunc("Remark",model.Remark.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Crm_Interactive model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.ProblemSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ProblemSysNo.ToString(),addFunc("[ProblemSysNo]")));
		}
					

						if(model.InteractiveName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InteractiveName.ToString(),addFunc("[InteractiveName]")));
		}
					

						if(model.Number!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Number.ToString(),addFunc("[Number]")));
		}
					

						if(model.Proportion!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Proportion.ToString(),addFunc("[Proportion]")));
		}
					

						if(model.Remark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Remark.ToString(),addFunc("[Remark]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Crm_Interactive)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Crm_Interactive)item[0];		
	var where=	(Crm_Interactive)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Crm_Interactive where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Crm_Interactive where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Crm_Interactive where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Crm_Interactive where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Crm_Interactive where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Crm_ProblemRepository : BaseRepository<Crm_Problem>, ICrm_ProblemRepository
{
		public Crm_ProblemRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Crm_Problem";
		} 
		public Crm_ProblemRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Crm_Problem model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.Problem!=null) 
		{
			list.Add(addFunc("Problem",model.Problem.ToString()));
		}

						if(model.Remark!=null) 
		{
			list.Add(addFunc("Remark",model.Remark.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Crm_Problem model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.Problem!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Problem.ToString(),addFunc("[Problem]")));
		}
					

						if(model.Remark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Remark.ToString(),addFunc("[Remark]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Crm_Problem)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Crm_Problem)item[0];		
	var where=	(Crm_Problem)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Crm_Problem where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Crm_Problem where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Crm_Problem where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Crm_Problem where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Crm_Problem where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Crm_PushRepository : BaseRepository<Crm_Push>, ICrm_PushRepository
{
		public Crm_PushRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Crm_Push";
		} 
		public Crm_PushRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Crm_Push model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.PushType!=null) 
		{
			list.Add(addFunc("PushType",model.PushType.ToString()));
		}

						if(model.GoodsPic!=null) 
		{
			list.Add(addFunc("GoodsPic",model.GoodsPic.ToString()));
		}

						if(model.GoodsName!=null) 
		{
			list.Add(addFunc("GoodsName",model.GoodsName.ToString()));
		}

						if(model.PushCount!=null) 
		{
			list.Add(addFunc("PushCount",model.PushCount.ToString()));
		}

						if(model.ClickCount!=null) 
		{
			list.Add(addFunc("ClickCount",model.ClickCount.ToString()));
		}

						if(model.Remark!=null) 
		{
			list.Add(addFunc("Remark",model.Remark.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Crm_Push model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.PushType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PushType.ToString(),addFunc("[PushType]")));
		}
					

						if(model.GoodsPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsPic.ToString(),addFunc("[GoodsPic]")));
		}
					

						if(model.GoodsName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsName.ToString(),addFunc("[GoodsName]")));
		}
					

						if(model.PushCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PushCount.ToString(),addFunc("[PushCount]")));
		}
					

						if(model.ClickCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ClickCount.ToString(),addFunc("[ClickCount]")));
		}
					

						if(model.Remark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Remark.ToString(),addFunc("[Remark]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Crm_Push)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Crm_Push)item[0];		
	var where=	(Crm_Push)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Crm_Push where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Crm_Push where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Crm_Push where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Crm_Push where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Crm_Push where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class Crm_UserRepository : BaseRepository<Crm_User>, ICrm_UserRepository
{
		public Crm_UserRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="Crm_User";
		} 
		public Crm_UserRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(Crm_User model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.Mobile!=null) 
		{
			list.Add(addFunc("Mobile",model.Mobile.ToString()));
		}

						if(model.MemPassWord!=null) 
		{
			list.Add(addFunc("MemPassWord",model.MemPassWord.ToString()));
		}

						if(model.MerchantName!=null) 
		{
			list.Add(addFunc("MerchantName",model.MerchantName.ToString()));
		}

						if(model.MerchantFullName!=null) 
		{
			list.Add(addFunc("MerchantFullName",model.MerchantFullName.ToString()));
		}

						if(model.MerchantAddress!=null) 
		{
			list.Add(addFunc("MerchantAddress",model.MerchantAddress.ToString()));
		}

						if(model.TotalPush!=null) 
		{
			list.Add(addFunc("TotalPush",model.TotalPush.ToString()));
		}

						if(model.TotalAttend!=null) 
		{
			list.Add(addFunc("TotalAttend",model.TotalAttend.ToString()));
		}

						if(model.TotalShare!=null) 
		{
			list.Add(addFunc("TotalShare",model.TotalShare.ToString()));
		}

						if(model.AccountBalance!=null) 
		{
			list.Add(addFunc("AccountBalance",model.AccountBalance.ToString()));
		}

						if(model.TotalNumber!=null) 
		{
			list.Add(addFunc("TotalNumber",model.TotalNumber.ToString()));
		}

						if(model.UserCount!=null) 
		{
			list.Add(addFunc("UserCount",model.UserCount.ToString()));
		}

						if(model.Remark!=null) 
		{
			list.Add(addFunc("Remark",model.Remark.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

						if(model.BrandLogo!=null) 
		{
			list.Add(addFunc("BrandLogo",model.BrandLogo.ToString()));
		}

						if(model.MerchantMobile!=null) 
		{
			list.Add(addFunc("MerchantMobile",model.MerchantMobile.ToString()));
		}

						if(model.ShoppLink!=null) 
		{
			list.Add(addFunc("ShoppLink",model.ShoppLink.ToString()));
		}

						if(model.ContactPeople!=null) 
		{
			list.Add(addFunc("ContactPeople",model.ContactPeople.ToString()));
		}

						if(model.ComboPic!=null) 
		{
			list.Add(addFunc("ComboPic",model.ComboPic.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(Crm_User model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.Mobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Mobile.ToString(),addFunc("[Mobile]")));
		}
					

						if(model.MemPassWord!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MemPassWord.ToString(),addFunc("[MemPassWord]")));
		}
					

						if(model.MerchantName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MerchantName.ToString(),addFunc("[MerchantName]")));
		}
					

						if(model.MerchantFullName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MerchantFullName.ToString(),addFunc("[MerchantFullName]")));
		}
					

						if(model.MerchantAddress!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MerchantAddress.ToString(),addFunc("[MerchantAddress]")));
		}
					

						if(model.TotalPush!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.TotalPush.ToString(),addFunc("[TotalPush]")));
		}
					

						if(model.TotalAttend!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.TotalAttend.ToString(),addFunc("[TotalAttend]")));
		}
					

						if(model.TotalShare!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.TotalShare.ToString(),addFunc("[TotalShare]")));
		}
					

						if(model.AccountBalance!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AccountBalance.ToString(),addFunc("[AccountBalance]")));
		}
					

						if(model.TotalNumber!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.TotalNumber.ToString(),addFunc("[TotalNumber]")));
		}
					

						if(model.UserCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserCount.ToString(),addFunc("[UserCount]")));
		}
					

						if(model.Remark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Remark.ToString(),addFunc("[Remark]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

						if(model.BrandLogo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.BrandLogo.ToString(),addFunc("[BrandLogo]")));
		}
					

						if(model.MerchantMobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MerchantMobile.ToString(),addFunc("[MerchantMobile]")));
		}
					

						if(model.ShoppLink!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShoppLink.ToString(),addFunc("[ShoppLink]")));
		}
					

						if(model.ContactPeople!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ContactPeople.ToString(),addFunc("[ContactPeople]")));
		}
					

						if(model.ComboPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ComboPic.ToString(),addFunc("[ComboPic]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(Crm_User)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(Crm_User)item[0];		
	var where=	(Crm_User)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(Crm_User where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, Crm_User where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(Crm_User where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, Crm_User where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, Crm_User where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_AccountRecommendRepository : BaseRepository<T_AccountRecommend>, IT_AccountRecommendRepository
{
		public T_AccountRecommendRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_AccountRecommend";
		} 
		public T_AccountRecommendRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_AccountRecommend model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.InforSysNo!=null) 
		{
			list.Add(addFunc("InforSysNo",model.InforSysNo.ToString()));
		}

						if(model.IsPushIn!=null) 
		{
			list.Add(addFunc("IsPushIn",model.IsPushIn.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_AccountRecommend model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.InforSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforSysNo.ToString(),addFunc("[InforSysNo]")));
		}
					

						if(model.IsPushIn!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsPushIn.ToString(),addFunc("[IsPushIn]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_AccountRecommend)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_AccountRecommend)item[0];		
	var where=	(T_AccountRecommend)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_AccountRecommend where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_AccountRecommend where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_AccountRecommend where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_AccountRecommend where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_AccountRecommend where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_AccountRecordRepository : BaseRepository<T_AccountRecord>, IT_AccountRecordRepository
{
		public T_AccountRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_AccountRecord";
		} 
		public T_AccountRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_AccountRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.TranType!=null) 
		{
			list.Add(addFunc("TranType",model.TranType.ToString()));
		}

						if(model.PlusReduce!=null) 
		{
			list.Add(addFunc("PlusReduce",model.PlusReduce.ToString()));
		}

						if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.TranNum!=null) 
		{
			list.Add(addFunc("TranNum",model.TranNum.ToString()));
		}

						if(model.Company!=null) 
		{
			list.Add(addFunc("Company",model.Company.ToString()));
		}

						if(model.TranName!=null) 
		{
			list.Add(addFunc("TranName",model.TranName.ToString()));
		}

						if(model.InRemarks!=null) 
		{
			list.Add(addFunc("InRemarks",model.InRemarks.ToString()));
		}

						if(model.IsPushIn!=null) 
		{
			list.Add(addFunc("IsPushIn",model.IsPushIn.ToString()));
		}

						if(model.Remark!=null) 
		{
			list.Add(addFunc("Remark",model.Remark.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_AccountRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.TranType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.TranType.ToString(),addFunc("[TranType]")));
		}
					

						if(model.PlusReduce!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PlusReduce.ToString(),addFunc("[PlusReduce]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.TranNum!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.TranNum.ToString(),addFunc("[TranNum]")));
		}
					

						if(model.Company!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Company.ToString(),addFunc("[Company]")));
		}
					

						if(model.TranName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.TranName.ToString(),addFunc("[TranName]")));
		}
					

						if(model.InRemarks!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InRemarks.ToString(),addFunc("[InRemarks]")));
		}
					

						if(model.IsPushIn!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsPushIn.ToString(),addFunc("[IsPushIn]")));
		}
					

						if(model.Remark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Remark.ToString(),addFunc("[Remark]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_AccountRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_AccountRecord)item[0];		
	var where=	(T_AccountRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_AccountRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_AccountRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_AccountRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_AccountRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_AccountRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_AnswerRepository : BaseRepository<T_Answer>, IT_AnswerRepository
{
		public T_AnswerRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_Answer";
		} 
		public T_AnswerRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_Answer model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.SubSysNo!=null) 
		{
			list.Add(addFunc("SubSysNo",model.SubSysNo.ToString()));
		}

						if(model.ChildrenSubSysNo!=null) 
		{
			list.Add(addFunc("ChildrenSubSysNo",model.ChildrenSubSysNo.ToString()));
		}

						if(model.AnswerNameUrl!=null) 
		{
			list.Add(addFunc("AnswerNameUrl",model.AnswerNameUrl.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_Answer model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.SubSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SubSysNo.ToString(),addFunc("[SubSysNo]")));
		}
					

						if(model.ChildrenSubSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ChildrenSubSysNo.ToString(),addFunc("[ChildrenSubSysNo]")));
		}
					

						if(model.AnswerNameUrl!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AnswerNameUrl.ToString(),addFunc("[AnswerNameUrl]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_Answer)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_Answer)item[0];		
	var where=	(T_Answer)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_Answer where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_Answer where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_Answer where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_Answer where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_Answer where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_AnswerRecommendRepository : BaseRepository<T_AnswerRecommend>, IT_AnswerRecommendRepository
{
		public T_AnswerRecommendRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_AnswerRecommend";
		} 
		public T_AnswerRecommendRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_AnswerRecommend model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.AnsSysNo!=null) 
		{
			list.Add(addFunc("AnsSysNo",model.AnsSysNo.ToString()));
		}

						if(model.GoodsSysNo!=null) 
		{
			list.Add(addFunc("GoodsSysNo",model.GoodsSysNo.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_AnswerRecommend model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.AnsSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AnsSysNo.ToString(),addFunc("[AnsSysNo]")));
		}
					

						if(model.GoodsSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsSysNo.ToString(),addFunc("[GoodsSysNo]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_AnswerRecommend)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_AnswerRecommend)item[0];		
	var where=	(T_AnswerRecommend)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_AnswerRecommend where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_AnswerRecommend where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_AnswerRecommend where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_AnswerRecommend where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_AnswerRecommend where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_AnswerRecordRepository : BaseRepository<T_AnswerRecord>, IT_AnswerRecordRepository
{
		public T_AnswerRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_AnswerRecord";
		} 
		public T_AnswerRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_AnswerRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.SubSysNo!=null) 
		{
			list.Add(addFunc("SubSysNo",model.SubSysNo.ToString()));
		}

						if(model.AnsSysNo!=null) 
		{
			list.Add(addFunc("AnsSysNo",model.AnsSysNo.ToString()));
		}

						if(model.AnswerMoney!=null) 
		{
			list.Add(addFunc("AnswerMoney",model.AnswerMoney.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_AnswerRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.SubSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SubSysNo.ToString(),addFunc("[SubSysNo]")));
		}
					

						if(model.AnsSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AnsSysNo.ToString(),addFunc("[AnsSysNo]")));
		}
					

						if(model.AnswerMoney!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AnswerMoney.ToString(),addFunc("[AnswerMoney]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_AnswerRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_AnswerRecord)item[0];		
	var where=	(T_AnswerRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_AnswerRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_AnswerRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_AnswerRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_AnswerRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_AnswerRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_CategoryRepository : BaseRepository<T_Category>, IT_CategoryRepository
{
		public T_CategoryRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_Category";
		} 
		public T_CategoryRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_Category model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.CateId!=null) 
		{
			list.Add(addFunc("CateId",model.CateId.ToString()));
		}

						if(model.CateName!=null) 
		{
			list.Add(addFunc("CateName",model.CateName.ToString()));
		}

						if(model.CatePic!=null) 
		{
			list.Add(addFunc("CatePic",model.CatePic.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

						if(model.Sysno!=null && (long)model.Sysno!=0) 
		{
			list.Add(addFunc("Sysno",model.Sysno.ToString()));
		}	
								if(model.Cateid!=null) 
		{
			list.Add(addFunc("Cateid",model.Cateid.ToString()));
		}

						if(model.Catename!=null) 
		{
			list.Add(addFunc("Catename",model.Catename.ToString()));
		}

						if(model.Catepic!=null) 
		{
			list.Add(addFunc("Catepic",model.Catepic.ToString()));
		}

						if(model.Intsort!=null) 
		{
			list.Add(addFunc("Intsort",model.Intsort.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_Category model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.CateId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CateId.ToString(),addFunc("[CateId]")));
		}
					

						if(model.CateName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CateName.ToString(),addFunc("[CateName]")));
		}
					

						if(model.CatePic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CatePic.ToString(),addFunc("[CatePic]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

						if(model.Sysno!=null && (long)model.Sysno!=0) 
		{
			list.Add(string.Format("{1}={0}",model.Sysno.ToString(),addFunc("[Sysno]")));
		}
					

						if(model.Cateid!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Cateid.ToString(),addFunc("[Cateid]")));
		}
					

						if(model.Catename!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Catename.ToString(),addFunc("[Catename]")));
		}
					

						if(model.Catepic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Catepic.ToString(),addFunc("[Catepic]")));
		}
					

						if(model.Intsort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Intsort.ToString(),addFunc("[Intsort]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_Category)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_Category)item[0];		
	var where=	(T_Category)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_Category where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_Category where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_Category where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_Category where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_Category where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_CouponExcRecordRepository : BaseRepository<T_CouponExcRecord>, IT_CouponExcRecordRepository
{
		public T_CouponExcRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_CouponExcRecord";
		} 
		public T_CouponExcRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_CouponExcRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.ShopSysNo!=null) 
		{
			list.Add(addFunc("ShopSysNo",model.ShopSysNo.ToString()));
		}

						if(model.GoodsSysNo!=null) 
		{
			list.Add(addFunc("GoodsSysNo",model.GoodsSysNo.ToString()));
		}

						if(model.CouponSysNo!=null) 
		{
			list.Add(addFunc("CouponSysNo",model.CouponSysNo.ToString()));
		}

						if(model.PrivateCode!=null) 
		{
			list.Add(addFunc("PrivateCode",model.PrivateCode.ToString()));
		}

						if(model.ExcAmount!=null) 
		{
			list.Add(addFunc("ExcAmount",model.ExcAmount.ToString()));
		}

						if(model.UseScore!=null) 
		{
			list.Add(addFunc("UseScore",model.UseScore.ToString()));
		}

						if(model.RechargeAmount!=null) 
		{
			list.Add(addFunc("RechargeAmount",model.RechargeAmount.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.CouponState!=null) 
		{
			list.Add(addFunc("CouponState",model.CouponState.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_CouponExcRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.ShopSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShopSysNo.ToString(),addFunc("[ShopSysNo]")));
		}
					

						if(model.GoodsSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsSysNo.ToString(),addFunc("[GoodsSysNo]")));
		}
					

						if(model.CouponSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CouponSysNo.ToString(),addFunc("[CouponSysNo]")));
		}
					

						if(model.PrivateCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PrivateCode.ToString(),addFunc("[PrivateCode]")));
		}
					

						if(model.ExcAmount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ExcAmount.ToString(),addFunc("[ExcAmount]")));
		}
					

						if(model.UseScore!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UseScore.ToString(),addFunc("[UseScore]")));
		}
					

						if(model.RechargeAmount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RechargeAmount.ToString(),addFunc("[RechargeAmount]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.CouponState!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CouponState.ToString(),addFunc("[CouponState]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_CouponExcRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_CouponExcRecord)item[0];		
	var where=	(T_CouponExcRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_CouponExcRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_CouponExcRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_CouponExcRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_CouponExcRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_CouponExcRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_CouponInfoRepository : BaseRepository<T_CouponInfo>, IT_CouponInfoRepository
{
		public T_CouponInfoRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_CouponInfo";
		} 
		public T_CouponInfoRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_CouponInfo model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.ShopSysNo!=null) 
		{
			list.Add(addFunc("ShopSysNo",model.ShopSysNo.ToString()));
		}

						if(model.CouponName!=null) 
		{
			list.Add(addFunc("CouponName",model.CouponName.ToString()));
		}

						if(model.ExcAmount!=null) 
		{
			list.Add(addFunc("ExcAmount",model.ExcAmount.ToString()));
		}

						if(model.CouponType!=null) 
		{
			list.Add(addFunc("CouponType",model.CouponType.ToString()));
		}

						if(model.CouponCode!=null) 
		{
			list.Add(addFunc("CouponCode",model.CouponCode.ToString()));
		}

						if(model.UseRule!=null) 
		{
			list.Add(addFunc("UseRule",model.UseRule.ToString()));
		}

						if(model.RuleContent!=null) 
		{
			list.Add(addFunc("RuleContent",model.RuleContent.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_CouponInfo model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.ShopSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShopSysNo.ToString(),addFunc("[ShopSysNo]")));
		}
					

						if(model.CouponName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CouponName.ToString(),addFunc("[CouponName]")));
		}
					

						if(model.ExcAmount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ExcAmount.ToString(),addFunc("[ExcAmount]")));
		}
					

						if(model.CouponType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CouponType.ToString(),addFunc("[CouponType]")));
		}
					

						if(model.CouponCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CouponCode.ToString(),addFunc("[CouponCode]")));
		}
					

						if(model.UseRule!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UseRule.ToString(),addFunc("[UseRule]")));
		}
					

						if(model.RuleContent!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RuleContent.ToString(),addFunc("[RuleContent]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_CouponInfo)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_CouponInfo)item[0];		
	var where=	(T_CouponInfo)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_CouponInfo where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_CouponInfo where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_CouponInfo where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_CouponInfo where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_CouponInfo where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_CouponPrivateCodeRepository : BaseRepository<T_CouponPrivateCode>, IT_CouponPrivateCodeRepository
{
		public T_CouponPrivateCodeRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_CouponPrivateCode";
		} 
		public T_CouponPrivateCodeRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_CouponPrivateCode model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.CouponSysNo!=null) 
		{
			list.Add(addFunc("CouponSysNo",model.CouponSysNo.ToString()));
		}

						if(model.PrivateCode!=null) 
		{
			list.Add(addFunc("PrivateCode",model.PrivateCode.ToString()));
		}

						if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.ExcDateTime!=null) 
		{
			list.Add(addFunc("ExcDateTime",model.ExcDateTime.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_CouponPrivateCode model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.CouponSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CouponSysNo.ToString(),addFunc("[CouponSysNo]")));
		}
					

						if(model.PrivateCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PrivateCode.ToString(),addFunc("[PrivateCode]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.ExcDateTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ExcDateTime.ToString(),addFunc("[ExcDateTime]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_CouponPrivateCode)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_CouponPrivateCode)item[0];		
	var where=	(T_CouponPrivateCode)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_CouponPrivateCode where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_CouponPrivateCode where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_CouponPrivateCode where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_CouponPrivateCode where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_CouponPrivateCode where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_FavoritesRepository : BaseRepository<T_Favorites>, IT_FavoritesRepository
{
		public T_FavoritesRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_Favorites";
		} 
		public T_FavoritesRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_Favorites model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.InforSysNo!=null) 
		{
			list.Add(addFunc("InforSysNo",model.InforSysNo.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_Favorites model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.InforSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforSysNo.ToString(),addFunc("[InforSysNo]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_Favorites)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_Favorites)item[0];		
	var where=	(T_Favorites)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_Favorites where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_Favorites where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_Favorites where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_Favorites where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_Favorites where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_InforConfigureRepository : BaseRepository<T_InforConfigure>, IT_InforConfigureRepository
{
		public T_InforConfigureRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_InforConfigure";
		} 
		public T_InforConfigureRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_InforConfigure model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.DataType!=null) 
		{
			list.Add(addFunc("DataType",model.DataType.ToString()));
		}

						if(model.StrInforType!=null) 
		{
			list.Add(addFunc("StrInforType",model.StrInforType.ToString()));
		}

						if(model.InforName!=null) 
		{
			list.Add(addFunc("InforName",model.InforName.ToString()));
		}

						if(model.InforRemark!=null) 
		{
			list.Add(addFunc("InforRemark",model.InforRemark.ToString()));
		}

						if(model.InforDesc!=null) 
		{
			list.Add(addFunc("InforDesc",model.InforDesc.ToString()));
		}

						if(model.LogoIcon!=null) 
		{
			list.Add(addFunc("LogoIcon",model.LogoIcon.ToString()));
		}

						if(model.HeadPic!=null) 
		{
			list.Add(addFunc("HeadPic",model.HeadPic.ToString()));
		}

						if(model.CoverPic!=null) 
		{
			list.Add(addFunc("CoverPic",model.CoverPic.ToString()));
		}

						if(model.ShopPic!=null) 
		{
			list.Add(addFunc("ShopPic",model.ShopPic.ToString()));
		}

						if(model.PushPic!=null) 
		{
			list.Add(addFunc("PushPic",model.PushPic.ToString()));
		}

						if(model.VideoUrl!=null) 
		{
			list.Add(addFunc("VideoUrl",model.VideoUrl.ToString()));
		}

						if(model.CateId!=null) 
		{
			list.Add(addFunc("CateId",model.CateId.ToString()));
		}

						if(model.ShopSysNo!=null) 
		{
			list.Add(addFunc("ShopSysNo",model.ShopSysNo.ToString()));
		}

						if(model.ShowMode!=null) 
		{
			list.Add(addFunc("ShowMode",model.ShowMode.ToString()));
		}

						if(model.InforSource!=null) 
		{
			list.Add(addFunc("InforSource",model.InforSource.ToString()));
		}

						if(model.LinkUrl!=null) 
		{
			list.Add(addFunc("LinkUrl",model.LinkUrl.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.IsShowIndex!=null) 
		{
			list.Add(addFunc("IsShowIndex",model.IsShowIndex.ToString()));
		}

						if(model.SourceDateTime!=null) 
		{
			list.Add(addFunc("SourceDateTime",model.SourceDateTime.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_InforConfigure model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.DataType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DataType.ToString(),addFunc("[DataType]")));
		}
					

						if(model.StrInforType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.StrInforType.ToString(),addFunc("[StrInforType]")));
		}
					

						if(model.InforName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforName.ToString(),addFunc("[InforName]")));
		}
					

						if(model.InforRemark!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforRemark.ToString(),addFunc("[InforRemark]")));
		}
					

						if(model.InforDesc!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforDesc.ToString(),addFunc("[InforDesc]")));
		}
					

						if(model.LogoIcon!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.LogoIcon.ToString(),addFunc("[LogoIcon]")));
		}
					

						if(model.HeadPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.HeadPic.ToString(),addFunc("[HeadPic]")));
		}
					

						if(model.CoverPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CoverPic.ToString(),addFunc("[CoverPic]")));
		}
					

						if(model.ShopPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShopPic.ToString(),addFunc("[ShopPic]")));
		}
					

						if(model.PushPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PushPic.ToString(),addFunc("[PushPic]")));
		}
					

						if(model.VideoUrl!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.VideoUrl.ToString(),addFunc("[VideoUrl]")));
		}
					

						if(model.CateId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CateId.ToString(),addFunc("[CateId]")));
		}
					

						if(model.ShopSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShopSysNo.ToString(),addFunc("[ShopSysNo]")));
		}
					

						if(model.ShowMode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShowMode.ToString(),addFunc("[ShowMode]")));
		}
					

						if(model.InforSource!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforSource.ToString(),addFunc("[InforSource]")));
		}
					

						if(model.LinkUrl!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.LinkUrl.ToString(),addFunc("[LinkUrl]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.IsShowIndex!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsShowIndex.ToString(),addFunc("[IsShowIndex]")));
		}
					

						if(model.SourceDateTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SourceDateTime.ToString(),addFunc("[SourceDateTime]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_InforConfigure)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_InforConfigure)item[0];		
	var where=	(T_InforConfigure)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_InforConfigure where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_InforConfigure where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_InforConfigure where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_InforConfigure where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_InforConfigure where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_JiGuangPushRepository : BaseRepository<T_JiGuangPush>, IT_JiGuangPushRepository
{
		public T_JiGuangPushRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_JiGuangPush";
		} 
		public T_JiGuangPushRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_JiGuangPush model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.JiGuangSysNo!=null) 
		{
			list.Add(addFunc("JiGuangSysNo",model.JiGuangSysNo.ToString()));
		}

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(addFunc("SourceTypeSysNo",model.SourceTypeSysNo.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_JiGuangPush model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.JiGuangSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.JiGuangSysNo.ToString(),addFunc("[JiGuangSysNo]")));
		}
					

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SourceTypeSysNo.ToString(),addFunc("[SourceTypeSysNo]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_JiGuangPush)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_JiGuangPush)item[0];		
	var where=	(T_JiGuangPush)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_JiGuangPush where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_JiGuangPush where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_JiGuangPush where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_JiGuangPush where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_JiGuangPush where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_JiGuangPushRecordRepository : BaseRepository<T_JiGuangPushRecord>, IT_JiGuangPushRecordRepository
{
		public T_JiGuangPushRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_JiGuangPushRecord";
		} 
		public T_JiGuangPushRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_JiGuangPushRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.JiGuangSysNo!=null) 
		{
			list.Add(addFunc("JiGuangSysNo",model.JiGuangSysNo.ToString()));
		}

						if(model.MsgTitle!=null) 
		{
			list.Add(addFunc("MsgTitle",model.MsgTitle.ToString()));
		}

						if(model.MsgAlert!=null) 
		{
			list.Add(addFunc("MsgAlert",model.MsgAlert.ToString()));
		}

						if(model.MsgContent!=null) 
		{
			list.Add(addFunc("MsgContent",model.MsgContent.ToString()));
		}

						if(model.PushMsgId!=null) 
		{
			list.Add(addFunc("PushMsgId",model.PushMsgId.ToString()));
		}

						if(model.PushResult!=null) 
		{
			list.Add(addFunc("PushResult",model.PushResult.ToString()));
		}

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(addFunc("SourceTypeSysNo",model.SourceTypeSysNo.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_JiGuangPushRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.JiGuangSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.JiGuangSysNo.ToString(),addFunc("[JiGuangSysNo]")));
		}
					

						if(model.MsgTitle!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MsgTitle.ToString(),addFunc("[MsgTitle]")));
		}
					

						if(model.MsgAlert!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MsgAlert.ToString(),addFunc("[MsgAlert]")));
		}
					

						if(model.MsgContent!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MsgContent.ToString(),addFunc("[MsgContent]")));
		}
					

						if(model.PushMsgId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PushMsgId.ToString(),addFunc("[PushMsgId]")));
		}
					

						if(model.PushResult!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PushResult.ToString(),addFunc("[PushResult]")));
		}
					

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SourceTypeSysNo.ToString(),addFunc("[SourceTypeSysNo]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_JiGuangPushRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_JiGuangPushRecord)item[0];		
	var where=	(T_JiGuangPushRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_JiGuangPushRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_JiGuangPushRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_JiGuangPushRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_JiGuangPushRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_JiGuangPushRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_MemberRepository : BaseRepository<T_Member>, IT_MemberRepository
{
		public T_MemberRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_Member";
		} 
		public T_MemberRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_Member model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.Mobile!=null) 
		{
			list.Add(addFunc("Mobile",model.Mobile.ToString()));
		}

						if(model.Portrait!=null) 
		{
			list.Add(addFunc("Portrait",model.Portrait.ToString()));
		}

						if(model.MemPassWord!=null) 
		{
			list.Add(addFunc("MemPassWord",model.MemPassWord.ToString()));
		}

						if(model.NickName!=null) 
		{
			list.Add(addFunc("NickName",model.NickName.ToString()));
		}

						if(model.Sex!=null) 
		{
			list.Add(addFunc("Sex",model.Sex.ToString()));
		}

						if(model.RegProvince!=null) 
		{
			list.Add(addFunc("RegProvince",model.RegProvince.ToString()));
		}

						if(model.RegCity!=null) 
		{
			list.Add(addFunc("RegCity",model.RegCity.ToString()));
		}

						if(model.RegArea!=null) 
		{
			list.Add(addFunc("RegArea",model.RegArea.ToString()));
		}

						if(model.Birthday!=null) 
		{
			list.Add(addFunc("Birthday",model.Birthday.ToString()));
		}

						if(model.InforType!=null) 
		{
			list.Add(addFunc("InforType",model.InforType.ToString()));
		}

						if(model.Account!=null) 
		{
			list.Add(addFunc("Account",model.Account.ToString()));
		}

						if(model.AccountWithdrawn!=null) 
		{
			list.Add(addFunc("AccountWithdrawn",model.AccountWithdrawn.ToString()));
		}

						if(model.Score!=null) 
		{
			list.Add(addFunc("Score",model.Score.ToString()));
		}

						if(model.ScoreWithdrawn!=null) 
		{
			list.Add(addFunc("ScoreWithdrawn",model.ScoreWithdrawn.ToString()));
		}

						if(model.OpenidWxOpen!=null) 
		{
			list.Add(addFunc("OpenidWxOpen",model.OpenidWxOpen.ToString()));
		}

						if(model.LastLoginTime!=null) 
		{
			list.Add(addFunc("LastLoginTime",model.LastLoginTime.ToString()));
		}

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(addFunc("SourceTypeSysNo",model.SourceTypeSysNo.ToString()));
		}

						if(model.DeviceCode!=null) 
		{
			list.Add(addFunc("DeviceCode",model.DeviceCode.ToString()));
		}

						if(model.MobileModel!=null) 
		{
			list.Add(addFunc("MobileModel",model.MobileModel.ToString()));
		}

						if(model.ClientIp!=null) 
		{
			list.Add(addFunc("ClientIp",model.ClientIp.ToString()));
		}

						if(model.MinWithdrawals!=null) 
		{
			list.Add(addFunc("MinWithdrawals",model.MinWithdrawals.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.Timestamp!=null) 
		{
			list.Add(addFunc("Timestamp",model.Timestamp.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_Member model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.Mobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Mobile.ToString(),addFunc("[Mobile]")));
		}
					

						if(model.Portrait!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Portrait.ToString(),addFunc("[Portrait]")));
		}
					

						if(model.MemPassWord!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MemPassWord.ToString(),addFunc("[MemPassWord]")));
		}
					

						if(model.NickName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.NickName.ToString(),addFunc("[NickName]")));
		}
					

						if(model.Sex!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Sex.ToString(),addFunc("[Sex]")));
		}
					

						if(model.RegProvince!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegProvince.ToString(),addFunc("[RegProvince]")));
		}
					

						if(model.RegCity!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegCity.ToString(),addFunc("[RegCity]")));
		}
					

						if(model.RegArea!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RegArea.ToString(),addFunc("[RegArea]")));
		}
					

						if(model.Birthday!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Birthday.ToString(),addFunc("[Birthday]")));
		}
					

						if(model.InforType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforType.ToString(),addFunc("[InforType]")));
		}
					

						if(model.Account!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Account.ToString(),addFunc("[Account]")));
		}
					

						if(model.AccountWithdrawn!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AccountWithdrawn.ToString(),addFunc("[AccountWithdrawn]")));
		}
					

						if(model.Score!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Score.ToString(),addFunc("[Score]")));
		}
					

						if(model.ScoreWithdrawn!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ScoreWithdrawn.ToString(),addFunc("[ScoreWithdrawn]")));
		}
					

						if(model.OpenidWxOpen!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.OpenidWxOpen.ToString(),addFunc("[OpenidWxOpen]")));
		}
					

						if(model.LastLoginTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.LastLoginTime.ToString(),addFunc("[LastLoginTime]")));
		}
					

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SourceTypeSysNo.ToString(),addFunc("[SourceTypeSysNo]")));
		}
					

						if(model.DeviceCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DeviceCode.ToString(),addFunc("[DeviceCode]")));
		}
					

						if(model.MobileModel!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MobileModel.ToString(),addFunc("[MobileModel]")));
		}
					

						if(model.ClientIp!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ClientIp.ToString(),addFunc("[ClientIp]")));
		}
					

						if(model.MinWithdrawals!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MinWithdrawals.ToString(),addFunc("[MinWithdrawals]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.Timestamp!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Timestamp.ToString(),addFunc("[Timestamp]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_Member)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_Member)item[0];		
	var where=	(T_Member)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_Member where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_Member where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_Member where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_Member where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_Member where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_OperationLogRepository : BaseRepository<T_OperationLog>, IT_OperationLogRepository
{
		public T_OperationLogRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_OperationLog";
		} 
		public T_OperationLogRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_OperationLog model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.OperType!=null) 
		{
			list.Add(addFunc("OperType",model.OperType.ToString()));
		}

						if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(addFunc("SourceTypeSysNo",model.SourceTypeSysNo.ToString()));
		}

						if(model.IdentityId!=null) 
		{
			list.Add(addFunc("IdentityId",model.IdentityId.ToString()));
		}

						if(model.ClientIp!=null) 
		{
			list.Add(addFunc("ClientIp",model.ClientIp.ToString()));
		}

						if(model.DeviceCode!=null) 
		{
			list.Add(addFunc("DeviceCode",model.DeviceCode.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_OperationLog model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.OperType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.OperType.ToString(),addFunc("[OperType]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.SourceTypeSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SourceTypeSysNo.ToString(),addFunc("[SourceTypeSysNo]")));
		}
					

						if(model.IdentityId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IdentityId.ToString(),addFunc("[IdentityId]")));
		}
					

						if(model.ClientIp!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ClientIp.ToString(),addFunc("[ClientIp]")));
		}
					

						if(model.DeviceCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.DeviceCode.ToString(),addFunc("[DeviceCode]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_OperationLog)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_OperationLog)item[0];		
	var where=	(T_OperationLog)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_OperationLog where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_OperationLog where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_OperationLog where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_OperationLog where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_OperationLog where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_RechargeRepository : BaseRepository<T_Recharge>, IT_RechargeRepository
{
		public T_RechargeRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_Recharge";
		} 
		public T_RechargeRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_Recharge model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.ShopSysNo!=null) 
		{
			list.Add(addFunc("ShopSysNo",model.ShopSysNo.ToString()));
		}

						if(model.GoodsSysNo!=null) 
		{
			list.Add(addFunc("GoodsSysNo",model.GoodsSysNo.ToString()));
		}

						if(model.GoodsName!=null) 
		{
			list.Add(addFunc("GoodsName",model.GoodsName.ToString()));
		}

						if(model.RechargeAmount!=null) 
		{
			list.Add(addFunc("RechargeAmount",model.RechargeAmount.ToString()));
		}

						if(model.PaymentNumber!=null) 
		{
			list.Add(addFunc("PaymentNumber",model.PaymentNumber.ToString()));
		}

						if(model.PayTime!=null) 
		{
			list.Add(addFunc("PayTime",model.PayTime.ToString()));
		}

						if(model.PayState!=null) 
		{
			list.Add(addFunc("PayState",model.PayState.ToString()));
		}

						if(model.IsUse!=null) 
		{
			list.Add(addFunc("IsUse",model.IsUse.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_Recharge model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.ShopSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShopSysNo.ToString(),addFunc("[ShopSysNo]")));
		}
					

						if(model.GoodsSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsSysNo.ToString(),addFunc("[GoodsSysNo]")));
		}
					

						if(model.GoodsName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsName.ToString(),addFunc("[GoodsName]")));
		}
					

						if(model.RechargeAmount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RechargeAmount.ToString(),addFunc("[RechargeAmount]")));
		}
					

						if(model.PaymentNumber!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PaymentNumber.ToString(),addFunc("[PaymentNumber]")));
		}
					

						if(model.PayTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PayTime.ToString(),addFunc("[PayTime]")));
		}
					

						if(model.PayState!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PayState.ToString(),addFunc("[PayState]")));
		}
					

						if(model.IsUse!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsUse.ToString(),addFunc("[IsUse]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_Recharge)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_Recharge)item[0];		
	var where=	(T_Recharge)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_Recharge where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_Recharge where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_Recharge where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_Recharge where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_Recharge where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_SelfMediaArticleRepository : BaseRepository<T_SelfMediaArticle>, IT_SelfMediaArticleRepository
{
		public T_SelfMediaArticleRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_SelfMediaArticle";
		} 
		public T_SelfMediaArticleRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_SelfMediaArticle model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.StrInforType!=null) 
		{
			list.Add(addFunc("StrInforType",model.StrInforType.ToString()));
		}

						if(model.AuthorSysNo!=null) 
		{
			list.Add(addFunc("AuthorSysNo",model.AuthorSysNo.ToString()));
		}

						if(model.HeadPic!=null) 
		{
			list.Add(addFunc("HeadPic",model.HeadPic.ToString()));
		}

						if(model.Title!=null) 
		{
			list.Add(addFunc("Title",model.Title.ToString()));
		}

						if(model.Subtitle!=null) 
		{
			list.Add(addFunc("Subtitle",model.Subtitle.ToString()));
		}

						if(model.Content!=null) 
		{
			list.Add(addFunc("Content",model.Content.ToString()));
		}

						if(model.ReadScore!=null) 
		{
			list.Add(addFunc("ReadScore",model.ReadScore.ToString()));
		}

						if(model.IsHot!=null) 
		{
			list.Add(addFunc("IsHot",model.IsHot.ToString()));
		}

						if(model.ShowMode!=null) 
		{
			list.Add(addFunc("ShowMode",model.ShowMode.ToString()));
		}

						if(model.IsShowIndex!=null) 
		{
			list.Add(addFunc("IsShowIndex",model.IsShowIndex.ToString()));
		}

						if(model.SortId!=null) 
		{
			list.Add(addFunc("SortId",model.SortId.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_SelfMediaArticle model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.StrInforType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.StrInforType.ToString(),addFunc("[StrInforType]")));
		}
					

						if(model.AuthorSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AuthorSysNo.ToString(),addFunc("[AuthorSysNo]")));
		}
					

						if(model.HeadPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.HeadPic.ToString(),addFunc("[HeadPic]")));
		}
					

						if(model.Title!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Title.ToString(),addFunc("[Title]")));
		}
					

						if(model.Subtitle!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Subtitle.ToString(),addFunc("[Subtitle]")));
		}
					

						if(model.Content!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Content.ToString(),addFunc("[Content]")));
		}
					

						if(model.ReadScore!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ReadScore.ToString(),addFunc("[ReadScore]")));
		}
					

						if(model.IsHot!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsHot.ToString(),addFunc("[IsHot]")));
		}
					

						if(model.ShowMode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShowMode.ToString(),addFunc("[ShowMode]")));
		}
					

						if(model.IsShowIndex!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsShowIndex.ToString(),addFunc("[IsShowIndex]")));
		}
					

						if(model.SortId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SortId.ToString(),addFunc("[SortId]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_SelfMediaArticle)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_SelfMediaArticle)item[0];		
	var where=	(T_SelfMediaArticle)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_SelfMediaArticle where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_SelfMediaArticle where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_SelfMediaArticle where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_SelfMediaArticle where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_SelfMediaArticle where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_SelfMediaAuthorRepository : BaseRepository<T_SelfMediaAuthor>, IT_SelfMediaAuthorRepository
{
		public T_SelfMediaAuthorRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_SelfMediaAuthor";
		} 
		public T_SelfMediaAuthorRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_SelfMediaAuthor model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.AuthorName!=null) 
		{
			list.Add(addFunc("AuthorName",model.AuthorName.ToString()));
		}

						if(model.Portrait!=null) 
		{
			list.Add(addFunc("Portrait",model.Portrait.ToString()));
		}

						if(model.Describe!=null) 
		{
			list.Add(addFunc("Describe",model.Describe.ToString()));
		}

						if(model.Score!=null) 
		{
			list.Add(addFunc("Score",model.Score.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_SelfMediaAuthor model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.AuthorName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AuthorName.ToString(),addFunc("[AuthorName]")));
		}
					

						if(model.Portrait!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Portrait.ToString(),addFunc("[Portrait]")));
		}
					

						if(model.Describe!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Describe.ToString(),addFunc("[Describe]")));
		}
					

						if(model.Score!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Score.ToString(),addFunc("[Score]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_SelfMediaAuthor)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_SelfMediaAuthor)item[0];		
	var where=	(T_SelfMediaAuthor)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_SelfMediaAuthor where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_SelfMediaAuthor where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_SelfMediaAuthor where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_SelfMediaAuthor where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_SelfMediaAuthor where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_SelfMediaFollowRecordRepository : BaseRepository<T_SelfMediaFollowRecord>, IT_SelfMediaFollowRecordRepository
{
		public T_SelfMediaFollowRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_SelfMediaFollowRecord";
		} 
		public T_SelfMediaFollowRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_SelfMediaFollowRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.AuthorSysNo!=null) 
		{
			list.Add(addFunc("AuthorSysNo",model.AuthorSysNo.ToString()));
		}

						if(model.IsFollow!=null) 
		{
			list.Add(addFunc("IsFollow",model.IsFollow.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_SelfMediaFollowRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.AuthorSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AuthorSysNo.ToString(),addFunc("[AuthorSysNo]")));
		}
					

						if(model.IsFollow!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsFollow.ToString(),addFunc("[IsFollow]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_SelfMediaFollowRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_SelfMediaFollowRecord)item[0];		
	var where=	(T_SelfMediaFollowRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_SelfMediaFollowRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_SelfMediaFollowRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_SelfMediaFollowRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_SelfMediaFollowRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_SelfMediaFollowRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_SelfMediaPayRecordRepository : BaseRepository<T_SelfMediaPayRecord>, IT_SelfMediaPayRecordRepository
{
		public T_SelfMediaPayRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_SelfMediaPayRecord";
		} 
		public T_SelfMediaPayRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_SelfMediaPayRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.AuthorSysNo!=null) 
		{
			list.Add(addFunc("AuthorSysNo",model.AuthorSysNo.ToString()));
		}

						if(model.ArticleSysNo!=null) 
		{
			list.Add(addFunc("ArticleSysNo",model.ArticleSysNo.ToString()));
		}

						if(model.PayScore!=null) 
		{
			list.Add(addFunc("PayScore",model.PayScore.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_SelfMediaPayRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.AuthorSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AuthorSysNo.ToString(),addFunc("[AuthorSysNo]")));
		}
					

						if(model.ArticleSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ArticleSysNo.ToString(),addFunc("[ArticleSysNo]")));
		}
					

						if(model.PayScore!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.PayScore.ToString(),addFunc("[PayScore]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_SelfMediaPayRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_SelfMediaPayRecord)item[0];		
	var where=	(T_SelfMediaPayRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_SelfMediaPayRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_SelfMediaPayRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_SelfMediaPayRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_SelfMediaPayRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_SelfMediaPayRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_SelfMediaRedDotRecordRepository : BaseRepository<T_SelfMediaRedDotRecord>, IT_SelfMediaRedDotRecordRepository
{
		public T_SelfMediaRedDotRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_SelfMediaRedDotRecord";
		} 
		public T_SelfMediaRedDotRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_SelfMediaRedDotRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.AuthorSysNo!=null) 
		{
			list.Add(addFunc("AuthorSysNo",model.AuthorSysNo.ToString()));
		}

						if(model.ArticleSysNo!=null) 
		{
			list.Add(addFunc("ArticleSysNo",model.ArticleSysNo.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_SelfMediaRedDotRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.AuthorSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AuthorSysNo.ToString(),addFunc("[AuthorSysNo]")));
		}
					

						if(model.ArticleSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ArticleSysNo.ToString(),addFunc("[ArticleSysNo]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_SelfMediaRedDotRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_SelfMediaRedDotRecord)item[0];		
	var where=	(T_SelfMediaRedDotRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_SelfMediaRedDotRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_SelfMediaRedDotRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_SelfMediaRedDotRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_SelfMediaRedDotRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_SelfMediaRedDotRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_SelfMediaSaveRecordRepository : BaseRepository<T_SelfMediaSaveRecord>, IT_SelfMediaSaveRecordRepository
{
		public T_SelfMediaSaveRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_SelfMediaSaveRecord";
		} 
		public T_SelfMediaSaveRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_SelfMediaSaveRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.Mobile!=null) 
		{
			list.Add(addFunc("Mobile",model.Mobile.ToString()));
		}

						if(model.AuthorSysNo!=null) 
		{
			list.Add(addFunc("AuthorSysNo",model.AuthorSysNo.ToString()));
		}

						if(model.ArticleSysNo!=null) 
		{
			list.Add(addFunc("ArticleSysNo",model.ArticleSysNo.ToString()));
		}

						if(model.TranNum!=null) 
		{
			list.Add(addFunc("TranNum",model.TranNum.ToString()));
		}

						if(model.IsTransfer!=null) 
		{
			list.Add(addFunc("IsTransfer",model.IsTransfer.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_SelfMediaSaveRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.Mobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Mobile.ToString(),addFunc("[Mobile]")));
		}
					

						if(model.AuthorSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AuthorSysNo.ToString(),addFunc("[AuthorSysNo]")));
		}
					

						if(model.ArticleSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ArticleSysNo.ToString(),addFunc("[ArticleSysNo]")));
		}
					

						if(model.TranNum!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.TranNum.ToString(),addFunc("[TranNum]")));
		}
					

						if(model.IsTransfer!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsTransfer.ToString(),addFunc("[IsTransfer]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_SelfMediaSaveRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_SelfMediaSaveRecord)item[0];		
	var where=	(T_SelfMediaSaveRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_SelfMediaSaveRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_SelfMediaSaveRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_SelfMediaSaveRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_SelfMediaSaveRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_SelfMediaSaveRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_ShareAnswerRecordRepository : BaseRepository<T_ShareAnswerRecord>, IT_ShareAnswerRecordRepository
{
		public T_ShareAnswerRecordRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_ShareAnswerRecord";
		} 
		public T_ShareAnswerRecordRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_ShareAnswerRecord model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.Mobile!=null) 
		{
			list.Add(addFunc("Mobile",model.Mobile.ToString()));
		}

						if(model.SubSysNo!=null) 
		{
			list.Add(addFunc("SubSysNo",model.SubSysNo.ToString()));
		}

						if(model.AnsSysNo!=null) 
		{
			list.Add(addFunc("AnsSysNo",model.AnsSysNo.ToString()));
		}

						if(model.AnswerMoney!=null) 
		{
			list.Add(addFunc("AnswerMoney",model.AnswerMoney.ToString()));
		}

						if(model.IsTransfer!=null) 
		{
			list.Add(addFunc("IsTransfer",model.IsTransfer.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_ShareAnswerRecord model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.Mobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Mobile.ToString(),addFunc("[Mobile]")));
		}
					

						if(model.SubSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SubSysNo.ToString(),addFunc("[SubSysNo]")));
		}
					

						if(model.AnsSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AnsSysNo.ToString(),addFunc("[AnsSysNo]")));
		}
					

						if(model.AnswerMoney!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AnswerMoney.ToString(),addFunc("[AnswerMoney]")));
		}
					

						if(model.IsTransfer!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsTransfer.ToString(),addFunc("[IsTransfer]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_ShareAnswerRecord)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_ShareAnswerRecord)item[0];		
	var where=	(T_ShareAnswerRecord)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_ShareAnswerRecord where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_ShareAnswerRecord where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_ShareAnswerRecord where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_ShareAnswerRecord where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_ShareAnswerRecord where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_ShareRegisterRepository : BaseRepository<T_ShareRegister>, IT_ShareRegisterRepository
{
		public T_ShareRegisterRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_ShareRegister";
		} 
		public T_ShareRegisterRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_ShareRegister model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.ShareSysNo!=null) 
		{
			list.Add(addFunc("ShareSysNo",model.ShareSysNo.ToString()));
		}

						if(model.ShareUserId!=null) 
		{
			list.Add(addFunc("ShareUserId",model.ShareUserId.ToString()));
		}

						if(model.CoverMobile!=null) 
		{
			list.Add(addFunc("CoverMobile",model.CoverMobile.ToString()));
		}

						if(model.CoverUserId!=null) 
		{
			list.Add(addFunc("CoverUserId",model.CoverUserId.ToString()));
		}

						if(model.IsReceive!=null) 
		{
			list.Add(addFunc("IsReceive",model.IsReceive.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_ShareRegister model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.ShareSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShareSysNo.ToString(),addFunc("[ShareSysNo]")));
		}
					

						if(model.ShareUserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShareUserId.ToString(),addFunc("[ShareUserId]")));
		}
					

						if(model.CoverMobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CoverMobile.ToString(),addFunc("[CoverMobile]")));
		}
					

						if(model.CoverUserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CoverUserId.ToString(),addFunc("[CoverUserId]")));
		}
					

						if(model.IsReceive!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsReceive.ToString(),addFunc("[IsReceive]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_ShareRegister)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_ShareRegister)item[0];		
	var where=	(T_ShareRegister)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_ShareRegister where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_ShareRegister where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_ShareRegister where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_ShareRegister where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_ShareRegister where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_ShopGoodsRepository : BaseRepository<T_ShopGoods>, IT_ShopGoodsRepository
{
		public T_ShopGoodsRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_ShopGoods";
		} 
		public T_ShopGoodsRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_ShopGoods model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.ShopSysNo!=null) 
		{
			list.Add(addFunc("ShopSysNo",model.ShopSysNo.ToString()));
		}

						if(model.GoodsName!=null) 
		{
			list.Add(addFunc("GoodsName",model.GoodsName.ToString()));
		}

						if(model.GoodsPic!=null) 
		{
			list.Add(addFunc("GoodsPic",model.GoodsPic.ToString()));
		}

						if(model.GoodsOutLink!=null) 
		{
			list.Add(addFunc("GoodsOutLink",model.GoodsOutLink.ToString()));
		}

						if(model.MarketPrice!=null) 
		{
			list.Add(addFunc("MarketPrice",model.MarketPrice.ToString()));
		}

						if(model.GoodsLabelOne!=null) 
		{
			list.Add(addFunc("GoodsLabelOne",model.GoodsLabelOne.ToString()));
		}

						if(model.GoodsLabelTwo!=null) 
		{
			list.Add(addFunc("GoodsLabelTwo",model.GoodsLabelTwo.ToString()));
		}

						if(model.ExcCouponSysNo!=null) 
		{
			list.Add(addFunc("ExcCouponSysNo",model.ExcCouponSysNo.ToString()));
		}

						if(model.CouponCount!=null) 
		{
			list.Add(addFunc("CouponCount",model.CouponCount.ToString()));
		}

						if(model.UseCouponCount!=null) 
		{
			list.Add(addFunc("UseCouponCount",model.UseCouponCount.ToString()));
		}

						if(model.OverCouponCount!=null) 
		{
			list.Add(addFunc("OverCouponCount",model.OverCouponCount.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_ShopGoods model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.ShopSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ShopSysNo.ToString(),addFunc("[ShopSysNo]")));
		}
					

						if(model.GoodsName!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsName.ToString(),addFunc("[GoodsName]")));
		}
					

						if(model.GoodsPic!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsPic.ToString(),addFunc("[GoodsPic]")));
		}
					

						if(model.GoodsOutLink!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsOutLink.ToString(),addFunc("[GoodsOutLink]")));
		}
					

						if(model.MarketPrice!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.MarketPrice.ToString(),addFunc("[MarketPrice]")));
		}
					

						if(model.GoodsLabelOne!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsLabelOne.ToString(),addFunc("[GoodsLabelOne]")));
		}
					

						if(model.GoodsLabelTwo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.GoodsLabelTwo.ToString(),addFunc("[GoodsLabelTwo]")));
		}
					

						if(model.ExcCouponSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ExcCouponSysNo.ToString(),addFunc("[ExcCouponSysNo]")));
		}
					

						if(model.CouponCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.CouponCount.ToString(),addFunc("[CouponCount]")));
		}
					

						if(model.UseCouponCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UseCouponCount.ToString(),addFunc("[UseCouponCount]")));
		}
					

						if(model.OverCouponCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.OverCouponCount.ToString(),addFunc("[OverCouponCount]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_ShopGoods)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_ShopGoods)item[0];		
	var where=	(T_ShopGoods)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_ShopGoods where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_ShopGoods where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_ShopGoods where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_ShopGoods where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_ShopGoods where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_SmsRepository : BaseRepository<T_Sms>, IT_SmsRepository
{
		public T_SmsRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_Sms";
		} 
		public T_SmsRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_Sms model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.Mobile!=null) 
		{
			list.Add(addFunc("Mobile",model.Mobile.ToString()));
		}

						if(model.SmsType!=null) 
		{
			list.Add(addFunc("SmsType",model.SmsType.ToString()));
		}

						if(model.SmsCode!=null) 
		{
			list.Add(addFunc("SmsCode",model.SmsCode.ToString()));
		}

						if(model.SmsStatus!=null) 
		{
			list.Add(addFunc("SmsStatus",model.SmsStatus.ToString()));
		}

						if(model.ExpireTime!=null) 
		{
			list.Add(addFunc("ExpireTime",model.ExpireTime.ToString()));
		}

						if(model.VerifTime!=null) 
		{
			list.Add(addFunc("VerifTime",model.VerifTime.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_Sms model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.Mobile!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.Mobile.ToString(),addFunc("[Mobile]")));
		}
					

						if(model.SmsType!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SmsType.ToString(),addFunc("[SmsType]")));
		}
					

						if(model.SmsCode!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SmsCode.ToString(),addFunc("[SmsCode]")));
		}
					

						if(model.SmsStatus!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.SmsStatus.ToString(),addFunc("[SmsStatus]")));
		}
					

						if(model.ExpireTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ExpireTime.ToString(),addFunc("[ExpireTime]")));
		}
					

						if(model.VerifTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.VerifTime.ToString(),addFunc("[VerifTime]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_Sms)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_Sms)item[0];		
	var where=	(T_Sms)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_Sms where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_Sms where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_Sms where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_Sms where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_Sms where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_SubjectRepository : BaseRepository<T_Subject>, IT_SubjectRepository
{
		public T_SubjectRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_Subject";
		} 
		public T_SubjectRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_Subject model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.InforSysNo!=null) 
		{
			list.Add(addFunc("InforSysNo",model.InforSysNo.ToString()));
		}

						if(model.ProblemNameUrl!=null) 
		{
			list.Add(addFunc("ProblemNameUrl",model.ProblemNameUrl.ToString()));
		}

						if(model.AnswerMoney!=null) 
		{
			list.Add(addFunc("AnswerMoney",model.AnswerMoney.ToString()));
		}

						if(model.IntSort!=null) 
		{
			list.Add(addFunc("IntSort",model.IntSort.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

						if(model.AnswerCount!=null) 
		{
			list.Add(addFunc("AnswerCount",model.AnswerCount.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_Subject model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.InforSysNo!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.InforSysNo.ToString(),addFunc("[InforSysNo]")));
		}
					

						if(model.ProblemNameUrl!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ProblemNameUrl.ToString(),addFunc("[ProblemNameUrl]")));
		}
					

						if(model.AnswerMoney!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AnswerMoney.ToString(),addFunc("[AnswerMoney]")));
		}
					

						if(model.IntSort!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IntSort.ToString(),addFunc("[IntSort]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

						if(model.AnswerCount!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.AnswerCount.ToString(),addFunc("[AnswerCount]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_Subject)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_Subject)item[0];		
	var where=	(T_Subject)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_Subject where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_Subject where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_Subject where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_Subject where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_Subject where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
public partial class T_WithdrawalsRepository : BaseRepository<T_Withdrawals>, IT_WithdrawalsRepository
{
		public T_WithdrawalsRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
		{
			_tableName="T_Withdrawals";
		} 
		public T_WithdrawalsRepository(IUnitOfWork unitOfWork,string tableName)
        : base(unitOfWork)
		{
			_tableName=tableName;
		}  
		private string _tableName;
	
	protected override string GetSqlFromModel(T_Withdrawals model,Func<string,string,string> addFunc,Func<string,string> joinFunc)
	{
		if(null==model)
		{
			return string.Empty;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(addFunc("SysNo",model.SysNo.ToString()));
		}	
								if(model.UserId!=null) 
		{
			list.Add(addFunc("UserId",model.UserId.ToString()));
		}

						if(model.OpenidWxOpen!=null) 
		{
			list.Add(addFunc("OpenidWxOpen",model.OpenidWxOpen.ToString()));
		}

						if(model.OpenidWxMp!=null) 
		{
			list.Add(addFunc("OpenidWxMp",model.OpenidWxMp.ToString()));
		}

						if(model.WithdrawalsMoney!=null) 
		{
			list.Add(addFunc("WithdrawalsMoney",model.WithdrawalsMoney.ToString()));
		}

						if(model.WithdrawalsState!=null) 
		{
			list.Add(addFunc("WithdrawalsState",model.WithdrawalsState.ToString()));
		}

						if(model.RowCeateDate!=null) 
		{
			list.Add(addFunc("RowCeateDate",model.RowCeateDate.ToString()));
		}

						if(model.ModifyTime!=null) 
		{
			list.Add(addFunc("ModifyTime",model.ModifyTime.ToString()));
		}

						if(model.IsEnable!=null) 
		{
			list.Add(addFunc("IsEnable",model.IsEnable.ToString()));
		}

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

	protected override string GetWhereSqlFromModel(T_Withdrawals model,Func<string,string> joinFunc,Func<string,string> addFunc=null)
	{
		if(null==model)
		{
			return string.Empty;
		}
		if(addFunc==null)
		{
			addFunc=(s)=>s;
		}
		List<string> list=new List<string>();
				if(model.SysNo!=null && (long)model.SysNo!=0) 
		{
			list.Add(string.Format("{1}={0}",model.SysNo.ToString(),addFunc("[SysNo]")));
		}
					

						if(model.UserId!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.UserId.ToString(),addFunc("[UserId]")));
		}
					

						if(model.OpenidWxOpen!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.OpenidWxOpen.ToString(),addFunc("[OpenidWxOpen]")));
		}
					

						if(model.OpenidWxMp!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.OpenidWxMp.ToString(),addFunc("[OpenidWxMp]")));
		}
					

						if(model.WithdrawalsMoney!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.WithdrawalsMoney.ToString(),addFunc("[WithdrawalsMoney]")));
		}
					

						if(model.WithdrawalsState!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.WithdrawalsState.ToString(),addFunc("[WithdrawalsState]")));
		}
					

						if(model.RowCeateDate!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.RowCeateDate.ToString(),addFunc("[RowCeateDate]")));
		}
					

						if(model.ModifyTime!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.ModifyTime.ToString(),addFunc("[ModifyTime]")));
		}
					

						if(model.IsEnable!=null) 
		{
			list.Add(string.Format("{1}='{0}'",model.IsEnable.ToString(),addFunc("[IsEnable]")));
		}
					

					
		return string.Join(joinFunc(string.Empty),list.ToArray());
	}

public override string PersistNewItem(params ModelBase[] item)
{
	var data=(T_Withdrawals)item[0];
string sql = string.Format("insert into {2}({0}) values({1})",
                                this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]",name),s=>","),
								this.GetSqlFromModel(data,(name,value)=>string.Format("'{0}'",value),s=>","),_tableName);
    return sql;
}

public override string PersistUpdatedItem(params ModelBase[] item)
{
	var data=(T_Withdrawals)item[0];		
	var where=	(T_Withdrawals)item[1];
string sql = string.Format("update {2} set {0} where {1}",  
						this.GetSqlFromModel(data,(name,value)=>string.Format("[{0}]='{1}'",name,value),s=>","),
						this.GetWhereSqlFromModel(where,s=>" and "),_tableName);
    return sql;
}      

protected override string QueryBySql(T_Withdrawals where = null, string order = null)
{
	string whereStr = string.Empty;
	if (null != where)
	{
		string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
		if (!string.IsNullOrEmpty(whereSql))
		{
			whereStr = string.Format("where {0}", whereSql);
		}
	}
    string sql = string.Format("select * from {2} {0} {1}", whereStr, order,_tableName);
    return sql;
}

protected override string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T_Withdrawals where = null, string order = null)
{
    string whereStr = string.Empty;
    if (null != where)
    {
        whereStr =this.GetWhereSqlFromModel(where, s => " and ");
    }
    string sql =
        string.Format(
            @"SELECT  t.*
			FROM    ( SELECT    * ,
								ROW_NUMBER() OVER ({0}) AS Rn
					  FROM {4} {1}
					) AS t
			WHERE   t.Rn BETWEEN {2} AND {3}",
            string.IsNullOrEmpty(order)?"ORDER BY GETDATE()":order,
            (string.IsNullOrEmpty(whereStr) ? string.Empty : string.Format("where {0}", whereStr)),
			(pageIndex-1)*pageSize+1,
			pageSize*pageIndex,_tableName);

    return sql;
}

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QueryCountBySql(T_Withdrawals where = null)
        {
            //TODO:Where不能为空

            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select count(1) from {1} {0} ", whereStr,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询指定列的数据之和
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected override string QuerySumBySql(string columnName, T_Withdrawals where = null)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(string.Format("查询指定列数据汇总失败，失败详情：指定列名不能为空"));

            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select SUM({1}) from {2} {0} ", whereStr, columnName,_tableName);
            return sql;
        }

        /// <summary>
        /// 查询top条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected override string QueryTopBySql(int? top, T_Withdrawals where = null, string order = null)
        {
            if (null == top)
            {
                throw new ArgumentNullException(string.Format("查询指定TOP数据失败，失败详情：TOP不能为空"));
            }
            string whereStr = string.Empty;
            if (null != where)
            {
                string whereSql = this.GetWhereSqlFromModel(where, s => " and ");
                if (!string.IsNullOrEmpty(whereSql))
                {
                    whereStr = string.Format("where {0}", whereSql);
                }
            }
            string sql = string.Format("select top ({2}) * from {3} {0} {1}", whereStr, order,
                                       Math.Abs((int)top),_tableName);

            return sql;
        }


public override void AddDataTable(System.Data.DataTable dataTable)
        {
            base.AddDataTable(dataTable,_tableName);
        }

}
	
}