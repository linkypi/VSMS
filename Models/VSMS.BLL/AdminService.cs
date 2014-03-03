using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VSMS.Models.Model;
using VSMS.Models.DAL;
using VSMS.Models.MVCModels;
using VSMS.Common.XphpTool;

namespace VSMS.Models.BLL
{
    public class AdminService
    {
        private AdminsDao adao = new AdminsDao();
        private EnterpriseDao eDao = new EnterpriseDao();
        private DepartmentDao dadao = new DepartmentDao();
        private OrdersDao oadao = new OrdersDao();
        private OrderDetailDao odadao = new OrderDetailDao();


        public string msg = ""; //错误信息

        #region 登录

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="name">登录名</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        public bool Login(string name,string pwd)
        {
            //zhanjiahang修改
            if (string.IsNullOrEmpty(name.Trim()))
            {
                this.msg = "用户名不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(pwd.Trim()))
            {
                this.msg = "密码不能为空";
                return false;
            }

            Admins model = this.GetModel(name);

            if (model == null)
            {
                this.msg = "用户名错误";
                return false;
            } 
            
            if (!model.Pwd.Equals(pwd.ToString()))
            {
                this.msg = "密码错误";
                return false;
            }

            return true;

        }

        #endregion 登录


        #region 添删改查

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool Add(Admins admin)
        {
            return adao.Add(admin);
        }

        /// <summary>
        /// 根据管理员登录名得到一个管理员实体
        /// </summary>
        /// <param name="name">管理员登录名</param>
        /// <returns>如果存在返回一个实体，否则返回null</returns>
        public Admins GetModel(string name)
        {
            return adao.GetModel(name);
        }

        /// <summary>
        /// 根据管理员登录id得到一个管理员实体
        /// </summary>
        /// <param name="id">管理员登录id</param>
        /// <returns>如果存在返回一个实体，否则返回null</returns>
        public Admins GetModel(int id)
        {
            return adao.GetModel(id);
        }

        /// <summary>
        /// 更新一个管理员实体
        /// </summary>
        /// <param name="model">管理员实体</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool Update(Admins model)
        {
            return adao.Update(model);
        }

        #endregion 添删改查

        #region 屏蔽一个实体信息
        /// <summary>
        /// 屏蔽或启用企业信息
        /// </summary>
        /// <param name="model">企业实体</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool BanEnterprise(Enterprise model)
        {
            model.Deleted=!(model.Deleted);
            return false;//eadao.Update(model) || dadao.BanList(model) || cadao.Banlist(model);
        }

        /// <summary>
        /// 屏蔽或启用企业信息
        /// </summary>
        /// <param name="model">企业实体</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool BanDepartment(Department model)
        {
            model.Deleted = !(model.Deleted);
            return false;//dadao.Update(model) || cadao.Banlist(model);
        }


        #endregion 屏蔽信息

       

        #region 添加一个实体

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns>添加成功返回当前部门编号   否则返回-1</returns>
        public int AddDepartment(Department model)
        {
            return dadao.Add(model);
        }

        /// <summary>
        /// 添加企业
        /// </summary>
        /// <param name="model"></param>
        /// <returns>添加成功返回该企业的编号，否则返回-1</returns>
        public int AddEnterprise(Enterprise model)
        {
            return eDao.Add(model);
        }

        public bool AddDepartment(Orders model)
        {
            return oadao.Add(model);
        }

        public bool AddOrderDetail(OrderDetail model)
        {
            return odadao.Add(model);
        }

        #endregion 添加一个实体

        #region 删除一个实体

        public bool Delete(Orders model)
        {
            return false;//oadao.Delete(model.OID) || odadao.DeleteByOID(model.OID);
        }

        public bool Delete(OrderDetail model)
        {
            return odadao.DeleteByOID(model.ODID);
        }

        #endregion 删除一个实体



        /// <summary>
        /// 获取相关订单数量
        /// </summary>
        /// <param name="state">订单状态</param>
        /// <param name="ids">订单列表字符串</param>
        /// <returns></returns>
        public int GetOIDCount(OrderState state,string ids)
        {
            string cmd = @"SELECT count(1)
                                FROM [Orders] as o 
                                where  OrderState=" + (int)state + @"
                                and OID not in( "+ids+" )";
            return (int) adao.ExcuteScalar(cmd,null);
        }

        /// <summary>
        /// 根据订单状态获取订单列表
        /// </summary>
        /// <param name="state">订单状态</param>
        /// <returns></returns>
        public List<OrderModel> GetOrdersByState(OrderState state)
        {
            string cmd =@"SELECT  OID,e.EName
                                      ,d.DName
                                      ,OrderCount= count(1) 
                                FROM [Orders] as o 
                                join  Customer as c on c.CID = o.CID 
                                join Department as d on d.DID=c.DID
                                join Enterprise as e on e.EID=d.EID
                                where  OrderState="+(int)state+@"
                                group  by OID,e.EName,d.DName order by EName asc";
            Dictionary<string,string> outDic =new Dictionary<string,string>();
            outDic.Add("EName","EName");
            outDic.Add("DName","DName");
            outDic.Add("OrderCount","OrderCount");
            outDic.Add("OID","OID");

            List<OrderModel> list =  adao.Excute(cmd,null,outDic);
            if (list.Count == 0) return null;
            List<OrderModel> oms = new List<OrderModel>();
            OrderModel om = null; 
            string ename = "";
            int index = 0;

            foreach(OrderModel omodel in list)
            {
                if (omodel.EName != ename)
                {
                    index++;
                    if (index != 1)
                    {
                        oms.Add(om);
                    }
                      om =new OrderModel();
                      om.EName = omodel.EName;
                      om.Dmodels = new List<OrderModel.DepartmentModel>();
                }
                OrderModel.DepartmentModel dmodel = new OrderModel.DepartmentModel();
                dmodel.Oid = omodel.OID;
                dmodel.DName = omodel.DName;
                dmodel.OrderCount = omodel.OrderCount;
                om.Dmodels.Add(dmodel);
                ename = omodel.EName;
            }
            oms.Add(om);
            return oms;
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
        public bool GetUpdateAdminMsg(string loginName, string newPwd, string address, string phone, string mobilPhone, string fax, string email, string previousLoginName)
        {
            try
            {
                return adao.UpdateAdminMsg(loginName, newPwd, address, phone, mobilPhone, fax, email, previousLoginName);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 查询要修改的管理员名称在数据库是否存在
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="aid">用户id</param>
        /// <returns>存在返回true，否则返回false</returns>
        public bool WhetherExistLoginName(string loginName, int aid)
        {
            try
            {
                return adao.Exists(loginName,aid);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 根据管理员登录名获取管理员信息
        /// </summary>
        /// <param name="AID">管理员登录名</param>
        /// <returns>若存在则返回管理员信息，否则返回null</returns>
        //public Admins GetAdminsMessageByLoginName(string loginname)
        //{
        //    try
        //    {
        //        return adao.GetModel(loginname);
        //    }
        //    catch (Exception ex)
        //    {
        //        XphpTool.CreateErrorLog(ex.ToString());
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 根据管理员编号获取管理员信息
        /// </summary>
        /// <param name="AID">管理员编号</param>
        /// <returns>若存在则返回管理员信息，否则返回null</returns>
        public Admins GetAdminsMessageByAID(int aid)
        {
            try
            {
                return adao.GetModel(aid);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 查询除了登陆id为AID的所有蔬菜名称
        /// </summary>
        /// <param name="AID">蔬菜id</param>
        /// <returns>返回除了登陆id为AID的所有蔬菜名称</returns>
        public List<Admins> GetLoginNamesByAID(int AID)
        {
            try
            {
                return adao.LoginName(AID);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                throw ex;
            }
        }
    }
}
