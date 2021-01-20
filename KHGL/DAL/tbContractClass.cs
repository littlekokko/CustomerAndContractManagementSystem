/*
* tbContractClass.cs
*
* 功 能： N/A
* 类 名： tbContractClass
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbContractClass
	/// </summary>
	public partial class tbContractClass
	{
		public tbContractClass()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TId", "tbContractClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbContractClass");
			strSql.Append(" where TId=@TId");
			SqlParameter[] parameters = {
					new SqlParameter("@TId", SqlDbType.Int,4)
			};
			parameters[0].Value = TId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tbContractClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbContractClass(");
			strSql.Append("TName,is_del)");
			strSql.Append(" values (");
			strSql.Append("@TName,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,50),
					new SqlParameter("@is_del", SqlDbType.Int,4)};
			parameters[0].Value = model.TName;
			parameters[1].Value = model.is_del;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tbContractClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbContractClass set ");
			strSql.Append("TName=@TName,");
			strSql.Append("is_del=@is_del");
			strSql.Append(" where TId=@TId");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,50),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@TId", SqlDbType.Int,4)};
			parameters[0].Value = model.TName;
			parameters[1].Value = model.is_del;
			parameters[2].Value = model.TId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbContractClass ");
			strSql.Append(" where TId=@TId");
			SqlParameter[] parameters = {
					new SqlParameter("@TId", SqlDbType.Int,4)
			};
			parameters[0].Value = TId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string TIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbContractClass ");
			strSql.Append(" where TId in ("+TIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tbContractClass GetModel(int TId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TId,TName,is_del from tbContractClass ");
			strSql.Append(" where TId=@TId");
			SqlParameter[] parameters = {
					new SqlParameter("@TId", SqlDbType.Int,4)
			};
			parameters[0].Value = TId;

			Maticsoft.Model.tbContractClass model=new Maticsoft.Model.tbContractClass();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tbContractClass DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbContractClass model=new Maticsoft.Model.tbContractClass();
			if (row != null)
			{
				if(row["TId"]!=null && row["TId"].ToString()!="")
				{
					model.TId=int.Parse(row["TId"].ToString());
				}
				if(row["TName"]!=null)
				{
					model.TName=row["TName"].ToString();
				}
				if(row["is_del"]!=null && row["is_del"].ToString()!="")
				{
					model.is_del=int.Parse(row["is_del"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TId,TName,is_del ");
			strSql.Append(" FROM tbContractClass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" TId,TName,is_del ");
			strSql.Append(" FROM tbContractClass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tbContractClass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.TId desc");
			}
			strSql.Append(")AS Row, T.*  from tbContractClass T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tbContractClass";
			parameters[1].Value = "TId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

