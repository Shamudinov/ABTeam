/* #region Getting*/
const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/message")
    .build();

hubConnection.on("Receive", function (result) {
    console.log(result);
        var color, background;

        if (result.urgency == 0)
            background = "white";
        else if (result.urgency == 1)
            background = "yellow";
        else
            background = "red";

        $("#mails").prepend(
            "<a href=/mail?id=" + result.id + ">"
            + "<div class='mail-block'>"
            + "<div class='mail-urgency' style=' background:" + background + ";'></div>"
            + "<p class='mail-title'>" + result.userFromName + "</p>"
            + "<p class='mail-message'><span class='mail-subject'>" + result.subject + "</span> - " + result.text.slice(0, 50) + "</p>"
            + "<p class='mail-time'>" + result.time.split("T")[0] + " " + result.time.split("T")[1].split(":")[0] + ":" + result.time.split("T")[1].split(":")[1] + "</p>"
            + "</div></a>"
        );
});

hubConnection.start();

$.ajax(/*Get  User + Message*/{
    type: 'Get',
    url: "/Api/Mail/GetMessages",
    data: "isFrom=false",
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    success: function (result) {
        console.log(result);

        for (var i = 0; i < result.length; i++) {

            var color, background;

            if (result[i].urgency == 0)
                background = "white";
            else if (result[i].urgency == 1)
                background = "yellow";
            else
                background = "red";

            $("#mails").append(
                "<a href=/mail?id=" + result[i].id + ">"
                + "<div class='mail-block'>"
                + "<div class='mail-urgency' style=' background:" + background + ";'></div>"
                + "<p class='mail-title'>" + result[i].userFromName + "</p>"
                + "<p class='mail-message'><span class='mail-subject'>" + result[i].subject + "</span> - " + result[i].text.slice(0, 50) + "</p>"
                + "<p class='mail-time'>" + result[i].time.split("T")[0] + " " + result[i].time.split("T")[1].split(":")[0] + ":" + result[i].time.split("T")[1].split(":")[1] + "</p>"
                + "</div></a>"
            );
        }
    },
    async: false
});
/* #endregion */

$("#outbox").click(function () {
    $("#outbox").removeClass("box-block");
    $("#inbox").removeClass("box-active-block");

    $("#outbox").addClass("box-active-block");
    $("#inbox").addClass("box-block");

    $("#mails").empty();

    $.ajax(/*Get  Message*/{
        type: 'Get',
        url: "/Api/Mail/GetMessages",
        data: "isFrom=true",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: function (result) {
            console.log(result);

            for (var i = 0; i < result.length; i++) {

                var color, background;

                if (result[i].urgency == 0)
                    background = "white";
                else if (result[i].urgency == 1)
                    background = "yellow";
                else
                    background = "red";

                $("#mails").append(
                    "<a href=/mail?id=" + result[i].id + ">"
                    + "<div class='mail-block'>"
                    + "<div class='mail-urgency' style=' background:" + background + ";'></div>"
                    + "<p class='mail-title'>" + result[i].userToName + "</p>"
                    + "<p class='mail-message'><span class='mail-subject'>" + result[i].subject + "</span> - " + result[i].text.slice(0, 50) + "</p>"
                    + "<p class='mail-time'>" + result[i].time.split("T")[0] + " " + result[i].time.split("T")[1].split(":")[0] + ":" + result[i].time.split("T")[1].split(":")[0] + "</p>"
                    + "</div></a>"
                );
            }
        },
        async: false
    });
});

$("#inbox").click(function () {
    $("#inbox").removeClass("box-block");
    $("#outbox").removeClass("box-active-block");

    $("#inbox").addClass("box-active-block");
    $("#outbox").addClass("box-block");

    $("#mails").empty();

    $.ajax(/*Get  User + Message*/{
        type: 'Get',
        url: "/Api/Mail/GetMessages",
        data: "isFrom=false",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: function (result) {
            console.log(result);

            for (var i = 0; i < result.length; i++) {

                var color, background;

                if (result[i].urgency == 0)
                    background = "white";
                else if (result[i].urgency == 1)
                    background = "yellow";
                else
                    background = "red";

                $("#mails").append(
                    "<a href=/mail?id=" + result[i].id + ">"
                    + "<div class='mail-block'>"
                    + "<div class='mail-urgency' style=' background:" + background + ";'></div>"
                    + "<p class='mail-title'>" + result[i].userFromName + "</p>"
                    + "<p class='mail-message' <span class='mail-subject'>>" + result[i].subject + "</span> - " + result[i].text.slice(0, 50) + "</p>"
                    + "<p class='mail-time'>" + result[i].time.split("T")[0] + " " + result[i].time.split("T")[1].split(":")[0] + ":" + result[i].time.split("T")[1].split(":")[0] + "</p>"
                    + "</div></a>"
                );
            }
        },
        async: false
    });
});