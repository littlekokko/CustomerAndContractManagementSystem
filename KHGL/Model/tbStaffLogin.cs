using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tbStaffLogin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbStaffLogin
	{
		public tbStaffLogin()
		{ }
		#region Model
		private int _id;
		private int? _bpid;
		private string _staffname;
		private string _staffpassword;
		private DateTime? _datetime;
		private int? _is_del;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set { _id = value; }
			get { return _id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BPId
		{
			set { _bpid = value; }
			get { return _bpid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string StaffName
		{
			set { _staffname = value; }
			get { return _staffname; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string StaffPassword
		{
			set { _staffpassword = value; }
			get { return _staffpassword; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set { _datetime = value; }
			get { return _datetime; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? is_del
		{
			set { _is_del = value; }
			get { return _is_del; }
		}
		#endregion Model

	}
}

