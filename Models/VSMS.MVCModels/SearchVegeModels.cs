using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.Model;

namespace VSMS.Models.MVCModels
{
    public class SearchVegeModels
    {
        /// <summary>
        /// 当前是第几页
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 页面总数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 常用列表蔬菜总数
        /// </summary>
        public int VegetableNum { get; set; }
        /// <summary>
        /// 常用列表list
        /// </summary>
        public List<Vegetable> list { get; set; }
        /// <summary>
        /// 页号导航
        /// </summary>
        public List<int> pageList { get; set; }
        /// <summary>
        /// 查询字符串
        /// </summary>
        public string SearchText { get; set; }
    }
}
