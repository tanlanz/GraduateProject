/* 
*通用脚本 
    alert("test");
*/

//$.ajax({
//    url: "",
//    type: "Post",
//    dataType: "html",
//    success: function (data, status) {
//        alert("");
//    }
//});

//$("#").click(function () {
//});

//var data = {
//    phone: $("#bind-phone").val(),
//    checkcode: $("#verificate").val()
//}

$(document).ready(function () {
    //alert("");
});

//注册
function SignUp() {
    var UserName = $("#UserName").val();
    var PhoneNumber = $("#PhoneNumber").val();
    var Email = $("#Email").val();
    var Password = $("#Password").val();
    var ConfirmPassword = $("#ConfirmPassword").val();
    //alert(UserName + PhoneNumber + Email + Password + ConfirmPassword);
    if (UserName == "" || PhoneNumber == "" || Email == "" || Password == "" || ConfirmPassword=="") {
        alert("所有项均不能为空"); return false;}
    reg = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/gi;
    if (!reg.test(Email)) {alert("非法的电子邮件");return false;}
    if (Password != ConfirmPassword) { alert("密码不一致!"); return false; }    
    data1 = {
        UserName: UserName,
        PhoneNumber: PhoneNumber,
        Email: Email,
        Password: Password,
        ConfirmPassword: ConfirmPassword
    }
    $.ajax({
        url: "../ashx/SignUp.ashx",
        data: data1,
        type:"Post",
        datatype:"Html",    
        success: function (data, status) {
            switch (data) {
                case "PWD_MISSMATCH":alert("密码不一致!"); break;
                case "USERNAME": alert("用户名已被注册!"); break;
                case "": break;
                default:
                    alert("成功注册，请登录您的邮箱进行验证!");
                    window.location.href("sign_In.html");
            }
        }
    });
}