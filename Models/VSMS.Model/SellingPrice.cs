using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
     /// <summary>
	/// SellingPrice:售价实体类
	/// </summary>
	[Serializable]
	public  class SellingPrice
	{
		#region Model
		private int _spid;
		private int _vid;
		private int _did;
		private double _actualprice;
		private DateTime _createtime= DateTime.Now;
        private double _profit;

        /// <summary>
        /// 利润
        /// </summary>
        public double Profit
        {
            set { _profit = value; }
            get { return _profit; }
        }

		/// <summary>
		///  售价编号
		/// </summary>
		public int SPID
		{
			set{ _spid=value;}
			get{return _spid;}
		}
		/// <summary>
		/// 蔬菜编号
		/// </summary>
		public int VID
		{
			set{ _vid=value;}
			get{return _vid;}
		}
		/// <summary>
		/// 客户编号
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 实际售价
		/// </summary>
		public double ActualPrice
		{
			set{ _actualprice=value;}
			get{return _actualprice;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}

 
		#endregion Model
    }
}
