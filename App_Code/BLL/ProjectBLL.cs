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

    PictureDAL picd = new PictureDAL();
    UsersDAL ud = new UsersDAL();
    UserInfoDAL uid = new UserInfoDAL();
    StatusDAL stausd = new StatusDAL();
    Common common = new Common();


    Project_status pstatus;

    public ProjectBLL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region ### 项目显示
    #region ### 个人项目查看

    // 根据项目ID查找项目权限*
    // 根据个人ID查找项目
    public string ProjectPerson(int id,string ProType)
    {
        string Text = "";
        UserInfo userinfo = uid.Get_UserInfoByUserId(id);
        string pic = "../images/6464.jpg";
        if (userinfo == null) return Text;
        if (!common.CheckUser(id)) return Text;
        try
        {
            List<Project_content> lstProject = contentD.Get_Project_content(id, ProType);
            if (lstProject.Count < 0) { return Text; }
            foreach (Project_content content1 in contentD.Get_Project_content(id))
            {
                pstatus = statusD.Get_Project_statusByProId(content1.id);
                if (pstatus == null) continue;
                if (pstatus.project_status1.Equals("未审核") || pstatus.project_status1.Equals("禁止发布")) { continue; }
                Text = string.Format("<div class='media'><a href = '#' class='pull-left'><img alt = 'Bootstrap Media Another Preview' src='{0}' class='media-object'></a>" +
                            "<div class='media-body'> <h4 class='media-heading'> 项目：{1}    状态：{3}</h4>{2}</div></div></div></div>"
                    , pic, content1.title, content1.summary, pstatus.project_status1);
            }
            
            return Text;
        }
        catch (Exception ex)
        {
            return string.Format("错误:{0}", ex);
        }
    }
    #endregion

    #region ### 已发布并通过审核的项目概述
    // 已发布并通过审核的项目(首页)
    public string Project_Display()
    {
        try
        {
            string text = "";
            List<Project_content> lstProject = contentD.Get_Project("");
            if (lstProject == null) { return text; }
            foreach (Project_content content1 in lstProject)
            {
                pstatus = statusD.Get_Project_statusByProId(content1.id);
                if (pstatus == null) continue;
                if (pstatus.project_status1.Equals("未审核") || pstatus.project_status1.Equals("禁止发布")) { continue; }
                text = string.Format("<div class='col-md-4'><div class='thumbnail'><img src = '{2}' />" +
                    "<div class='caption'><h3>{0}</h3><p>{1}</p><p><a class='btn btn-primary' href='#'>参与</a> <a class='btn' href='#'>更多</a></p></div></div></div>"
                    ,content1.title, content1.summary, content1.files.Split(',').First());
            }
            return text;
        }
        catch (Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }    
    
    // 所有项目(管理)
    public string Project_Manage(int id,string status)
    {
        if (!common.Check(id)) { }
        UserInfo userinfo = uid.Get_UserInfoByUserId(id);
        string pic = "../images/6464.jpg";
        string Text = "";
        if (userinfo == null) return Text;
        try
        {
            List<Project_content> lstProject = contentD.Get_Project(status);
            if (lstProject == null) { return Text; }
            foreach (Project_content content1 in lstProject)
            {
                pstatus = statusD.Get_Project_statusByProId(content1.id);
                //if (pstatus == null) continue;
                Text = string.Format("<div class='media'><a href = '#' class='pull-left'><img alt = 'Bootstrap Media Preview' src='{0}' class='media-object'></a><div class='media-body'><h4 class='media-heading'>" +
                            "用户:{1}</h4> 项目数：{2}  状态：{3}<div class='media'><a href = '#' class='pull-left'><img alt = 'Bootstrap Media Another Preview' src='{4}' class='media-object'></a>" +
                            "<div class='media-body'> <h4 class='media-heading'> 项目{5}</h4>{6}</div></div></div></div>"
                    , pic, userinfo.username, lstProject.Count, pstatus.project_status1, pic, content1.title, content1.summary);
            }
            return Text;
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
    // 已发布并通过审核的项目内容*
    public string Project_Verify(int id)
    {
        if (!common.Check(id)) { }
        try
        {
            string text = "";
            List<Project_content> lstProject = contentD.Get_Project("");
            if (lstProject == null) { return text; }
            foreach (Project_content content1 in lstProject)
            {
                pstatus = statusD.Get_Project_statusByProId(content1.id);
                if (pstatus == null) continue;
                if (pstatus.project_status1.Equals("未审核") || pstatus.project_status1.Equals("禁止发布")) { continue; }
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

    #region ### 项目发布
    //项目发布*
    public string Project_Publish(int UserID)
    {
        try
        {
            //Users user = ud.Get_UsersById(UserID);
            Status status = stausd.Get_StatusByUserId(UserID);
            if (status == null) { return "NOTALLOW"; }
            if (status.status_name.Equals("游客")) { return "NOTALLOW"; }//游客不允许发布
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
    //根据项目ID查找项目*
    //查看权限
    //执行撤回
    public string Project_Back(int id)
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

    #region 项目类别（sort）

    //设置项目类别*
    public string Project_Type(int id)
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
    //设置项目类别显示*
    public string Project_Type_Show(int id)
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

    //支持（用户名，金额，时间）
    //匿名支持（金额，时间）

    //项目排序

}