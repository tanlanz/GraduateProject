using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// ProjectBLL 的摘要说明
/// </summary>
public class ProjectBLL
{
    Project_contentDAL contentD = new Project_contentDAL();
    Project_fundsDAL fundsD = new Project_fundsDAL();
    Project_joinDAL joinD = new Project_joinDAL();
    Project_reviewDAL reviewD = new Project_reviewDAL();
    Project_sortDAL sortD = new Project_sortDAL();
    Project_statusDAL statusD = new Project_statusDAL();
    //UsersDAL ud = new UsersDAL();
    UserInfoDAL uid = new UserInfoDAL();
    StatusDAL stausd = new StatusDAL();

    public ProjectBLL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    
    //检查权限

    #region ### 项目显示
    #region ### 个人项目查看
    //根据个人ID查找项目
    //根据项目ID查找项目权限
    #endregion

    #region ### 已发布并通过审核的项目概述
    public string Project_Display()
    {
        try
        {
            string text = "";
            if (contentD.Get_Project() == null) { return text; }
            foreach (Project_content content1 in contentD.Get_Project())
            {
                if (content1.Project_status.Equals("未审核") || content1.Project_status.Equals("禁止发布")) { continue; }
                text = string.Format("< div class='col-md-4'><div class='thumbnail'><img src = '{2}' /> '>" +
                    "<div class='caption'><h3>{0}</h3><p>{1}</p><p><a class='btn btn-primary' href='#'>参与</a> <a class='btn' href='#'>更多</a></p></div></div></div>"
                    , content1.title, content1.summary, content1.files.Split(',').First());
            }
            return text;
        }
        catch (Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }
        #endregion

    #endregion

    #region ### 项目审核
    //根据项目ID查找项目权限
    //修改权限
    #endregion

    #region ### 项目发布
    public string Project_Publish(int UserID)
    {
        try
        {
            //Users user = ud.Get_UsersById(UserID);
            Status status = stausd.Get_StatusByUserId(UserID);
            if (status.status_name == "游客") { return "NOTALLOW"; }//游客不允许发布
            Project_content project = new Project_content();
            project.content = "";
            project.files = "";
            project.projectname = "";
            project.time_start = DateTime.Parse("");
            project.time_end = DateTime.Parse("");
            project.title = "";
            project.user_id = UserID;
            project.summary = "";
            project.sort = "";
            //设置项目为未审核

            if (!contentD.Insert_Project_content(project)) { return "ERROR"; }//发布之后还没有审核

            return "";
        }
        catch(Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }
    #endregion

    #region ### 项目撤回
    //根据项目ID查找项目
    //查看权限
    //执行撤回
    #endregion

    //设置项目类别
    #region 项目类别
    #endregion
}