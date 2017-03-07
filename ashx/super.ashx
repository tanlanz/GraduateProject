<%@ WebHandler Language="C#" Class="super" %>

using System;
using System.Web;

public class super : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        UserInfoBLL userbll = new UserInfoBLL();
        if (context.Request.Params.Count != 0)
        {
            string typeSuper = context.Request.Params["typeSuper"].ToString();
            switch (typeSuper)
            {
                case "": return;
                case "USERLOAD":
                    context.Response.Write(userbll.ShowAllUser()); break;
                case "USERSAVE":
                    int id = int.Parse(context.Request.Params["id"]);
                    string username = context.Request.Params["username"];
                    string Email = context.Request.Params["Email"];
                    string status = context.Request.Params["status"];
                    string time = context.Request.Params["time"];
                    context.Response.Write(userbll.SaveUser(id, username, Email, status, time));
                    break;
                default: context.Response.Write("1"); break;
            }
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}