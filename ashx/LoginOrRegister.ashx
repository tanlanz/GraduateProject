<%@ WebHandler Language="C#" Class="LoginOrRegister" %>

using System;
using System.Web;
using BLL;

public class LoginOrRegister : IHttpHandler, System.Web.SessionState.IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string userName,Password;
        string type2 = context.Request.Params["type2"].ToString();
        switch (type2)
        {
            case "":return;
            case "SIGNIN":
                userName = context.Request.Params["UserName"].ToString();
                Password = context.Request.Params["Password"].ToString();
                string Text = new UserBLL().Login(userName, Password);
                if (Text.Equals("SUCCESSLOGIN"))
                {
                    context.Session["ACCOUNT"] = userName;//context.Session.Remove("ACCOUNT");//登出
                }
                context.Response.Write(Text);break;
            case "SIGNUP":
                userName = context.Request.Params["UserName"].ToString();
                string Email = context.Request.Params["Email"].ToString();
                string PhoneNumber = context.Request.Params["PhoneNumber"].ToString();
                string ConfirmPassword = context.Request.Params["ConfirmPassword"].ToString();
                Password = context.Request.Params["Password"].ToString();
                if(!Password.Equals(ConfirmPassword)) context.Response.Write("PWD_MISSMATCH");
                context.Response.Write(new UserBLL().Register(userName, Password, Email, PhoneNumber));
                break;
            default:context.Response.Write(""); break;
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}