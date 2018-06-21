<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat2_Ball.aspx.cs" Inherits="Chat_2Ball.Chat2_Ball" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Chat_2Ball</title>
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <!--Ссылка на библиотеку SignalR -->
    <script src="~/Scripts/jquery.signalR-2.2.3.min.js"></script>
    <script src="~/Scripts/jquery.unobtrusive-ajax.js"></script>
    <!--Ссылка на автоматически сгенерированный скрипт хаба SignalR -->
    <script src="~/signalr/hubs"></script>
    <script src="~/Scripts/util.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Chat_2Ball</h2>

        <asp:ScriptManager EnablePageMethods="true" ID="scpt" runat="server"></asp:ScriptManager>
        <div class="main">
            <div id="loginBlock">
                Введите логин:<br />
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Войти" />
                <asp:Button ID="btn" OnClientClick="RegisterUser();return false;" runat="server" Text="Регистрация"></asp:Button>
            </div>
            <div id="chatBody">
                <div id="header"></div>
                <div id="inputForm">
                    <input type="text" id="message" />
                    <input type="button" id="sendmessage" value="Отправить" />
                </div>
                <div id="chatroom"></div>

                <div id="chatusers">
                    <p><b>Все пользователи</b></p>
                </div>
            </div>
            <input id="hdId" type="hidden" />
            <input id="username" type="hidden" />
        </div>

        
    </form>
</body>
</html>
