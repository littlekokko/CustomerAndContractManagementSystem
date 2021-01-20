/*
* tbStaff.cs
*
* 功 能： N/A
* 类 名： tbStaff
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbStaff
	/// </summary>
	public partial class tbStaff
	{
		public tbStaff()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BPId", "tbStaff"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BPId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbStaff");
			strSql.Append(" where BPId=@BPId");
			SqlParameter[] parameters = {
					new SqlParameter("@BPId", SqlDbType.Int,4)
			};
			parameters[0].Value = BPId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tbStaff model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbStaff(");
			strSql.Append("Name,Sex,Address,Mobile,Remark,AddDate,MidDate,is_del)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Sex,@Address,@Mobile,@Remark,@AddDate,@MidDate,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Char,1),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MidDate", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.Address;
			parameters[3].Value = model.Mobile;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.AddDate;
			parameters[6].Value = model.MidDate;
			parameters[7].Value = model.is_del;

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
		public bool Update(Maticsoft.Model.tbStaff model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbStaff set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Address=@Address,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("MidDate=@MidDate,");
			strSql.Append("is_del=@is_del");
			strSql.Append(" where BPId=@BPId");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Char,1),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MidDate", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@BPId", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.Address;
			parameters[3].Value = model.Mobile;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.AddDate;
			parameters[6].Value = model.MidDate;
			parameters[7].Value = model.is_del;
			parameters[8].Value = model.BPId;

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
		public bool Delete(int BPId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbStaff ");
			strSql.Append(" where BPId=@BPId");
			SqlParameter[] parameters = {
					new SqlParameter("@BPId", SqlDbType.Int,4)
			};
			parameters[0].Value = BPId;

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
		public bool DeleteList(string BPIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbStaff ");
			strSql.Append(" where BPId in ("+BPIdlist + ")  ");
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
		public Maticsoft.Model.tbStaff GetModel(int BPId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BPId,Name,Sex,Address,Mobile,Remark,AddDate,MidDate,is_del from tbStaff ");
			strSql.Append(" where BPId=@BPId");
			SqlParameter[] parameters = {
					new SqlParameter("@BPId", SqlDbType.Int,4)
			};
			parameters[0].Value = BPId;

			Maticsoft.Model.tbStaff model=new Maticsoft.Model.tbStaff();
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
		public Maticsoft.Model.tbStaff DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbStaff model=new Maticsoft.Model.tbStaff();
			if (row != null)
			{
				if(row["BPId"]!=null && row["BPId"].ToString()!="")
				{
					model.BPId=int.Parse(row["BPId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["AddDate"]!=null && row["AddDate"].ToString()!="")
				{
					model.AddDate=DateTime.Parse(row["AddDate"].ToString());
				}
				if(row["MidDate"]!=null && row["MidDate"].ToString()!="")
				{
					model.MidDate=DateTime.Parse(row["MidDate"].ToString());
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
			strSql.Append("select BPId,Name,Sex,Address,Mobile,Remark,AddDate,MidDate,is_del ");
			strSql.Append(" FROM tbStaff ");
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
			strSql.Append(" BPId,Name,Sex,Address,Mobile,Remark,AddDate,MidDate,is_del ");
			strSql.Append(" FROM tbStaff ");
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
			strSql.Append("select count(1) FROM tbStaff ");
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
				strSql.Append("order by T.BPId desc");
			}
			strSql.Append(")AS Row, T.*  from tbStaff T ");
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
			parameters[0].Value = "tbStaff";
			parameters[1].Value = "BPId";
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

