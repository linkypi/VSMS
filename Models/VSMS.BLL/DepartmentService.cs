using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.DAL;
using VSMS.Common.XphpTool;
using VSMS.Models.Model;

namespace VSMS.Models.BLL
{
    public class DepartmentService
    {
        private readonly DepartmentDao ddao = new DepartmentDao();

        /// <summary>
        /// 验证该企业是否存在该部门
        /// </summary>
        /// <param name="eid">企业编号</param>
        /// <param name="dname">部门名称</param>
        /// <returns></returns>
        public bool ExistOrNot(int eid,string dname)
        {
            return ddao.Exists(dname,eid);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="did">部门编号</param>
        /// <returns></returns>
        public bool Delete(int did)
        {
            return ddao.Delete(did);
        }
        /// <summary>
        /// 将部门状态取反   
        /// </summary>
        /// <param name="did">部门编号</param>
        /// <returns></returns>
        public bool SetDelState(int did)
        {
            return ddao.SetDelState(did); 
        }
        /// <summary>
        /// 添加部门  记得指定部门所属企业编号EID
        /// </summary>
        /// <param name="dp"></param>
        /// <returns>添加成功返回当前部门编号   否则返回-1</returns>
        public int Add(Department dp)
        {
            return ddao.Add(dp);
        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="dp"></param>
        /// <returns></returns>
        public bool Update(Department dp)
        {
            return ddao.Update(dp);
        }
        /// <summary>
        /// 根据查询字符串获取部门信息列表
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentsByString(string cmd)
        {
           List<Department> list =  ddao.GetListByString(cmd);
           if (list == null) return null;
           return list;
        }


        /// <summary>
        /// 根据部门编号获取部门信息
        /// </summary>
        /// <param name="did">部门编号</param>
        /// <returns></returns>
        public Department GetModel(int did)
        {
            return ddao.GetDepartmentByID(did);
        }


        /// <summary>
        /// 根据部门ID获取部门信息
        /// </summary>
        /// <param name="did">部门ID</param>
        /// <returns></returns>
        public Department GetDepartmentByID(int did)
        {
            return ddao.GetDepartmentByID(did);
        }

        /// <summary>
        /// 根据企业ID获取部门列表信息
        /// </summary>
        /// <param name="Eid">企业ID</param>
        /// <returns></returns>
        public List<Department> GetDepartmentListByEnterpriseID(int Eid)
        {
            return ddao.GetDepartmentListByEnterpriseID(Eid);
        }

    }
}
