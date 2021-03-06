﻿/*
* tbContract.cs
*
* 功 能： N/A
* 类 名： tbContract
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tbContract
	/// </summary>
	public partial class tbContract
	{
		public tbContract()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ContractNo", "tbContract"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ContractNo,int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbContract");
			strSql.Append(" where ContractNo=@ContractNo and id=@id and is_del=1");
			SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = ContractNo;
			parameters[1].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tbContract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbContract(");
			strSql.Append("ContractNo,TId,ContractNum,CustomerNo,SignedDate,ExpDate,ContractPrice,BPId,FirstPrice,PayAllDate,ServiceStartDate,ServiceEndDate,Remark,AddDate,MidDate,is_del)");
			strSql.Append(" values (");
			strSql.Append("@ContractNo,@TId,@ContractNum,@CustomerNo,@SignedDate,@ExpDate,@ContractPrice,@BPId,@FirstPrice,@PayAllDate,@ServiceStartDate,@ServiceEndDate,@Remark,@AddDate,@MidDate,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.Int,4),
					new SqlParameter("@TId", SqlDbType.Int,4),
					new SqlParameter("@ContractNum", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerNo", SqlDbType.Int,4),
					new SqlParameter("@SignedDate", SqlDbType.DateTime),
					new SqlParameter("@ExpDate", SqlDbType.DateTime),
					new SqlParameter("@ContractPrice", SqlDbType.Decimal,9),
					new SqlParameter("@BPId", SqlDbType.Int,4),
					new SqlParameter("@FirstPrice", SqlDbType.Decimal,9),
					new SqlParameter("@PayAllDate", SqlDbType.DateTime),
					new SqlParameter("@ServiceStartDate", SqlDbType.DateTime),
					new SqlParameter("@ServiceEndDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MidDate", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4)};
			parameters[0].Value = model.ContractNo;
			parameters[1].Value = model.TId;
			parameters[2].Value = model.ContractNum;
			parameters[3].Value = model.CustomerNo;
			parameters[4].Value = model.SignedDate;
			parameters[5].Value = model.ExpDate;
			parameters[6].Value = model.ContractPrice;
			parameters[7].Value = model.BPId;
			parameters[8].Value = model.FirstPrice;
			parameters[9].Value = model.PayAllDate;
			parameters[10].Value = model.ServiceStartDate;
			parameters[11].Value = model.ServiceEndDate;
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
		public bool Update(Maticsoft.Model.tbContract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbContract set ");
			strSql.Append("TId=@TId,");
			strSql.Append("ContractNum=@ContractNum,");
			strSql.Append("CustomerNo=@CustomerNo,");
			strSql.Append("SignedDate=@SignedDate,");
			strSql.Append("ExpDate=@ExpDate,");
			strSql.Append("ContractPrice=@ContractPrice,");
			strSql.Append("BPId=@BPId,");
			strSql.Append("FirstPrice=@FirstPrice,");
			strSql.Append("PayAllDate=@PayAllDate,");
			strSql.Append("ServiceStartDate=@ServiceStartDate,");
			strSql.Append("ServiceEndDate=@ServiceEndDate,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("MidDate=@MidDate,");
			strSql.Append("is_del=@is_del");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@TId", SqlDbType.Int,4),
					new SqlParameter("@ContractNum", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerNo", SqlDbType.Int,4),
					new SqlParameter("@SignedDate", SqlDbType.DateTime),
					new SqlParameter("@ExpDate", SqlDbType.DateTime),
					new SqlParameter("@ContractPrice", SqlDbType.Decimal,9),
					new SqlParameter("@BPId", SqlDbType.Int,4),
					new SqlParameter("@FirstPrice", SqlDbType.Decimal,9),
					new SqlParameter("@PayAllDate", SqlDbType.DateTime),
					new SqlParameter("@ServiceStartDate", SqlDbType.DateTime),
					new SqlParameter("@ServiceEndDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MidDate", SqlDbType.DateTime),
					new SqlParameter("@is_del", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ContractNo", SqlDbType.Int,4)};
			parameters[0].Value = model.TId;
			parameters[1].Value = model.ContractNum;
			parameters[2].Value = model.CustomerNo;
			parameters[3].Value = model.SignedDate;
			parameters[4].Value = model.ExpDate;
			parameters[5].Value = model.ContractPrice;
			parameters[6].Value = model.BPId;
			parameters[7].Value = model.FirstPrice;
			parameters[8].Value = model.PayAllDate;
			parameters[9].Value = model.ServiceStartDate;
			parameters[10].Value = model.ServiceEndDate;
			parameters[11].Value = model.Remark;
			parameters[12].Value = model.AddDate;
			parameters[13].Value = model.MidDate;
			parameters[14].Value = model.is_del;
			parameters[15].Value = model.id;
			parameters[16].Value = model.ContractNo;

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
			strSql.Append("update tbContract set is_del=0");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ContractNo,int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbContract set is_del=0");
			strSql.Append(" where ContractNo=@ContractNo and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = ContractNo;
			parameters[1].Value = id;

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
			strSql.Append("update tbContract set is_del=0");
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
		public Maticsoft.Model.tbContract GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ContractNo,TId,ContractNum,CustomerNo,SignedDate,ExpDate,ContractPrice,BPId,FirstPrice,PayAllDate,ServiceStartDate,ServiceEndDate,Remark,AddDate,MidDate,is_del from tbContract ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tbContract model=new Maticsoft.Model.tbContract();
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
		public Maticsoft.Model.tbContract DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tbContract model=new Maticsoft.Model.tbContract();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ContractNo"]!=null && row["ContractNo"].ToString()!="")
				{
					model.ContractNo=int.Parse(row["ContractNo"].ToString());
				}
				if(row["TId"]!=null && row["TId"].ToString()!="")
				{
					model.TId=int.Parse(row["TId"].ToString());
				}
				if(row["ContractNum"]!=null)
				{
					model.ContractNum=row["ContractNum"].ToString();
				}
				if(row["CustomerNo"]!=null && row["CustomerNo"].ToString()!="")
				{
					model.CustomerNo=int.Parse(row["CustomerNo"].ToString());
				}
				if(row["SignedDate"]!=null && row["SignedDate"].ToString()!="")
				{
					model.SignedDate=DateTime.Parse(row["SignedDate"].ToString());
				}
				if(row["ExpDate"]!=null && row["ExpDate"].ToString()!="")
				{
					model.ExpDate=DateTime.Parse(row["ExpDate"].ToString());
				}
				if(row["ContractPrice"]!=null && row["ContractPrice"].ToString()!="")
				{
					model.ContractPrice=decimal.Parse(row["ContractPrice"].ToString());
				}
				if(row["BPId"]!=null && row["BPId"].ToString()!="")
				{
					model.BPId=int.Parse(row["BPId"].ToString());
				}
				if(row["FirstPrice"]!=null && row["FirstPrice"].ToString()!="")
				{
					model.FirstPrice=decimal.Parse(row["FirstPrice"].ToString());
				}
				if(row["PayAllDate"]!=null && row["PayAllDate"].ToString()!="")
				{
					model.PayAllDate=DateTime.Parse(row["PayAllDate"].ToString());
				}
				if(row["ServiceStartDate"]!=null && row["ServiceStartDate"].ToString()!="")
				{
					model.ServiceStartDate=DateTime.Parse(row["ServiceStartDate"].ToString());
				}
				if(row["ServiceEndDate"]!=null && row["ServiceEndDate"].ToString()!="")
				{
					model.ServiceEndDate=DateTime.Parse(row["ServiceEndDate"].ToString());
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
			strSql.Append("select id,ContractNo,TId,ContractNum,CustomerNo,SignedDate,ExpDate,ContractPrice,BPId,FirstPrice,PayAllDate,ServiceStartDate,ServiceEndDate,Remark,AddDate,MidDate,is_del ");
			strSql.Append(" FROM tbContract ");
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
			strSql.Append(" id,ContractNo,TId,ContractNum,CustomerNo,SignedDate,ExpDate,ContractPrice,BPId,FirstPrice,PayAllDate,ServiceStartDate,ServiceEndDate,Remark,AddDate,MidDate,is_del ");
			strSql.Append(" FROM tbContract ");
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
			strSql.Append("select count(1) FROM tbContract ");
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
			strSql.Append(")AS Row, T.*  from tbContract T ");
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
			parameters[0].Value = "tbContract";
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

