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
    public class DepartmentDao
    {

        /// <summary>
        /// 是否存在该部门
        /// </summary>
        /// <param name="dname">部门名称</param>
        /// <param name="eid">企业编号</param>
        /// <returns>存在则返回true   否则返回false</returns>
        public bool Exists(string dname,int eid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from Department");
                strSql.Append(" where ");
                strSql.Append(" DName = @DName and EID = @EID");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@DName", dname);
                paraDic.Add("@EID",eid);
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
        /// 添加一条数据  返回收影响的函数
        /// </summary>
        /// <param name="model">部门实体</param>
        /// <returns>添加成功返回当前部门编号   否则返回-1</returns>
        public int Add(Department model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Department(");
                strSql.Append("EID,DName,Addr,MobilePhone,Fax,Email,Discount,LabourCharges ");
                strSql.Append(") values (");
                strSql.Append("@EID,@DName,@Addr,@MobilePhone,@Fax,@Email,@Discount,@LabourCharges"); 
                strSql.Append(") ");
                strSql.Append(";select @@IDENTITY");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@DName", model.DName);
                paraDic.Add("@EID", model.EID);
                paraDic.Add("@Addr",model.Addr);
                paraDic.Add("@Discount", model.DisCount);
                paraDic.Add("@LabourCharges",model.LabourCharges);
                paraDic.Add("@MobilePhone", model.MobilePhone);
                paraDic.Add("@Fax", model.Fax);
                paraDic.Add("@Email", model.Email);

                int rows = (int)SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);
                if (rows <= 0) return -1;
                string cmd = "select MAX(DID) from Department ";
                int did = (int)SqlHelper.ExecuteScalarByString(cmd,paraDic);
                return did;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }
        }


       /// <summary>
        /// 更新一条数据     返回收影响的函数
       /// </summary>
       /// <param name="model">部门实体</param>
       /// <returns> 返回收影响的函数</returns>
        public bool Update(Department model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Department set ");
                strSql.Append(" EID = @EID , ");
                strSql.Append(" DName = @DName , ");
                strSql.Append(" Deleted = @Deleted, ");
                strSql.Append("DisCount=@DisCount, ");
                strSql.Append("LabourCharges=@LabourCharges, ");
                strSql.Append("Email =@Email,");
                strSql.Append("Addr=@Addr,");
                strSql.Append("Fax =@Fax,");
                strSql.Append("MobilePhone=@MobilePhone");
                strSql.Append(" where DID=@DID ");
            
                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@DName", model.DName);
                paraDic.Add("@EID", model.EID);
                paraDic.Add("@Addr", model.Addr);
                paraDic.Add("@Deleted",model.Deleted);
                paraDic.Add("@DisCount",model.DisCount);
                paraDic.Add("@LabourCharges", model.LabourCharges);
                paraDic.Add("@Fax",model.Fax);
                paraDic.Add("@MobilePhone",model.MobilePhone);
                paraDic.Add("@Email",model.Email);
                paraDic.Add("@DID",model.DID);

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
       /// 删除部门   
       /// </summary>
       /// <param name="did"></param>
       /// <returns></returns>
        public bool Delete(int did)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Department ");
                strSql.Append(" where DID=@DID");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@DID", did);

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
        /// 设置部门转态  激活或禁用
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool SetDelState(int did)
        {
            string cmd = " update Department set Deleted=~Deleted where DID="+did;
            int ret = (int)SqlHelper.ExecuteNonQuery(cmd,new Dictionary<string,object>());
            return ret > 0;
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        /// <param name="DIDlist">企业编号列表</param>
        /// <returns>屏蔽成功返回true   否则返回false</returns>
        public bool DeleteList(string DIDlist)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Department ");
                strSql.Append(" where ID in (" + DIDlist + ")  ");
                int rows = (int)SqlHelper.ExecuteNonQuery(strSql.ToString(), null);

                return rows > 0;
            }
            catch(Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 根据企业ID获取部门列表信息
        /// </summary>
        /// <param name="Eid">企业ID</param>
        /// <returns></returns>
        public List<Department> GetDepartmentListByEnterpriseID(int Eid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select * ");
                strSql.Append(" from Department ");
                strSql.Append(" WHERE EID=@EID");
                Dictionary<string, string> returnValueBingding = new Dictionary<string, string>();
                returnValueBingding.Add("DID", "DID");
                returnValueBingding.Add("EID", "EID");
                returnValueBingding.Add("DName", "DName");
                returnValueBingding.Add("Addr", "Addr");
                returnValueBingding.Add("DisCount", "DisCount");
                returnValueBingding.Add("LabourCharges", "LabourCharges");
                returnValueBingding.Add("phone", "Phone");
                returnValueBingding.Add("MobilePhone", "MobilePhone");
                returnValueBingding.Add("Fax", "Fax");
                returnValueBingding.Add("Email", "Email");
                returnValueBingding.Add("Deleted", "Deleted");
                Dictionary<string,object> paramsValue = new Dictionary<string,object>();
                paramsValue.Add("EID",Eid);
                List<Department> list = SqlHelper.GetDataListByString<Department>(strSql.ToString(), paramsValue, returnValueBingding);
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
        /// 根据部门编号获取部门信息
        /// </summary>
        /// <param name="did">部门编号</param>
        /// <returns></returns>
        public Department GetDepartmentByID(int did)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT [DID],[EID],[DName] ,[Addr],[LabourCharges],[DisCount],[Phone],[MobilePhone],[Fax],[Email] ,[Deleted]");
                strSql.Append(" FROM Department");
                strSql.Append(" where DID=@DID");

                Dictionary<string, object> inputDic = new Dictionary<string, object>();
                inputDic.Add("@DID",did);

                List<Department> list = SqlHelper.GetDataListByString<Department>(strSql.ToString(), inputDic, GetOutDic());
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
        /// 根据查询条件获得列表
        /// </summary>
        /// <param name="cmd">查询字符串</param>
        /// <returns></returns>
        public List<Department> GetListByString(string cmd)
        {
            try
            {
                List<Department> list = SqlHelper.GetDataListByString<Department>(cmd, null, GetOutDic());
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
        /// 获取部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetModel(int id)
        {
            try
            {
                string cmd = "select * from Department where did=" + id;
                List<Department> list = GetListByString(cmd);
                if (list == null) return null;
                return list[0];
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }


        #region  私有方法

        private Dictionary<string, string> GetOutDic()
        {
            Dictionary<string, string> outDic = new Dictionary<string, string>();
            outDic.Add("DID", "DID");
            outDic.Add("EID", "EID");
            outDic.Add("DName", "DName");
            outDic.Add("Addr", "Addr");
            outDic.Add("LabourCharges", "LabourCharges");
            outDic.Add("DisCount", "DisCount");
            outDic.Add("Phone", "Phone");
            outDic.Add("MobilePhone", "MobilePhone");
            outDic.Add("Fax", "Fax");
            outDic.Add("Email", "Email");
            outDic.Add("Deleted", "Deleted");
            return outDic;
        }

        #endregion
    }
}
