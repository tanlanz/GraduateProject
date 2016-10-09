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
    public class Project_statusDAL
    {
        public Project_statusDAL()
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
            Project_status Project_statusIns      一个Project_status实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_Project_status 插入一个Project_status对象
        public bool Insert_Project_status(Project_status Project_statusIns)
        {
            try
            {
                db.Project_status.InsertOnSubmit(Project_statusIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_Project_status exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_status对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_Project_statusById  依据ID删除一个Project_status对象
        public bool Detele_Project_statusById(int id)
        {
            try
            {
                db.Project_status.DeleteOnSubmit(Get_Project_statusById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_Project_statusById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            Project_status Project_statusIns             一个Project_status实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_Project_status  更新一个Project_status对象
        public bool Update_Project_status(Project_status Project_statusIns)
        {
            try
            {
                Project_status a = db.Project_status.First(t => t.id == Project_statusIns.id);
                a.project_id = Project_statusIns.project_id;
                a.content = Project_statusIns.content;
                a.project_status1 = Project_statusIns.project_status1;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_Project_status exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_status对象唯一识别码         
        ** 输出参数：
            Project_status               一个Project_status实例
        ******************************/
        #region ### Get_Project_statusById  依据id获取一个Project_status对象
        public Project_status Get_Project_statusById(int id)
        {
            try
            {
                return db.Project_status.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_Project_statusById exception caught." + e);
                return null;
            }
        }
        #endregion

    }
}