using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.Model;

namespace VSMS.Models.MVCModels
{
    /// <summary>
    /// 订单详细页面models
    /// OrderDetail页面的所有数据
    /// </summary>
    public class OrderDetailModels
    {
        private Orders order;
        private Department department;
        private Enterprise enterprise;
        private List<OrderDetail> orderDetailList;
        //private 


        /// <summary>
        /// 订单对象
        /// </summary>
        public Orders Order
        {
            get { return order; }
            set { order = value; }
        }
        /// <summary>
        /// 部门对象
        /// </summary>
        public Department Department
        {
            get { return department; }
            set { department = value; }
        }
        /// <summary>
        /// 企业（酒店）对象
        /// </summary>
        public Enterprise Enterprise
        {
            get { return enterprise; }
            set { enterprise = value; }
        }
        /// <summary>
        /// 订单详细列表，注意：实现蔬菜名
        /// </summary>
        public List<OrderDetail> OrderDetailList
        {
            get { return orderDetailList; }
            set { orderDetailList = value; }
        } 
    }
}