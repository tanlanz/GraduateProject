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
    public class StatusDAL
    {
        public StatusDAL()
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
            Status StatusIns      一个Status实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_Status 插入一个Status对象
        public bool Insert_Status(Status StatusIns)
        {
            try
            {
                db.Status.InsertOnSubmit(StatusIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_Status exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Status对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_StatusById  依据ID删除一个Status对象
        public bool Detele_StatusById(int id)
        {
            try
            {
                db.Status.DeleteOnSubmit(Get_StatusById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_StatusById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            Status StatusIns             一个Status实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_Status  更新一个Status对象
        public bool Update_Status(Status StatusIns)
        {
            try
            {
                Status a = db.Status.First(t => t.id == StatusIns.id);
                a.user_id = StatusIns.user_id;
                a.status_name = StatusIns.status_name;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_Status exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Status对象唯一识别码         
        ** 输出参数：
            Status               一个Status实例
        ******************************/
        #region ### Get_StatusById  依据id获取一个Status对象
        public Status Get_StatusById(int id)
        {
            try
            {
                return db.Status.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_StatusById exception caught." + e);
                return null;
            }
        }
        #endregion

    }
}