using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VSMS.Models.Model;
using VSMS.Models.MVCModels;
using VSMS.Common.XphpTool;
using VSMS.Models.DAL;

namespace VSMS.Models.BLL
{
    public class OrdersService
    {
        private readonly OrdersDao dao = new OrdersDao();

        /// <summary>
        /// 根据条件组合成查询语句，并查询获得Order列表
        /// </summary>
        /// <param name="DID">部门id</param>
        /// <param name="Time">时间段</param>
        /// <param name="State">订单状态</param>
        /// <param name="Page">当前页号</param>
        /// <param name="Count">显示的数目</param>
        /// <returns></returns>
        public List<Orders> GetListByCondition(string EID,string DID,string Time,string State,int Page,int Count)
        {
            string s=GetSearch(EID, DID, Time, State);
            string search = s;
            s = s.Replace("*", " OID ");
            search += " order by OID desc";
            string newStr = "top " + (Count * Page-Count) + " OID";
            search = search.Replace("*", newStr);
            search = "select top " + Count + " * from Orders where OID not in(" + search + ") and OID in ( "+s+") order by OID desc";
            return GetListBySearch(search);
        }
        /// <summary>
        /// 根据条件，组合成sql查询语句
        /// </summary>
        /// <param name="EID"></param>
        /// <param name="DID"></param>
        /// <param name="Time"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        private static string GetSearch(string EID, string DID, string Time, string State)
        {
            string search = "select * from Orders where 1=1 ";
            if (DID != null && DID != "-1")
            {
                search += " and DID='" + DID + "' ";
            }
            else
            {
                if (EID != null && EID != "-1")
                {
                    search += " and DID in (select DID from Department where EID = '" + EID + "') ";
                }
            }
            if (Time != null && Time != "all")
            {
                search += " and DateDiff(dd,OrderTime,getdate())<'" + Time + "' ";
            }
            if (State != null && State != "all")
            {
                search += " and OrderState='" + State + "' ";
            }

            return search;
        }
        /// <summary>
        /// 根据查询语句获取List
        /// </summary>
        /// <param name="search">查询语句</param>
        /// <returns>OrderList</returns>
        public List<Orders> GetListBySearch(string search)
        {
            return dao.GetListBySearch(search);
        }

        /// <summary>
        /// 获取查询结构集是数据笔数
        /// </summary>
        /// <param name="search">查询语句</param>
        /// <returns>影响行数</returns>
        public int GetCountByCondition(string EID, string DID, string Time, string State)
        {
            int count = dao.GetCountBySearch(GetSearch(EID, DID, Time, State));
            return count;
        }

