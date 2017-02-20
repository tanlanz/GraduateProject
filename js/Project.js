$(document).ready(function () {
});

$("#ProjectSummary").click(function () {
    alert("");
    return;
    $("#ProjectSummary").html("<li><a href='javascript:void(0);'><img src='images/port.png' /><div><h3>Lorem ipsum</h3></div></a></li>");
});

function Load() {
    $.ajax({
        url: "../ashx/SummaryLoad.ashx",
        data: "",//项目分类
        type: "Post",
        datatype: "Html",
        success: function (data, status) {
            alert(data);
            if (data == "") { return;}
            $("#ProjectSummary").html(data);
        }
    });
}

//switch (data) {
//    case "": return;
//    case "NOTALLOW": alert("你没有权限继续操作"); break;
//    default: alert("ERROR"); break;
//}