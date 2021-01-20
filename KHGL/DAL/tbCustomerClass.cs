/*
* tbCustomerClass.cs
*
* 功 能： N/A
* 类 名： tbCustomerClass
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbCustomerClass
	/// </summary>
	public partial class tbCustomerClass
	{
		public tbCustomerClass()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CTId", "tbCustomerClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CTId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbCustomerClass");
			strSql.Append(" where CTId=@CTId");
			SqlParameter[] parameters = {
					new SqlParameter("@CTId", SqlDbType.Int,4)
			};
			parameters[0].Value = CTId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tbCustomerClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbCustomerClass(");
			strSql.Append("CTName,is_del)");
			strSql.Append(" values (");
			strSql.Append("@CTName,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CTName", SqlDbType.VarChar,50),
					new SqlParameter("@is_del", SqlDbType.Int,4)};
			parameters[0].Value = model.CTName;
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
		public bool Update(Maticsoft.Model.tbCustomerClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbCustomerClass set ");
			strSql.Append("CTName=@CTName,");
			strSql.Append("is_del=@is_del");
			strSql.Append(" where CTId=@CTId");
			SqlParameter[] parameters = {
					new SqlParameter("@CTName", SqlDbType.VarChar,50),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@CTId", SqlDbType.Int,4)};
			parameters[0].Value = model.CTName;
			parameters[1].Value = model.is_del;
			parameters[2].Value = model.CTId;

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
		public bool Delete(int CTId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbCustomerClass ");
			strSql.Append(" where CTId=@CTId");
			SqlParameter[] parameters = {
					new SqlParameter("@CTId", SqlDbType.Int,4)
			};
			parameters[0].Value = CTId;

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
		public bool DeleteList(string CTIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbCustomerClass ");
			strSql.Append(" where CTId in ("+CTIdlist + ")  ");
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
		public Maticsoft.Model.tbCustomerClass GetModel(int CTId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CTId,CTName,is_del from tbCustomerClass ");
			strSql.Append(" where CTId=@CTId");
			SqlParameter[] parameters = {
					new SqlParameter("@CTId", SqlDbType.Int,4)
			};
			parameters[0].Value = CTId;

			Maticsoft.Model.tbCustomerClass model=new Maticsoft.Model.tbCustomerClass();
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
		public Maticsoft.Model.tbCustomerClass DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbCustomerClass model=new Maticsoft.Model.tbCustomerClass();
			if (row != null)
			{
				if(row["CTId"]!=null && row["CTId"].ToString()!="")
				{
					model.CTId=int.Parse(row["CTId"].ToString());
				}
				if(row["CTName"]!=null)
				{
					model.CTName=row["CTName"].ToString();
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
			strSql.Append("select CTId,CTName,is_del ");
			strSql.Append(" FROM tbCustomerClass ");
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
			strSql.Append(" CTId,CTName,is_del ");
			strSql.Append(" FROM tbCustomerClass ");
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
			strSql.Append("select count(1) FROM tbCustomerClass ");
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
				strSql.Append("order by T.CTId desc");
			}
			strSql.Append(")AS Row, T.*  from tbCustomerClass T ");
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
			parameters[0].Value = "tbCustomerClass";
			parameters[1].Value = "CTId";
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

