/*
* tbProjectClass.cs
*
* 功 能： N/A
* 类 名： tbProjectClass
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbProjectClass
	/// </summary>
	public partial class tbProjectClass
	{
		public tbProjectClass()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PTId", "tbProjectClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PTId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbProjectClass");
			strSql.Append(" where PTId=@PTId");
			SqlParameter[] parameters = {
					new SqlParameter("@PTId", SqlDbType.Int,4)
			};
			parameters[0].Value = PTId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tbProjectClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbProjectClass(");
			strSql.Append("PTName,is_del)");
			strSql.Append(" values (");
			strSql.Append("@PTName,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PTName", SqlDbType.VarChar,50),
					new SqlParameter("@is_del", SqlDbType.Int,4)};
			parameters[0].Value = model.PTName;
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
		public bool Update(Maticsoft.Model.tbProjectClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbProjectClass set ");
			strSql.Append("PTName=@PTName,");
			strSql.Append("is_del=@is_del");
			strSql.Append(" where PTId=@PTId");
			SqlParameter[] parameters = {
					new SqlParameter("@PTName", SqlDbType.VarChar,50),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@PTId", SqlDbType.Int,4)};
			parameters[0].Value = model.PTName;
			parameters[1].Value = model.is_del;
			parameters[2].Value = model.PTId;

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
		public bool Delete(int PTId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbProjectClass ");
			strSql.Append(" where PTId=@PTId");
			SqlParameter[] parameters = {
					new SqlParameter("@PTId", SqlDbType.Int,4)
			};
			parameters[0].Value = PTId;

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
		public bool DeleteList(string PTIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbProjectClass ");
			strSql.Append(" where PTId in ("+PTIdlist + ")  ");
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
		public Maticsoft.Model.tbProjectClass GetModel(int PTId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PTId,PTName,is_del from tbProjectClass ");
			strSql.Append(" where PTId=@PTId");
			SqlParameter[] parameters = {
					new SqlParameter("@PTId", SqlDbType.Int,4)
			};
			parameters[0].Value = PTId;

			Maticsoft.Model.tbProjectClass model=new Maticsoft.Model.tbProjectClass();
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
		public Maticsoft.Model.tbProjectClass DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbProjectClass model=new Maticsoft.Model.tbProjectClass();
			if (row != null)
			{
				if(row["PTId"]!=null && row["PTId"].ToString()!="")
				{
					model.PTId=int.Parse(row["PTId"].ToString());
				}
				if(row["PTName"]!=null)
				{
					model.PTName=row["PTName"].ToString();
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
			strSql.Append("select PTId,PTName,is_del ");
			strSql.Append(" FROM tbProjectClass ");
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
			strSql.Append(" PTId,PTName,is_del ");
			strSql.Append(" FROM tbProjectClass ");
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
			strSql.Append("select count(1) FROM tbProjectClass ");
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
				strSql.Append("order by T.PTId desc");
			}
			strSql.Append(")AS Row, T.*  from tbProjectClass T ");
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
			parameters[0].Value = "tbProjectClass";
			parameters[1].Value = "PTId";
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

