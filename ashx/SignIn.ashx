<%@ WebHandler Language="C#" Class="SignIn" %>

using System;
using System.Web;
using BLL;

public class SignIn : IHttpHandler {
            
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string userName = context.Request.Params["UserName"].ToString();
        string Password = context.Request.Params["Password"].ToString();
        context.Response.Write(new UserBLL().Login(userName,Password));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}