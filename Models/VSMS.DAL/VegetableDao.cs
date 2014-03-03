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
using VSMS.Models.DAL;
using VSMS.Models.MVCModels;


namespace VSMS.Models.DAL
{
    /// <summary>
    /// 数据访问类:Vegetables
    /// </summary>
    public  class VegetableDao
    {
        #region  Method

        /// <summary>
        /// 检查指定的蔬菜是否存在
        /// </summary>
        /// <param name="name">蔬菜名称</param>
        /// <returns>若存在则true  否则返回false</returns>
        public bool Exists(string name)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from Vegetable");
                strSql.Append(" where VName=@VName ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@VName", name);
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
        /// 获取蔬菜代码
        /// </summary>
        /// <param name="veg">蔬菜实体</param>
        /// <returns></returns>
        public string GetVCode(Vegetable veg)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  MAX(VID) from Vegetable ");
                string vid = SqlHelper.ExecuteScalarByString(strSql.ToString(), null).ToString();

                string temp = (int.Parse(vid) + 1).ToString();
                if (temp.Length < 5)
                {
                    int count = temp.Length;
                    for (int i = 0; i < 5 - count; i++)
                    {
                        temp = "0" + temp;
                    }
                }
                string cid = veg.CID.ToString();
                if (cid.Length < 2)
                {
                    cid = "0"+cid;
                }
                return veg.Keys + cid + temp;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }
        /// <summary>
        /// 获取蔬菜代码
        /// </summary>
        /// <param name="veg">蔬菜实体</param>
        /// <returns></returns>
        public string SetVCode(Vegetable veg)
        {
            try
            {
                
                string temp = (veg.VID + 1).ToString();
                if (temp.Length < 5)
                {
                    int count = temp.Length;
                    for (int i = 0; i < 5 - count; i++)
                    {
                        temp = "0" + temp;
                    }
                }
                string cid = veg.CID.ToString();
                if (cid.Length < 2)
                {
                    cid = "0" + cid;
                }
                return veg.Keys + cid + temp;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return veg.VCode;
            }
        }


        /// <summary>
        /// 执行没有查询的sql语句
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>执行成功返回受影响的行数</returns>
        public int ExecuteNonQuery(string cmd)
        {
            return SqlHelper.ExecuteNonQuery(cmd,new Dictionary<string,object>());
        }

