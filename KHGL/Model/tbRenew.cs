/*
* tbRenew.cs
*
* 功 能： N/A
* 类 名： tbRenew
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class tbRenew
	{
		public tbRenew()
		{}
		#region Model
		private int _id;
		private int _no;
		private int? _tid;
		private string _contractnum;
		private int? _customerno;
		private DateTime? _signeddate;
		private DateTime? _expdate;
		private decimal? _addprice;
		private int? _BPId;
		private DateTime? _servicestartdate;
		private DateTime? _serviceenddate;
		private string _remark;
		private DateTime? _adddate;
		private DateTime? _middate;
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
		public int No
		{
			set{ _no=value;}
			get{return _no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TId
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContractNum
		{
			set{ _contractnum=value;}
			get{return _contractnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CustomerNo
		{
			set{ _customerno=value;}
			get{return _customerno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SignedDate
		{
			set{ _signeddate=value;}
			get{return _signeddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ExpDate
		{
			set{ _expdate=value;}
			get{return _expdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AddPrice
		{
			set{ _addprice=value;}
			get{return _addprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BPId
		{
			set{ _BPId=value;}
			get{return _BPId;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ServiceStartDate
		{
			set{ _servicestartdate=value;}
			get{return _servicestartdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ServiceEndDate
		{
			set{ _serviceenddate=value;}
			get{return _serviceenddate;}
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

