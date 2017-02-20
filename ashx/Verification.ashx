<%@ WebHandler Language="C#" Class="Verification" %>

using System;
using System.Web;
using BLL;

public class Verification : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //检查登陆状态
        if (context.Session["ACCOUNT"] == null){ context.Response.Write("NOLOGIN"); }
        context.Response.Write(new UserBLL().Check_Login(context.Session["ACCOUNT"].ToString()));
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}