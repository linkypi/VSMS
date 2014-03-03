using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VSMS.Models.DAL;
using VSMS.Models.Model;
using VSMS.Common.XphpTool;
using VSMS.Models.MVCModels;

namespace VSMS.Models.BLL
{
    public class VegetableService
    {
        private readonly VegetableDao vdao = new VegetableDao();

     
        /// <summary>
        /// 根据蔬菜ID获取蔬菜信息
        /// </summary>
        /// <param name="vid">蔬菜VID</param>
        /// <returns>蔬菜Model</returns>
        public Vegetable GetVegetableByVid(int vid)
        {
            return vdao.GetVegetableByVid(vid);
        }


         /// <summary>
        /// 获取当天交易的所有蔬菜
        /// </summary>
        /// <returns></returns>
        public List<Vegetable> GetAllVegetableDayTrading()
        {
            return vdao.GetAllVegetableDayTrading();
        }

        /// <summary>
        /// 更新蔬菜
        /// </summary>
        /// <param name="vid">蔬菜id</param>
        /// <param name="vname">蔬菜名</param>
        /// <param name="cid">类别id</param>
        /// <param name="keys">关键字</param>
        /// <param name="specification">规格</param>
        /// <returns>更新成功返回true  否则返回false</returns>
        public bool Update(int vid, string vname, int cid, string keys, double specification)
        {
            if (vid <= 0) return false;
            Vegetable vege = vdao.GetVegetableByVid(vid);
            if(!string.IsNullOrEmpty(vname)) vege.VName = vname;
            if (!string.IsNullOrEmpty(keys)) vege.Keys = keys;
            if (specification >= 0) vege.Specification = specification;
            vege.VCode = vdao.SetVCode(vege);//更新VCode

            return vdao.Update(vege);
        }

        /// <summary>
        /// 获取所有蔬菜（包含关键字，排序）
        /// </summary>
        /// <returns>返回对应关键字列表的字典</returns>
        public Dictionary<string, object> GetVegetableFromKeys()
        {
            try
            {
                List<Vegetable> list = vdao.GetVegetablesByKeys();
                if (list.Count == 0) return null;

                Dictionary<string, object> returnDic = new Dictionary<string, object>();

                string currentKey = list[0].Keys;
                List<Vegetable> newlist = new List<Vegetable>();

                foreach (Vegetable v in list)
                {
                    if (v.Keys != currentKey)
                    {
                        returnDic.Add(currentKey, newlist);
                        newlist = new List<Vegetable>();
                        currentKey = v.Keys;
                        newlist.Add(v);
                        continue;
                    }
                    newlist.Add(v);
                }
                returnDic.Add(currentKey, newlist);
                return returnDic;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 获取检货单所有蔬菜信息
        /// </summary>
        /// <returns></returns>
        public List<Vegetable> GetInspectionSheetVegetabls()
        {
            try
            {
                return vdao.GetInspectionSheetVegetables();
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 更改蔬菜顺序
        /// </summary>
        /// <returns>返回更改蔬菜顺序的列表</returns>
        public List<Vegetable> GetChangeVOrder()
        {
            try
            {
                return vdao.ChangeVOrder();
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获得拼音首字母
        /// </summary>
        /// <param name="letter">要获得拼音首字母的蔬菜名</param>
        /// <returns>蔬菜名的拼音首字母</returns>
        public string GetFirstLetter(string letter)
        {
            try
            {
                return vdao.GetHeadOfChs(letter);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获得未删除蔬菜，并按字母顺序排序、按蔬菜记录的顺序排序
        /// </summary>
        /// <returns>蔬菜列表</returns>
        public List<Vegetable> GetUnDeleteVegetables()
        {
            return vdao.GetUnDeleteVegetables();

        }

        /// <summary>
        /// 获得已删除蔬菜名
        /// </summary>
        /// <returns></returns>
        //public List<Vegetable> GetDeletedVegetableName(string keys)
        //{
        //    try
        //    {
        //        return vdao.DeletedVegetableName(keys);
        //    }
        //    catch (Exception ex)
        //    {
        //        XphpTool.CreateErrorLog(ex.ToString());
        //        throw ex;
        //    }
        //}


        /// <summary>
        /// 根据蔬菜id屏蔽蔬菜
        /// </summary>
        /// <param name="vid">蔬菜id</param>
        /// <returns>屏蔽蔬菜成功返回true，否则返回false</returns>
        public bool DisappearVegetable(int vid)
        {
            try
            {
                return vdao.Delete(vid);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 根据蔬菜id恢复已删除蔬菜
        /// </summary>
        /// <param name="vid">蔬菜id</param>
        /// <returns>恢复屏蔽成功返回true，否则返回false</returns>
        public bool AppearVegetable(int vid)
        {
            try
            {
                return vdao.Activate(vid);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 根据蔬菜名字得到蔬菜id
        /// </summary>
        /// <param name="vname">蔬菜名</param>
        /// <returns>返回蔬菜名对应的蔬菜id</returns>
        public int GetVIDByVName(string vname)
        {
            try
            {
                return vdao.GetIDByName(vname);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 验证蔬菜名称是否存在
        /// </summary>
        /// <param name="vname">蔬菜名称</param>
        /// <returns></returns>
        public bool ExistOrNot(string vname)
        {
            return vdao.Exists(vname);
        }

        /// <summary>
        /// 添加蔬菜
        /// </summary>
        /// <param name="vt"></param>
        /// <returns></returns>
        public bool Add(Vegetable vt)
        {
           int vid= vdao.Add(vt);
            if(vid==-1)  return false;
            //生成利润
            int rows = GenerateProfit(vid);
            return rows>0;
        }

        /// <summary>
        /// 获取订购蔬菜与企业的映射关系
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetVEDicMap()
        {
            List<MapModel> list = vdao.GetMapModels();
            Dictionary<string, object> dic = new Dictionary<string, object>();

            foreach (MapModel mm in list)
            {
                dic.Add(mm.VID.ToString() + "_" + mm.EID.ToString(), "true");
            }
            return dic;
        }
        
        #region 私有方法

        /// <summary>
        /// 生成利润
        /// </summary>
        /// <param name="vid">蔬菜编号</param>
        /// <returns>返回受影响的行数</returns>
        private int GenerateProfit(int vid)
        {
            StringBuilder strbd = new StringBuilder();
            strbd.Append(@"  declare @currentDID int 
                                        declare DID_cur cursor
                                        for 
	                                        select DID from Department 
	                                        order by DID
                                        open DID_cur 
                                        fetch next from DID_cur into @currentDID
                                        while @@FETCH_STATUS=0
                                        begin 

                                           insert into Profit(DID,VID,profit)
                                           values(@currentDID,"+vid+@",0.1)
                                           fetch next from DID_cur into @currentDID

                                        end
                                        close DID_cur
                                        deallocate DID_cur");
           return   vdao.ExecuteNonQuery(strbd.ToString());
        }

        #endregion

    }
}
