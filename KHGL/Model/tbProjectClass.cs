/*
* tbProjectClass.cs
*
* 功 能： N/A
* 类 名： tbProjectClass
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class tbProjectClass
	{
		public tbProjectClass()
		{}
		#region Model
		private int _ptid;
		private string _ptname;
		private int? _is_del;
		/// <summary>
		/// 
		/// </summary>
		public int PTId
		{
			set{ _ptid=value;}
			get{return _ptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PTName
		{
			set{ _ptname=value;}
			get{return _ptname;}
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

