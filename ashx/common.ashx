<%@ WebHandler Language="C#" Class="common" %>

using System;
using System.Web;
using BLL;

public class common : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
       /******************************
       ** 作者：zhu 
       ** 创建时间：2016年10月10日
       ** 输入参数：
           ***                  ***        
       ** 输出参数：
           ***                  ***
       ******************************/
        //context.Response.Write("Hello World");
         
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}