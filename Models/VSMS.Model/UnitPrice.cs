using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    /// <summary>
	/// 类Price。
	/// </summary>
    [Serializable]
    public  class UnitPrice
    {
     	#region Model

		private int _upid;
		private int _vid;
        private double _marketprice;
        private double _wholesaleprice;
		private DateTime _createtime= DateTime.Now;
        private bool hasPrice;

        /// <summary>
        /// 是否已经录入成本价
        /// </summary>
        public bool HasPrice
        {
            get { return hasPrice; }
            set { hasPrice = value; }
        }


		/// <summary>
		/// 价格编号
		/// </summary>
		public int UPID
		{
			set{ _upid=value;}
			get{return _upid;}
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
		/// 市场价
		/// </summary>
        public double MarketPrice
		{
			set{ _marketprice=value;}
			get{return _marketprice;}
		}

		/// <summary>
		/// 批发价
		/// </summary>
        public double WholesalePrice
		{
			set{ _wholesaleprice=value;}
			get{return _wholesaleprice;}
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
