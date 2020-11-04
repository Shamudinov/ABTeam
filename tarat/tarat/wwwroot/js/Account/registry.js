var form = new Vue({
    el: "#Form",
    data: {
        name: "",
        nameErr: "",

        surname: "",
        surnameErr: "",

        email: "",
        emailErr: "",

        password: "",
        passwordErr: "",

        ipp: "",
        ippErr: "",

        school: "",

        grade: "",

        error: ""
    },
    methods: {
        Registry: function (e) {
            if (!emailValid() || !nameValid() || !surnameValid() || !passwordValid()) {
                e.preventDefault();
                return;
            }
            save();
            return true;
        }
    }
});
var schools;

// #region Valid

function emailValid() {
    var email = form.email;
    if (email == "" || !email.includes('@')) {
        form.emailErr = "1";
        return 0;
    }

    var last = email.split("@").slice(-1)[0];
    if (last != 'gmail.com') {
        form.emailErr = "1";
        if (sessionStorage.getItem("lang") == 'kg') {
            $("#registry-error").html("<span class='lang-gmail-use'>Gmail почтасын киргизиңиз.</span>");
        }
        else if (sessionStorage.getItem("lang") == 'en') {
            $("#registry-error").html("<span class='lang-gmail-use'Enter Gmail account.</span>");
        }
        else {
            $("#registry-error").html("<span class='lang-gmail-use'>Введите Gmail почту.</span>");
        }
        return 0;
    }

    var res = 0;
   
    $.ajax({
        type: 'Get',
        url: "/Api/Account/CheckEmail",
        data: "email=" + email,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: function (result) {
            if (result) {
                form.emailErr = "1";
                if (sessionStorage.getItem("lang") == 'kg') {
                    $("#registry-error").html("<span class='lang-email-exist'>Берилген электрондук почта регистрациядан өткөн.</span>");
                }
                else if (sessionStorage.getItem("lang") == 'en') {
                    $("#registry-error").html("<span class='lang-email-exist'>E-mail already exists.</span>");
                }
                else {
                    $("#registry-error").html("<span class='lang-email-exist'>Заданная электронная почта уже прошла регистрацию.</span>");
                }

                return;
            }

            res = 1;
        },
        async: false
    });

    return res;
}

function nameValid() {
    value = form.name;
    if (value == "") {
        form.nameErr = "1";
        return 0;
    }
    return 1;
}

function surnameValid() {
    value = form.surname;
    if (value == "") {
        form.surnameErr = "1";
        return 0;
    }
    return 1;
}

function passwordValid() {
    value = form.password;
    if (value.length < 6) {
        form.passwordErr = "1";
        return 0;
    }

    return 1;
}

// #endregion

// #region Getting
$.ajax(/*Get school and grade*/{
    type: 'Get',
    url: "/Api/School/List",
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    success: function (result) {

        result.sort(function (a, b) {
            if (a.name < b.name)
                return -1;
            else if (a.name == b.name)
                return 0;
            return 1;
        });

        for (var i = 0; i < result.length; i++) {
            $("#school").append("<option value='" + i + "'>" + result[i].name + "</option>");

            result[i].grades.sort(function (a, b) {
                if (a.length < b.length)
                    return -1;
                if (a.length > b.length)
                    return 1;
                if (a < b)
                    return -1;
                if (a > b)
                    return 1;
                return 0;
            });
        }

        schools = result;
    },
    async: true
});

// #endregion

// #region Onchage

$("#school").change(function () {

    var id = $("#school").val();
    $("#grade").empty();
    for (var i = 0; i < schools[id].grades.length; i++) {
        $("#grade").append("<option>" + schools[id].grades[i] + "</option>")
    }
});

// #endregion

// #region Save
function save() {
    var data = new FormData();

    data.append("Name", form.name);
    data.append("Surname", form.surname);
    data.append("Email", form.email);
    data.append("Password", form.password);
    data.append("School", schools[form.school].name);
    data.append("IPP", form.ipp);
    data.append("Grades", form.grade);

    var result = 0;
    $.ajax(/*save*/{
        type: 'Post',
        url: "/Api/Account/Registry",
        data: data,
        contentType: false,
        processData: false,
        success: function (res) {
            result = res
        },
        async: false
    });

    return result;
}
// #endregion

$("#login-btn").click(function () {
    location.replace("/login");
});