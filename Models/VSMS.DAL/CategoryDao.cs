using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using VSMS.Models.Model;
using VSMS.Common.DataHelper;
using System.Reflection;
using VSMS.Common.XphpTool;

namespace VSMS.Models.DAL
{
    /// <summary>
    /// 数据访问类:Category
    /// </summary>
    public class CategoryDao
    {
        #region  Method

        /// <summary>
        /// 检测指定的种类是否存在
        /// </summary>
        /// <param name="cname">种类编号</param>
        /// <returns>存在则返回true   否则返回false</returns>
        public bool Exists(string cname)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from Category");
                strSql.Append(" where CName=@CName ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("CName", cname);
                int row = (int)SqlHelper.ExecuteScalarByString(strSql.ToString(), paraDic);

                return row > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public bool Delete(int cid)
        {
            string cmd = " delete from Category where CID="+cid;
           int rows=  SqlHelper.ExecuteNonQuery(cmd,null);
           return rows > 0;
        }

        /// <summary>
        /// 添加子类
        /// </summary>
        /// <param name="model">种类实体</param>
        /// <returns>添加成功返回当前编号 否则返回-1</returns>
        public int AddChild(Category cat)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"declare @cid int 
                                        select @cid=MAX(cid) from Category
                                        insert into Category(CID,PCID,CName)");
                strSql.Append(" values (@cid+1,@PCID, @CName)");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("PCID", cat.PCID);
                paraDic.Add("@CName", cat.CName);
                int ret = (int)SqlHelper.InsertDataByString(strSql.ToString(), paraDic);
                if (ret <= 0) return -1;
                string cmd = " select MAX(CID) from Category";
                int cid = (int)SqlHelper.ExecuteScalarByString(cmd,null);
                return cid;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 添加父类别   类别的编号和父类的编号一致时表示该类为父类
        /// </summary>
        /// <param name="name">父类名称</param>
        /// <returns>添加成功当前编号  否则-1</returns>
        public int AddParent(string name)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"declare @cid int 
                                        select @cid=MAX(cid) from Category
                                        insert into Category(CID , PCID,CName)
                                         values (@cid+1,@cid+1,@CName)");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@CName", name);
                int ret = (int)SqlHelper.InsertDataByString(strSql.ToString(), paraDic);

                if (ret <= 0) return -1;
                string cmd = " select MAX(CID) from Category";
                int cid = (int)SqlHelper.ExecuteScalarByString(cmd, null);
                return cid;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }

        }


        /// <summary>
        /// 更新蔬菜种类
        /// </summary>
        /// <param name="model">种类实体</param>
        /// <returns>更新成功返回true   否则返回false</returns>
        public bool Update(Category model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Category set ");
                strSql.Append("CName=@CName");
                strSql.Append("PCID=@PCID");
                strSql.Append("COrder=@COrder,");
                strSql.Append(" where CID=@CID");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@PCID", model.PCID);
                paraDic.Add("@CName", model.CName);
                paraDic.Add("@COrder",model.COrder);
                paraDic.Add("@CID", model.CID);

                int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);
                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 根据类别名称 获取类别信息
        /// </summary>
        /// <param name="name">类别名称</param>
        /// <returns></returns>
        public List<Category> GetModels()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@" select PCID,CID ,CName,COrder from Category  
                                             group by PCID,CID,CName,COrder
                                             order by PCID asc ");
                Dictionary<string,string> retDic = new Dictionary<string,string>();
                retDic.Add("PCID","PCID");
                retDic.Add("CID","CID");
                retDic.Add("CName","CName");
                retDic.Add("COrder","COrder");
                List<Category> list = SqlHelper.GetDataListByString<Category>(strSql.ToString(), null, retDic);
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
        /// 根据类别编号获取类别信息
        /// </summary>
        /// <param name="name">类别编号</param>
        /// <returns></returns>
        public Category GetModel(int cid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  CID,PCID,CName,COrder from Category ");
                strSql.Append(" where CID=@CID");

                Dictionary<string, object> inputDic = new Dictionary<string, object>();
                inputDic.Add("@CID", cid);

                List<Category> list = GetList(strSql.ToString(), inputDic);
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
        /// 获取所有父类信息
        /// </summary>
        /// <param name="cid">种类编号</param>
        /// <returns>存在则返回种类信息    否则返回null</returns>
        public List<Category> GetParents()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  CID,PCID,CName,COrder from Category ");
            strSql.Append(" where CID=PCID");

            return GetList(strSql.ToString(), null);
        }

        /// <summary>
        /// 获取指定父类的所有子类
        /// </summary>
        /// <param name="cid">父类名称</param>
        /// <returns>存在则返回种类信息    否则返回null</returns>
        public List<Category> GetChildsByParent(string pname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  CID,PCID,CName from Category ");
            strSql.Append(" where PCID=(select CID from Category where CName =@CName)");

            Dictionary<string, object> inputDic = new Dictionary<string, object>();
            inputDic.Add("@CName", pname);

            return GetList(strSql.ToString(), inputDic);
        }

        /// <summary>
        /// 获取所有类别
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllList()
        {
            try
            {
                string cmd = "select * from Category ";
                List<Category> list = GetList(cmd,new Dictionary<string,object>());
                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        #region 私有方法

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <returns></returns>
        private static List<Category> GetList(string strSql, Dictionary<string, object> inputDic)
        {
            try
            {
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("CID", "CID");
                outDic.Add("PCID", "PCID");
                outDic.Add("CName", "CName");
                outDic.Add("COrder", "COrder");
                List<Category> list = SqlHelper.GetDataListByString<Category>(strSql, inputDic, outDic);
                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        #endregion

        #endregion  Method
    }
}
