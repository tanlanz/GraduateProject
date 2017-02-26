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

    #region ### 项目显示
    #region ### 个人项目查看

    #endregion

    #region ### 已发布并通过审核的项目概述
    public string Project_Display()
    {
        string text = "";
        if (contentD.Get_Project() == null) { return text; }
        foreach(Project_content content1 in contentD.Get_Project())
        {
            /*text = "ProjectName = " + content1.projectname
                + "ProjectTitle" + content1.title
                + "ProjectFunds" + content1.Project_funds
                + "ProjectJoin" + content1.Project_join
                + "ProjectSummary" + content1.summary
                + "ProjectStart" + content1.time_start
                + "ProjectEnd" + content1.time_end
                + "ProjectFile" + content1.files //string[] roles = Model.Configuration.UserProfiles.UserRoleIDs.Split(',');
                + "ProjectContent" + content1.content
                + "ProjectReview" + content1.Project_review
                + "ProjectSort" + content1.Project_sort
                + "ProjectStatus" + content1.Project_status
                + "ProjectUser" + content1.Users;*/
            if (content1.Project_status.Equals("未审核") || content1.Project_status.Equals("禁止发布")) { continue; }
            text = string.Format("<li><a href='javascript:void(0);'><img src='{2}' /><div><h3>{0}</h3></div></a></li>"
                , content1.title,content1.summary,content1.files.Split(',').First());
        }
        return text;
    }
        #endregion

    #endregion

    #region ### 项目审核

    #endregion

    #region ### 项目发布
    public string Project_Publish(int UserID)
    {
        //Users user = ud.Get_UsersById(UserID);
        Status status = stausd.Get_StatusByUserId(UserID);
        if (status.status_name == "游客") { return "NOTALLOW"; }
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

        if (!contentD.Insert_Project_content(project)) { return "ERROR"; }

        return "";
    }
    #endregion

    #region ### 项目撤回

    #endregion
}