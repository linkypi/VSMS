using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VSMS.Models.DAL;
using VSMS.Models.Model;

namespace VSMS.Models.BLL
{
   public  class CategoryService
    {
       CategoryDao cdao = new CategoryDao();

       /// <summary>
       /// 添加蔬菜类别
       /// </summary>
       /// <param name="name">类别名称</param>
       /// <returns> 添加成功返回当前类别编号  添加失败返回-1</returns>
       public int Add(Category cat)
       {
           //添加父类
           if (cat.PCID == 0)
           {  
              return  cdao.AddParent(cat.CName);
           }
           //添加子类
           return cdao.AddChild(cat);
       }

       /// <summary>
       /// 验证类别名称是否存在
       /// </summary>
       /// <param name="cname"></param>
       /// <returns></returns>
       public bool ExistOrNot(string cname)
       {
           return cdao.Exists(cname);
       }

       /// <summary>
       /// 根据类别编号获取类别信息
       /// </summary>
       /// <param name="cid"></param>
       /// <returns></returns>
       public Category GetModelByCID(int cid)
       {
          return  cdao.GetModel(cid);
       }

       /// <summary>
       /// 删除类别
       /// </summary>
       /// <param name="cid"></param>
       /// <returns></returns>
       public bool DelCategory(int cid)
       {
           return cdao.Delete(cid);
       }

       /// <summary>
       /// 更新类别
       /// </summary>
       /// <param name="ct"></param>
       /// <returns></returns>
       public bool Update(Category ct)
       {
           return cdao.Update(ct);
       }

       /// <summary>
       /// 获取所有类别
       /// </summary>
       /// <returns></returns>
       public List<Category> GetAllCategories()
       {
           return cdao.GetAllList();
       }

       /// <summary>
       /// 获取所有类别    类别中包含所有子类别
       /// </summary>
       /// <returns></returns>
       public List<Category> GetModels()
       {
           List<Category> list = cdao.GetModels();
           if (list == null) return null;
           Category currentCg = list[0];
           List<Category> retList = new List<Category>();
           Category parent = null;
           Category child = null;
           int index = 0;

           foreach (Category cg in list)
           {
               index++;
               if (cg.CID == cg.PCID)
               {
                   if (index == 1)
                   {
                       parent = new Category();
                       parent = cg; continue;
                   }  
                   retList.Add(parent);
                   currentCg = cg;
                   parent = new Category();
                   parent = cg; continue;
               }
               if (cg.PCID == currentCg.PCID)
               {
                   child = new Category();
                   child = cg;
                   parent.Children.Add(child);
               }
           }
           retList.Add(parent);
           return retList;
       }

       /// <summary>
       /// 获取所有父类
       /// </summary>
       /// <returns></returns>
       public List<Category> GetAllParents()
       {
           return cdao.GetParents();
       }
    }
}
