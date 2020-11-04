$.ajax(/*Get school and grade*/{
    type: 'Get',
    url: "/Api/Account/GetTeachers",
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    success: function (result) {
        result.sort(function (a, b) {
            if (a.surname < b.surname)
                return -1;
            else if (a.surname == b.surname)
                return 0;
            return 1;
        });

        for (var i = 0; i < result.length; i++) {
            $("#table").append("<tr><td>" + result[i].surname + "</td><td>" + result[i].name + "</td><td><a href='/editGrade?id=" + result[i].id + "'><span class='lang-edit-class'></span></a></td></tr>")
        }
    },
    async: false
});