using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.Model;

namespace VSMS.Models.MVCModels
{
    /// <summary>
    /// 订单查询model
    /// </summary>
    public class OrderSearchModel
    {
        private List<Enterprise> enterpriseList;
        private List<Department> currentDepartmentList = null;
        private List<Orders> ordersList;
        private string currentEnterprise = "-1";
        private string currentDepartment = "-1";
        private string currentOrderTime = "all";
        private string currentOrderState = "all";
        private int currentPage = 1;
        private int count;
        private int totalPage;
        private List<int> pageList;


        /// <summary>
        /// 页号导航
        /// </summary>
        public List<int> PageList
        {
            get { return pageList; }
            set { pageList = value; }
        }


        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get { return totalPage; }
            set { totalPage = value; }
        }


        /// <summary>
        /// 根据查询条件得到的 数据行数
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        /// <summary>
        /// 当前部门，初始为-1
        /// </summary>
        public string CurrentDepartment
        {
            get { return currentDepartment; }
            set { currentDepartment = value; }
        }
        /// <summary>
        /// 当前企业，初始为-1
        /// </summary>
        public string CurrentEnterprise
        {
            get { return currentEnterprise; }
            set { currentEnterprise = value; }
        }
        /// <summary>
        /// 当前选中的时间段，初始为all
        /// </summary>
        public string CurrentOrderTime
        {
            get { return currentOrderTime; }
            set { currentOrderTime = value; }
        }
        /// <summary>
        /// 当前选中的订单状态，初始为all
        /// </summary>
        public string CurrentOrderState
        {
            get { return currentOrderState; }
            set { currentOrderState = value; }
        }
        /// <summary>
        /// 所有的企业列表
        /// </summary>
        public List<Enterprise> EnterpriseList
        {
            get { return enterpriseList; }
            set { enterpriseList = value; }
        }
        /// <summary>
        /// 当前部门列表
        /// </summary>
        public List<Department> CurrentDepartmentList
        {
            get { return currentDepartmentList; }
            set { currentDepartmentList = value; }
        }
        /// <summary>
        /// 查询得到的订单列表
        /// </summary>
        public List<Orders> OrdersList
        {
            get { return ordersList; }
            set { ordersList = value; }
        }
    }
}
