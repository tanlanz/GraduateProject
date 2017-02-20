<%@ WebHandler Language="C#" Class="SummaryLoad" %>

using System;
using System.Web;
using BLL;

public class SummaryLoad : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string type1 = context.Request.Params["type1"].ToString();
        if (true) {; }//项目分类
        switch (type1)
        {
            case "":;break;
            case "INDEX":
                context.Response.Write(new ProjectBLL().Project_Display());break;
            default:context.Response.Write(""); break;
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}