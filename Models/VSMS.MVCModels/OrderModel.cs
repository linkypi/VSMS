using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.MVCModels
{
    public class OrderModel
    {
        private string ename;
        private string dname;
        private int ordercount;
        private string oID;
        private List<DepartmentModel> dmodels = new List<DepartmentModel>();

        /// <summary>
        /// 企业所管部门
        /// </summary>
        public List<DepartmentModel> Dmodels
        {
            get { return dmodels; }
            set { dmodels = value;}
        }

      
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DName
        {
            get { return dname; }
            set { dname = value; }
        }

        /// <summary>
        /// 订购数量
        /// </summary>
        public int OrderCount
        {
            get { return ordercount; }
            set { ordercount = value; }
        }

        /// <summary>
        /// 订单总量
        /// </summary>
        public int Total
        {
            get 
            {
                int ocount=0;
                foreach(DepartmentModel dm in Dmodels)
                {
                    ocount += dm.OrderCount;
                }
                return ocount;
            }
        }
      
        /// <summary>
        /// 企业名称
        /// </summary>
        public string EName
        {
            get { return ename; }
            set { ename = value; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OID
        {
            get { return oID; }
            set { oID = value; }
        }

        public class DepartmentModel
        {
            private int ordercount;
            private string dname;
            private string oid;

            public int OrderCount
            {
                get { return ordercount; }
                set { ordercount = value; }
            }
            public string DName
            {
                get { return dname; }
                set { dname = value; }
            }
            /// <summary>
            /// 订单编号
            /// </summary>
            public string Oid
            {
                get { return oid; }
                set { oid = value; }
            }
        }

    }
}
