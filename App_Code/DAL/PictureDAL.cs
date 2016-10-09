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
    public class PictureDAL
    {
        public PictureDAL()
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
            Picture PictureIns      一个Picture实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_Picture 插入一个Picture对象
        public bool Insert_Picture(Picture PictureIns)
        {
            try
            {
                db.Picture.InsertOnSubmit(PictureIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_Picture exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Picture对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_PictureById  依据ID删除一个Picture对象
        public bool Detele_PictureById(int id)
        {
            try
            {
                db.Picture.DeleteOnSubmit(Get_PictureById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_PictureById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            Picture PictureIns             一个Picture实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_Picture  更新一个Picture对象
        public bool Update_Picture(Picture PictureIns)
        {
            try
            {
                Picture a = db.Picture.First(t => t.id == PictureIns.id);
                a.pic_name = PictureIns.pic_name;
                a.pic_url = PictureIns.pic_url;
                a.pic_state = PictureIns.pic_state;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_Picture exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个Picture对象唯一识别码         
        ** 输出参数：
            Picture               一个Picture实例
        ******************************/
        #region ### Get_PictureById  依据id获取一个Picture对象
        public Picture Get_PictureById(int id)
        {
            try
            {
                return db.Picture.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_PictureById exception caught." + e);
                return null;
            }
        }
        #endregion

    }
}