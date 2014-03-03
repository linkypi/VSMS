using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    public class OrderDetail
    {
        private int _odid;
        private string _oid;
        private int _vid;
        private string _vName;
        private decimal _ordercount;
        private decimal _realcount;
        private string _remarks;
        private bool hasRealCount;
        private double _actualprice;


        /// <summary>
        /// 实际售价
        /// </summary>
        public double ActualPrice
        {
            set { _actualprice = value; }
            get { return _actualprice; }
        }

        /// <summary>
        /// 根据Vid获取VName，蔬菜名
        /// </summary>
        public string VName
        {
            get { return _vName; }
            set { _vName = value; }
        }
        /// <summary>
        /// 是否已经录入实收量
        /// </summary>
        public bool HasRealCount
        {
            get { return hasRealCount; }
            set { hasRealCount = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>		 
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        /// <summary>
        /// 订单明细编号
        /// </summary>		
        public int ODID
        {
            get { return _odid; }
            set { _odid = value; }
        }


        /// <summary>
        /// 订单编号
        /// </summary>		
        public string OID
        {
            get { return _oid; }
            set { _oid = value; }
        }

        /// <summary>
        /// 蔬菜编号
        /// </summary>		   
        public int VID
        {
            get { return _vid; }
            set { _vid = value; }
        }


        /// <summary>
        /// 订购数量
        /// </summary>		
        public decimal OrderCount
        {
            get { return _ordercount; }
            set { _ordercount = value; }
        }

        /// <summary>
        /// 实际接收数量
        /// </summary>		
        public decimal RealCount
        {
            get { return _realcount; }
            set { _realcount = value; }
        }


    }
}
