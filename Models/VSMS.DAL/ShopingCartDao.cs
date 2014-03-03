using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.Model;
using VSMS.Common.DataHelper;
using VSMS.Common.XphpTool;

namespace VSMS.Models.DAL
{
    public class ShopingCartDao
    {
        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="model">购物车对象</param>
        /// <returns>添加成功返回true，错误返回false</returns>
        public bool AddShoppingCart(ShopingCart model)
        {
            try
            {
                //StringBuilder strSql = new StringBuilder();
                //strSql.Append("insert into ShopingCart(");
                //strSql.Append("SCID,DID,VID,VCount,Remarks)");
                //strSql.Append(" values (");
                //strSql.Append("@SCID,@DID,@VID,@VCount,@Remarks)");
                //strSql.Append(";select @@IDENTITY");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@SCID",model.SCID);
                paraDic.Add("@DID", model.DID);
                paraDic.Add("@VID", model.VID);
                paraDic.Add("@VCount", model.VCount);
                paraDic.Add("@Remarks", model.Remarks);

                //执行成功返回受影响的行数
                //int ret = int.Parse(SqlHelper.ExecuteScalarByString(strSql.ToString(), paraDic).ToString());
                return SqlHelper.InsertDataByProc("proc_AddItemToShopingCart", paraDic) > 0;
                //return ret > 0;
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
        /// <param name="scid">购物车行ID</param>
        /// <returns>删除成功返回true，错误返回false</returns>
        public bool DeleteShopingCartItem(string scid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from ShopingCart ");
                strSql.Append(" where SCID=@SCID");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@SCID", scid);
                int rows = (int)SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);

                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        public bool DeleteShopingCart(int did,int vid)
        {
            return DeleteShopingCartItem((did + "-" + vid).ToString());
        }

        /// <summary>
        /// 更新购物车
        /// </summary>
        /// <param name="model">购物车对象</param>
        /// <returns>更新成功返回true，错误返回false</returns>
        public bool UpdateShopingCart(ShopingCart model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update ShopingCart set ");
                strSql.Append(" DID = @DID , ");
                strSql.Append(" VID = @VID , ");
                strSql.Append(" VCount = @VCount , ");
                strSql.Append(" Remarks = @Remarks ");
                strSql.Append(" where SCID=@SCID ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@DID", model.DID);
                paraDic.Add("@VID", model.VID);
                paraDic.Add("@VCount", model.VCount);
                paraDic.Add("@Remarks", model.Remarks);
                paraDic.Add("@SCID", model.SCID);

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
        /// 根据部门ID返回购物车物品列表
        /// </summary>
        /// <param name="Did">Did</param>
        /// <returns></returns>
        public List<ShopingCart> GetShopingCartListByDepartmentID(int Did)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT SCID, DID, ShopingCart.VID, VCount, Remarks ,Vegetable.VName ");
                strSql.Append(" FROM ShopingCart,Vegetable ");
                strSql.Append("WHERE DID=@DID and ShopingCart.VID = Vegetable.VID");

                Dictionary<string,string> returnValueBingding = new Dictionary<string,string>();
                returnValueBingding.Add("SCID", "SCID");
                returnValueBingding.Add("VName", "VName");
                returnValueBingding.Add("DID", "DID");
                returnValueBingding.Add("VID", "VID");
                returnValueBingding.Add("VCount", "VCount");
                returnValueBingding.Add("Remarks", "Remarks");
                Dictionary<string,object> paramsValue = new Dictionary<string,object>();
                paramsValue.Add("DID", Did);
                return SqlHelper.GetDataListByString<ShopingCart>(strSql.ToString(), paramsValue, returnValueBingding);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }
    }
}
