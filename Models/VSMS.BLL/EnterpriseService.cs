using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.Model;
using VSMS.Models.DAL;

namespace VSMS.Models.BLL
{
    public class EnterpriseService
    {
        EnterpriseDao edao = new EnterpriseDao();

        /// <summary>
        /// 验证企业名称是否存在
        /// </summary>
        /// <param name="string">企业名称</param>
        /// <returns></returns>
        public bool Exist(string name)
        {
            return edao.Exists(name);
        }

        /// <summary>
        /// 获取企业状态
        /// </summary>
        /// <param name="did">部门编号</param>
        /// <returns></returns>
        public bool GetEpDelState(int did)
        {
            return edao.GetDelState(did);
        }

        /// <summary>
        /// 添加企业
        /// </summary>
        /// <param name="ep"></param>
        /// <returns>添加成功返回最新企业的编号   否则返回-1</returns>
        public int Add(Enterprise ep)
        {
            return edao.Add(ep);
        }

        /// <summary>
        /// 更新企业信息
        /// </summary>
        /// <param name="ep"></param>
        /// <returns></returns>
        public bool Update(Enterprise ep)
        {
            return edao.Update(ep);
        }

        /// <summary>
        /// 获取企业列表
        /// </summary>
        /// <returns>企业列表</returns>
        public List<Enterprise> GetEnterpriseList()
        {
            return edao.GetEnterpriseList();
        }

        /// <summary>
        /// 获取企业所有实体   包括所有部门实体
        /// </summary>
        /// <returns></returns>
        public List<Enterprise> GetAllModels()
        {
            List<Enterprise> list = edao.GetAllModel();
            List<Enterprise> retList = new List<Enterprise>();

            Enterprise model = list[0];
            Enterprise temp = new Enterprise();

            int index = 0;
            foreach (Enterprise ep in list)
            {
                index++;
              
                if (ep.EName == model.EName)
                { 
                    Department dp = new Department();
                    dp.DName = ep.DName;
                    dp.Deleted = ep.Deleted;
                    dp.DID = ep.DID;
                    temp.DepList.Add(dp);  
                    if (index == list.Count)
                    {
                        temp.EName = model.EName;
                        temp.EID = model.EID;
                        retList.Add(temp); continue;
                    }
                }
                else 
                {
                     temp.EName = model.EName;
                     temp.EID = model.EID;
                    retList.Add(temp);

                    model = ep;
                    temp = new Enterprise();
                    Department dp = new Department();
                    dp.DName = ep.DName;
                    dp.Deleted = ep.Deleted;
                    dp.DID = ep.DID;
                    temp.DepList.Add(dp);
                }
            }
            return retList;
        }
        /// <summary>
        /// 根据企业编号获取企业信息
        /// </summary>
        /// <param name="eid">企业编号</param>
        /// <returns>若存在则返回企业信息   否则返回null</returns>
        public Enterprise GetModel(int eid)
        {
            return edao.GetModel(eid);
        }


        /// <summary>
        /// 删除企业
        /// </summary>
        /// <param name="eid">企业编号</param>
        /// <returns></returns>
        public bool DelEnterprise(int eid)
        {
            return edao.Delete(eid);
        }

        /// <summary>
        /// 屏蔽或者恢复企业
        /// </summary>
        /// <param name="eid">企业编号</param>
        /// <returns></returns>
        public bool SetDelState(int eid)
        {
            return edao.SetDelState(eid);
        }


    }
}
