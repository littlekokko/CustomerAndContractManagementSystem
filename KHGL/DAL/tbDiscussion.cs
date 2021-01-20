/*
* tbDiscussion.cs
*
* 功 能： N/A
* 类 名： tbDiscussion
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbDiscussion
	/// </summary>
	public partial class tbDiscussion
	{
		public tbDiscussion()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tbDiscussion"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbDiscussion");
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
		public int Add(Maticsoft.Model.tbDiscussion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbDiscussion(");
			strSql.Append("CustomerNo,DiscussionTopic,DiscussionContent,DiscussionDate,Remark,AddDate,MidDate,is_del,BPId)");
			strSql.Append(" values (");
			strSql.Append("@CustomerNo,@DiscussionTopic,@DiscussionContent,@DiscussionDate,@Remark,@AddDate,@MidDate,@is_del,@BPId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerNo", SqlDbType.Int,4),
					new SqlParameter("@DiscussionTopic", SqlDbType.VarChar,50),
					new SqlParameter("@DiscussionContent", SqlDbType.Text),
					new SqlParameter("@DiscussionDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MidDate", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@BPId", SqlDbType.Int,4)
			};
			parameters[0].Value = model.CustomerNo;
			parameters[1].Value = model.DiscussionTopic;
			parameters[2].Value = model.DiscussionContent;
			parameters[3].Value = model.DiscussionDate;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.AddDate;
			parameters[6].Value = model.MidDate;
			parameters[7].Value = model.is_del;
			parameters[8].Value = model.BPId;

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
		public bool Update(Maticsoft.Model.tbDiscussion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbDiscussion set ");
			strSql.Append("CustomerNo=@CustomerNo,");
			strSql.Append("DiscussionTopic=@DiscussionTopic,");
			strSql.Append("DiscussionContent=@DiscussionContent,");
			strSql.Append("DiscussionDate=@DiscussionDate,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("MidDate=@MidDate,");
			strSql.Append("is_del=@is_del,");
			strSql.Append("BPId=@BPId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerNo", SqlDbType.Int,4),
					new SqlParameter("@DiscussionTopic", SqlDbType.VarChar,50),
					new SqlParameter("@DiscussionContent", SqlDbType.Text),
					new SqlParameter("@DiscussionDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MidDate", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@BPId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.CustomerNo;
			parameters[1].Value = model.DiscussionTopic;
			parameters[2].Value = model.DiscussionContent;
			parameters[3].Value = model.DiscussionDate;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.AddDate;
			parameters[6].Value = model.MidDate;
			parameters[7].Value = model.is_del;
			parameters[8].Value = model.BPId;
			parameters[9].Value = model.id;

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
			strSql.Append("update tbDiscussion set is_del=0");
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
			strSql.Append("update tbDiscussion set is_del=0");
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
		public Maticsoft.Model.tbDiscussion GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,CustomerNo,DiscussionTopic,DiscussionContent,DiscussionDate,Remark,AddDate,MidDate,is_del,BPId from tbDiscussion ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tbDiscussion model=new Maticsoft.Model.tbDiscussion();
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
		public Maticsoft.Model.tbDiscussion DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbDiscussion model=new Maticsoft.Model.tbDiscussion();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["CustomerNo"]!=null && row["CustomerNo"].ToString()!="")
				{
					model.CustomerNo=int.Parse(row["CustomerNo"].ToString());
				}
				if(row["DiscussionTopic"]!=null)
				{
					model.DiscussionTopic=row["DiscussionTopic"].ToString();
				}
				if(row["DiscussionContent"]!=null)
				{
					model.DiscussionContent=row["DiscussionContent"].ToString();
				}
				if(row["DiscussionDate"]!=null && row["DiscussionDate"].ToString()!="")
				{
					model.DiscussionDate=DateTime.Parse(row["DiscussionDate"].ToString());
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
				if (row["is_del"] != null && row["is_del"].ToString() != "")
				{
					model.is_del = int.Parse(row["is_del"].ToString());
				}
				if (row["BPId"] != null && row["BPId"].ToString() != "")
				{
					model.is_del = int.Parse(row["BPId"].ToString());
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
			strSql.Append("select id,CustomerNo,DiscussionTopic,DiscussionContent,DiscussionDate,Remark,AddDate,MidDate,is_del,BPId ");
			strSql.Append(" FROM tbDiscussion ");
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
			strSql.Append(" id,CustomerNo,DiscussionTopic,DiscussionContent,DiscussionDate,Remark,AddDate,MidDate,is_del,BPId ");
			strSql.Append(" FROM tbDiscussion ");
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
			strSql.Append("select count(1) FROM tbDiscussion ");
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
			strSql.Append(")AS Row, T.*  from tbDiscussion T ");
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
			parameters[0].Value = "tbDiscussion";
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

