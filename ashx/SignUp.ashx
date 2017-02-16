<%@ WebHandler Language="C#" Class="SignUp" %>

using System;
using System.Web;
using BLL;

public class SignUp : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string userName = context.Request.Params["UserName"].ToString();
        string Email = context.Request.Params["Email"].ToString();
        string PhoneNumber = context.Request.Params["PhoneNumber"].ToString();
        string ConfirmPassword = context.Request.Params["ConfirmPassword"].ToString();                                                          /*PhoneNumber = $(*/
        string Password = context.Request.Params["Password"].ToString();
        if(!Password.Equals(ConfirmPassword)) context.Response.Write("PWD_MISSMATCH");
        context.Response.Write(new UserBLL().Register(userName,Password,Email,PhoneNumber));
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}