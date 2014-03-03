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

namespace VSMS.Models.DAL
{
    /// <summary>
    /// 企业数据访问类
    /// </summary>
    public class EnterpriseDao
    {
        #region  Method

       /// <summary>
        /// 是否存在该企业
       /// </summary>
       /// <param name="name">企业名称</param>
       /// <returns>存在则返回true   否则返回false</returns>
        public bool Exists(string name)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from Enterprise");
                strSql.Append(" where EName=@EName");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@EName", name);
                int ret = int.Parse(SqlHelper.ExecuteScalarByString(strSql.ToString(), paraDic).ToString());
                return ret > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 添加企业
        /// </summary>
        /// <param name="model">企业实体</param>
        /// <returns>添加成功返回最新企业的编号   否则返回-1</returns>
        public int Add(Enterprise model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Enterprise(");
                strSql.Append("EName,Addr,MobilePhone,Fax,Email,DisCount)");
                strSql.Append(" values (");
                strSql.Append("@EName,@Addr,@MobilePhone,@Fax,@Email,DisCount)");
                strSql.Append(";select @@IDENTITY");

                Dictionary<string, object> paraDic = GetInputDic(model);
                int rows =  (int)SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);

                if (rows <= 0) return -1;
                string cmd = "select MAX(EID) from Enterprise ";
                return (int)SqlHelper.ExecuteScalarByString(cmd,new Dictionary<string,object>());
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 更新企业
        /// </summary>
        /// <param name="model">企业实体</param>
        /// <returns>更新成功返回true   否则返回false</returns>
        public bool Update(Enterprise model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Enterprise set ");
                strSql.Append("EName=@EName,");
               // strSql.Append("LoginName=@LoginName,");
                //strSql.Append("Pwd=@Pwd,");
                //strSql.Append("Manager=@Manager,");
                strSql.Append("Addr=@Addr,");
               // strSql.Append("Phone=@Phone,");
                strSql.Append("MobilePhone=@MobilePhone,");
                strSql.Append("Fax=@Fax,");
                strSql.Append("Email=@Email,");
                strSql.Append("DisCount=@DisCount ");
                //strSql.Append("Deleted=@Deleted");
                strSql.Append(" where EID=@EID");

                Dictionary<string, object> paraDic = GetInputDic(model);
                paraDic.Add("@EID", model.EID);
                int rows = (int)SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);
                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }

        }

        /// <summary>
        /// 获取企业状态
        /// </summary>
        /// <param name="did">部门编号</param>
        /// <returns></returns>
        public bool GetDelState(int did)
        {
            try
            {
                string cmd = @"select Deleted from Enterprise as e where e.EID=
                                (select d.EID from Department as d where DID =" + did + ")";

                bool state = (bool)SqlHelper.ExecuteScalarByString(cmd, null);
                return state;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }

        }

        /// <summary>
        /// 删除企业信息  数据删除后不可恢复
        /// </summary>
        /// <param name="eid">企业编号</param>
        /// <returns>删除成功返回true   否则返回false </returns>
        public bool Delete(int eid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" delete from Enterprise where EID="+eid);
                strSql.Append(" delete from Department where EID= "+eid);

