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
    public class Project_reviewDAL
    {
        public Project_reviewDAL()
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
            Project_review Project_reviewIns      一个Project_review实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_Project_review 插入一个Project_review对象
        public bool Insert_Project_review(Project_review Project_reviewIns)
        {
            try
            {
                db.Project_review.InsertOnSubmit(Project_reviewIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_Project_review exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_review对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_Project_reviewById  依据ID删除一个Project_review对象
        public bool Detele_Project_reviewById(int id)
        {
            try
            {
                db.Project_review.DeleteOnSubmit(Get_Project_reviewById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_Project_reviewById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            Project_review Project_reviewIns             一个Project_review实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_Project_review  更新一个Project_review对象
        public bool Update_Project_review(Project_review Project_reviewIns)
        {
            try
            {
                Project_review a = db.Project_review.First(t => t.id == Project_reviewIns.id);
                a.project_id = Project_reviewIns.project_id;
                a.user_id = Project_reviewIns.user_id;
                a.time = Project_reviewIns.time;
                a.content = Project_reviewIns.content;
                a.status = Project_reviewIns.status;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_Project_review exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Project_review对象唯一识别码         
        ** 输出参数：
            Project_review               一个Project_review实例
        ******************************/
        #region ### Get_Project_reviewById  依据id获取一个Project_review对象
        public Project_review Get_Project_reviewById(int id)
        {
            try
            {
                return db.Project_review.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_Project_reviewById exception caught." + e);
                return null;
            }
        }
        #endregion
    }
}