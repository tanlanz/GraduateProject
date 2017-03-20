<%@ WebHandler Language="C#" Class="Project" %>

using System;
using System.Web;
using BLL;

public class Project : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string TEXT = "";
        string type1 = context.Request.Params["type1"].ToString();
        int id = 2;
        switch (type1)
        {
            case "SavePublish":TEXT = new ProjectBLL().Project_Publish(id);break;
            case "Person":TEXT = new ProjectBLL().ProjectPerson(id,"");break;
            case "Manage": TEXT = new ProjectBLL().Project_Manage(id, "");break;
            default:;break;
        }
        context.Response.Write(TEXT);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}