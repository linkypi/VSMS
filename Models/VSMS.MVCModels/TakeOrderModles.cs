﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.Model;

namespace VSMS.Models.MVCModels
{
    public class TakeOrderModles
    {
        /// <summary>
        /// 企业列表
        /// </summary>
        public List<Enterprise> EnterpriseList { get; set; }
        /// <summary>
        /// 当前企业的部门列表
        /// </summary>
        public List<Department> CurrentDepartmentList { get; set; }
        /// <summary>
        /// 当前操作的企业ID
        /// </summary>
        public int CurrentEnterprisesID { get; set; }
        /// <summary>
        /// 当前操作的部门ID
        /// </summary>
        public int CurrentDepartmentID { get; set; }
        /// <summary>
        /// 已有蔬菜列表
        /// </summary>
        public List<Vegetable> Vges { get; set; }

        /// <summary>
        /// 购物车物品列表
        /// </summary>
        public List<ShopingCart> ShopingCartItems { get; set; }
    }
}
