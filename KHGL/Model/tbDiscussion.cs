/*
* tbDiscussion.cs
*
* 功 能： N/A
* 类 名： tbDiscussion
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class tbDiscussion
	{
		public tbDiscussion()
		{}
		#region Model
		private int _id;
		private int _BPId;
		private int? _customerno;
		private string _discussiontopic;
		private string _discussioncontent;
		private DateTime? _discussiondate;
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
		public int BPId
		{
			set { _BPId = value; }
			get { return _BPId; }
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
		public string DiscussionTopic
		{
			set{ _discussiontopic=value;}
			get{return _discussiontopic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiscussionContent
		{
			set{ _discussioncontent=value;}
			get{return _discussioncontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DiscussionDate
		{
			set{ _discussiondate=value;}
			get{return _discussiondate;}
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

