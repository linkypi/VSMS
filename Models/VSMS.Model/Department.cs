using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    public class Department
    {
        private int _eid;
        private int _did;
        private string _dname;
        private string _addr;
        private bool _deleted = false;
        private double _discount;
        private double _labourcharges;

       
        /// <summary>
        /// 部门id
        /// </summary>		 
        public int DID
        {
            get { return _did; }
            set { _did = value; }
        }
        /// <summary>
        /// 企业id
        /// </summary>		
        public int EID
        {
            get { return _eid; }
            set { _eid = value; }
        }


        /// <summary>
        /// 部门名称
        /// </summary>		    
        public string DName
        {
            get { return _dname; }
            set { _dname = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Addr
        {
            set { _addr = value; }
            get { return _addr; }
        }

        /// <summary>
        /// 是否删除.true代表是,默认false
        /// </summary>		 
        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }

        /// <summary>
        /// 返点（折扣）
        /// </summary>
        public double DisCount
        {
            set { _discount = value; }
            get { return _discount; }
        }
      

        /// <summary>
        /// 人工车费
        /// </summary>
        public double LabourCharges
        {
            set { _labourcharges = value; }
            get { return _labourcharges; }
        }
        /// <summary>
        /// 部门联系电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 部门联系手机号码
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 部门传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 部门电子邮件地址
        /// </summary>
        public string Email { get; set; }
        #region 扩展属性

        private int orderCount;
        private string oID;

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OID
        {
            get { return oID; }
            set { oID = value; }
        }


        /// <summary>
        /// 部门订购数量
        /// </summary>
        public int OrderCount
        {
            get { return orderCount; }
            set { orderCount = value; }
        }

        #endregion
    }
}
