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
	public  class Profit
	{
		#region Model
		private int _pid;
		private int _vid;
		private int _did;
        private DateTime _modifytime = DateTime.Now;
        private double _profit;


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Modifytime
        {
            get { return _modifytime; }
            set { _modifytime = value; }
        }
      

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
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
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

		#endregion Model
    }
}
