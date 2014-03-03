using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using VSMS.Models.Model;
using VSMS.Common.DataHelper;
using System.Reflection;
using VSMS.Common.XphpTool;
using VSMS.Models.MVCModels;

namespace VSMS.Models.DAL
{
    public class AdminsDao
    {
		#region  Method

		/// <summary>
		/// 查询是否存在该管理员帐号
		/// </summary>
		/// <param name="loginname">管理员帐号</param>
		/// <returns>若存在则返回true   否则返回false</returns>
		public bool Exists(string loginname,int aid)
		{
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from Admins");
                strSql.Append(" where LoginName=@LoginName and AID<>@AID");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@LoginName", loginname);
                paraDic.Add("@AID", aid);
                int count = (int)SqlHelper.ExecuteScalarByString(strSql.ToString(), paraDic);
                return count > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
			
		}

       /// <summary>
       /// 添加数据
       /// </summary>
       /// <param name="model">管理员实体类</param>
       /// <returns>添加成功返回true  否则返回false</returns>
        public bool Add(Admins model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Admins(");
                strSql.Append("LoginName,RealName,Pwd,Addr,Phone,Fax,Email)");
                strSql.Append(" values (");
                strSql.Append("@LoginName,@RealName,@Pwd,@Addr,@Phone,@Fax,@Email)");
                strSql.Append(";select @@IDENTITY");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@LoginName", model.LoginName);
                paraDic.Add("@RealName", model.RealName);
                paraDic.Add("@Pwd", model.Pwd);
                paraDic.Add("@Addr", model.Addr);
                paraDic.Add("@Phone", model.Phone);
                paraDic.Add("@Fax", model.Fax);
                paraDic.Add("@Email", model.Email);

                int row = (int)SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);
                return row > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

		/// <summary>
		/// 更新管理员信息
		/// </summary>
		/// <param name="model">管理员实体</param>
		/// <returns>更新成功返回true  否则返回false</returns>
		public bool Update(Admins model)
		{
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Admins set ");
                strSql.Append("LoginName=@LoginName,");
                strSql.Append("RealName=@RealName,");
                strSql.Append("Pwd=@Pwd,");
                strSql.Append("Addr=@Addr,");
                strSql.Append("Phone=@Phone,");
                strSql.Append("Fax=@Fax,");
                strSql.Append("Email=@Email");
                strSql.Append(" where AID=@AID");

                Dictionary<string, object> paras = new Dictionary<string, object>();
                paras.Add("@LoginName", model.LoginName);
                paras.Add("@LoginName", model.RealName);
                paras.Add("@Pwd", model.Pwd);
                paras.Add("@Addr", model.Addr);
                paras.Add("@Phone", model.Phone);
                paras.Add("@Fax", model.Fax);
                paras.Add("@Email", model.Email);
                paras.Add("@AID", model.AID);

                int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), paras);

                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
			
		}

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="address">地址</param>
        /// <param name="phone">联系电话</param>
        /// <param name="fax">传真</param>
        /// <param name="email">邮箱地址</param>
        /// <returns>修改个人信息成功返回true，否则返回false</returns>
        public bool UpdateAdminMsg(string loginName, string newPwd, string address, string phone, string mobilePhone, string fax, string email, string previousLoginName)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Admins set ");
                strSql.Append("LoginName=@LoginName,");
                strSql.Append("Pwd=@Pwd,");
                strSql.Append("Addr=@Addr,");
                strSql.Append("Phone=@Phone,");
                strSql.Append("MobilePhone=@MobilePhone,");
                strSql.Append("Fax=@Fax,");
                strSql.Append("Email=@Email");
                strSql.Append(" where AID=(select AID from Admins where LoginName=@PreviousLoginName)");

