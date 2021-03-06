﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// UserInfoBLL 的摘要说明
/// </summary>
public class UserInfoBLL
{
    UserInfoDAL uinfoD = new UserInfoDAL();
    UserInfo uinfo = new UserInfo();
    StatusDAL statusD = new StatusDAL();
    Status status = new Status();
    UsersDAL userD = new UsersDAL();
    Users user = new Users();
    Common common = new Common();

    public UserInfoBLL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    #region ### 

    #endregion


    #region ### 显示已有用户
    //【1】
    //显示所有用户
    public string ShowAllUser()
    {
        try
        {
            string Text = "";
            List<UserInfo> lstUinfo = uinfoD.Get_UserInfos();
            if (lstUinfo == null) { return Text; }
            foreach (UserInfo info in lstUinfo)
            {
                status = statusD.Get_StatusByUserId(info.user_id);
                user = userD.Get_UsersById(info.user_id);
                Text += string.Format("<tr class=off onMouseOut=\"this.className = \'Off\'\" onMouseOver=\"this.className = \'up\'\" ondblclick=\"SaveChange({0})\">" +
                                    "<td>{0}</td><td><input type='text' value='{1}' id='username{0}' />" +
                                    "</td><td><input type = 'text' value = '{3}' id='status{0}' />" +
                                    "</td><td><input type = 'text' value = '{5}' id='time{0}' />" +
                                    "</td><td><input type = 'text' value = '{2}' id='email{0}' />" +
                                    "</td><td><input type = 'text' value = '{4}' id='create{0}' /></td></tr>"
                    , info.id, info.username, info.email, status.status_name, user.create_time, user.time);
            }
            return Text;
        }
        catch(Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }
    #endregion

    #region ### 管理用户（权限，删除）
    //【1】
    //根据ID查找用户进行修改*
    //根据ID修改*
    public string UserManage_Delete(int id)
    {
        if (!common.Check(id)) { }
        try
        {
            string text = "";

            return text;
        }
        catch (Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }

    public string UserManage_Type(int id)
    {
        if (!common.Check(id)) { }
        try
        {
            string text = "";

            return text;
        }
        catch (Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }
    #endregion

    #region ### 个人信息显示
    //根据ID显示信息*
    public string InfoShow(int id)
    {
        if (!common.Check(id)) { }
        try
        {
            string text = "";

            return text;
        }
        catch (Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }
    #endregion

    #region ### 管理显示用户信息修改保存
    /// <summary>
    /// 根据信息更新数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="username"></param>
    /// <param name="email"></param>
    /// <param name="status1"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public string SaveUser(int id,string username,string email,string status1,string time)
    {
        try
        {
            string Text = "ERROR";
            uinfo = uinfoD.Get_UserInfoById(id);
            status = statusD.Get_StatusByUserId(id);
            user = userD.Get_UsersById(uinfo.id);

            user.time = DateTime.Parse(time);
            uinfo.email = email;
            uinfo.username = username;
            status.status_name = status1;
            if (uinfoD.Update_UserInfo(uinfo) && userD.Update_Users(user) && statusD.Update_Status(status))
            {
                Text = "SUCC";
            }
            return Text;
        }
        catch (Exception ex)
        {
            return string.Format("错误{0}",ex);
        }
        
    }
    #endregion

    //图片保存
    //（照片、项目图片）
}