/*
* tbCustomer.cs
*
* 功 能： N/A
* 类 名： tbCustomer
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class tbCustomer
	{
		public tbCustomer()
		{}
		#region Model
		private int _id;
		private int? _customerno;
		private string _companyname;
		private int? _ctid;
		private int? _ptid;
		private string _projectname;
		private string _url;
		private string _linkman;
		private string _phone;
		private string _mobile;
		private string _fax;
		private string _email;
		private string _address;
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
		public int? CustomerNo
		{
			set{ _customerno=value;}
			get{return _customerno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CTId
		{
			set{ _ctid=value;}
			get{return _ctid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PTId
		{
			set{ _ptid=value;}
			get{return _ptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkMan
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
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
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
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

