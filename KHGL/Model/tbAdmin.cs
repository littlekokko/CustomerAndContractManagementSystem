/**
* tbAdmin.cs
* 类 名： tbAdmin
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tbAdmin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbAdmin
	{
		public tbAdmin()
		{}
		#region Model
		private int _id;
		private string _adminname;
		private string _adminpassword;
		private DateTime? _datetime;
		private int? _orderby;
		private int? _is_del;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdminName
		{
			set{ _adminname=value;}
			get{return _adminname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdminPassword
		{
			set{ _adminpassword=value;}
			get{return _adminpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderBy
		{
			set{ _orderby=value;}
			get{return _orderby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? is_del
		{
			set{ _is_del=value;}
			get{return _is_del;}
		}
		#endregion Model

	}
}

