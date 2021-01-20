/*
* tbCustomer.cs
*
* 功 能： N/A
* 类 名： tbCustomer
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbCustomer
	/// </summary>
	public partial class tbCustomer
	{
		public tbCustomer()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tbCustomer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbCustomer");
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
		public int Add(Maticsoft.Model.tbCustomer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbCustomer(");
			strSql.Append("CustomerNo,CompanyName,CTId,PTId,ProjectName,Url,LinkMan,Phone,Mobile,Fax,Email,Address,Remark,AddDate,MidDate,is_del)");
			strSql.Append(" values (");
			strSql.Append("@CustomerNo,@CompanyName,@CTId,@PTId,@ProjectName,@Url,@LinkMan,@Phone,@Mobile,@Fax,@Email,@Address,@Remark,@AddDate,@MidDate,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerNo", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@CTId", SqlDbType.Int,4),
					new SqlParameter("@PTId", SqlDbType.Int,4),
					new SqlParameter("@ProjectName", SqlDbType.VarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MidDate", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4)};
			parameters[0].Value = model.CustomerNo;
			parameters[1].Value = model.CompanyName;
			parameters[2].Value = model.CTId;
			parameters[3].Value = model.PTId;
			parameters[4].Value = model.ProjectName;
			parameters[5].Value = model.Url;
			parameters[6].Value = model.LinkMan;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Mobile;
			parameters[9].Value = model.Fax;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.Address;
			parameters[12].Value = model.Remark;
			parameters[13].Value = model.AddDate;
			parameters[14].Value = model.MidDate;
			parameters[15].Value = model.is_del;

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
		public bool Update(Maticsoft.Model.tbCustomer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbCustomer set ");
			strSql.Append("CustomerNo=@CustomerNo,");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("CTId=@CTId,");
			strSql.Append("PTId=@PTId,");
			strSql.Append("ProjectName=@ProjectName,");
			strSql.Append("Url=@Url,");
			strSql.Append("LinkMan=@LinkMan,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("Email=@Email,");
			strSql.Append("Address=@Address,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("MidDate=@MidDate,");
			strSql.Append("is_del=@is_del");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerNo", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@CTId", SqlDbType.Int,4),
					new SqlParameter("@PTId", SqlDbType.Int,4),
					new SqlParameter("@ProjectName", SqlDbType.VarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MidDate", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.CustomerNo;
			parameters[1].Value = model.CompanyName;
			parameters[2].Value = model.CTId;
			parameters[3].Value = model.PTId;
			parameters[4].Value = model.ProjectName;
			parameters[5].Value = model.Url;
			parameters[6].Value = model.LinkMan;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Mobile;
			parameters[9].Value = model.Fax;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.Address;
			parameters[12].Value = model.Remark;
			parameters[13].Value = model.AddDate;
			parameters[14].Value = model.MidDate;
			parameters[15].Value = model.is_del;
			parameters[16].Value = model.id;

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
			strSql.Append("update tbCustomer set is_del=0");
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
			strSql.Append("update tbCustomer set is_del=0");
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
		public Maticsoft.Model.tbCustomer GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,CustomerNo,CompanyName,CTId,PTId,ProjectName,Url,LinkMan,Phone,Mobile,Fax,Email,Address,Remark,AddDate,MidDate,is_del from tbCustomer ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tbCustomer model=new Maticsoft.Model.tbCustomer();
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
		public Maticsoft.Model.tbCustomer DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbCustomer model=new Maticsoft.Model.tbCustomer();
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
				if(row["CompanyName"]!=null)
				{
					model.CompanyName=row["CompanyName"].ToString();
				}
				if(row["CTId"]!=null && row["CTId"].ToString()!="")
				{
					model.CTId=int.Parse(row["CTId"].ToString());
				}
				if(row["PTId"]!=null && row["PTId"].ToString()!="")
				{
					model.PTId=int.Parse(row["PTId"].ToString());
				}
				if(row["ProjectName"]!=null)
				{
					model.ProjectName=row["ProjectName"].ToString();
				}
				if(row["Url"]!=null)
				{
					model.Url=row["Url"].ToString();
				}
				if(row["LinkMan"]!=null)
				{
					model.LinkMan=row["LinkMan"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["Fax"]!=null)
				{
					model.Fax=row["Fax"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
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
			strSql.Append("select id,CustomerNo,CompanyName,CTId,PTId,ProjectName,Url,LinkMan,Phone,Mobile,Fax,Email,Address,Remark,AddDate,MidDate,is_del ");
			strSql.Append(" FROM tbCustomer ");
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
			strSql.Append(" id,CustomerNo,CompanyName,CTId,PTId,ProjectName,Url,LinkMan,Phone,Mobile,Fax,Email,Address,Remark,AddDate,MidDate,is_del ");
			strSql.Append(" FROM tbCustomer ");
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
			strSql.Append("select count(1) FROM tbCustomer ");
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
			strSql.Append(")AS Row, T.*  from tbCustomer T ");
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
			parameters[0].Value = "tbCustomer";
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

