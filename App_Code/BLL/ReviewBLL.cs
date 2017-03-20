using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// ReviewBLL 的摘要说明
/// </summary>
public class ReviewBLL
{
    Project_contentDAL contentD = new Project_contentDAL();
    Project_fundsDAL fundsD = new Project_fundsDAL();
    Project_joinDAL joinD = new Project_joinDAL();
    Project_reviewDAL reviewD = new Project_reviewDAL();
    Project_sortDAL sortD = new Project_sortDAL();
    Project_statusDAL statusD = new Project_statusDAL();
    UserInfoDAL uid = new UserInfoDAL();
    StatusDAL stausd = new StatusDAL();

    public ReviewBLL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    //查看评论（评论的显示权限）
    public string ReviewLoad()
    {
        string Text = "";
        try
        {
            return Text;
        }
        catch (Exception ex)
        {
            return string.Format("错误:{0}",ex);
        }
    }
    //评论管理（管理评论的权限）
    public string ReviewDele()
    {
        string Text = "";
        try
        {
            return Text;
        }
        catch (Exception ex)
        {
            return string.Format("错误:{0}", ex);
        }
    }
    //隐藏评论
    public string ReviewHide()
    {
        string Text = "";
        try
        {
            return Text;
        }
        catch (Exception ex)
        {
            return string.Format("错误:{0}", ex);
        }
    }
    //添加评论
    public string ReviewAdd()
    {
        string Text = "";
        try
        {
            return Text;
        }
        catch (Exception ex)
        {
            return string.Format("错误:{0}", ex);
        }
    }
}