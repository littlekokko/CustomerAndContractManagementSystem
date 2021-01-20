/*
* tbCustomerClass.cs
*
* 功 能： N/A
* 类 名： tbCustomerClass
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class tbCustomerClass
	{
		public tbCustomerClass()
		{}
		#region Model
		private int _ctid;
		private string _ctname;
		private int? _is_del;
		/// <summary>
		/// 
		/// </summary>
		public int CTId
		{
			set{ _ctid=value;}
			get{return _ctid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CTName
		{
			set{ _ctname=value;}
			get{return _ctname;}
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

