/*
* tbStaff.cs
*
* 功 能： N/A
* 类 名： tbStaff
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class tbStaff
	{
		public tbStaff()
		{}
		#region Model
		private int _BPId;
		private string _name;
		private string _sex;
		private string _address;
		private string _mobile;
		private string _remark;
		private DateTime? _adddate;
		private DateTime? _middate;
		private int? _is_del;
		/// <summary>
		/// 
		/// </summary>
		public int BPId
		{
			set{ _BPId=value;}
			get{return _BPId;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MidDate
		{
			set{ _middate=value;}
			get{return _middate;}
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