        /// <summary>
        /// 添加蔬菜
        /// </summary>
        /// <param name="model">蔬菜</param>
        /// <returns>添加成功返回当前编号  否则返回-1</returns>
        public int Add(Vegetable model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Vegetable(");
                strSql.Append("[VCode],[CID],[Keys],[VName],[Specification])");
                strSql.Append(" values (");
                strSql.Append("@VCode,@CID,@Keys,@VName,@Specification)");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@VCode", GetVCode(model));
                paraDic.Add("@CID", model.CID);
                paraDic.Add("@Keys", model.Keys);
                paraDic.Add("@VName", model.VName);
                paraDic.Add("@Specification",model.Specification);

                int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);
                if (rows <= 0) return -1;

                string cmd = "select MAX(VID) from Vegetable ";
                return (int) SqlHelper.ExecuteScalarByString(cmd,new Dictionary<string,object>());
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 更新蔬菜
        /// </summary>
        /// <param name="model">蔬菜实体</param>
        /// <returns>更新成功返回true  否则返回false</returns>
        public bool Update(Vegetable model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Vegetable set ");
                strSql.Append("VCode=@VCode,");
                strSql.Append("CID=@CID,");
                strSql.Append("Keys=@Keys,");
                strSql.Append("VName=@VName,");
                strSql.Append("VOrder=@VOrder,");
                strSql.Append("Specification = @Specification,");
                strSql.Append("Deleted=@Deleted");
                //strSql.Append("ModifyTime=@ModifyTime");
                strSql.Append(" where VID=@VID");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("VCode", model.VCode);
                paraDic.Add("CID", model.CID);
                paraDic.Add("Keys", model.Keys);
                paraDic.Add("VName", model.VName);
                paraDic.Add("VOrder",model.VOrder);
                paraDic.Add("Specification",model.Specification);
                paraDic.Add("Deleted", model.Deleted);
               // paraDic.Add("ModifyTime", model.ModifyTime);
                paraDic.Add("VID", model.VID);
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
       /// 屏蔽蔬菜
       /// </summary>
       /// <param name="vid">蔬菜编号</param>
       /// <returns>屏蔽成功则返回true   否则返回false</returns>
        public bool Delete(int vid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Vegetable set Deleted = 1 ");
                strSql.Append(" where VID=@VID ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("VID", vid);
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
        /// 恢复已删除的蔬菜
        /// </summary>
        /// <param name="vid">蔬菜编号</param>
        /// <returns>恢复成功则返回true   否则返回false</returns>
        public bool Activate(int vid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Vegetable set Deleted = 0  ");
                strSql.Append(" where VID =@VID ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("VID", vid);
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
        /// 根据蔬菜名称获取其对应的编号
        /// </summary>
        /// <param name="name">蔬菜名称</param>
        /// <returns>若存在则返回其编号  否则返回-1</returns>
        public int GetIDByName(string name)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  VID from Vegetable ");
                strSql.Append(" where VName=@VName ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("VName", name);

                object obj = SqlHelper.ExecuteScalarByString(strSql.ToString(), paraDic);
                if (obj == null) return -1;

                int ret = (int)obj;
                return ret;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }
        }
        /// <summary>
        /// 根据编号获取其对应的蔬菜名称
        /// </summary>
        /// <param name="name">编号</param>
        /// <returns>若存在则返回其蔬菜名称  否则返回-1</returns>
        public string GetNameByID(int vid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  VName from Vegetable ");
                strSql.Append(" where VID=@VID ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("VID", vid);

                object obj = SqlHelper.ExecuteScalarByString(strSql.ToString(), paraDic);
                if (obj == null) return null;

                string ret = (string)obj;
                return ret;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获得蔬菜列表，并排序
        /// </summary>
        /// <returns>返回蔬菜列表，并排序</returns>
        public List<Vegetable> GetVegetablesByKeys()
        {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("select VID,VOrder,Keys,VName,Deleted from vegetable order by  Keys,VOrder");
             Dictionary<string,string> outDic = new Dictionary<string,string>();
             outDic.Add("VID", "VID");
             outDic.Add("VOrder", "VOrder");
             outDic.Add("Keys", "Keys");
             outDic.Add("VName","VName");
             outDic.Add("Deleted", "Deleted");
             
             //前者为model字段   后者为数据库字段

            List<Vegetable> list =  SqlHelper.GetDataListByString<Vegetable>(strSql.ToString(),null,outDic);

            if (list==null)
                return null;
            return list;
        }

        
        /// <summary>
        /// 更改蔬菜排列顺序
        /// </summary>
        /// <returns>更改蔬菜排序列表</returns>
        public List<Vegetable> ChangeVOrder()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select vname,vid,VOrder from vegetable");
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("VName", "VName");
                outDic.Add("VID", "VID");
                outDic.Add("VOrder", "VOrder");
                List<Vegetable> list = SqlHelper.GetDataListByString<Vegetable>(strSql.ToString(), null, outDic);

                if (list == null)
                    return null;
                return list;
            }
            catch (System.Exception e)
            {
                XphpTool.CreateErrorLog(e.ToString());
                return null;
            }
            
        }

        
        public List<Vegetable> GetUnDeleteVegetables()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select VID, VName,Keys from Vegetable where Deleted=0 ORDER by VName");
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("VName", "VName");
                outDic.Add("VID", "VID");
                outDic.Add("Keys", "keys");
                List<Vegetable> list = SqlHelper.GetDataListByString<Vegetable>(strSql.ToString(), null, outDic);

                if (list == null)
                    return null;
                return list;
            }
            catch (System.Exception e)
            {
                XphpTool.CreateErrorLog(e.ToString());
                return null;
            }

        }

        /// <summary>
        /// 根据蔬菜编号获取一种蔬菜
        /// </summary>
        /// <param name="vid">蔬菜编号</param>
        /// <returns>存在则返回蔬菜实体   否则返回null</returns>
        public Vegetable GetModel(int vid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select 
                                        v.[VID] ,v.[IID],[CID],[Keys] ,[VName],[Specification]
                                      ,[Descriptions] ,[Deleted] ,[ValidateTime]
                                      ,[Unit] ,v.[Creater] ,v.[CreateTime] ,[Modifier]
                                      ,[ModifyTime] ,[Paths] ,[PID] ,[ActualPrice]
                                      ,[MarketPrice] ,[WholesalePrice] ,[LabourCharges]
                                      ,[DisCount] ,[Profit] ,p.[Creater] as pCreater
                                      ,p.[CreateTime] as pCreateTime   ,[Vertifier]
                                      ,[VertifyTime] ,[VertifyResault] ");
            strSql.Append(" from Vegetable as v , Images as i , UnitPrice as p ");
            strSql.Append(" where  i.IID= v.IID and p.VID = v.VID  and VID=@VID ");

            //选出已经审核过的最近5天的价格信息 
            strSql.Append(@"and  VertifyTime> getdate()- 5 and VertifyResault=1
                                        order by  v.vid asc ,VertifyTime asc ");

            SqlParameter[] parameters = { new SqlParameter("@VID", SqlDbType.Int,4)	};
            parameters[0].Value = vid;

            return null;
        }

        /// <summary>
        /// 根据蔬菜ID获取蔬菜信息
        /// </summary>
        /// <param name="vid">蔬菜VID</param>
        /// <returns>蔬菜Model</returns>
        public Vegetable GetVegetableByVid(int vid) 
        {
            StringBuilder StrSql = new StringBuilder();
            StrSql.Append("SELECT  [VID],[VCode],[CID],[VOrder],[Keys],[VName],[Specification],[Deleted],[CreateTime],[ModifyTime]");
            StrSql.Append("FROM [VSMS].[dbo].[Vegetable]");
            StrSql.Append("WHERE [VID]=@VID");
            Dictionary<string, object> paramsValue = new Dictionary<string, object>();
            paramsValue.Add("VID", vid);
            Dictionary<string, string> returnValuesBinding = new Dictionary<string, string>();
            returnValuesBinding.Add("VID", "VID");
            returnValuesBinding.Add("VCode", "VCode");
            returnValuesBinding.Add("CID", "CID");
            returnValuesBinding.Add("VOrder", "VOrder");
            returnValuesBinding.Add("Keys", "Keys");
            returnValuesBinding.Add("VName", "VName");
            returnValuesBinding.Add("Specification", "Specification");
            returnValuesBinding.Add("Deleted", "Deleted");
            returnValuesBinding.Add("CreateTime", "CreateTime");
            returnValuesBinding.Add("ModifyTime", "ModifyTime");
            return SqlHelper.GetDataModelByString<Vegetable>(StrSql.ToString(), paramsValue, returnValuesBinding);
        }
        /// <summary>
        /// 获取检货单蔬菜名称列表
        /// </summary>
        /// <returns></returns>
        public List<Vegetable> GetInspectionSheetVegetables()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"select VName
                                            from Orders as o ,OrderDetail as od,
                                            Vegetable as v
                                            where od.OID=o.OID and v.VID = od.VID
                                            --and datediff(day,o.OrderTime,getdate())=0
                                            group by VName");
                Dictionary<string,string> outDic = new Dictionary<string,string>();
                outDic.Add("VName","VName");
                List<Vegetable> list = SqlHelper.GetDataListByString<Vegetable>(strSql.ToString(),null,outDic);
                if (list==null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取当天交易的所有蔬菜
        /// </summary>
        /// <returns></returns>
        public List<Vegetable> GetAllVegetableDayTrading()
        {
            try
            {
                StringBuilder strbd = new StringBuilder();
                strbd.Append(@"  select distinct v.VID,VName,WholesalePrice
                                        from Vegetable as v 
                                        join OrderDetail as od on v.VID=od.VID
                                        join Orders as o on od.OID = o.OID
                                        join UnitPrice as u on u.VID = v.VID
                                        where datediff(day,o.OrderTime,GETDATE())=0
                                        and o.OrderState=1");
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("VID", "VID");
                outDic.Add("VName", "VName");
                outDic.Add("WholesalePrice", "WholesalePrice");

                List<Vegetable> list = SqlHelper.GetDataListByString<Vegetable>(strbd.ToString(), null, outDic);
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
        /// 获取企业和企业所订购蔬菜的映射关系  实体映射
        /// </summary>
        /// <returns></returns>
        public List<MapModel> GetMapModels()
        {
            try
            {
                StringBuilder strbd = new StringBuilder();
                strbd.Append(@"  select distinct od.VID,e.EID
                                        from  Orders as o
                                        join OrderDetail as od on od.OID=o.OID
                                        join Department as d on d.DID=o.DID 
                                        join Enterprise as e on e.EID= d.EID
                                        where datediff(day,o.OrderTime,getdate())=0
                                        and OrderState=1
                                        group by od.VID,e.EID");
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("VID", "VID");
                outDic.Add("EID", "EID");

                List<MapModel> list = SqlHelper.GetDataListByString<MapModel>(strbd.ToString(), null, outDic);
                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }
        #endregion  Method


        #region 获得蔬菜拼音字母（取首个拼音字母用substring（0,1）获得）
        #region 编码定义

        private static int[] pyvalue = new int[]
            {
                -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, -20230, -20051, -20036, -20032,
                -20026,
                -20002, -19990, -19986, -19982, -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746,
                -19741, -19739, -19728,
                -19725, -19715, -19540, -19531, -19525, -19515, -19500, -19484, -19479, -19467, -19289, -19288, -19281,
                -19275, -19270, -19263,
                -19261, -19249, -19243, -19242, -19238, -19235, -19227, -19224, -19218, -19212, -19038, -19023, -19018,
                -19006, -19003, -18996,
                -18977, -18961, -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, -18731, -18722, -18710,
                -18697, -18696, -18526,
                -18518, -18501, -18490, -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220, -18211,
                -18201, -18184, -18183,
                -18181, -18012, -17997, -17988, -17970, -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759,
                -17752, -17733, -17730,
                -17721, -17703, -17701, -17697, -17692, -17683, -17676, -17496, -17487, -17482, -17468, -17454, -17433,
                -17427, -17417, -17202,
                -17185, -16983, -16970, -16942, -16915, -16733, -16708, -16706, -16689, -16664, -16657, -16647, -16474,
                -16470, -16465, -16459,
                -16452, -16448, -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, -16393, -16220,
                -16216, -16212, -16205,
                -16202, -16187, -16180, -16171, -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915,
                -15903, -15889, -15878,
                -15707, -15701, -15681, -15667, -15661, -15659, -15652, -15640, -15631, -15625, -15454, -15448, -15436,
                -15435, -15419, -15416,
                -15408, -15394, -15385, -15377, -15375, -15369, -15363, -15362, -15183, -15180, -15165, -15158, -15153,
                -15150, -15149, -15144,
                -15143, -15141, -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, -14941, -14937, -14933,
                -14930, -14929, -14928,
                -14926, -14922, -14921, -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, -14678,
                -14674, -14670, -14668,
                -14663, -14654, -14645, -14630, -14594, -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353,
                -14345, -14170, -14159,
                -14151, -14149, -14145, -14140, -14137, -14135, -14125, -14123, -14122, -14112, -14109, -14099, -14097,
                -14094, -14092, -14090,
                -14087, -14083, -13917, -13914, -13910, -13907, -13906, -13905, -13896, -13894, -13878, -13870, -13859,
                -13847, -13831, -13658,
                -13611, -13601, -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, -13359, -13356,
                -13343, -13340, -13329,
                -13326, -13318, -13147, -13138, -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060,
                -12888, -12875, -12871,
                -12860, -12858, -12852, -12849, -12838, -12831, -12829, -12812, -12802, -12607, -12597, -12594, -12585,
                -12556, -12359, -12346,
                -12320, -12300, -12120, -12099, -12089, -12074, -12067, -12058, -12039, -11867, -11861, -11847, -11831,
                -11798, -11781, -11604,
                -11589, -11536, -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067, -11055, -11052, -11045,
                -11041, -11038, -11024,
                -11020, -11019, -11018, -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587, -10544,
                -10533, -10519, -10331,
                -10329, -10328, -10322, -10315, -10309, -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256,
                -10254
            };

        private static string[] pystr = new string[]
            {
                "a", "ai", "an", "ang", "ao", "ba", "bai", "ban", "bang", "bao", "bei", "ben", "beng", "bi", "bian",
                "biao",
                "bie", "bin", "bing", "bo", "bu", "ca", "cai", "can", "cang", "cao", "ce", "ceng", "cha", "chai", "chan"
                , "chang", "chao", "che", "chen",
                "cheng", "chi", "chong", "chou", "chu", "chuai", "chuan", "chuang", "chui", "chun", "chuo", "ci", "cong"
                , "cou", "cu", "cuan", "cui",
                "cun", "cuo", "da", "dai", "dan", "dang", "dao", "de", "deng", "di", "dian", "diao", "die", "ding",
                "diu", "dong", "dou", "du", "duan",
                "dui", "dun", "duo", "e", "en", "er", "fa", "fan", "fang", "fei", "fen", "feng", "fo", "fou", "fu", "ga"
                , "gai", "gan", "gang", "gao",
                "ge", "gei", "gen", "geng", "gong", "gou", "gu", "gua", "guai", "guan", "guang", "gui", "gun", "guo",
                "ha", "hai", "han", "hang",
                "hao", "he", "hei", "hen", "heng", "hong", "hou", "hu", "hua", "huai", "huan", "huang", "hui", "hun",
                "huo", "ji", "jia", "jian",
                "jiang", "jiao", "jie", "jin", "jing", "jiong", "jiu", "ju", "juan", "jue", "jun", "ka", "kai", "kan",
                "kang", "kao", "ke", "ken",
                "keng", "kong", "kou", "ku", "kua", "kuai", "kuan", "kuang", "kui", "kun", "kuo", "la", "lai", "lan",
                "lang", "lao", "le", "lei",
                "leng", "li", "lia", "lian", "liang", "liao", "lie", "lin", "ling", "liu", "long", "lou", "lu", "lv",
                "luan", "lue", "lun", "luo",
                "ma", "mai", "man", "mang", "mao", "me", "mei", "men", "meng", "mi", "mian", "miao", "mie", "min",
                "ming", "miu", "mo", "mou", "mu",
                "na", "nai", "nan", "nang", "nao", "ne", "nei", "nen", "neng", "ni", "nian", "niang", "niao", "nie",
                "nin", "ning", "niu", "nong",
                "nu", "nv", "nuan", "nue", "nuo", "o", "ou", "pa", "pai", "pan", "pang", "pao", "pei", "pen", "peng",
                "pi", "pian", "piao", "pie",
                "pin", "ping", "po", "pu", "qi", "qia", "qian", "qiang", "qiao", "qie", "qin", "qing", "qiong", "qiu",
                "qu", "quan", "que", "qun",
                "ran", "rang", "rao", "re", "ren", "reng", "ri", "rong", "rou", "ru", "ruan", "rui", "run", "ruo", "sa",
                "sai", "san", "sang",
                "sao", "se", "sen", "seng", "sha", "shai", "shan", "shang", "shao", "she", "shen", "sheng", "shi",
                "shou", "shu", "shua",
                "shuai", "shuan", "shuang", "shui", "shun", "shuo", "si", "song", "sou", "su", "suan", "sui", "sun",
                "suo", "ta", "tai",
                "tan", "tang", "tao", "te", "teng", "ti", "tian", "tiao", "tie", "ting", "tong", "tou", "tu", "tuan",
                "tui", "tun", "tuo",
                "wa", "wai", "wan", "wang", "wei", "wen", "weng", "wo", "wu", "xi", "xia", "xian", "xiang", "xiao",
                "xie", "xin", "xing",
                "xiong", "xiu", "xu", "xuan", "xue", "xun", "ya", "yan", "yang", "yao", "ye", "yi", "yin", "ying", "yo",
                "yong", "you",
                "yu", "yuan", "yue", "yun", "za", "zai", "zan", "zang", "zao", "ze", "zei", "zen", "zeng", "zha", "zhai"
                , "zhan", "zhang",
                "zhao", "zhe", "zhen", "zheng", "zhi", "zhong", "zhou", "zhu", "zhua", "zhuai", "zhuan", "zhuang",
                "zhui", "zhun", "zhuo",
                "zi", "zong", "zou", "zu", "zuan", "zui", "zun", "zuo"
            };

        #endregion

        /// <summary>
        /// 将一串中文转化为拼音
        /// </summary>
        /// <param name="chsstr">指定汉字</param>
        /// <returns>拼音首字母</returns>
        public string GetHeadOfChs(string chsstr)
        {
            string strRet = string.Empty;

            char[] ArrChar = chsstr.ToCharArray();

            foreach (char c in ArrChar)
            {
                strRet += GetHeadOfSingleChs(c.ToString());
            }

            return strRet;
        }

        /// <summary>
        /// 单个汉字转化为拼音
        /// </summary>
        /// <param name="SingleChs">单个汉字</param>
        /// <returns>拼音</returns>
        public string SingleChs2Spell(string SingleChs)
        {
            byte[] array;
            int iAsc;
            string strRtn = string.Empty;

            array = Encoding.Default.GetBytes(SingleChs);

            try
            {
                iAsc = (short)(array[0]) * 256 + (short)(array[1]) - 65536;
            }
            catch
            {
                iAsc = 1;
            }

            if (iAsc > 0 && iAsc < 160)
                return SingleChs;

            for (int i = (pyvalue.Length - 1); i >= 0; i--)
            {
                if (pyvalue[i] <= iAsc)
                {
                    strRtn = pystr[i];
                    break;
                }
            }

            //将首字母转为大写
            if (strRtn.Length > 1)
            {
                strRtn = strRtn.Substring(0, 1).ToUpper() + strRtn.Substring(1);
            }

            return strRtn;
        }

        /// <summary>
        /// 得到单个汉字拼音的首字母
        /// </summary>
        /// <returns></returns>
        public string GetHeadOfSingleChs(string SingleChs)
        {
            return SingleChs2Spell(SingleChs).Substring(0, 1);
        }
        #endregion



    }
}
