function AllUserLoad() {
    data1 = {typeSuper: "USERLOAD"}
    $.ajax({
        url: "../ashx/super.ashx",
        data: data1,
        type: "Post",
        datatype: "Html",
        success: function (data, status) {
            //alert(data);
            if (data == null && data == "") return;
            if (!data)return;
            if (data == "ERROR")return;
            $("#ListUser").html(data);
        }
    });
}

function SaveChange(id) {
    if (window.confirm('是否保存？') ? false : true) return;
    var username = $("#username" + id).val();
    var Email = $("#email" + id).val();
    var status = $("#status" + id).val();
    var time = $("#time" + id).val();    
    if (!username || !Email || !status) {  return; }
    data2 = {
        typeSuper: "USERSAVE",
        id: id,
        username: username,
        Email: Email,
        status: status,
        time: time
    }
    $.ajax({
        url: "../ashx/Super.ashx",
        data: data2,
        type: "Post",
        datatype: "Html",
        success: function (data, status) {
            alert(data);
            if (!data) return;
            if (data == "ERROR") return;
            if(data == "SUCC")
            window.location.href = "../manage/UserManage.html";
        }
    });
}