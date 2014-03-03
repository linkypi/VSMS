using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    [Serializable]
    public class Enterprise
    {
        #region Model
        private int _eid;
        private string _ename;
        private string _loginname;
        private string _pwd;
        private string _manager;
        private string _addr;
        private string _phone;
        private string _mobilephone;
        private string _fax;
        private string _email;
        private bool _deleted = false;
        private double _discount;

        /// <summary>
        /// 企业编号
        /// </summary>
        public int EID
        {
            set { _eid = value; }
            get { return _eid; }
        }
        /// <summary>
        ///  企业名称
        /// </summary>
        public string EName
        {
            set { _ename = value; }
            get { return _ename; }
        }

        /// <summary>
        /// 企业主管登录帐号
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        ///  企业主管登录密码
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 企业主管名称
        /// </summary>
        public string Manager
        {
            set { _manager = value; }
            get { return _manager; }
        }

    
        /// <summary>
        /// 企业地址
        /// </summary>
        public string Addr
        {
            set { _addr = value; }
            get { return _addr; }
        }
        /// <summary>
        /// 企业联系电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }

        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 是否屏蔽企业  1表示屏蔽  0不屏蔽
        /// </summary>
        public bool Deleted
        {
            set { _deleted = value; }
            get { return _deleted; }
        }

        /// <summary>
        /// 返点（折扣）
        /// </summary>
        public double DisCount
        {
            set { _discount = value; }
            get { return _discount; }
        }

        #endregion 

        #region 扩展属性

        private List<Department> depList = new List<Department>();
        private int _did;
        private string _dname;

        /// <summary>
        /// 部门id
        /// </summary>		 
        public int DID
        {
            get { return _did; }
            set { _did = value; }
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
        /// 部门列表
        /// </summary>
        public List<Department> DepList
        {
            get { return depList; }
            set { depList = value; }
        }


        #endregion

    }
}
