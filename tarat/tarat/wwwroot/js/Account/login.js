var loginForm = new Vue({
    el: "#LoginForm",
    data: {
        email: "",
        emailErr: "",

        password: "",
        passwordErr: "",

        error: ""
    },
    methods: {
        Login: function (e) {
            if (!valid() || !checkLogin()) {
                e.preventDefault();
                return;
            }

            return;
        }
    }
});

function valid() {
    var res = 1;

    if (!loginForm.email || !loginForm.email.includes('@'))
        loginForm.emailErr = "1", res = 0;
    else
        loginForm.emailErr = "";

    if (!loginForm.password)
        loginForm.passwordErr = "1", res = 0;
    else
        loginForm.passwordErr = "";

    return res;
}

function checkLogin() {
    var result = 0;
    var data = new FormData();

    data.append("Email", loginForm.email);
    data.append("Password", loginForm.password);

    $.ajax({
        type: 'Post',
        url: "/Api/Account/Login",
        data: data,
        contentType: false,
        processData: false,
        success: function (res) {
            if (!res) {
                $("#login-error").show();
                if (sessionStorage.getItem("lang") == 'kg') {
                    $("#login-error").html("<span class='lang-login-password-error'>Электрондук почта же купая сөз катта берилген.</span>");
                }
                else if (sessionStorage.getItem("lang") == 'en') {
                    $("#login-error").html("<span class='lang-login-password-error'>E-mail or password are a error.</span>");
                }
                else {
                    $("#login-error").html("<span class='lang-login-password-error'>Неправильная электронная почта или пароль.</span>");
                }
            }
            else {
                result = 1;
            }
        },
        async: false
    });

    return result;
}

$("#registry-btn").click(function () {
    location.replace("/registry");
});