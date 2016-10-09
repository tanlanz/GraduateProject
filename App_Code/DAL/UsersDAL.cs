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
    public class UsersDAL
    {
        public UsersDAL()
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
            Users UsersIns      一个Users实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_Users 插入一个Users对象
        public bool Insert_Users(Users UsersIns)
        {
            try
            {
                db.Users.InsertOnSubmit(UsersIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_Users exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Users对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_UsersById  依据ID删除一个Users对象
        public bool Detele_UsersById(int id)
        {
            try
            {
                db.Users.DeleteOnSubmit(Get_UsersById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_UsersById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            Users UsersIns             一个Users实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_Users  更新一个Users对象
        public bool Update_Users(Users UsersIns)
        {
            try
            {
                Users a = db.Users.First(t => t.id == UsersIns.id);
                a.password = UsersIns.password;
                a.create_time = UsersIns.create_time;
                a.time = UsersIns.time;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_Users exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Users对象唯一识别码         
        ** 输出参数：
            Users               一个Users实例
        ******************************/
        #region ### Get_UsersById  依据id获取一个Users对象
        public Users Get_UsersById(int id)
        {
            try
            {
                return db.Users.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_UsersById exception caught." + e);
                return null;
            }
        }
        #endregion
    }
}