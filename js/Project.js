$(document).ready(function () {
});

//首页概述项目加载
function Load() {
    data = {
        type1: "INDEX"
    }
    LoadASHX(data, "#ProjectSummary", "../ashx/SummaryLoad.ashx");
}

//个人概述项目的加载
function PersonLoad() {
    data = {
        type1:"Person"
    }
    LoadASHX(data, "#ProjectSumMy","../ashx/Project.ashx");
}

//管理员概述项目加载
function ManageLoad() {
    data = {
        type1:"Manage"
    }
    LoadASHX(data, "#ProjectManage", "../ashx/Project.ashx");
}

//加载修改
function LoadASHX(data,tag,url) {
    $.ajax({
        url: url,
        data: data,//项目分类
        type: "Post",
        datatype: "Html",
        success: function (data, status) {
            if (data == "") { alert(data);return; }
            //alert(data);
            $(tag).html(data);
        }
    });
}



//发布项目保存
function SavePublish() {
    alert("");
    //switch (data) {
    //    case "": return;
    //    case "NOTALLOW": alert("你没有权限继续操作"); break;
    //    default: alert("ERROR"); break;
    //}
    //var UserName = $("#UserName").val();
    //var PhoneNumber = $("#PhoneNumber").val();
    //var Email = $("#Email").val();
    //var Password = $("#Password").val();
    //var ConfirmPassword = $("#ConfirmPassword").val();
    //if (!UserName || !PhoneNumber || !Email || !Password || !ConfirmPassword) {
    //    alert("所有项均不能为空"); return false;
    //}
    //if (Password != ConfirmPassword) { alert("密码不一致!"); return false; }
    //data1 = {
    //    type2: "SIGNUP",
    //    UserName: UserName,
    //    PhoneNumber: PhoneNumber,
    //    Email: Email,
    //    Password: Password,
    //    ConfirmPassword: ConfirmPassword
    //}
    //alert("");
    //$.ajax({
    //    url: "../ashx/LoginOrRegister.ashx",
    //    data: data1,
    //    type: "Post",
    //    datatype: "Html",
    //    success: function (data, status) {
    //        switch (data) {
    //            case "PWD_MISSMATCH": alert("密码不一致!"); break;
    //            case "RENAME": alert("用户名已被注册!"); break;
    //            case "REEMAIL": alert("邮箱已注册过!"); break;
    //            case "Success": alert("成功注册，请登录您的邮箱进行验证!"); window.location.href = "../sign_In.html"; break;
    //            default:
    //                alert(data);
    //        }
    //    }
    //});
}
