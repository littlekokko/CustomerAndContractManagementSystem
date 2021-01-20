using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbStaffLogin
	/// </summary>
	public partial class tbStaffLogin
	{
		public tbStaffLogin()
		{ }
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tbStaffLogin");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}
		#region Exists
		public bool Exists(string StaffName, string StaffPassword)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tbStaffLogin");
			strSql.Append(" where StaffName=@StaffName");
			strSql.Append(" and StaffPassword=@StaffPassword");
			strSql.Append(" and is_del=1");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffName", SqlDbType.Char,50),
					new SqlParameter("@StaffPassword", SqlDbType.Char,50)
			};
			parameters[0].Value = StaffName;
			parameters[1].Value = StaffPassword;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}
		#endregion

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tbStaffLogin model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tbStaffLogin(");
			strSql.Append("BPId,StaffName,StaffPassword,DateTime,is_del)");
			strSql.Append(" values (");
			strSql.Append("@BPId,@StaffName,@StaffPassword,@DateTime,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BPId", SqlDbType.Int,4),
					new SqlParameter("@StaffName", SqlDbType.VarChar,50),
					new SqlParameter("@StaffPassword", SqlDbType.VarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4)};
			parameters[0].Value = model.BPId;
			parameters[1].Value = model.StaffName;
			parameters[2].Value = model.StaffPassword;
			parameters[3].Value = model.DateTime;
			parameters[4].Value = model.is_del;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
		public bool Update(Maticsoft.Model.tbStaffLogin model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tbStaffLogin set ");
			strSql.Append("BPId=@BPId,");
			strSql.Append("StaffName=@StaffName,");
			strSql.Append("StaffPassword=@StaffPassword,");
			strSql.Append("DateTime=@DateTime,");
			strSql.Append("is_del=@is_del");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@BPId", SqlDbType.Int,4),
					new SqlParameter("@StaffName", SqlDbType.VarChar,50),
					new SqlParameter("@StaffPassword", SqlDbType.VarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.BPId;
			parameters[1].Value = model.StaffName;
			parameters[2].Value = model.StaffPassword;
			parameters[3].Value = model.DateTime;
			parameters[4].Value = model.is_del;
			parameters[5].Value = model.id;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tbStaffLogin set is_del=0");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public bool DeleteList(string idlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tbStaffLogin set is_del=0 ");
			strSql.Append(" where id in (" + idlist + ")  ");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.tbStaffLogin GetModel(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 id,BPId,StaffName,StaffPassword,DateTime,is_del from tbStaffLogin ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tbStaffLogin model = new Maticsoft.Model.tbStaffLogin();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
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
		public Maticsoft.Model.tbStaffLogin DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbStaffLogin model = new Maticsoft.Model.tbStaffLogin();
			if (row != null)
			{
				if (row["id"] != null && row["id"].ToString() != "")
				{
					model.id = int.Parse(row["id"].ToString());
				}
				if (row["BPId"] != null && row["BPId"].ToString() != "")
				{
					model.BPId = int.Parse(row["BPId"].ToString());
				}
				if (row["StaffName"] != null)
				{
					model.StaffName = row["StaffName"].ToString();
				}
				if (row["StaffPassword"] != null)
				{
					model.StaffPassword = row["StaffPassword"].ToString();
				}
				if (row["DateTime"] != null && row["DateTime"].ToString() != "")
				{
					model.DateTime = DateTime.Parse(row["DateTime"].ToString());
				}
				if (row["is_del"] != null && row["is_del"].ToString() != "")
				{
					model.is_del = int.Parse(row["is_del"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,BPId,StaffName,StaffPassword,DateTime,is_del ");
			strSql.Append(" FROM tbStaffLogin ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" id,BPId,StaffName,StaffPassword,DateTime,is_del ");
			strSql.Append(" FROM tbStaffLogin ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM tbStaffLogin ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
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
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from tbStaffLogin T ");
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
			parameters[0].Value = "tbStaffLogin";
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

		#endregion  ExtensionMethod
	}
}

