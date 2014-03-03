using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    /// <summary>
	/// 类Category。
	/// </summary>
    [Serializable]
    public  class Category
    {
        #region Model
        private int _cid;
        private int _pcid;
        private string _cname;
        private int _corder = 0;

        /// <summary>
        /// 种类顺序
        /// </summary>
        public int COrder
        {
            set { _corder = value; }
            get { return _corder; }
        }

        /// <summary>
        /// 种类编号
        /// </summary>
        public int CID
        {
            set { _cid = value; }
            get { return _cid; }
        }

        /// <summary>
        /// 父类编号
        /// </summary>
        public int PCID
        {
            get { return _pcid; }
            set { _pcid = value; }
        }

        /// <summary>
        ///  种类名称
        /// </summary>
        public string CName
        {
            set { _cname = value; }
            get { return _cname; }
        }

        #endregion Model

        #region 扩展属性
        /// <summary>
        /// 子类列表
        /// </summary>
        private List<Category> children = new List<Category>();

        public List<Category> Children
        {
            get { return children; }
            set { children = value; }
        }


        #endregion 

    }
}
