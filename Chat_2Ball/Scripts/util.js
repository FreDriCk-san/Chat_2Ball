$(function () {


    $('#chatBody').hide();
    $('#loginBlock').show();
    // Ссылка на автоматически-сгенерированный прокси хаба
    var chat = $.connection.chatHub;
    // Объявление функции, которая хаб вызывает при получении сообщений
    chat.client.addMessage = function (name, message) {
        // Добавление сообщений на веб-страницу 
        $('#chatroom').append('<p><b>' + htmlEncode(name)
            + '</b>: ' + htmlEncode(message) + '</p>' + '<p></p>');
    };

    // Функция, вызываемая при подключении нового пользователя
    chat.client.onConnected = function (id, userName, allUsers) {


        $('#loginBlock').hide();
        $('#chatBody').show();
        // установка в скрытых полях имени и id текущего пользователя
        $('#hdId').val(id);
        $('#username').val(userName);
        $('#hdId-1').val(id);
        $('#header').html('<h3>Добро пожаловать, ' + userName + '</h3>');
        $.post('http://localhost:62422/Users/Create', { ConnectionId: $('#hdId').val(), Name: $('#username').val() });

        // Добавление всех пользователей
        for (i = 0; i < allUsers.length; i++) {

            AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }
    }

    // Добавляем нового пользователя
    chat.client.onNewUserConnected = function (id, name) {

        AddUser(id, name);
    }

    // Удаляем пользователя
    chat.client.onUserDisconnected = function (id, userName) {

        $('#' + id).remove();
    }

    // Открываем соединение
    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
            // Вызываем у хаба метод Send
            chat.server.send($('#username').val(), $('#message').val());

            var image;
            var file = document.querySelector('#inputForm input[type="file"]').files[0];
            if (file != undefined) {
                readFile(file, function (e) {
                    image = e.target.result;
                });
            }
            

            $.post('http://localhost:62422/Messages/Create', { Text: $('#message').val(), Image: image, UserName: $('#username').val() });
            $('#message').val('');
            $('#image').val(undefined);
        });

        // обработка логина
        $("#btnLogin").click(function () {

            var name = $("#txtUserName").val();
            if (name.length > 0) {
                chat.server.connect(name);
            }
            else {
                alert("Введите имя");
            }
        });
    });

    $('#SendMessage').submit(function (e) {
        e.preventDefault();
    });

    //$('#SignIn').submit(function () {
    //    var User = {
    //        ConnectionId: $('#hdId').val(),
    //        Name: $('#username').val()
    //    }

    //    $.ajax({
    //        type: 'POST',
    //        url: 'http://localhost:62422/Users/Create',
    //        data: JSON.stringify(User),
    //        contentType: 'application/json; charset=utf-8',
    //        error: function () {
    //            alert('Something got wrong')
    //        },
    //        complete: function () {
    //            alert('All is good')
    //        }
    //    })
    //});
});


// Кодирование тегов
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}


//Добавление нового пользователя
function AddUser(id, name) {

    var userId = $('#hdId').val();

    if (userId != id) {

        $("#chatusers").append('<p id="' + id + '"><b>' + name + '</b></p>');
    }
}


function ChangeUrl(page, url) {
    if (typeof (history.pushState) != "undefined") {
        var obj = { Page: page, Url: url };
        history.pushState(obj, obj.Page, obj.Url);
    } else {
        alert("Browser does not support HTML5.");
    }
}


function readFile(file, callback) {
    var reader = new FileReader();
    reader.onload = callback;
    reader.readAsText(file);
}