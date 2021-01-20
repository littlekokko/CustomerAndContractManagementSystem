/*
* tbAdmin.cs
*
* 功 能： N/A
* 类 名： tbAdmin
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbAdmin
	/// </summary>
	public partial class tbAdmin
	{
		public tbAdmin()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tbAdmin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbAdmin");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tbAdmin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbAdmin(");
			strSql.Append("AdminName,AdminPassword,DateTime,OrderBy,is_del)");
			strSql.Append(" values (");
			strSql.Append("@AdminName,@AdminPassword,@DateTime,@OrderBy,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AdminName", SqlDbType.VarChar,50),
					new SqlParameter("@AdminPassword", SqlDbType.VarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@OrderBy", SqlDbType.Int,4),
					new SqlParameter("@is_del", SqlDbType.Int,4)};
			parameters[0].Value = model.AdminName;
			parameters[1].Value = model.AdminPassword;
			parameters[2].Value = model.DateTime;
			parameters[3].Value = model.OrderBy;
			parameters[4].Value = model.is_del;

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
		public bool Update(Maticsoft.Model.tbAdmin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbAdmin set ");
			strSql.Append("AdminName=@AdminName,");
			strSql.Append("AdminPassword=@AdminPassword,");
			strSql.Append("DateTime=@DateTime,");
			strSql.Append("OrderBy=@OrderBy,");
			strSql.Append("is_del=@is_del");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@AdminName", SqlDbType.VarChar,50),
					new SqlParameter("@AdminPassword", SqlDbType.VarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@OrderBy", SqlDbType.Int,4),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.AdminName;
			parameters[1].Value = model.AdminPassword;
			parameters[2].Value = DateTime.Now;
			parameters[3].Value = 0;
			parameters[4].Value = 1;
			parameters[5].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbAdmin set is_del=0 ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbAdmin ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Maticsoft.Model.tbAdmin GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,AdminName,AdminPassword,DateTime,OrderBy,is_del from tbAdmin ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tbAdmin model=new Maticsoft.Model.tbAdmin();
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
		public Maticsoft.Model.tbAdmin DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbAdmin model=new Maticsoft.Model.tbAdmin();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["AdminName"]!=null)
				{
					model.AdminName=row["AdminName"].ToString();
				}
				if(row["AdminPassword"]!=null)
				{
					model.AdminPassword=row["AdminPassword"].ToString();
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
				}
				if(row["OrderBy"]!=null && row["OrderBy"].ToString()!="")
				{
					model.OrderBy=int.Parse(row["OrderBy"].ToString());
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
			strSql.Append("select id,AdminName,AdminPassword,DateTime,OrderBy,is_del ");
			strSql.Append(" FROM tbAdmin ");
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
			strSql.Append(" id,AdminName,AdminPassword,DateTime,OrderBy,is_del ");
			strSql.Append(" FROM tbAdmin ");
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
			strSql.Append("select count(1) FROM tbAdmin ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from tbAdmin T ");
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
			parameters[0].Value = "tbAdmin";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
		#region Exists
		public bool Exists(string AdminName,string AdminPassword)
        {
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tbAdmin");
			strSql.Append(" where AdminName=@AdminName");
			strSql.Append(" and AdminPassword=@AdminPassword");
			strSql.Append(" and is_del=1");
			SqlParameter[] parameters = {
					new SqlParameter("@AdminName", SqlDbType.Char,50),
					new SqlParameter("@AdminPassword", SqlDbType.Char,50)
			};
			parameters[0].Value = AdminName;
			parameters[1].Value = AdminPassword;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}
		#endregion
		public bool Delete(string AdminName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tbAdmin");
			strSql.Append(" where AdminName=@AdminName and is_del=1");
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminName",SqlDbType.Char,50)
			};

			var flag1 = false;
			parameters[0].Value = AdminName;
			if (DbHelperSQL.Exists(strSql.ToString(), parameters))
			{
				StringBuilder strSql1 = new StringBuilder();
				strSql1.Append("update tbAdmin");
				strSql1.Append(" set is_del=0");
				strSql1.Append(" where AdminName=@AdminName");
				DbHelperSQL.Exists(strSql1.ToString(), parameters);
				flag1 = true;
			}
			return flag1;
		}
		public bool Add(string AdminName, string AdminPassword)
		{
			bool flag1;
				StringBuilder strSql1 = new StringBuilder();
				strSql1.Append("insert into tbAdmin (AdminName,AdminPassword,DateTime,OrderBy,is_del) ");
				strSql1.Append(" values (@AdminName,@AdminPassword,@DateTime,@OrderBy,@is_del) ");
				SqlParameter[] parameters1 =
				{
					new SqlParameter("@AdminName", SqlDbType.Char,50),
					new SqlParameter("@AdminPassword", SqlDbType.Char,50),
					new SqlParameter("@DateTime",SqlDbType.DateTime),
					new SqlParameter("@OrderBy",SqlDbType.Int),
					new SqlParameter("@is_del",SqlDbType.Int)
				};
				parameters1[0].Value = AdminName;
				parameters1[1].Value = AdminPassword;
				parameters1[2].Value = DateTime.Now;
				parameters1[3].Value = 0;
				parameters1[4].Value = 1;

				DbHelperSQL.Exists(strSql1.ToString(), parameters1);
				flag1 = true;
		    return flag1;
		}

		public DataSet GetListByPage(int startIndex, int endIndex, string strWhere, string filedOrder)
		{
			StringBuilder strsql = new StringBuilder();
			strsql.Append("Select * From ( SELECT ROW_NUMBER() OVER ( ");
			if (!string.IsNullOrEmpty(filedOrder.Trim()))
			{
				strsql.Append("order by T." + filedOrder);
			}
			else
			{
				strsql.Append("order by T.id desc");
			}
			strsql.Append(" )AS Row, T.*  from tbAdmin T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strsql.Append(" WHERE " + strWhere);
			}
			strsql.Append(" ) TT");
			strsql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strsql.ToString());
		}
		#endregion  ExtensionMethod
	}
}