                Dictionary<string, object> paras = new Dictionary<string, object>();
                paras.Add("@LoginName", loginName);
                paras.Add("@Pwd", newPwd);
                paras.Add("@Addr", address);
                paras.Add("@Phone", phone);
                paras.Add("@MobilePhone", mobilePhone);
                paras.Add("@Fax", fax);
                paras.Add("@Email", email);
                paras.Add("@PreviousLoginName", previousLoginName);

                int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), paras);

                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }

        }

		/// <summary>
		/// 根据管理员编号获取管理员信息
		/// </summary>
        /// <param name="AID">管理员编号</param>
		/// <returns>若存在则返回管理员信息，否则返回null</returns>
		public Admins GetModel(int AID)
		{
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 AID,LoginName,RealName,Pwd,Addr,Phone,MobilePhone,Fax,Email from Admins ");
                strSql.Append(" where AID=@AID");

                Dictionary<string, object> inputDic = new Dictionary<string, object>();
                inputDic.Add("@AID", AID);

                List<Admins> list = GetList(strSql.ToString(), inputDic);
                if (list == null) return null;

                return list[0];
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
		}

        
        

        /// <summary>
        /// 根据管理员登录名获取管理员信息
        /// </summary>
        /// <param name="AID">管理员登录名</param>
        /// <returns>若存在则返回管理员信息，否则返回null</returns>
        public Admins GetModel(string LoginName)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 AID,LoginName,RealName,Pwd,Addr,Phone,MobilePhone,Fax,Email from Admins ");
                strSql.Append(" where LoginName=@LoginName");

                Dictionary<string, object> inputDic = new Dictionary<string, object>();
                inputDic.Add("@LoginName", LoginName);

                List<Admins> list = GetList(strSql.ToString(), inputDic);
                if (list== null) return null;

                return list[0];
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 查询除了登陆id为AID的所有蔬菜名称
        /// </summary>
        /// <param name="AID">蔬菜id</param>
        /// <returns>返回除了登陆id为AID的所有蔬菜名称</returns>
        public List<Admins> LoginName(int AID)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select LoginName from Admins where AID<>@AID");

                Dictionary<string, object> inputDic = new Dictionary<string, object>();

                inputDic.Add("AID", AID);
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("LoginName", "LoginName");

                List<Admins> list = SqlHelper.GetDataListByString<Admins>(strSql.ToString(), inputDic, outDic);

                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 执行查询语句      返回结果第一行第一列
        /// </summary>
        /// <param name="cmdstr">查询字符串</param>
        /// <param name="inputDic">输入参数字典</param>
        /// <returns></returns>
        public object ExcuteScalar(string cmdstr,Dictionary<string,object> inputDic)
        {
            return SqlHelper.ExecuteScalarByString(cmdstr,inputDic);
        }

        /// <summary>
        /// 执行查询语句     
        /// </summary>
        /// <param name="cmdstr">查询字符串</param>
        /// <param name="inputDic">输入参数字典</param>
        /// <param name="outDic">输出参数字典</param>
        /// <returns>返回订单实体列表</returns>
        public List<OrderModel> Excute(string cmdstr, Dictionary<string, object> inputDic, Dictionary<string, string> outDic)
        {
            return SqlHelper.GetDataListByString<OrderModel>(cmdstr, inputDic,outDic);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="sqlstr">查询字符串</param>
        /// <param name="inputDic">输入参数字典</param>
        /// <returns>返回数据列表</returns>
        private  List<Admins> GetList(string sqlstr,Dictionary<string, object> inputDic )
        {
            try
            {
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("AID", "AID");
                outDic.Add("LoginName", "LoginName");
                outDic.Add("RealName", "RealName");
                outDic.Add("Pwd", "Pwd");
                outDic.Add("Addr", "Addr");
                outDic.Add("Phone", "Phone");
                outDic.Add("MobilePhone", "MobilePhone");
                outDic.Add("Fax", "Fax");
                outDic.Add("Email", "Email");
                List<Admins> admins = SqlHelper.GetDataListByString<Admins>(sqlstr, inputDic, outDic);

                return admins;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }


     #endregion  method

 
    }
}
