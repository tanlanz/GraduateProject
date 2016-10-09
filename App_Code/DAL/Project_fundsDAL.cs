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
    public class Project_fundsDAL
    {
        public Project_fundsDAL()
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
            Project_funds Project_fundsIns      一个Project_funds实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_Project_funds 插入一个Project_funds对象
        public bool Insert_Project_funds(Project_funds Project_fundsIns)
        {
            try
            {
                db.Project_funds.InsertOnSubmit(Project_fundsIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_Project_funds exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_funds对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_Project_fundsById  依据ID删除一个Project_funds对象
        public bool Detele_Project_fundsById(int id)
        {
            try
            {
                db.Project_funds.DeleteOnSubmit(Get_Project_fundsById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_Project_fundsById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            Project_funds Project_fundsIns             一个Project_funds实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_Project_funds  更新一个Project_funds对象
        public bool Update_Project_funds(Project_funds Project_fundsIns)
        {
            try
            {
                Project_funds a = db.Project_funds.First(t => t.id == Project_fundsIns.id);
                a.project_id = Project_fundsIns.project_id;
                a.funds_limit = Project_fundsIns.funds_limit;
                a.funds_now = Project_fundsIns.funds_now;
                a.funds_begin = Project_fundsIns.funds_begin;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_Project_funds exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_funds对象唯一识别码         
        ** 输出参数：
            Project_funds               一个Project_funds实例
        ******************************/
        #region ### Get_Project_fundsById  依据id获取一个Project_funds对象
        public Project_funds Get_Project_fundsById(int id)
        {
            try
            {
                return db.Project_funds.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_Project_fundsById exception caught." + e);
                return null;
            }
        }
        #endregion

        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            string ip              一个Project_funds对象d的ip        
        ** 输出参数：
            Project_funds               一个Project_funds实例
        ******************************/
        #region ### Get_Project_funds 依据id获取一个Project_funds对象
        public List<Project_funds> Get_Project_funds(int state)
        {
            try
            {
                return db.Project_funds.Where(a => a.project_id == state).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("{4} Get_Project_funds exception caught." + e);
                return null;
            }
        }
        #endregion
    }
}