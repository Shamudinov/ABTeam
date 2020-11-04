// #region Getting
$.ajax(/*Get user*/{
    type: 'Get',
    url: "/Api/Account/GetCurrentUser",
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    success: function (result) {
        $("#header-fullname").html(result.name + " " + result.surname);
    }
});
// #endregion

$("#header-logout").click(function () {
    window.location.replace('logout');
});
$("#class-distribution").click(function () {
    window.location.replace("/distribution");
});
$("#user-list").click(function () {
    window.location.replace("/userlist");
});
$(".header-logo").click(function () {
    window.location.replace("/");
});
$("#messages").click(function () {
    window.location.replace("/messages");
});