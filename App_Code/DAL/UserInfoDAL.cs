﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DAL 的摘要说明
/// </summary>
/// 
namespace DAL
{
    public class UserInfoDAL
    {
        public UserInfoDAL()
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
            UserInfo UserInfoIns      一个UserInfo实例         
        ** 输出参数：
            bool                插入成功与否
        ******************************/
        #region ### Insert_UserInfo 插入一个UserInfo对象
        public bool Insert_UserInfo(UserInfo UserInfoIns)
        {
            try
            {
                db.UserInfo.InsertOnSubmit(UserInfoIns);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Insert_UserInfo exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者： zhu 
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个UserInfo对象唯一识别码         
        ** 输出参数：
            bool                删除成功与否
        ******************************/
        #region ### Detele_UserInfoById  依据ID删除一个UserInfo对象
        public bool Detele_UserInfoById(int id)
        {
            try
            {
                db.UserInfo.DeleteOnSubmit(Get_UserInfoById(id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} Detele_UserInfoById exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：  zhu
        ** 创建时间：  2016年10月9日
        ** 输入参数：
            UserInfo UserInfoIns             一个UserInfo实例         
        ** 输出参数：
            bool                       更新成功与否
        ******************************/
        #region ### Update_UserInfo  更新一个UserInfo对象
        public bool Update_UserInfo(UserInfo UserInfoIns)
        {
            try
            {
                UserInfo a = db.UserInfo.First(t => t.id == UserInfoIns.id);
                a.user_id = UserInfoIns.user_id;
                a.img_id = UserInfoIns.img_id;
                a.username = UserInfoIns.username;
                a.name = UserInfoIns.name;
                a.email = UserInfoIns.email;
                a.address = UserInfoIns.address;
                a.phone = UserInfoIns.phone;
                a.ID_Card = UserInfoIns.ID_Card;
                a.funds = UserInfoIns.funds;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{2} Update_UserInfo exception caught." + e);
                return false;
            }
        }
        #endregion


        /******************************
        ** 作者：zhu
        ** 创建时间：2016年10月9日
        ** 输入参数：
            int id              一个UserInfo对象唯一识别码         
        ** 输出参数：
            UserInfo               一个UserInfo实例
        ******************************/
        #region ### Get_UserInfoById  依据id获取一个UserInfo对象
        public UserInfo Get_UserInfoById(int id)
        {
            try
            {
                return db.UserInfo.First(a => a.id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_UserInfoById exception caught." + e);
                return null;
            }
        }
        #endregion

        /******************************
        ** 作者：zhu
        ** 创建时间：2017年2月15日
        ** 最后维护时间：2017年2月15日
        ** 输出参数：
            List<UserInfo>               一组UserInfo实例
        ******************************/
        #region ### Get_UserInfos  获取所有UserInfo对象
        public List<UserInfo> Get_UserInfos()
        {
            try
            {
                return db.UserInfo.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_UserInfos exception caught." + e);
                return null;
            }
        }
        #endregion

        /******************************
        ** 作者：zhu
        ** 创建时间：2017年2月15日
        ** 最后维护时间：2017年2月15日
        ** 输出参数：
            UserInfo              一个UserInfo实例
        ******************************/
        #region ### Get_UserInfoByUserName  获取UserInfo对象
        public UserInfo Get_UserInfoByUserName(string Name)
        {
            try
            {
                return db.UserInfo.First(a => a.username.Equals(Name));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_UserInfoByUserName exception caught." + e);
                return null;
            }
        }
        #endregion

        /******************************
        ** 作者：zhu
        ** 创建时间：2017年2月19日
        ** 最后维护时间：2017年2月19日
        ** 输出参数：
            UserInfo              一个UserInfo实例
        ******************************/
        #region ### Get_UserInfoByUserEmail  获取UserInfo对象
        public UserInfo Get_UserInfoByUserEmail(string Email)
        {
            try
            {
                return db.UserInfo.First(a => a.email.Equals(Email));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_UserInfoByUserEmail exception caught." + e);
                return null;
            }
        }
        #endregion

        /******************************
        ** 作者：zhu
        ** 创建时间：2017年3月20日
        ** 输入参数：
            int id              一个UserInfo对象唯一识别码
        ** 输出参数：
            UserInfo 一个UserInfo实例
        ******************************/
        #region ### Get_UserInfoByUserId  依据id获取一个UserInfo对象
        public UserInfo Get_UserInfoByUserId(int Userid)
        {
            try
            {
                return db.UserInfo.First(a => a.user_id.Equals(Userid));
            }
            catch (Exception e)
            {
                Console.WriteLine("{3} Get_UserInfoByUserId exception caught." + e);
                return null;
            }
        }
        #endregion
    }
}