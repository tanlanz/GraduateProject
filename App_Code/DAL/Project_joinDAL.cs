using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DAL 的摘要说明
/// </summary>
/// 
namespace DAL
{
    public class Project_joinDAL
    {
        public Project_joinDAL()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /*  数据库连接  */
        private DataClassesDataContext db = new DataClassesDataContext();

        /******************************
        ** 作者：zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            Project_join Project_joinIns      一个Project_join实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_Project_join 插入一个Project_join对象
        public bool Insert_Project_join(Project_join Project_joinIns)
        {
            try
            {
                db.Project_join.InsertOnSubmit(Project_joinIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_Project_join exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_join对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_Project_joinById  依据ID删除一个Project_join对象
        public bool Detele_Project_joinById(int id)
        {
            try
            {
                db.Project_join.DeleteOnSubmit(Get_Project_joinById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_Project_joinById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            Project_join Project_joinIns             一个Project_join实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_Project_join  更新一个Project_join对象
        public bool Update_Project_join(Project_join Project_joinIns)
        {
            try
            {
                Project_join a = db.Project_join.First(t => t.id == Project_joinIns.id);
                a.project_id = Project_joinIns.project_id;
                a.user_id = Project_joinIns.user_id;
                a.funds = Project_joinIns.funds;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_Project_join exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_join对象唯一识别码         
        ** 输出参数：
            Project_join               一个Project_join实例
        ******************************/
        #region ### Get_Project_joinById  依据id获取一个Project_join对象
        public Project_join Get_Project_joinById(int id)
        {
            try
            {
                return db.Project_join.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_Project_joinById exception caught." + e);
                return null;
            }
        }
        #endregion

        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            string ip              一个Project_join对象d的ip        
        ** 输出参数：
            Project_join               一个Project_join实例
        ******************************/
        #region ### Get_Project_join 依据id获取一个Project_join对象
        public List<Project_join> Get_Project_join(int state)
        {
            try
            {
                return db.Project_join.Where(a => a.user_id == state).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("{4} Get_Project_join exception caught." + e);
                return null;
            }
        }
        #endregion
    }
}