        #region 添删改查

        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="model">订单实体</param>
        /// <returns></returns>
        public bool Add(Orders model)
        {
            return dao.Add(model);
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="OID">根据id删除</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool Delete(int OID)
        {
            return dao.Delete(OID) || new OrderDetailDao().DeleteByOID(OID);
        }


        public bool Update(Orders model)
        {
            return dao.Update(model);
        }

        /// <summary>
        /// 根据订单编号获取订单信息
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        public Orders GetModel(string OID)
        {
            return dao.GetModel(OID);
        }

        /// <summary>
        /// 根据订单编号获取送货单
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        public List<DeliveryNote> GetDeliveryNoteByOID(string oid)
        {
            if (string.IsNullOrEmpty(oid)) return null;

            List<DeliveryNote> list = dao.GetDeliveryNoteByOID(oid);
            if (list == null) return null;
            return list;
        }

        /// <summary>
        /// 获取所有送货单
        /// </summary>
        /// <returns></returns>
        public List<Enterprise> GetAllDeliveryNote()
        {
            try
            {
                List<Enterprise> eplist = new List<Enterprise>();
                List<DeliveryNote> dlvrList = dao.GetAllDeliveryNote();
                if (dlvrList == null || dlvrList.Count==0 ) return null;
                Enterprise ep = new Enterprise();
                ep.EName = dlvrList[0].EName;
                ep.EID = dlvrList[0].EID;
                string currentEName = dlvrList[0].EName;
                foreach (DeliveryNote dn in dlvrList)
                {
                    if (dn.EName == currentEName)
                    {
                        Department dp = new Department();
                        dp.DName = dn.DName;
                        dp.OID = dn.OID;
                        ep.DepList.Add(dp);
                    }
                    else
                    {
                        eplist.Add(ep);
                        currentEName = dn.EName;
                        ep = new Enterprise();
                        ep.EName = dn.EName;
                        ep.EID = dn.EID;
                        Department dp = new Department();
                        dp.DName = dn.DName;
                        dp.OID = dn.OID;
                        ep.DepList.Add(dp);
                    }
                }
                eplist.Add(ep);

                return eplist;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取当天所有交易的企业
        /// </summary>
        /// <returns></returns>
        public List<Enterprise> GetAllEnterpriseDayTrading()
        {
            return dao.GetAllEnterpriceDayTrading();
        }

        /// <summary>
        /// 获取采购单数据列表
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <returns></returns>
        public List<PurchaseNote> GetPurchaseNote(int pageIndex)
        {
            List<PurchaseNote> list = dao.GetPurchaseNote(pageIndex);
            if (list == null) return null;
            return list;
        }

        /// <summary>
        /// 获取采购单总页数
        /// </summary>
        /// <returns></returns>
        public int GetPNTotalPage()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"select count(distinct VID)
                                            from UnitPrice where HasPrice =0 ");

                int count = (int)dao.ExecuteScalar(strSql.ToString(),new Dictionary<string,object>());
                return (int)(Math.Ceiling(count / 20.0));
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 根据订单编号获取送货单总页数
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public int GetDNTotalPage(int oid)
        {
            try
            {
                string cmd = @" select COUNT(VID) from  OrderDetail as od 
                                      where OID= " + oid;
                int count= (int)dao.ExecuteScalar(cmd, new Dictionary<string, object>());

                return (int)(Math.Ceiling(count / 50.0));
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 获取检货单数据列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetInspectionSheet( out  List<Enterprise> epList)
        { 
            epList = new List<Enterprise>(); //企业列表
            try
            {
               
                List<InspectionSheet> list = dao.GetInspectionSheet();
                if (list == null)
                {
                   // epList = null; 
                    return null;
                }
                Dictionary<string, string> valueDic = new Dictionary<string, string>();//部门对应的订购量
                
                //获取企业列表，包括各企业中的订购蔬菜的所有部门
                
                Enterprise ep =new Enterprise();
                Department dp = new Department();
                string currentEName= list[0].EName;
                string currentDName = list[0].DName;
                ep.EName = currentEName;
               
                dp.DName = currentDName;
                ep.DepList.Add(dp);

                foreach (InspectionSheet ins in list)
                {
                    if (currentEName == ins.EName)
                    {
                        if (currentDName != ins.DName)
                        {
                            dp = new Department();
                            dp.DName = ins.DName;
                            ep.DepList.Add(dp);
                            currentDName = ins.DName;
                        }
                    }
                    else
                    {
                        epList.Add(ep);
                        ep = new Enterprise();
                        ep.EName = ins.EName;
                        currentEName = ins.EName;
                        dp = new Department();
                        dp.DName = ins.DName;
                        currentDName = ins.DName;
                        ep.DepList.Add(dp);
                    }

                   if (!valueDic.ContainsKey(ins.EName + ins.DName + ins.VName) )
                    {
                        valueDic.Add(ins.EName + ins.DName + ins.VName, ins.OrderCount.ToString());
                    }
                }
                epList.Add(ep);

                if (list.Count == 0) return null;
                return valueDic;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
         
        }

        /// <summary>
        /// 录入成本价    (录入成本价后自动生成实际售价)
        /// </summary>
        /// <param name="listVID">蔬菜编号列表</param>
        /// <param name="values">蔬菜成本价列表</param>
        /// <returns></returns>
        public bool TypeInWholesalePrice(List<string> listVID,List<double> values)
        {
            try
            {
                if (listVID.Count == 0) return false;

                 StringBuilder str = new StringBuilder();
                 str.Append(@" set xact_abort on 
                                       begin transaction  ");
                for (int i = 0; i < listVID.Count; i++)
                {
                    str.Append(@"  INSERT INTO [UnitPrice]
                                       ([VID] ,[WholesalePrice])  
                                        VALUES ("+listVID[i]+","+values[i]+" )  ");
                    //str.Append(@"  update  UnitPrice set WholesalePrice =" + values[i]);
                    //str.Append(" where  VID= " + listVID[i]);
                }
           
                //关联订单明细UPID
                str.Append( UpdateUPID()) ;
                //生成售价
                //str.Append(GenerateActualPrice());
                str.Append(@"  commit transaction
                                         set xact_abort off  ");

                Dictionary<string, object> dic = new Dictionary<string, object>();
                int count = dao.ExecuteNoQurey(str.ToString(), dic);
        
                return count>0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 录入实收量
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <param name="listVID">蔬菜编号列表</param>
        /// <param name="counts">实收量列表</param>
        public void TypeInRealCount(string oid,List<string> listVID, List<double> counts)
        {
            try
            {
                StringBuilder strbd = new StringBuilder();
                strbd.Append(@" set xact_abort on 
                                       begin transaction  ");
                for (int i = 0; i < counts.Count; i++)
                {
                    strbd.Append(@"  update OrderDetail set RealCount= " + counts[i]);
                    strbd.Append(@" where OID= " + oid + " and VID=" + listVID[i]);
                }
                strbd.Append(" update Orders set OrderState=2 where OID="+oid );
                //生成总额  总成本
                strbd.Append(GenerateTotal(oid));
                strbd.Append(@"  commit transaction
                                      set xact_abort off");
               int ret = dao.ExecuteNoQurey(strbd.ToString(), new Dictionary<string, object>());
               if (ret <= 0) return;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return ;
            }
        }

        /// <summary>
        /// 执行命令  返回受影响的行数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="inputDic"></param>
        /// <returns></returns>
        public int ExecuteNoQurey(string cmd, Dictionary<string, object> inputDic)
        {
            return dao.ExecuteNoQurey(cmd, inputDic);
        }
        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="ShopCartList"></param>
        /// <returns></returns>
        public bool Add(List<ShopingCart> ShopCartList) 
        {
            return dao.Add(ShopCartList);
        }
       #endregion 添删改查

        #region  私有方法

        /// <summary>
        /// 生成总额及总成本  同时更新订单为完成状态
        /// <param name="oid">订单编号</param>
       ///<returns>返回受影响的行数</returns>
        private string GenerateTotal(string oid )
        {
             StringBuilder strbd = new StringBuilder();
            strbd.Append(@"  declare @amount decimal(12,2)      --总额
                                        declare @cost  decimal(12,2)           --总成本
                                        declare @realcount int                    --实收量
                                        declare @price decimal(7,2)             --售价
                                        declare @unitprice decimal(7,2)       --成本价
                                        declare @currentODID int       
                                        set @amount = 0
                                        set @cost = 0
                                        ----定义订单编号游标
                                        declare ODid_cur cursor
                                        for  
                                            --选出所有订单明细编号
	                                        select ODID from OrderDetail
	                                        where OID = " + oid);
           strbd.Append(@"  for read only
                                        open ODid_cur
                                        fetch next from ODid_cur into @currentODID
                                        while @@fetch_status=0
                                        begin 
                                                declare @temp1 decimal(12,2)
                                                declare @temp2 decimal(12,2)
                                                set @temp1=0
                                                set @temp2=0
                                                --获取实收量及售价
		                                        select @realcount=RealCount,@price=ActualPrice from OrderDetail 
		                                        where  ODID = @currentODID
		                                        --合计总额
                                                set @temp1 = @realcount * @price
                                                set @amount =@temp1+@amount 
        
                                                --获取成本价
                                                select @unitprice=Wholesaleprice from UnitPrice 
                                                where UPID=( select UPID from OrderDetail
                                                where ODID = @currentODID)
                                                --合计总成本
                                                set @temp2 = @realcount * @unitprice
                                                set @cost =@temp2 + @cost
        
		                                        fetch next from ODid_cur into @currentODID
                                        end
                                        close ODid_cur
                                        deallocate ODid_cur

                                        --更新总额及总成本
                                        update Orders set Amount=@amount,TotalCost=@cost
                                        where OID = " + oid);
           return strbd.ToString();// dao.ExecuteNoQurey(strbd.ToString(), new Dictionary<string, object>());
        }

        /// <summary>
        /// 生成实际售价  同时更新订单状态
        /// </summary>
        /// <returns>返回受影响的行数</returns>
        private string GenerateActualPrice()
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"  ---declare @currentOID bigint  --当前订单编号
                                    declare @currentVID int  --当前蔬菜编号
                                    declare @currentDID int  --当前部门编号

                                    declare @profit decimal(1,1)          --利润
                                    declare @unitprice decimal(7,2)       --成本价
                                    declare @discount decimal(1,1)        --折扣
                                    declare @labourcharges decimal(1,1)   --人工车费

                                  ----定义订单编号游标
                                    declare GAOid_cur cursor
                                    for
	                                    select OID from Orders where OrderState=0
	                                    and datediff(day,OrderTime,GETDATE())=0
	                                    order by OID
                                        for read only

                                    --打开游标GAOid_cur
                                    open GAOid_cur

                                    --使用游标GAOid_cur
                                    fetch next from GAOid_cur into @currentOID
                                    while @@fetch_status=0
                                    begin  
                                            --定义蔬菜编号游标
                                            declare Vid_cur cursor
                                            for  
		
		                                    --根据订单编号获取部门所订购的蔬菜编号
		                                    select VID from OrderDetail where OID=@currentOID
		                                    for read only

		                                    --打开游标Vid_cur
		                                    open Vid_cur
		
		                                    --使用游标Vid_cur
		                                    fetch next from Vid_cur into @currentVID
		                                    while @@fetch_status=0
		                                    begin  
		                                            --获取当前部门编号
				                                    select @currentDID = DID from Orders
				                                    where  datediff(day,OrderTime,GETDATE())=0
				                                    and OID=@currentOID 
				
		                                            --获取部门利润
                                                    select @profit=Profit from Profit
				                                    where DID=@currentDID and VID=@currentVID 
				
				                                    --获取成本价
				                                    select @unitprice = WholesalePrice from UnitPrice
			                                        where VID = @currentVID
				
				                                    --获取折扣 及 人工车费
				                                    select @labourcharges=LabourCharges,@discount=DisCount 
				                                    from Department where DID=@currentDID
			
				                                    --更新售价
				                                    update OrderDetail set
				                                    ActualPrice = @unitprice*(1+@discount+@profit+@labourcharges) 
				                                    where OID=@currentOID and VID=@currentVID 
				
				                                    fetch next from Vid_cur into @currentVID
		                                    end
		                                    --关闭游标did_cur
		                                    close Vid_cur
		                                    --删除游标did_cur
		                                    deallocate Vid_cur
        
		                                    --更新订单状态 
		                                    update Orders set OrderState=1 where OID=@currentOID
		
		                                    fetch next from GAOid_cur into @currentOID
                                    end
                                    --关闭游标GAOid_cur
                                    close GAOid_cur
                                    --删除游标GAOid_cur
                                    deallocate GAOid_cur  ");
            return str.ToString();
           // return  dao.ExecuteNoQurey(str.ToString(),new Dictionary<string,object>());
        }

        /// <summary>
        /// 关联订单明细的UPID
        /// </summary>
        /// <returns></returns>
        private string UpdateUPID()
        {
            StringBuilder strbd = new StringBuilder();
            strbd.Append(@"     declare @currentODID int  
                                            declare @currentOID  bigint 
                                            declare @currentUPID int 
    
	                                        ----定义订单编号游标
	                                        declare Oid_cur cursor
	                                        for
		                                        select OID from Orders 
		                                        where OrderState=0 and
		                                        datediff(DAY,OrderTime,GETDATE())=0
		                                        for read only

	                                        open Oid_cur
	                                        fetch next from Oid_cur into @currentOID
	                                        while @@fetch_status=0
	                                        begin 
			                                        declare ODid_cur cursor
			                                        for
				                                        select ODID from OrderDetail 
				                                        where OID = @currentOID
				                                        for read only

			                                        open ODid_cur
			                                        fetch next from ODid_cur into @currentODID
			                                        while @@fetch_status=0
			                                        begin 
	           
	                                                   declare @vid int 
	                                                   --获取蔬菜编号
	                                                   select @vid=VID from OrderDetail 
	                                                   where ODID = @currentODID
	                                                   --获取UPID
	                                                   select @currentUPID = UPID from UnitPrice 
	                                                   where VID=@vid and DATEDIFF(DAY,CreateTime,GETDATE())=0
	                                                   --更新订单明细UPID
			                                           update OrderDetail set UPID = @currentUPID
			                                           where ODID = @currentODID
				
		                                            fetch next from ODid_cur into @currentODID
			                                        end
			                                        close ODid_cur
			                                        deallocate ODid_cur
                                                    --更新订单状态 
		                                            update Orders set OrderState=1 where OID=@currentOID

   		                                            fetch next from Oid_cur into @currentOID
                                            end
                                            --关闭游标Oid_cur
	                                        close Oid_cur
	                                        --删除游标Oid_cur
	                                        deallocate Oid_cur  ");
            return strbd.ToString();// dao.ExecuteNoQurey(strbd.ToString(), new Dictionary<string, object>());
        }


        #endregion



    }
}
