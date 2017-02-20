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
    public class Project_contentDAL
    {
        public Project_contentDAL()
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
            Project_content Project_contentIns      一个Project_content实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_Project_content 插入一个Project_content对象
        public bool Insert_Project_content(Project_content Project_contentIns)
        {
            try
            {
                db.Project_content.InsertOnSubmit(Project_contentIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_Project_content exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_content对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_Project_contentById  依据ID删除一个Project_content对象
        public bool Detele_Project_contentById(int id)
        {
            try
            {
                db.Project_content.DeleteOnSubmit(Get_Project_contentById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_Project_contentById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            Project_content Project_contentIns             一个Project_content实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_Project_content  更新一个Project_content对象
        public bool Update_Project_content(Project_content Project_contentIns)
        {
            try
            {
                Project_content a = db.Project_content.First(t => t.id == Project_contentIns.id);
                a.user_id = Project_contentIns.user_id;
                a.projectname = Project_contentIns.projectname;
                a.time_start = Project_contentIns.time_start;
                a.time_end = Project_contentIns.time_end;
                a.title = Project_contentIns.title;
                a.content = Project_contentIns.content;
                a.sort = Project_contentIns.sort;
                a.files = Project_contentIns.files;
                a.summary = Project_contentIns.summary;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_Project_content exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_content对象唯一识别码         
        ** 输出参数：
            Project_content               一个Project_content实例
        ******************************/
        #region ### Get_Project_contentById  依据id获取一个Project_content对象
        public Project_content Get_Project_contentById(int id)
        {
            try
            {
                return db.Project_content.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_Project_contentById exception caught." + e);
                return null;
            }
        }
        #endregion

        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            string state              一个Project_content对象的state        
        ** 输出参数：
            Project_content               一个Project_content实例
        ******************************/
        #region ### Get_Project_content 依据id获取一个Project_content对象
        public List<Project_content> Get_Project_content(int state)
        {
            try
            {
                return db.Project_content.Where(a => a.user_id == state).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("{4} Get_Project_content exception caught." + e);
                return null;
            }
        }
        #endregion

        /******************************
        ** 作者：zhu
        ** 创建时间：2017年2月20日        
        ** 输出参数：
            Get_Project               Get_Project
        ******************************/
        #region ### Get_Project 依据id获取一个Project_content对象
        public List<Project_content> Get_Project()
        {
            try
            {
                return db.Project_content.OrderByDescending(a => a.id).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("{4} Get_Project exception caught." + e);
                return null;
            }
        }
        #endregion
    }
}