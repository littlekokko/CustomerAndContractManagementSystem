/*
* tbContractClass.cs
*
* 功 能： N/A
* 类 名： tbContractClass
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class tbContractClass
	{
		public tbContractClass()
		{}
		#region Model
		private int _tid;
		private string _tname;
		private int? _is_del;
		/// <summary>
		/// 
		/// </summary>
		public int TId
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TName
		{
			set{ _tname=value;}
			get{return _tname;}
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