                int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), new Dictionary<string, object>());

                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }

        }

        /// <summary>
        /// 屏蔽或恢复企业   
        /// 若企业已屏蔽  则执行此函数后可恢复企业
        /// </summary>
        /// <returns></returns>
        public bool SetDelState(int eid)
        {
            string cmd = " update enterprise set Deleted=~Deleted where EID="+eid;
            cmd += " update Department set Deleted=~Deleted where EID="+eid;
            int rows = (int)SqlHelper.ExecuteNonQuery(cmd,new Dictionary<string,object>());
            return rows > 0;
        }

        /// <summary>
        /// 根据企业编号获取企业信息
        /// </summary>
        /// <param name="eid">企业编号</param>
        /// <returns>若存在则返回企业信息   否则返回null</returns>
        public Enterprise GetModel(int eid)
        {
            try
            {
                Dictionary<string, object> inputDic = new Dictionary<string, object>();
                inputDic.Add("EID", eid);
                return GetModel(" e.EID=@EID", inputDic);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 根据企业用户登录名获取企业信息
        /// </summary>
        /// <param name="loginName">企业用户登录名</param>
        /// <returns>若存在则返回企业信息   否则返回null</returns>
        public Enterprise GetModel(string loginName)
        {
            try
            {
                Dictionary<string, object> inputDic = new Dictionary<string, object>();
                inputDic.Add("@LoginName", loginName);
                return GetModel(" and loginname=@LoginName",inputDic);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取所有企业   包括部门
        /// </summary>
        /// <returns></returns>
        public List<Enterprise> GetAllModel()
        {
            try
            {
                string cmd = @"SELECT e.[EID],[EName],
                                    [DID],[DName],d.Deleted  FROM [Enterprise] as e
                                    join Department as d on d.EID = e.EID order by e.EID asc ";
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("DID", "DID");
                outDic.Add("DName", "DName");
                outDic.Add("EID", "EID");
                outDic.Add("EName", "EName");
                outDic.Add("Deleted", "Deleted");
                List<Enterprise> list = SqlHelper.GetDataListByString<Enterprise>(cmd, null, outDic);
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
        /// 获取所有企业
        /// </summary>
        /// <returns></returns>
        public List<Enterprise> GetEnterpriseList()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select EID,EName,LoginName,EName,Pwd,Manager,Addr,Phone,MobilePhone,Fax,Email,Deleted,Discount ");
                strSql.Append(" from Enterprise where 1=1 ");
               // Dictionary<string, string> outDic = new Dictionary<string, string>();
             
                List<Enterprise> list = SqlHelper.GetDataListByString<Enterprise>(strSql.ToString(), null,GetOutDic());
                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        #region  私有方法

        /// <summary>
        /// 根据查询条件获取企业信息
        /// </summary>
        /// <param name="condition">条件 ”and ····“</param>
        /// <param name="inputDic">输入参数字典</param>
        /// <returns></returns>
        private Enterprise GetModel(string condition,Dictionary<string,object> inputDic)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  EID,EName,LoginName,Pwd,Manager,Addr,MobilePhone,Fax,Discount, ");
                strSql.Append("Phone,Email,Deleted from Enterprise as e where"+condition);
                List<Enterprise> list = SqlHelper.GetDataListByString<Enterprise>(strSql.ToString(), inputDic, GetOutDic());
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
        /// 获取输入参数字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static Dictionary<string, object> GetInputDic(Enterprise model)
        {
            Dictionary<string, object> paraDic = new Dictionary<string, object>();
            paraDic.Add("@EName", model.EName);
           // paraDic.Add("@LoginName", model.LoginName);
           // paraDic.Add("@Pwd", model.Pwd);
           // paraDic.Add("@Manager", model.Manager);
            paraDic.Add("@Addr", model.Addr);
            paraDic.Add("@DisCount",model.DisCount);
            //paraDic.Add("@Phone", model.Phone);
            paraDic.Add("@MobilePhone", model.MobilePhone);
            paraDic.Add("@Fax", model.Fax);
            paraDic.Add("@Email", model.Email);
            return paraDic;
        }

        /// <summary>
        /// 获取输出参数字典
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetOutDic()
        {
            Dictionary<string, string> outDic = new Dictionary<string, string>();
            outDic.Add("EID", "EID");
            outDic.Add("EName", "EName");
            outDic.Add("LoginName", "LoginName");
            outDic.Add("Pwd", "Pwd");
            outDic.Add("Manager", "Manager");
            outDic.Add("Addr", "Addr");
            outDic.Add("Phone", "Phone");
            outDic.Add("MobilePhone", "MobilePhone");
            outDic.Add("DisCount", "DisCount");
            outDic.Add("Fax", "Fax");
            outDic.Add("Email", "Email");
            outDic.Add("Deleted", "Deleted");
            return outDic;
        }

        #endregion

        #endregion
    }
}
