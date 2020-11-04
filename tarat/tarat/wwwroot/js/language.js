function getResources() {
    var kg = new Array();
    var ru = new Array();
    var en = new Array();

    /// #region Words
        kg['sent-messages'] = 'Жиберилген каттар';
        en['sent-messages'] = 'Sent messages';
        ru['sent-messages'] = 'Отправленные сообщении';

        kg['list-user'] = 'Колдонуучулардын тизмеси';
        en['list-user'] = 'List of users';
        ru['list-user'] = 'Список пользователей';
        
        kg['received-messages'] = 'Кабыл алынган каттар';
        en['received-messages'] = 'Received messages';
        ru['received-messages'] = 'Полученные сообщении';

        kg['login'] = 'Кирүү';
        en['login'] = 'Login';
        ru['login'] = 'Вход';    

        kg['email'] = 'Gmail почта';
        ru['email'] = 'Gmail почта';
        en['email'] = 'Gmail';

        kg['password'] = 'Купая сөз';
        ru['password'] = 'Пароль';    
        en['password'] = 'Password';

        kg['registry'] = 'Регистрация';
        ru['registry'] = 'Регистрация';    
        en['registry'] = 'Registration';

        kg['login-password-error'] = 'Электрондук почта же купая сөз катта берилген.';
        ru['login-password-error'] = 'Неправильная электронная почта или пароль.';    
        en['login-password-error'] = 'E-mail or password are a error.';

        kg['email-exist'] = 'Берилген электрондук почта регистрациядан өткөн.';
        ru['email-exist'] = 'Заданная электронная почта уже прошла регистрацию.';    
        en['email-exist'] = 'E-mail already exists.';

        kg['gmail-advise'] = 'Система үчүн жаңы <a target="_blank" href="https://accounts.google.com/signup">gmail</a> аккаунт колдонуңуз.';
        ru['gmail-advise'] = 'Для системы используйте новый <a target="_blank" href="https://accounts.google.com/signup">gmail</a> аккаунт.';    
        en['gmail-advise'] = 'Create new <a target="_blank" href="https://accounts.google.com/signup">gmail</a account to use the system.';

        kg['gmail-use'] = 'Gmail почтасын киргизиңиз.';
        ru['gmail-use'] = 'Введите Gmail почту.';    
        en['gmail-use'] = 'Enter Gmail account.';

        kg['name'] = 'Ат';
        ru['name'] = 'Имя';    
        en['name'] = 'Name';

        kg['surname'] = 'Фамилия';
        ru['surname'] = 'Фамилия';    
        en['surname'] = 'Surname';

        kg['school'] = 'Мектеп';
        ru['school'] = 'Школа';    
        en['school'] = 'School';

        kg['grade'] = 'Класс';
        ru['grade'] = 'Класс';    
        en['grade'] = 'Grade';

        kg['select-school'] = 'Мектебиңизди тандаңыз';
        ru['select-school'] = 'Выберите школу';    
        en['select-school'] = 'Choose school';

        kg['class-distribution'] = 'Мугалимдердин арасындагы класстарды бөлүштүрүү';
        ru['class-distribution'] = 'Распределение классов среди учителей';    
        en['class-distribution'] = 'Сlass distribution among teacher';

        kg['edit-class'] = 'Класстарды өзгөртүү';
        ru['edit-class'] = 'Редактирование классов';    
        en['edit-class'] = 'Editing of class';
    
        kg['save'] = 'Сактоо';
        ru['save'] = 'Сохранить';    
        en['save'] = 'Save';

        kg['write'] = 'Кат жазуу';
        ru['write'] = 'Написать письмо';    
        en['write'] = 'Write message';

        kg['teachers'] = 'Мугалимдер';
        ru['teachers'] = 'Учителя';    
        en['teachers'] = 'Teachers';

        kg['students'] = 'Окуучулар';
        ru['students'] = 'Ученики';    
        en['students'] = 'Students';

        kg['messages'] = 'Каттар';
        ru['messages'] = 'Письма';    
        en['messages'] = 'Letters';

        kg['grades'] = 'Классты тандаңыз';
        ru['grades'] = 'Выберите класс';    
        en['grades'] = 'Choose grade';

        kg['students'] = 'Окуучуларды тандаңыз';
        ru['students'] = 'Выберите учеников';    
        en['students'] = 'Choose students';

        kg['recipient'] = 'Кат алуучулар';
        ru['recipient'] = 'Получатели';
        en['recipient'] = 'Recipients';    

        kg['send-message'] = 'Кат жөнөтүү';
        ru['send-message'] = 'Отправка письма';
        en['send-message'] = 'Send letter';

        kg['select-all'] = 'Бардыгын тандоо';
        ru['select-all'] = 'Выбрать все';
        en['select-all'] = 'Select all';

        kg['templates'] = 'Шаблондор';
        ru['templates'] = 'Шаблоны';
        en['templates'] = 'Templates';

        kg['send'] = 'Жөнөтүү';
        ru['send'] = 'Отправить';
        en['send'] = 'Send';

        kg['ipp'] = 'ИПП';
        ru['ipp'] = 'ИПП';
        en['ipp'] = 'IPP';

        kg['urgency'] = 'Шашылыштылуугу';
        ru['urgency'] = 'Экстренность';
        en['urgency'] = 'Urgency';

        kg['urgent'] = 'Өтө шашылыш';
        ru['urgent'] = 'Очень срочное';
        en['urgent'] = 'Urgent';

        kg['important'] = 'Маанилүү';
        ru['important'] = 'Важное';
        en['important'] = 'Important';    

        kg['daily'] = 'Күнүмдүк';
        ru['daily'] = 'Обычное';
        en['daily'] = 'Daily';

        kg['inbox'] = 'Келгендер';
        ru['inbox'] = 'Входящие';
        en['inbox'] = 'Inbox';

        kg['outbox'] = 'Жиберилгендер';
        ru['outbox'] = 'Посланные';
        en['outbox'] = 'Sent';

        kg['back'] = 'Артка';
        ru['back'] = 'Назад';
        en['back'] = 'Back';

        kg['to'] = '';
        ru['to'] = 'Кому';
        en['to'] = 'To';

        kg['from'] = '';
        ru['from'] = 'От';
        en['from'] = 'From';

        kg['reply'] = 'Жооп берүү';
        ru['reply'] = 'Ответить';
        en['reply'] = 'Reply';

        kg['subject'] = 'Темасы';
        ru['subject'] = 'Тема';
        en['subject'] = 'Subject';

        kg['lesson'] = 'Сабак';
        ru['lesson'] = 'Урок';
        en['lesson'] = 'Lesson';

        kg['homework'] = 'Үй тапшырма';
        ru['homework'] = 'Домашное задание';
        en['homework'] = 'Homework';

        kg['homework-date'] = 'Үй тапшырма убактысы';
        ru['homework-date'] = 'Время домашнего задание';
        en['homework-date'] = 'Date of homework';
    /// #endregion

    var resources = new Array();

    resources['kg'] = kg;
    resources['ru'] = ru;
    resources['en'] = en;

    return resources;
}
var resources = new Array();
var showKg = 0;
var showRu = 0;
var showEn = 0;

