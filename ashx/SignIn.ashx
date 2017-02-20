<%@ WebHandler Language="C#" Class="SignIn" %>

using System;
using System.Web;
using BLL;

public class SignIn : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string userName = context.Request.Params["UserName"].ToString();
        string Password = context.Request.Params["Password"].ToString();
        string Text = new UserBLL().Login(userName, Password);
        if (Text == "SUCCESSLOGIN")
        {
            context.Session["ACCOUNT"] = userName;//context.Session.Remove("ACCOUNT");//登出
        }
        context.Response.Write(Text);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}