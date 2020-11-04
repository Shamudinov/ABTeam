var grade;
var template;
// #region Getting

$.ajax(/*Get Template*/{
    type: 'Get',
    url: "/Api/Mail/Templates",
    data: "lang=" + sessionStorage.getItem("lang"),
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    success: function (result) {
        template = result;
        for (var i = 0; i < result.length; i++) {
            $("#templates").append("<option value='" + result[i].id + "'>" + result[i].subject + "</option>");
        }
    },
    async: true
});

// #endregion

// #region onchange
$("#templates").change(function () {
    var id = $("#templates").val();

    for (var i = 0; i < template.length; i++) {
        if (template[i].id == id) {
            $("#text").val(template[i].body);
            break;
        }
    }
});
// #endregion 

// #region Send
$("#sent-btn").click(function () {
    var data = new FormData();

    var id = $("#id").val();
    var message = $("#text").val();
    var urgency = $("#urgency").val();
    var subject = $("#subject").val();

    data.append("Users", id);
    data.append("Text", message);
    data.append("Urgency", urgency);
    data.append("Subject", subject);

    $.ajax({
        type: 'Post',
        url: '/Api/Mail/SendTeacher',
        data: data,
        contentType: false,
        processData: false,
        success: function (res) {
        },
        async: false
    });

    window.location.replace("/messages");
});
// endregion