function language_init(lang) {

    changeLanguage(lang);
    sessionStorage.setItem('lang', lang);

    showEn = (!(lang == 'en'));
    showRu = (!(lang == 'ru'));
    showKg = (!(lang == 'kg'));

    if (showKg)
        $("#header-language-kg").show();
    else
        $("#header-language-kg").hide();

    if (showRu)
        $("#header-language-ru").show();
    else
        $("#header-language-ru").hide();

    if (showEn)
        $("#header-language-en").show();
    else
        $("#header-language-en").hide();

    loadsLanguage();
}

function changeLanguage(lang) {
    resources = getResources()[lang];
}

function loadsLanguage() {
    $('span[class^="lang"]').each(function () {

        var LangVar = (this.className).replace('lang-', '');
        var Text = resources[LangVar];
        $(this).html(Text);
    });

    $('option[class^="lang"]').each(function () {

        var LangVar = (this.className).replace('lang-', '');
        var Text = resources[LangVar];
        $(this).html(Text);
    });
}

if (sessionStorage.getItem("lang") != null)
    language_init(sessionStorage.getItem("lang"));
else
    language_init("ru");

$("#header-language-kg").click(function () {
    language_init('kg');
});
$("#header-language-ru").click(function () {
    language_init('ru');
});
$("#header-language-en").click(function () {
    language_init('en');
});
