<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authorization.aspx.cs" Inherits="Duty_Bot2.Authorization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Авторизация</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">

     

        body {
            background: #000 url(phonk.jpg); /* Фоновый цвет и фоновый рисунок*/
            color: #fff; /*Цвет текста на странице*/
            background-attachment: fixed; /* Фон страницы фиксируется */
            background-repeat: repeat-x; /* Изображение повторяется по горизонтали */
            background-size: 100%;
        }

        .Button {
            border-radius: 5px;
        }


        .div {
            background: #fff; /* Цвет фона */
            color: #000000; /* Цвет текста */
            /* Чёрная рамка */
            padding: 10px; /* Поля вокруг текста */
            border-radius: 5px;
            height: 308px;
            width: 486px;
        }


        sizeChanged {
            display: grid;
            grid-gap: 200px;
            grid-template-columns: repeat(auto-fit, minmax(750px,1fr));
            grid-template-rows: repeat(2,100px);
            margin-left: 10px;
        }

        min-width: 1000px {
            div .sizeChanged

        {
            font-size: 20px;
        }

        }

        min-width: 1500px {
            div .sizeChanged

        {
            font-size: 30px;
        }

        .bt_Style {
  
        }

        .tb_Style {
        }

  
    </style>
</head>
<body>
    
    <form id="form1" runat="server" style="">
       
        <br>
         <br>
        <br>
         <center>
        <div class="container" runat="server" id="THEDIV1">
            <div id="TheDiv" class ="div" runat="server">
                <h2> Авторизация </h2>
            <asp:Label ID ="lblTitle" runat ="server" CssClass ="font_style"
                Text ="" Font-Size="X-Large">Логин</asp:Label> 
            <br>
            
            <asp:TextBox id="tbLogin" runat ="server"
                CssClass ="tb_Style" Width="405px" Height="40px" Font-Size="Medium" ForeColor="#999999"></asp:TextBox>
            
            <br>
               
      
       
            <br>
                       <asp:Label ID ="Label1" runat ="server" CssClass ="font_style"
                Text ="" Font-Size="X-Large">Пароль</asp:Label> 
            <br>
      
           <asp:TextBox id="tbPassword" runat ="server"
                CssClass ="tb_Style" Width="405px" Height="40px" Font-Size="Medium" ForeColor="#999999" TextMode="Password"></asp:TextBox>
            <br>
            <br>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
            <asp:Button ID ="btEnter" runat ="server" Text ="Войти" 
                CssClass ="btn btn-danger btn- Button"  Width="203px" Height="45px" ToolTip="Авторизоваться" Font-Size="Medium" OnClick="btEnter_Click" />
    </ContentTemplate>
</asp:UpdatePanel>
                </br>
        <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
    <ProgressTemplate>
        <div id="overlay ">
            <div id="modalprogress" class="#modalprogress">
                <div id="theprogres" class="#theprogress">
<img src="wait.gif" />
                    Please wait...
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
            <br>
            <br>
            
            <br>
            <br>
        </div>
        </div>
        </center>
    </form>
</body>
</html>
