using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    /// <summary>
    /// 系统管理员实体类
    /// </summary>
    [Serializable]
    public class Admins
    {
        #region Model
        private int _aid;
        private string _loginname;
        private string _realname;
        private string _pwd;
        private string _addr;
        private string _phone;
        private string _mobilePhone;

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set { _mobilePhone = value; }
        }
        private string _fax;
        private string _email;
        private bool _deleted;

        /// <summary>
        /// 管理员编号
        /// </summary>
        public int AID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 管理员登录帐号
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 管理员登录密码
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
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
        /// 联系电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
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
        /// 禁用标志
        /// </summary>
        public bool Deleted
        {
            set { _deleted = value; }
            get { return _deleted; }
        }

        #endregion Model

        public override string ToString()
        {
            return this.RealName.ToString();
        }
    }
}
