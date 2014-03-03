using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.DAL;
using VSMS.Common.XphpTool;
using VSMS.Models.Model;

namespace VSMS.Models.BLL
{
    public class ShopingCartService
    {
        private readonly ShopingCartDao scdao=new ShopingCartDao();

        /// <summary>
        /// 更新购物车
        /// </summary>
        /// <param name="model">购物车对象</param>
        /// <returns>更新成功返回true，错误返回false</returns>
        public bool GetUpdateShopingCart(ShopingCart model)
        {
            try
            {
                return scdao.UpdateShopingCart(model);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 购物车删除数据
        /// </summary>
        /// <param name="scid">蔬菜单位编号</param>
        /// <returns>删除成功返回true，错误返回false</returns>
        public bool DeleteShopingCartItem(string scid)
        {
            try
            {
                return scdao.DeleteShopingCartItem(scid);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="model">购物车对象</param>
        /// <returns>添加成功返回true，错误返回false</returns>
        public bool AddItemToShopingCart(ShopingCart model)
        {
            try
            {
                return scdao.AddShoppingCart(model);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 根据部门ID返回购物车物品列表
        /// </summary>
        /// <param name="Did">Did</param>
        /// <returns></returns>
        public List<ShopingCart> GetShopingCartListByDepartmentID(int Did)
        {
            return scdao.GetShopingCartListByDepartmentID(Did);
        }
    }
}
