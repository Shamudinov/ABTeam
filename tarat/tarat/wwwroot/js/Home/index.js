var grade;
var template;
const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/message")
    .build();
// #region Getting
$.ajax(/*Get grade*/{
    type: 'Get',
    url: "/Api/School/GetGrades",
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    success: function (result) {
        grade = result;
        for (var i = 0; i < result.length; i++) {
            $("#grades").append("<option value=" + result[i].id + ">" + result[i].name + "</option>")
        }
    },
    async: false
});
$.ajax(/*Get Template*/{
    type: 'Get',
    url: "/Api/Mail/Templates",
    data: "lang=" + sessionStorage.getItem("lang"),
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    success: function (result) {
        template = result;
        for (var i = 0; i < result.length; i++) {
            if (result[i].languageId == 1 && sessionStorage.getItem("lang") == 'kg'
                || result[i].languageId == 2 && sessionStorage.getItem("lang") == 'ru'
                || result[i].languageId == 3 && sessionStorage.getItem("lang") == 'en')
                $("#templates").append("<option value='" + result[i].id + "'>" + result[i].subject + "</option>");
        }
    },
    async: true
});

// #endregion

// #region select
function addGrade(id) {
    for (var i = 0; i < grade.length; i++) {
        if (grade[i].id == id) {
            console.log(grade[i].users);
            user = grade[i].users;
            for (var j = 0; j < user.length; j++) {
                $("#students").append("<option value='" + user[j].item1 + "'>" + user[j].item2 + "</option>")
                $('#students').multiselect('rebuild');
            }
            break;
        }
    }
}
function removeGrade(id) {
    for (var i = 0; i < grade.length; i++) {
        if (grade[i].id == id) {
            console.log(grade[i].users);
            user = grade[i].users;
            for (var j = 0; j < user.length; j++) {
                $("#students").find("[value='" + user[j].item1 + "']").remove();
                $('#students').multiselect('rebuild');
            }
            break;
        }
    }
}
// #endregion

// #region Multiselect
$(document).ready(function () {
    $("#grades").multiselect({
        onChange: function (element, checked) {
            if (checked) {
                addGrade(element.val())
            }
            else {
                console.log("remove");
                removeGrade(element.val());
            }
        }
    });
});
$(document).ready(function () {
    $("#students").multiselect({
        includeSelectAllOption: true,
        enableFiltering: true,
        numberDisplayed: 1,
    });
});
// #endregion

// #region onchange
$("#templates").change(function () {
    var id = $("#templates").val();
    $("#text").empty();

    for (var i = 0; i < template.length; i++) {

        if (template[i].id == id && (template[i].subject == 'Үй иши' || template[i].subject == 'Домашнее задание' || template[i].subject == 'Homework')) {
            $("#lesson").show();
            $("#homework").show();
            $("#homework-date").show();
            $("#text").val(template[i].body);
            break;
        }
        else if (template[i].id == id) {
            $("#lesson").hide();
            $("#homework").hide();
            $("#homework-date").hide();
            $("#text").val(template[i].body);
            break;
        }
    }
});

$("#header-language-kg").click(function () {
    $("#templates").empty();
    $("#text").val("");
    $("#templates").append('<option value="" disabled selected></option>');
    for (var i = 0; i < template.length; i++) {
        if (template[i].languageId == 1) {
            $("#templates").append("<option value='" + template[i].id + "'>" + template[i].subject + "</option>");
        }
    }
});
$("#header-language-en").click(function () {
    $("#templates").empty();
    $("#text").val("");
    $("#templates").append('<option value="" disabled selected></option>');
    for (var i = 0; i < template.length; i++) {
        if (template[i].languageId == 3) {
            $("#templates").append("<option value='" + template[i].id + "'>" + template[i].subject + "</option>");
        }
    }
});
$("#header-language-ru").click(function () {
    $("#templates").empty();
    $("#text").val("");
    $("#templates").append('<option value="" disabled selected></option>');
    for (var i = 0; i < template.length; i++) {
        if (template[i].languageId == 2) {
            $("#templates").append("<option value='" + template[i].id + "'>" + template[i].subject + "</option>");
        }
    }
});

function changeText() {
    if (sessionStorage.getItem("lang") == 'kg') {
        $("#text").val("Саламатсыңарбы, "
            + $("#homework-date-text").val()
            + " карата "
            + $("#lesson-text").val()
            + " сабагынан төмөнкү тапшырмалар: "
            + $("#homework-text").val());
    }
    else if (sessionStorage.getItem("lang") == 'ru') {
        $("#text").val("Здравствуйте, на "
            + $("#homework-date-text").val()
            + " задание по "
            + $("#lesson-text").val()
            + " следующее: "
            + $("#homework-text").val());
    }
    else if (sessionStorage.getItem("lang") == 'en') {
        $("#text").val("Hi, Here is the "
            + $("#lesson-text").val()
            + " home work for "
            + $("#homework-date-text").val()
            + ": "
            + $("#homework-text").val());
    }
}

$("#lesson-text").change(function () {
    changeText();
});
$("#homework-text").change(function () {
    changeText();
});
$("#homework-date-text").change(function () {
    changeText();
});
// #endregion

// #region Send
$("#sent-btn").click(function () {
    var data = new FormData();

    var grades = $("#grades").val();
    var students = $("#students").val();
    var urgency = $("#urgency").val();
    var subject = $("#subject").val();
    var message = $("#text").val();
    var students = $("#students").val();
    var currentdate = new Date();
    var time = currentdate.toJSON();
    console.log(time);

    data.append("Grades", grades);
    data.append("Users", students);
    data.append("Text", message);
    data.append("Urgency", urgency);
    data.append("Subject", subject);
    data.append("Time", time);


    $.ajax({
        type: 'Post',
        url: '/Api/Mail/SendTeacher',
        data: data,
        contentType: false,
        processData: false,
        success: function (res) {
            console.log(res);
        },
        async: false
    });

    hubConnection.invoke("SendGroups", students, time);
});
hubConnection.start();
// #endregion
